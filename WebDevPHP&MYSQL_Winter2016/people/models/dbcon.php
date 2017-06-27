<?php

$dsn = "mysql:host=localhost;dbname=friday";
$username = "fridayphp";
$password = "PASSWORD";

try {
    //what code may fail
    $db = new PDO($dsn, $username, $password);
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $db->exec('SET NAMES "utf8"'); 
} catch (PDOException $e) {
    //code to handle the exception
    //echo $e->getMessage();
    //exit();
    die("There was a problem connecting to the database");
}

//echo "Got connected!";

?>
