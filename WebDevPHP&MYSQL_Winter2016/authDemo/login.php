<?php
session_start();

$username = $_POST['username'];
$pwd = $_POST['pwd'];

$db = new PDO('mysql:host=localhost;dbname=friday', 'fridayphp', 'password');
$sql = "SELECT id FROM users WHERE username='$username' AND pwd='$pwd'";
$results = $db->query($sql);
$row = $results->fetch();

if (!empty($row['id'])){
    $_SESSION['userid'] = $row['id'];
    header('Location: secretStuff.php');
} else {
    if (!empty($_POST['submit'])){
        echo "<p>Bad user id or password</p>";
    }
}
?>

<form action="login.php" method="post">
    Username: <input type="text" name="username" />
    Password: <input type="password" name="pwd" />
    <input name="submit" value="Log in" type="submit" />
</form>