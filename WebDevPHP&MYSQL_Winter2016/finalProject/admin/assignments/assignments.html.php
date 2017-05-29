<?php include_once $_SERVER['DOCUMENT_ROOT'] . '/includes/helpers.inc.php'; ?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>Manage Assignments: Search Results</title>
    </head>
    <body>
        <h1>Search Results</h1>
        <?php if (isset($assignments)): ?>
        <table>
            <tr><th>Assignment Text</th><th>Options</th></tr>
            <?php foreach ($assignments as $assignment): ?>
            <tr>
                <td><?php htmlout($assignment['text']); ?></td>
                <td>
                    <form action="?" method="post">
                        <div>
                            <input type="hidden" name="id" value="<?php htmlout($assignment['id']); ?>">
                            <input type="submit" name="action" value="Edit">
                            <input type="submit" name="action" value="Delete">
                        </div>
                    </form>
                </td>
            </tr>
            <?php endforeach; ?>
        </table>
        <?php endif; ?>
        <p><a href="?">New search</a></p>
        <p><a href="..">Return to home</a></p>
        <?php include '../logout.inc.html.php'; ?>
    </body>
</html>