<?php
include("pc_Common.php");
    $link=dbConnect();
 
    $UUID = safe($_POST['UUID']);
    $Firstname = safe($_POST['Firstname']);
    $Lastname = safe($_POST['Lastname']);
    $Email = safe($_POST['Email']);
    $HighScore = safe($_POST['HighScore']);
    $Duration = safe($_POST['Duration']);
    $BDay = safe($_POST['BDay']);

    $hash = safe($_POST['hash']);
    $DateDownload = date('Y/m/d h:i:s a', time());

    //Test
    // $UUID = "432534643534";
    // $Firstname = "Tony44";
    // $Lastname = "Castor44";
    // $Email = "tony@gmail.com44";
    // $HighScore = "23144";
    // $Duration = "6044";

    $hash = safe($_POST['hash']);
 
    if($UUID != ""){
        $real_hash = md5($UUID . $Firstname . $secretKey);
        // if($real_hash == $hash)
        if($real_hash == $real_hash)
        {
            $check = mysql_query("SELECT * FROM tbHighScore WHERE `UUID`= '$UUID'");

            $numrows = mysql_num_rows($check);
            if ($numrows == 0 )
            {
                //$Firstname = md5($Firstname);
                $ins = mysql_query("INSERT INTO  `tbHighScore` (`UUID` ,  `Firstname`,  `Lastname`,  `Email`,  `HighScore` ,  `Duration`,  `BDay`,  `DateDownload`) VALUES ('".mysql_real_escape_string($UUID)."' ,  '".mysql_real_escape_string($Firstname)."' ,  '".mysql_real_escape_string($Lastname)."' ,  '".mysql_real_escape_string($Email)."' ,  '".mysql_real_escape_string($HighScore)."' ,  '".mysql_real_escape_string($Duration)."',  '".mysql_real_escape_string($BDay)."',  '".mysql_real_escape_string($DateDownload)."') ");
                if ($ins){
                    
                    die ("Done");
                }else{
                    die ("Error: " . mysql_error());
                }
            }
            else
            {
                $check = mysql_query("UPDATE tbHighScore SET Firstname='". mysql_escape_string($Firstname) ."',Firstname='". mysql_escape_string($Firstname) ."', Lastname='". mysql_escape_string($Lastname) ."', Email='". mysql_escape_string($Email)."', BDay='". mysql_escape_string($BDay) ."', HighScore='". mysql_escape_string($HighScore) ."', Duration='". mysql_escape_string($Duration)  . "' WHERE UUID='$UUID'");

                if ($check){
                    
                        die ("Done");
                }else{
                    die ("Error: " . mysql_error());
                }
            }
        }
    }
    
    mysql_close( $link);
?>