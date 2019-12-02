<?php
include("pc_Common.php");

$tblAccount_Username = $_POST['tblAccount_Username'];
$tblAccount_Password = $_POST['tblAccount_Password'];

$link=dbConnect();
 
$check = mysql_query("SELECT * FROM tblAccount WHERE `tblAccount_Username` ='$tblAccount_Username' ") or die(mysql_error());
$numrows = mysql_num_rows($check);

if ($numrows == 0)
{
    die ("Error");
}
else
{
    //$pass = md5($pass);
    while($row = mysql_fetch_assoc($check))
    {
        if ($tblAccount_Password == $row['tblAccount_Password']){
            die("successful");
        } else {
            die("failed");
        }
    }
}
mysql_close($link);
?>