<?php include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/helpers.inc.php'; ?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>Manage Students</title>
    </head>
    <body>
        <h1>Manage Students</h1>
        <p><a href="?add">Add new student</a></p>
        <ul>
            <?php foreach ($students as $student): ?>
            <li>
                <form action="" method="post">
                    <div>
                        <?php htmlout($student['name']); ?>
                        <input type="hidden" name="id" value="<?php echo $student['id']; ?>">
                        <input type="submit" name="action" value="Edit">
                        <input type="submit" name="action" value="Delete">
                    </div>
                </form>
            </li>
            <?php endforeach; ?>
        </ul>
        <p><a href="..">Return to home</a></p>
        <?php include '../logout.inc.html.php'; ?>
    </body>
</html>