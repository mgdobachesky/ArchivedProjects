<?php
function getActors($db) {
    $sql = "SELECT * FROM actors";
    try {
        $ps = $db->prepare($sql);
        $ps->execute();
        $results = $ps->fetchAll(PDO::FETCH_ASSOC);
    } catch (PDOException $e) {
        exit("There was a problem getting the actors");
    }
    return $results;
}

function getActor($db, $actorId) {
    $sql = "SELECT * FROM actors WHERE actorId = :actorId LIMIT 1";
    try {
        $ps = $db->prepare($sql);
        $ps->bindValue(':actorId', $actorId, PDO::PARAM_INT);
        $ps->execute();
        $result = $ps->fetch(PDO::FETCH_ASSOC);
        return $result;
    } catch (PDOException $e) {
        exit("There was a problem getting the record");
    }
}

function addActor($db, $fName, $lName, $birthMonth, $birthYear, $birthDay, $gender, $actionGenre, $comedyGenre, $dramaGenre, $sciFiGenre) {
	$sql = "INSERT INTO actors (actorId, firstName, lastName, birthMonth, birthYear, birthDay, gender, action, comedy, drama, scienceFiction) VALUES (NULL, :fName, :lName, :birthMonth, :birthYear, :birthDay, :gender, :actionGenre, :comedyGenre, :dramaGenre, :sciFiGenre)";
	try {
		$ps = $db->prepare($sql);
		$ps->bindValue(':fName', $fName, PDO::PARAM_STR);
		$ps->bindValue(':lName', $lName, PDO::PARAM_STR);
		$ps->bindValue(':birthMonth', $birthMonth, PDO::PARAM_INT);
		$ps->bindValue(':birthYear', $birthYear, PDO::PARAM_INT);
		$ps->bindValue(':birthDay', $birthDay, PDO::PARAM_INT);
		$ps->bindValue(':gender', $gender, PDO::PARAM_STR);
		$ps->bindValue(':actionGenre', $actionGenre, PDO::PARAM_STR);
		$ps->bindValue(':comedyGenre', $comedyGenre, PDO::PARAM_STR);
		$ps->bindValue(':dramaGenre', $dramaGenre, PDO::PARAM_STR);
		$ps->bindValue(':sciFiGenre', $sciFiGenre, PDO::PARAM_STR);
		$ps->execute();
		$result = $db->lastInsertId();
		return $result;
	} catch(PDOException $e) {
		exit("There was a problem adding the actor");
	}
}
?>