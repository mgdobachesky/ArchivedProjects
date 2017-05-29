<?php
require("models/dbConn.php");
require("models/functions.php");

$action = $_REQUEST['action'];
$fName = $_POST['fName'];
$lName = $_POST['lName'];
$birthMonth = $_POST['birthMonth'];
$birthYear = $_POST['birthYear'];
$birthDay = $_POST['birthDay'];
$gender = $_POST['gender'];
$actionGenre = $_POST['actionGenre'];
$comedyGenre = $_POST['comedyGenre'];
$dramaGenre = $_POST['dramaGenre'];
$sciFiGenre = $_POST['sciFiGenre'];

if($actionGenre == NULL || empty($actionGenre)) {
	$actionGenre = "false";
} 
if($comedyGenre == NULL || empty($comedyGenre)) {
	$comedyGenre = "false";
} 
if($dramaGenre == NULL || empty($dramaGenre)) {
	$dramaGenre = "false";
} 
if($sciFiGenre == NULL || empty($sciFiGenre)) {
	$sciFiGenre = "false";
} 


if($action == NULL || empty($action)):
	$action = 'htmlView';
endif;

switch ($action):
	case "htmlView":
	$actors = getActors($db);
	include("views/header.php");
	include("views/form.php");
	include("views/lists.php");
	include("views/footer.php");
	break;
	
	case "ajaxAddActor":
	$actorId = addActor($db, $fName, $lName, $birthMonth, $birthYear, $birthDay, $gender, $actionGenre, $comedyGenre, $dramaGenre, $sciFiGenre);
	echo json_encode(getActor($db, $actorId));
	break;
	
endswitch;

?>