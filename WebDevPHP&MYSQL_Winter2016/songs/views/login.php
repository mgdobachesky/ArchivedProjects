 <?php
session_start();
$username = $_POST['username'];
$pwd = $_POST['pwd'];

$row = login($db, $username, $pwd);

if (!empty($row['id'])) {
    $_SESSION['userid'] = $row['id'];
    header('Location: index.php');
    } else {
        if (!empty($_POST['submit'])) {
            echo "<p>Invalid username or password</p>";
        }
    }

if ($_SESSION['userid'] == NULL || empty($_SESSION['userid'])) {
?>

    <form action="." method="post">
        <table>
            <tr><td style="text-align: right";>Username: </td><td><input type="text" name="username" /></td></tr>
            <tr><td style="text-align: right";>Password: </td><td><input type="password" name="pwd" /></td></tr>
            <tr><td></td><td><input name="submit" value="Log in" type="submit" /></td></tr>
        </table>
    </form>
<?php } ?>