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
    //Make connection
    $conn = new mysqli($servername, $username, $password, $dbName);
    //Check connection
    if(!$conn)
        die("Connection failed.".mysqli_connect_error());
    
    $sql = "SELECT id, name, cost FROM items";
    $result = mysqli_query($conn, $sql);

    if(mysqli_num_rows($result)>0)
    {
        while($row = mysqli_fetch_assoc($result)){
            echo "id:".$row['id']."|name:".$row['name']."|cost:".$row['cost'].";";
        }
    }
?>