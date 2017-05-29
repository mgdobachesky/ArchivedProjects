<?php
require_once('models/dbcon.php');
require_once('models/people.php');

if (get_magic_quotes_gpc())
{
    $process = array(&$_GET, &$_POST, &$_COOKIE, &$_REQUEST);
    while (list($key, $val) = each($process))
    {
        foreach ($val as $k => $v)
        {
            unset($process[$key][$k]);
            if (is_array($v))
            {
                $process[$key][stripslashes($k)] = $v;
                $process[] = &$process[$key][stripslashes($k)];
            }
            else
            {
                $process[$key][stripslashes($k)] = stripslashes($v);
            }
        }
    }
    unset($process);
}

$action = $_REQUEST['action'];
$personID = $_GET['id'];
$fName = $_POST['fName'];
$lName = $_POST['lName'];
$dob = $_POST['dob'];
$address = $_POST['address'];
$city = $_POST['city'];
$state = $_POST['state'];
$zip = $_POST['zip'];
$gender = $_POST['gender'];

include_once('views/header.php');
$people = get_people($db);
include_once('views/peopleList.php');

/*if ($action == "personDetails"):
    $person = get_person($personID, $db);
    include_once('views/personDetails.php');
endif;*/

switch($action) {
    case "personDetails":
        $person = get_person($personID, $db);
        include_once('views/personDetails.php');
        break;
    case "new":
        $person = "";
        include_once("views/personForm.php");
        break;
    case "edit":
        $person = get_person($personID, $db);
        include_once("views/personForm.php");
        break;
    case "delete":
        delete_person($personID, $db);
        break;
    case "Save":
        $rows = new_person($db, $fName, $lName, $address, $city, $state, $zip, $gender, $dob);
        break;
    case "Update":
        $rows = update_person($db, $personID, $fName, $lName, $address, $city, $state, $zip, $gender, $dob);
        break;
}

include_once('views/footer.php');
?>