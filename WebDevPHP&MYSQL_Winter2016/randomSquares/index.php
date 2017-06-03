<?php
$hexArray = array();
?>

<!DOCTYPE html>
<html lang="en">
<head><title>Colors</title></head>

<body>
<?php 
for ($hexStored =1; $hexStored <=100; $hexStored++):

$hexNumber = "";

	for ($hex =1; $hex <7; $hex++):
	
		$hexDigit = mt_rand(0, 15);
		$hexDigit >= 10;
	
		switch ($hexDigit):
			case 10:
				$hexDigit = 'A';
				break;
		
			case 11:
				$hexDigit = 'B';
				break;
		
			case 12:
				$hexDigit = 'C';
				break;
		
			case 13:
				$hexDigit = 'D';
				break;
		
			case 14:
				$hexDigit = 'E';
				break;
		
			case 15:
				$hexDigit = 'F';
				break;
		endswitch;
	
		$hexNumber = "$hexNumber" . "$hexDigit";
	endfor;
	
	array_push($hexArray, "$hexNumber");
	
endfor;
sort($hexArray);
?>

<table style= 'border-collapse: collapse;'>
	<tbody>
	<?php
	$hexKey = 0;
	for ($row =1; $row <=10; $row++):
		echo "<tr>";
		for ($col =1; $col <=10; $col++):
			echo "<td style='background-color:#$hexArray[$hexKey];padding:4px 4px;text-align:center;'>";
			echo "<span>" . $hexArray[$hexKey] . "<br />" . "</span>";
			echo "<span style=color:white;'>" . $hexArray[$hexKey] . "</span>";
			echo "</td>";
			$hexKey++;
		endfor;
		echo "</tr>";
	endfor;
	?>
	</tbody>
</table>

</body>

</html>