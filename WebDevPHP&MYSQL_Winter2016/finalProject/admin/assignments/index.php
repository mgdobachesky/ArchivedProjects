<?php
include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/magicquotes.inc.php';

require_once $_SERVER['DOCUMENT_ROOT'] . '/includes/access.inc.php';

if(!userIsLoggedIn())
{
 include '../login.html.php';
 exit();
}

if (!userHasRole('Content Editor'))
{
 $error = 'Only Content Editors may access this page.';
 include '../accessdenied.html.php';
 exit();
}

if (isset($_GET['add']))
{
    $pageTitle = 'New Assignment';
    $action = 'addform';
    $text = '';
    $authorid = '';
    $id = '';
    $button = 'Add assignment';
    
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    
    try
    {
        $result = $pdo->query('SELECT id, name FROM student');
    }
    catch (PDOException $e)
    {
        $error = 'Error fetching list of students.';
        include 'error.html.php';
        exit();
    }
    
    foreach($result as $row)
    {
        $students[] = array('id' => $row['id'], 'name' => $row['name']);
    }
    
    try
    {
        $result = $pdo->query('SELECT id, name FROM course');
    }
    catch (PDOException $e)
    {
        $error = 'Error fetching list of courses.';
        include 'error.html.php';
        exit();
    }
    
    foreach ($result as $row)
    {
        $courses[] = array (
            'id' => $row['id'],
            'name' => $row['name'],
            'selected' => FALSE);
    }
    
    include 'form.html.php';
    exit();
}

if (isset($_POST['action']) and $_POST['action'] == 'Edit')
{   
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    
    try
    {
        $sql = 'SELECT id, assignmentname, studentid FROM assignment WHERE id = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error fetching assignments.';
        include 'error.html.php';
        exit();
    }
    
    $row = $s->fetch();
    
    $pageTitle = 'Edit Assignment';
    $action = 'editform';
    $text = $row['assignmentname'];
    $studentid = $row['studentid'];
    $id = $row['id'];
    $button = 'Update assignment';
    
    try
    {
        $result = $pdo->query('SELECT id, name FROM student');
    }
    catch (PDOException $e)
    {
        $error = 'Error fetching list of students.';
        include 'error.html.php';
        exit();
    }
    
    foreach($result as $row)
    {
        $students[] = array('id' => $row['id'], 'name' => $row['name']);
    }
    
    try
    {
        $sql = 'SELECT courseid FROM assignmentcourse
        WHERE assignmentid = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $id);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error fetching list of selected courses.';
        include 'error.html.php';
        exit();
    }
    
    foreach ($s as $row)
    {
        $selectedCourses[] = $row['courseid'];
    }
    
    try
    {
        $result = $pdo->query('SELECT id, name FROM course');
    }
    catch (PDOException $e)
    {
        $error = 'Error fetching list of courses.';
        include 'error.html.php';
        exit();
    }
    
    foreach ($result as $row)
    {
        $courses[] = array (
            'id' => $row['id'],
            'name' => $row['name'],
            'selected' => in_array($row['id'], $selectedCourses));
    }
    
    include 'form.html.php';
    exit();
}

if (isset($_GET['addform']))
{
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    
    if ($_POST['student'] == '')
    {
        $error = 'You must choose a student for this assignment. Click &lsquo;back&rsquo; and try again.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'INSERT INTO assignment SET
        assignmentname = :assignmentname,
        assignmentdate = CURDATE(),
        studentid = :studentid';
        $s = $pdo->prepare($sql);
        $s->bindValue(':assignmentname', $_POST['text']);
        $s->bindValue(':studentid', $_POST['student']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error adding submitted assignment.';
        include 'error.html.php';
        exit();
    }
    
    $assignmentid = $pdo->lastInsertId();
    
    if (isset($_POST['courses']))
    {
        try
        {
            $sql = 'INSERT INTO assignmentcourse SET
            assignmentid = :assignmentid,
            courseid = :courseid';
            $s = $pdo->prepare($sql);
            
            foreach($_POST['courses'] as $courseid)
            {
                $s->bindValue(':assignmentid', $assignmentid);
                $s->bindValue(':courseid', $courseid);
                $s->execute();
            }
        }
        catch (PDOException $e)
        {
            $error = 'Error inserting assignment into selected courses.';
            include 'error.html.php';
            exit();
        }
    }
    
    header('Location: .');
    exit();
}

if (isset($_GET['editform']))
{
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    
    if ($_POST['student'] == '')
    {
        $error = 'You must choose a student for this assignment. Click &lsquo;back&rsquo; and try again.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'UPDATE assignment SET
        assignmentname = :assignmentname,
        studentid = :studentid
        WHERE id = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->bindValue(':assignmentname', $_POST['text']);
        $s->bindValue(':studentid', $_POST['studentid']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error updating submitted assignment.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'DELETE FROM assignmentcourse WHERE assignmentid = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error removing obsolete assignment course entries.';
        include 'error.html.php';
        exit();
    }
    
    if (isset($_POST['courses']))
    {
        try
        {
            $sql = 'INSERT INTO assignmentcourse SET
            assignmentid = :assignmentid,
            courseid = :courseid';
            $s = $pdo->prepare($sql);
            
            foreach($_POST['courses'] as $courseid)
            {
                $s->bindValue(':assignmentid', $_POST['id']);
                $s->bindValue(':courseid', $courseid);
                $s->execute();
            }
        }
        catch (PDOException $e)
        {
            $error = 'Error inserting assignment into selected courses.';
            include 'error.html.php';
            exit();
        }
    }
    
    header('Location: .');
    exit();
}

if (isset($_POST['action']) and $_POST['action'] == 'Delete')
{
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    
    try
    {
        $sql = 'DELETE FROM assignmentcourse WHERE assignmentid = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch(PDOException $e)
    {
        $error = 'Error removing assignment from courses.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'DELETE FROM assignment WHERE id = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch (PDOException $e)
    {
     $error = 'Error deleting assignment.';
     include 'error.html.php';
     exit();
    }
    
    header('Location: .');
    exit();
}

include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';

if (isset($_GET['action']) and $_GET['action'] == 'search')
{
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    $select = 'SELECT id, assignmentname';
    $from = ' FROM assignment';
    $where = ' WHERE TRUE';

    $placeholders = array();
    
    if ($_GET['student'] != '')
    {
     $where .= " AND studentid = :studentid";
     $placeholders[':studentid'] = $_GET['student'];
    }
    
    if ($_GET['course'] != '')
    {
        $from .= ' INNER JOIN assignmentcourse ON id = assignmentid';
        $where .= " AND courseid = :courseid";
        $placeholders[':courseid'] = $_GET['course'];
    }
    
    if ($_GET['text'] != '')
    {
        $where .= " AND assignmentname LIKE :assignmentname";
        $placeholders[':assignmentname'] = '%' . $_GET['text'] . '%';
    }
    
    try
    {
        $sql = $select . $from . $where;
        $s = $pdo->prepare($sql);
        $s->execute($placeholders);
    }
    catch (PDOException $e)
    {
        if (!empty($sql))
        {
            $error = 'Error fetching assignments.';
            include 'error.html.php';
            exit();
        }
    }
    
    foreach($s as $row)
    {
        $assignments[] = array('id' => $row['id'], 'text' => $row['assignmentname']);
    }
    
    include 'assignments.html.php';
    exit();
}

try
{
    $result = $pdo->query('SELECT id, name FROM student');
}
catch (PDOException $e)
{
    $error = 'Error fetching students from database!';
    include 'error.html.php';
    exit();
}

foreach ($result as $row)
{
    $students[] = array('id' => $row['id'], 'name' => $row['name']);
}

try
{
    $result = $pdo->query('SELECT id, name FROM course');
}
catch (PDOException $e)
{
    $error = 'Error fetching courses from database!';
    include 'error.html.php';
    exit();
}

foreach ($result as $row)
{
    $courses[] = array('id' => $row['id'], 'name' => $row['name']);
}

include 'searchform.html.php';
?>