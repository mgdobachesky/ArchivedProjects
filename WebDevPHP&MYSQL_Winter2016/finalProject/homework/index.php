<?php
include $_SERVER['DOCUMENT_ROOT'] . '/includes/db.inc.php';

try
{
    $sql = 'SELECT assignment.id, assignment.assignmentname, assignment.assignmentdate, student.name, student.email, course.name AS coursename
      FROM assignment INNER JOIN student
      ON studentid = student.id INNER JOIN assignmentcourse
	  ON assignment.id = assignmentcourse.assignmentid INNER JOIN course
	  ON assignmentcourse.courseid = course.id';
    $result = $pdo->query($sql);
}
catch (PDOException $e)
{
     $output = 'Error fetching assignments: ' . $e->getMessage();
    include 'output.html.php';
    exit();
}

foreach ($result as $row)
{
  $assignments[] = array(
    'id' => $row['id'],
    'assignmentname' => $row['assignmentname'],
	'assignmentdate' => $row['assignmentdate'],
    'name' => $row['name'],
    'email' => $row['email'],
	'coursename' => $row['coursename']
  );
}

include 'homework.html.php';

?>