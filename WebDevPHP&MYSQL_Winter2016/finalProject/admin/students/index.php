<?php
include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/magicquotes.inc.php';

require_once $_SERVER['DOCUMENT_ROOT'] . '/includes/access.inc.php';

if(!userIsLoggedIn())
{
 include '../login.html.php';
 exit();
}

if (!userHasRole('Account Administrator'))
{
 $error = 'Only Account Administrators may access this page.';
 include '../accessdenied.html.php';
 exit();
}

//Add
if (isset($_GET['add']))
{
  include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
  
 $pageTitle = 'New Student';
 $action = 'addform';
 $name = '';
 $email = '';
 $id = '';
 $button = 'Add student';
 
 try
 {
  $result = $pdo->query('SELECT id, description FROM privilegedetails');
 }
 catch (PDOException $e)
 {
  $error = 'Error fetching list of privileges.';
  include 'error.html.php';
  exit();
 }
 
 foreach ($result as $row)
 {
  $roles[] = array(
     'id' => $row['id'],
     'description' => $row['description'],
     'selected' => FALSE);
 }
 
 include 'form.html.php';
 exit();
}

if (isset($_GET['addform']))
{
 include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
 
 try
 {
  $sql = 'INSERT INTO student SET
  name = :name,
  email = :email';
  $s = $pdo->prepare($sql);
  $s->bindValue(':name', $_POST['name']);
  $s->bindValue(':email', $_POST['email']);
  $s->execute();
 }
 catch (PDOException $e)
 {
  $error = 'Error adding submitted student.';
  include 'error.html.php';
  exit();
 }
 
 $studentid = $pdo->lastInsertId();
 
 if ($_POST['password'] != '')
 {
  $password = md5($_POST['password'] . 'homework');
  
  try
  {
   $sql = 'UPDATE student SET
    password = :password
    WHERE id = :id';
   $s = $pdo->prepare($sql);
   $s->bindValue(':password', $password);
   $s->bindValue(':id', $studentid);
   $s->execute();
  }
  catch (PDOException $e)
  {
   $error = 'Error setting student password.';
   include 'error.html.php';
   exit();
  }
 }
 
 if (isset($_POST['roles']))
 {
  foreach ($_POST['roles'] as $privilegedetails)
  {
   try
   {
    $sql = 'INSERT INTO privilege SET
     studentid = :studentid,
     privilegeid = :privilegeid';
     $s = $pdo->prepare($sql);
     $s->bindValue(':studentid', $studentid);
     $s->bindValue(':privilegeid', $privilegedetails);
     $s->execute();
   }
   catch (PDOException $e)
   {
    $error = 'Error assigning selected privilege to student.';
    include 'error.html.php';
    exit();
   }
  }
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
  $sql = 'SELECT id, name, email FROM student WHERE id = :id';
  $s = $pdo->prepare($sql);
  $s->bindValue(':id', $_POST['id']);
  $s->execute();
 }
 catch(PDOException $e)
 {
  $error = 'Error fetching student details.';
  include 'error.html.php';
  exit();
 }
 $row = $s->fetch();
 
 $pageTitle = 'Edit Student';
 $action = 'editform';
 $name = $row['name'];
 $email = $row['email'];
 $id = $row['id'];
 $button = 'Update student';
 
 try
 {
  $sql = 'SELECT privilegeid FROM privilege WHERE studentid = :id';
  $s = $pdo->prepare($sql);
  $s->bindValue(':id', $id);
  $s->execute();
 }
 catch (PDOException $e)
 {
  $error = 'Error fetching list of assigned privileges.';
  include 'error.html.php';
  exit();
 }
 
 $selectedRoles = array();
 foreach($s as $row)
 {
  $selectedRoles[] = $row['privilegeid'];
 }
 
 try
 {
  $result = $pdo->query('SELECT id, description FROM privilegedetails');
 }
 catch (PDOException $e)
 {
  $error = 'Error fetching list of privileges.';
  include 'error.html.php';
  exit();
 }
 
 foreach ($result as $row)
 {
  $roles[] = array(
   'id' => $row['id'],
   'description' => $row['description'],
   'selected' => in_array($row['id'], $selectedRoles));
 }
 
 include 'form.html.php';
 exit();
}

if (isset($_GET['editform']))
{
 include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';
 
 try
 {
  $sql = 'UPDATE student SET
  name = :name,
  email = :email
  WHERE id = :id';
  
  $s = $pdo->prepare($sql);
  $s->bindValue(':id', $_POST['id']);
  $s->bindValue(':name', $_POST['name']);
  $s->bindValue(':email', $_POST['email']);
  $s->execute();
 }
 catch (PDOException $e)
 {
  $error = 'Error updating submitted student.';
  include 'error.html.php';
  exit();
 }
 
 if ($_POST['password'] != '')
 {
  $password = md5($_POST['password'] . 'homework');
  
  try
  {
   $sql = 'UPDATE student SET
   password = :password
   WHERE id = :id';
   $s = $pdo->prepare($sql);
   $s->bindValue(':password', $password);
   $s->bindValue(':id', $_POST['id']);
   $s->execute();
  }
  catch (PDOException $e)
  {
   $error = 'Error setting student password.';
   include 'error.html.php';
   exit();
  } 
 }
 
 try
 {
  $sql = 'DELETE FROM privilege WHERE studentid = :id';
  $s = $pdo->prepare($sql);
  $s->bindValue(':id', $_POST['id']);
  $s->execute();
 }
 catch (PDOException $e)
 {
  $error = 'Error removing obsolete student privilege entries.';
  include 'error.html.php';
  exit();
 }
 
 if (isset($_POST['roles']))
 {
  foreach($_POST['roles'] as $privilegedetails)
  {
   try
   {
    $sql = 'INSERT INTO privilege SET
    studentid = :studentid,
    privilegeid = :privilegeid';
    $s = $pdo->prepare($sql);
    $s->bindValue(':studentid', $_POST['id']);
    $s->bindValue(':privilegeid', $privilegedetails);
    $s->execute();
   }
   catch (PDOException $e)
   {
    $error = 'Error assigning selected privilege to student.';
    include 'error.html.php';
    exit();
   }
  }
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
     $sql = 'DELETE FROM privilege WHERE studentid = :id';
     $s = $pdo->prepare($sql);
     $s->bindValue(':id', $_POST['id']);
     $s->execute();
    }
    catch (PDOException $e)
    {
     $error = 'Error removing student from privileges.';
     include 'error.html.php';
     exit();
    }
    
    try
    {
       $sql = 'SELECT id FROM assignment WHERE studentid = :id';
       $s = $pdo->prepare($sql);
       $s->bindValue(':id', $_POST['id']);
       $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error getting list of assignments to delete.';
        include 'error.html.php';
        exit();
    }
    
    $result = $s->fetchAll();
    
    try
    {
        $sql = 'DELETE FROM assignmentcourse WHERE assignmentid = :id';
        $s = $pdo->prepare($sql);
        
        foreach ($result as $row)
        {
           $jokeId = $row['id'];
           $s->bindValue(':id', $assignmentId);
           $s->execute();
        }
    }
    catch (PDOException $e)
    {
        $error - 'Error deleting course entries for assignment.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'DELETE FROM assignment WHERE studentid = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error deleting assignments for student.';
        include 'error.html.php';
        exit();
    }
    
    try
    {
        $sql = 'DELETE FROM student WHERE id = :id';
        $s = $pdo->prepare($sql);
        $s->bindValue(':id', $_POST['id']);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error deleting student.';
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

include 'students.html.php';
?>