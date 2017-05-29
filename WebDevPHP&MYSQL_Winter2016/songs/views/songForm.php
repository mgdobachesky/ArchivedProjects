<td class="formDetails">
    
<form action="index.php<?php if ($action == "edit") {echo "?id=" . $song['id']; }?>" method="post">
<table>
<tr>
   <table>
    
    <tr>
    <td style="text-align: right";><label for="name">Song Name: </label></td>
    <td><input type="text" id="name" name="name" value="<?php echo $song['name'];?>" /></td>
    </tr>
    
    <tr>
    <td style="text-align: right";><label for="artist">Artist Name: </label></td>
    <td><input type="text" id="artist" name="artist" value="<?php echo $song['artist'];?>" /></td>
    </tr>
    
    <tr>
    <td style="text-align: right";><label for="running_time">Running Time: </label></td>
    <td><input type="text" id="running_time" name="running_time" value="<?php echo $song['running_time'];?>" /></td>
    </tr>
    
    <tr>
    <td style="text-align: right";><label for="lyrics">Lyrics: </label></td>
    <td><textarea cols="40" rows="5" id="lyrics" name="lyrics"><?php echo $song['lyrics'];?></textarea><</td>
    </tr>
     
     <tr>
     <td style="text-align: right";><label for="rating">Rating: </label></td>
     <td><input type="text" id="rating" name="rating" value="<?php echo $song['rating'];?>" /></td>
     </tr>
    
    <tr>
      <td></td>
      <td><input type="submit" name="action" value="<?php if ($action == 'new') {echo "Save";} else {echo "Update";}?>" /></td>
    </tr>
   
   </table>
</tr>
</table>

</form>
</td>