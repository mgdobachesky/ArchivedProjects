<form action="index.php<?php if ($action == "edit") {echo "?id=" . $person['id']; }?>" method="post">
    
    <label for="fname">First Name: </label>
    <input type="text" id="fname" name="fName" value="<?php echo $person['fName'];?>" /><br />
    
    <label for="lname">Last Name: </label>
    <input type="text" id="lname" name="lName" value="<?php echo $person['lName'];?>" /><br />
    
    <label for="dob">Date Of Birth: </label>
    <input type="text" id="dob" name="dob" value="<?php echo $person['dob'];?>" />YYYY-MM-DD<br />
    
    <label for="address">Address: </label>
    <input type="text" id="address" name="address" value="<?php echo $person['address'];?>" /><br />
    
    <label for="city">City: </label>
    <input type="text" id="city" name="city" value="<?php echo $person['city'];?>" /><br />
    
    <label for="state">State: </label>
    <input type="text" size="2" maxlength="2" id="state" name="state" value="<?php echo $person['state'];?>" /><br />
    
    <label for="zip">Zip: </label>
    <input type="text" id="zip" name="zip" value="<?php echo $person['zip'];?>" /><br />
    
    <label for="male">Male: </label>
    <input type="radio" id="male" name="gender" <?php if($person['gender'] == "M") {echo "checked='checked' "; }?> value="M" /><br />
    
    <label for="female">Female: </label>
    <input type="radio" id="female" name="gender" <?php if($person['gender'] == "F") {echo "checked='checked' "; }?> value="F" /><br />
    
    <input type="submit" name="action" value="<?php if ($action == 'new') { echo "Save";} else {echo "Update";}?>" />
</form>