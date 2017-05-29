<?php
function get_people($db){
    //global $db;
    $sql = "SELECT * FROM people ORDER BY lName, fName";
    $results = $db->query($sql);
    return $results;
}

function get_person($id, $db){
    $sql = "SELECT * FROM people WHERE id=$id";
    $results = $db->query($sql);
    $person = $results->fetch();
    return $person;
}

function delete_person($id, $db){
     //$sql = "DELETE FROM people WHERE id=$id";
     //$db->exec($sql);
     $sql = "DELETE FROM people WHERE id = :id";
     $ps = $db->prepare($sql);
     $ps->bindValue(':id', $id);
     $ps->execute();
}

function new_person($db, $fName, $lName, $address, $city, $state, $zip, $gender, $dob) {
  try {
    $sql = "INSERT INTO people SET fName = :fName, lName = :lName, address = :address, city = :city, state = :state, zip = :zip, gender = :gender, dob = :dob";
    $ps = $db->prepare($sql);
    $ps->bindValue(':fName', $fName);
    $ps->bindValue(':lName', $lName);
    $ps->bindValue(':address', $address);
    $ps->bindValue(':city', $city);
    $ps->bindValue(':state', $state);
    $ps->bindValue(':zip', $zip);
    $ps->bindValue(':gender', $gender);
    $ps->bindValue(':dob', $dob);
    return $ps->execute();
  }
  
  catch  (PDOException $e) {
    die("There was a problem with the add query.");
  }
  
}

function update_person($db, $personID, $fName, $lName, $address, $city, $state, $zip, $gender, $dob) {
    try {
    $sql = "UPDATE people SET fName = :fName, lName = :lName, address = :address, city = :city, state = :state, zip = :zip, gender = :gender, dob = :dob WHERE id = :id";
    $ps = $db->prepare($sql);
    $ps->bindValue(':fName', $fName);
    $ps->bindValue(':lName', $lName);
    $ps->bindValue(':address', $address);
    $ps->bindValue(':city', $city);
    $ps->bindValue(':state', $state);
    $ps->bindValue(':zip', $zip);
    $ps->bindValue(':gender', $gender);
    $ps->bindValue(':dob', $dob);
    $ps->bindValue(':id', $personID);
    return $ps->execute();
  }
  
  catch  (PDOException $e) {
    die("There was a problem with the update query.");
  }
}
?>