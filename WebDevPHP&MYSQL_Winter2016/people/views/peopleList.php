<aside>
    <p><a href="index.php?action=new">Add a New Person</a></p>
    <ul>
        <?php foreach($people as $person): ?>
        <li>
            <a href="index.php?action=personDetails&id=<?php echo $person['id']; ?>"><?php echo $person['lName'] . ", " . $person['fName']; ?></a>
        </li>
        <?php endforeach; ?>
    </ul>
</aside>