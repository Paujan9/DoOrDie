<?php

    $servername = "localhost";
    $username = "id5647961_do_or_die_database";
    $password = "duomenubaze";
    $dbName = "id5647961_do_or_die_database";
    
   /*
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbName = "do_or_die";
    */

    $user_username = $_POST["usernamePost"];
    $new_item = $_POST["itemPost"];
   
    //Make connection
    $conn = new mysqli($servername, $username, $password, $dbName);
    //Check connection
    //echo "|".$user_username."|".$new_highscore."|";
    if(!$conn)
        die("Connection failed.".mysqli_connect_error());
    
    $sql = "UPDATE unlockeditems set arAtrakintas= 1 WHERE fk_username ='".$user_username."' and itemId=".$new_item.";";
    $result = mysqli_query($conn, $sql);
    
    //get result and confirm login
/*
    if(mysqli_num_rows($result)>0)
    {
        while($row = mysqli_fetch_assoc($result)){
            echo $row['username']."|".$row['highscore'];
        }
    }
    else{
        echo "There was an error.";
    }
    */
?>