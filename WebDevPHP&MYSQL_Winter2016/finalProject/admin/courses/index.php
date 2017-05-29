<?php
include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/magicquotes.inc.php';

require_once $_SERVER['DOCUMENT_ROOT'] . '/includes/access.inc.php';

if(!userIsLoggedIn())
{
 include '../login.html.php';
 exit();
}

if (!userHasRole('Site Administrator'))
{
 $error = 'Only Site Administrators may access this page.';
 include '../accessdenied.html.php';
 exit();
}

//Add
if (isset($_GET['add']))
{
 $pageTitle = 'New Course';
 $action = 'addform';
 $name = '';
 $email = '';
 $id = '';
 $button = 'Add course';
 
 include 'form.html.php';
 exit();
}

if (isset($_GET['addform']))
{
 include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
 
 try
 {
  $sql = 'INSERT INTO course SET
  name = :name';
  $s = $pdo->prepare($sql);
  $s->bindValue(':name', $_POST['name']);
  $s->execute();
 }
 catch (PDOException $e)
 {
  $error = 'Error adding submitted course.';
  include 'error.html.php';
  exit();
 }
 
 header('Location: .');
 exit();
}

//Edit
if (isset($_POST['action']) and $_POST['action'] == 'Edit')
{
 include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
 
 try
 {
  $sql = 'SELECT id, name FROM course WHERE id = :id';
  $s = $pdo->prepare($sql);
  $s->bindValue(':id', $_POST['id']);
  $s->execute();
 }
 catch(PDOException $e)
 {
  $error = 'Error fetching course details.';
  include 'error.html.php';
  exit();
 }
 
 $row = $s->fetch();
 
 $pageTitle = 'Edit Course';
 $action = 'editform';
 $name = $row['name'];
 $id = $row['id'];
 $button = 'Update course';
 
 include 'form.html.php';
 exit();
}

if (isset($_GET['editform']))
{
 include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
 
 try
 {
  $sql = 'UPDATE course SET
  name = :name
  WHERE id = :id';
  
  $s = $pdo->prepare($sql);
  $s->bindValue(':id', $_POST['id']);
  $s->bindValue(':name', $_POST['name']);
  $s->execute();
 }
 catch (PDOException $e)
 {
  $error = 'Error updating submitted course.';
  include 'error.html.php';
  exit();
 }
 
 header('Location: .');
 exit();
}

//Delete
if (isset($_POST['action']) and $_POST['action'] == 'Delete')
{
    include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
    
    try
    {
        $sql = 'DELETE FROM assignmentcourse WHERE courseid = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error removing assignments from course.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'DELETE FROM course WHERE id = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
     catch (PDOException $e)
    {
        $error = 'Error deleting course.';
        include 'error.html.php';
        exit();
    }
    
    header('Location: .');
    exit();
}


//Display list
include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';

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

include 'courses.html.php';
?>