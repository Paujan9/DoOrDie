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
 
    //Make connection
    $conn = new mysqli($servername, $username, $password, $dbName);
    //Check connection
    if(!$conn)
        die("Connection failed.".mysqli_connect_error());

    ///////Issaugojama kiek isvis duomenu bazeje daiktu
    $sql="SELECT Count(items.name) as kiekDaiktu from items;";
    $result = mysqli_query($conn, $sql);
    $row = mysqli_fetch_assoc($result);
    $kiekDaiktu=$row['kiekDaiktu'];
    /////////////////////////////////////

    $sql = "SELECT players.username, highscores.highscore, gold.gold FROM players, highscores, gold 
    WHERE players.username =highscores.fk_username AND  players.username=gold.fk_username and
    players.username ='".$user_username."';";
    $result = mysqli_query($conn, $sql);
    //get result and confirm login
    
    if(mysqli_num_rows($result)>0)
    {
        while($row = mysqli_fetch_assoc($result)){
            echo $row['username']."|".$row['highscore']."|".$row['gold']."|".$kiekDaiktu;
        }
        echo "|";
    }
    else{
        die("There was an error while getting name and highscore.".mysqli_connect_error());
    }

    $sql = "SELECT unlockeditems.arAtrakintas FROM players, unlockeditems 
    where players.username=unlockeditems.fk_username and players.username ='".$user_username."';";
    $result = mysqli_query($conn, $sql);
    //get result and confirm login
    
    if(mysqli_num_rows($result)>0)
    {
        while($row = mysqli_fetch_assoc($result)){
            echo $row['arAtrakintas'].",";
        }
        echo "|";
    }
    else{
        die("There was an error while getting players unlocked items.".mysqli_connect_error());
    }
?>