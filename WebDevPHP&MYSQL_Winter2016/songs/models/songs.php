<?php
function get_songs($db){
    $sql = "SELECT * FROM songs ORDER BY artist, name";
    $results = $db->query($sql);
    return $results;
}

function get_song($id, $db){
    $sql = "SELECT * FROM songs WHERE id=$id";
    $results = $db->query($sql);
    $song = $results->fetch();
    return $song;
}

function delete_song($id, $db){
    $sql = "DELETE FROM songs WHERE id = :id";
    $ps = $db->prepare($sql);
    $ps->bindValue(':id', $id);
    $ps->execute();
}

function login($db, $username, $pwd){
    $sql = "SELECT id FROM users WHERE username='$username' AND pwd='$pwd'";
    $results = $db->query($sql);
    $row = $results->fetch();
    return $row;
}

function logout(){
    $_SESSION = array();
    session_destroy();
}

function new_song($db, $name, $artist, $running_time, $lyrics, $rating){
    try{
        $sql = "INSERT INTO songs SET name = :name, artist = :artist, running_time = :running_time, lyrics = :lyrics, rating = :rating";
        $ps = $db->prepare($sql);
        $ps->bindValue(':name', $name);
        $ps->bindValue(':artist', $artist);
        $ps->bindValue(':running_time', $running_time);
        $ps->bindValue(':lyrics', $lyrics);
        $ps->bindValue(':rating', $rating);
        return $ps->execute();
    } catch (PDOException $e) {
        die ("There was a problem adding this song.");
    }
}
    
function update_song($db, $id, $name, $artist, $running_time, $lyrics, $rating){
    try{
        $sql = "UPDATE songs SET name = :name, artist = :artist, running_time = :running_time, lyrics = :lyrics, rating = :rating WHERE id = :id";
        $ps = $db->prepare($sql);
        $ps->bindValue(':name', $name);
        $ps->bindValue(':artist', $artist);
        $ps->bindValue(':running_time', $running_time);
        $ps->bindValue(':lyrics', $lyrics);
        $ps->bindValue(':rating', $rating);
        $ps->bindValue(':id', $id);
        return $ps->execute();
    } catch (PDOException $e) {
        die ("There was a problem updating this song.");
    }
}
?>