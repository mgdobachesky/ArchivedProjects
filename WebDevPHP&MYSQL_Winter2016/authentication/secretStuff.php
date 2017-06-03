<?php
session_start();

if($_SESSION['userid'] == NULL || empty($_SESSION['userid'])) {
    header('Location: login.php');
}
?>

<p>This is secret writing.</p>
<p>You can't see this unless you are authorized.</p>

<?php
$_SESSION = array();
session_destroy();
?>