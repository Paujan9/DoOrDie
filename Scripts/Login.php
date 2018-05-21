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
    $user_password = $_POST["passwordPost"];
    //Make connection
    $conn = new mysqli($servername, $username, $password, $dbName);
    //Check connection
    if(!$conn)
        die("Connection failed.".mysqli_connect_error());
    
    $sql = "SELECT password FROM players WHERE username ='".$user_username."'";
    $result = mysqli_query($conn, $sql);
    //get result and confirm login
    if(mysqli_num_rows($result)>0)
    {
        while($row = mysqli_fetch_assoc($result)){
            if($row['password']==$user_password)
            {
                echo "Login success";
            }
            else{
                echo "Password incorrect";
            }
        }
    }
    else{
        echo "User not found";
    }
?>