<?php

    $servername = "localhost";
    $server_username = "id5647961_do_or_die_database";
    $server_password = "duomenubaze";
    $dbName = "id5647961_do_or_die_database";
    
    /*
    $servername = "localhost";
    $server_username = "root";
    $server_password = "";
    $dbName = "do_or_die";
    */

    $username=$_POST["usernamePost"];//"test";
    $email=$_POST["emailPost"];//"test email";
    $password =$_POST["passwordPost"];// "123456";

    //Make connection
    $conn = new mysqli($servername, $server_username, $server_password, $dbName);
    //Check connection
    if(!$conn)
        die("Connection failed.".mysqli_connect_error());
    
    $sql = "INSERT INTO players (username, email, password)
            VALUES('".$username."','". $email."','". $password."')";
           
    $result = mysqli_query($conn, $sql);
    if(!$result)
    {
        die("There was an error when inserting new player".mysqli_connect_error());
    } 
    else 
    {
        echo "player inserted\n";
        $sql = "INSERT INTO highscores (fk_username, highscore)
            VALUES('".$username."',". "0)";
        $result = mysqli_query($conn, $sql);
        if(!$result)
        {
            die("There was an error when inserting new players highscore".mysqli_connect_error());
        } 
        else 
        {
            echo "new players highscore inserted.\n";
            $sql = "INSERT INTO unlockeditems (fk_username, itemId, arAtrakintas)
            VALUES('".$username."',". "0, 0),
            ('".$username."',". "1, 0),
            ('".$username."',". "2, 0),
            ('".$username."',". "3, 0),
            ('".$username."',". "4, 0),
            ('".$username."',". "5, 0),
            ('".$username."',". "6, 0),
            ('".$username."',". "7, 0),
            ('".$username."',". "8, 0),
            ('".$username."',". "9, 0)";
            
            $result = mysqli_query($conn, $sql);
            if(!$result)
            {
                die("There was an error when inserting new players unlocker items".mysqli_connect_error());
            }
            else 
            {
                echo "new players unlocked items inserted.\n";
                $sql = "INSERT INTO gold (fk_username, gold)
                VALUES('".$username."',". "0)";
                $result = mysqli_query($conn, $sql);
                if(!$result)
                {
                    die("There was an error when inserting new players gold".mysqli_connect_error());
                } 
                else
                {
                    echo "new players gold inserted.\n";
                }
            }
        }
    }

    
?>