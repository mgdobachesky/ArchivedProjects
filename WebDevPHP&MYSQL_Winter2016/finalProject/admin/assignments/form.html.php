<?php include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/helpers.inc.php'; ?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title><?php htmlout($pageTitle); ?></title>
        <style type="text/css">
            textarea {
               display: block;
               width: 100%;
            }
        </style>
    </head>
    <body>
        <h1><?php htmlout($pageTitle); ?></h1>
        <form action="?<?php htmlout($action); ?>" method="post">
            <div>
                <label for="text"> Type your assignment here:</label>
                <textarea id="text" name="text" rows="3" cols="40"><?php htmlout($text); ?></textarea>
            </div>
            <div>
                <label for="student">Student:</label>
                <select name="student" id="student">
                    <option value="">Select one</option>
                    <?php foreach ($students as $student): ?>
                    <option value="<?php htmlout($student['id']); ?>"
                    <?php if ($student['id'] == $studentid)
                    {
                        echo ' selected';
                    } ?>>
                        <?php htmlout($student['name']); ?>
                    </option>
                    <?php endforeach; ?>
                </select>
            </div>
            <fieldset>
                <legend>Courses:</legend>
                <?php foreach ($courses as $course): ?>
                <div><label for="course<?php htmlout($course['id']); ?>"><input type="checkbox" name="courses[]" id="course<?php htmlout($course['id']); ?>"<?php
                if ($course['selected'])
                {
                    echo ' checked';
                }
                ?>><?php htmlout($course['name']); ?></label></div>
                <?php endforeach; ?>
            </fieldset>
            <div>
                <input type="hidden" name="id" value="<?php htmlout($id); ?>">
                <input type="submit" value="<?php htmlout($button); ?>">
            </div>
        </form>
    </body>
</html>