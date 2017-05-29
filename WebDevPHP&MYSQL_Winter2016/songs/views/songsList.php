<aside>
    <tr>
        <td rowspan="2" class="songLinks">
            
            <?php
            session_start();            
            if (!empty($_SESSION['userid'])) { ?>
                <p><a href="index.php?action=new">Add a New Song</a></p>
                <?php
            }
            
            include_once('views/login.php');
            ?>
            
            <ul>
                <?php foreach($songs as $song): ?>
                    <li>
                        <a href="index.php?action=songDetails&id=<?php echo $song['id']; ?>"><?php echo htmlspecialchars($song['artist'], ENT_QUOTES, 'UTF-8') . " - " . htmlspecialchars($song['name'], ENT_QUOTES, 'UTF-8'); ?></a>
                    </li>
                <?php endforeach; ?>
            </ul>
            
            <?php
            session_start();            
            if (!empty($_SESSION['userid'])) { ?>
                <p><a href="index.php?action=logout">Log Out</a></p>
            <?php } ?>
        </td>
</aside>