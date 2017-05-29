<?php
session_start();

require_once('models/dbcon.php');
require_once('models/songs.php');

include_once('models/cancelMagicQuotes.php');

$action = $_REQUEST['action'];
$songID = $_GET['id'];
$name = $_POST['name'];
$artist = $_POST['artist'];
$running_time = $_POST['running_time'];
$lyrics = $_POST['lyrics'];
$rating = $_POST['rating'];

include_once('views/header.php');


if ($action == "songDetails"):
    $song = get_song($songID, $db);
    include_once('views/songDetails.php');
endif;

if (!empty($_SESSION['userid'])) {
	switch ($action) {
		case "new":
			$song = "";
			include_once("views/songForm.php");
			break;
		case "edit":
			$song = get_song($songID, $db);
			include_once("views/songForm.php");
			break;
		case "delete":
			delete_song($songID, $db);
			break;
		case "Save":
			$rows = new_song($db, $name, $artist, $running_time, $lyrics, $rating);
			break;
		case "Update":
			$rows = update_song($db, $songID, $name, $artist, $running_time, $lyrics, $rating);
			break;
		case "logout":
			logout();
			header('Location: index.php');
			break;
	}
}

$songs = get_songs($db);
include_once('views/songsList.php');

include_once('views/footer.php');

?>