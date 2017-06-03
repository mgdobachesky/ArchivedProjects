<!DOCTYPE html>
<html lang="en">
<head><title>Colors</title></head>

<body>
<?php 
function hexGenerator() 
{
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

echo "<td style='background-color:#$hexNumber;padding:4px 4px;text-align:center;'>";
echo "<span>" . $hexNumber . "<br />" . "</span>";
echo "<span style=color:white;'>" . $hexNumber . "</span>";
echo "</td>";
}
?>

<table style='border-collapse:collapse;'>
	<tbody>
		<?php
			for ($row =1; $row <=10; $row++)
			{
				echo "<tr>";
				for ($col =1; $col <=10; $col++)
				{ 
					hexGenerator(); 
				}
				echo "</tr>";
			}
		?>
	</tbody>
</table>

</body>

</html>