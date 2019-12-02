<?php
include("pc_Common.php");

 	$link=dbConnect();
 	$UUID = safe($_POST['UUID']);

    $query = "SELECT * FROM tbHighScore WHERE `UUID`= '$UUID'";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['Prize'];
    }
    mysql_close($link);
?>