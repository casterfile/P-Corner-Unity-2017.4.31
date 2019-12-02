<?php
include("pc_Common.php");

 $link=dbConnect();
 $UserPhoneID = safe($_POST['UserPhoneID']);

if($UserPhoneID != "")
{
    $check = mysql_query("SELECT * FROM tblPrizeCount WHERE `tblPrizeCount_UserID`= '$UserPhoneID'");

    $numrows = mysql_num_rows($check);
    if ($numrows == 0 )
    {
        echo $numrows+"";
    }
    else
    {
        echo $numrows+"";
    }
}

mysql_close($link);
?>

