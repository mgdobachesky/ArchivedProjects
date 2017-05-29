<?php include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/helpers.inc.php'; ?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>List of Assignments</title>
    </head>
    <body>
        <h1>Assignments Due</h1>
        <?php foreach ($assignments as $assignment): ?>
        <form action="" method="post">
            <p>
            <input type="hidden" name="id" value="<?php echo $assignment['id']; ?>">
            
			<strong>Student: </strong><?php htmlout($assignment['name']); ?><br />
            <strong>Assignment: </strong><?php htmlout($assignment['assignmentname']); ?> <br />
			<strong>Class: </strong><?php htmlout($assignment['coursename']) ?> <br />
			<strong>Date Added: </strong><?php htmlout($assignment['assignmentdate']); ?><br />
			</p>
        </form>
        <?php endforeach; ?>
    </body>
</html>