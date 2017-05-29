<?php include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/helpers.inc.php'; ?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>Manage Assignments</title>
    </head>
    <body>
        <h1>Manage Assignments</h1>
        <p><a href="?add">Add new assignment</a></p>
        <form action="" method="get">
            <p>View assignments satisfying the following criteria:</p>
            <div>
                <label for="student">By student:</label>
                <select name="student" id="student">
                    <option value="">Any student</option>
                    <?php foreach ($students as $student): ?>
                    <option value="<?php htmlout($student['id']); ?>"><?php htmlout($student['name']); ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
             <div>
                <label for="course">By course:</label>
                <select name="course" id="course">
                    <option value="">Any course</option>
                    <?php foreach ($courses as $course): ?>
                    <option value="<?php htmlout($course['id']); ?>"><?php htmlout($course['name']); ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
             <div>
                <label for="text">Containing text:</label>
                <input type="text" name="text" id="text">
             </div>
             <div>
                <input type="hidden" name="action" value="search">
                <input type="submit" value="Search">
             </div>
        </form>
        <p><a href="..">Return to home</a></p>
        <?php include '../logout.inc.html.php'; ?>
    </body>
</html>