<table id="actorLinks">
<tr>
<th></th><th>First Name</th><th>Last Name</th>
</tr>
<?php
foreach($actors as $actor):
echo "<tr>";
echo "<td>" . $actor['actorId'] . "</td>";
echo "<td>" . $actor['firstName'] . "</td>";
echo "<td>" . $actor['lastName'] . "</td>";
echo "</tr>";
endforeach;
?>
</table>