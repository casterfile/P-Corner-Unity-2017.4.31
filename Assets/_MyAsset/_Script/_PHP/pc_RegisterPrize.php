<?php
include("pc_Common.php");
    $link=dbConnect();
 
 
    $tblPrizeCount_UserID = safe($_POST['tblPrizeCount_UserID']);
    $tblPrizeCount_Storecode = safe($_POST['tblPrizeCount_Storecode']);
    $tbHighScore_Prize = safe($_POST['tbHighScore_Prize']);
    $tblPrizeCount_RefNo = safe($_POST['tblPrizeCount_RefNo']);

    $tblPrizeCount_Date_Year = date("Y");;
    $tblPrizeCount_Date_Month = date("m");;
    $tblPrizeCount_Date_Day = date("d");;
    

    $hash = safe($_POST['hash']);
 
    //$hash = md5($tblPrizeCount_UserID . $tblPrizeCount_Date_Year . $tblPrizeCount_Date_Month);
    //$real_hash = md5($tblPrizeCount_UserID . $tblPrizeCount_Date_Year . $tblPrizeCount_Date_Month);
    if($tblPrizeCount_UserID != "")
    {
        $check = mysql_query("SELECT * FROM tblPrizeCount WHERE `tblPrizeCount_UserID`= '$tblPrizeCount_UserID' AND `tblPrizeCount_Date_Year`= '$tblPrizeCount_Date_Year' AND `tblPrizeCount_Date_Month`= '$tblPrizeCount_Date_Month' AND `tblPrizeCount_Date_Day`= '$tblPrizeCount_Date_Day'");

        $numrows = mysql_num_rows($check);
        if ($numrows == 0 )
        {
        	
        	$ins = mysql_query("INSERT INTO  `tblPrizeCount` (`tblPrizeCount_UserID` ,  `tblPrizeCount_Date_Year`,  `tblPrizeCount_Date_Month`,  `tblPrizeCount_Date_Day`,  `tblPrizeCount_Storecode`,  `tblPrizeCount_RefNo`  ) VALUES ('".mysql_real_escape_string($tblPrizeCount_UserID)."' ,  '".mysql_real_escape_string($tblPrizeCount_Date_Year)."' ,  '".mysql_real_escape_string($tblPrizeCount_Date_Month)."' ,  '".mysql_real_escape_string($tblPrizeCount_Date_Day)."' ,  '".mysql_real_escape_string($tblPrizeCount_Storecode)."',  '".mysql_real_escape_string($tblPrizeCount_RefNo)."') ");

            //$ins2 = mysql_query("INSERT INTO  `tbHighScore` (`Prize`) VALUES ('".mysql_real_escape_string($tbHighScore_Prize)."') ");

            $ins2 = mysql_query("UPDATE tbHighScore SET Prize='". mysql_escape_string($tbHighScore_Prize). "' WHERE UUID='$tblPrizeCount_UserID'");
            if ($ins){
                die ("successful");
            }else{
                die ("failed");
            }
        }
        else
        {
        	die ("failed");
        }
    }
    mysql_close( $link);
?>