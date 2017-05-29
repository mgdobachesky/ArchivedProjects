<section>
        <td class="songDetails">
            <h1><?php echo htmlspecialchars($song['artist'], ENT_QUOTES, 'UTF-8'); ?></h1>
            <p>
                Rating: <?php echo htmlspecialchars($song['rating'], ENT_QUOTES, 'UTF-8'); ?><br />
                Running Time: <?php echo htmlspecialchars($song['running_time'], ENT_QUOTES, 'UTF-8'); ?> seconds<br />
                
                <?php
                session_start();            
                if (!empty($_SESSION['userid'])) {
                        ?>
                        <p><a href="index.php?action=edit&id=<?php echo $song['id'];?>">Edit</a>
                        |
                        <a href="index.php?action=delete&id=<?php echo $song['id'];?>">Delete</a>
                        </p>
                <?php } ?>
                
                <h4>"<?php echo htmlspecialchars($song['name'], ENT_QUOTES, 'UTF-8'); ?>"</h4>
                <p><?php echo nl2br(htmlspecialchars($song['lyrics'], ENT_QUOTES, 'UTF-8')); ?></p>
        </td>
    </tr>
</section>