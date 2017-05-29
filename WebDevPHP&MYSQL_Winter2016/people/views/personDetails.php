<section>
    <h1><?php echo $person['lName'] . ", " . $person['fName']; ?></h1>
    <p>Gender: <?php echo $person['gender']; ?><br />
    <p>Address: <?php echo $person['address']; ?><br />
    City, State, and Zip: <?php echo $person['city'] . ", " . $person['state'] . " " . $person['zip']; ?></p>
<p><a href="index.php?action=edit&id=<?php echo $person['id'];?>">Edit</a>
|
<a href="index.php?action=delete&id=<?php echo $person['id'];?>">Delete</a>
</p>
</section>