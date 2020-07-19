<?php
include_once("api/sqlConnectAPI.php");


if (isset($_POST["test"])) {
    $conn = ConnectDB();
    if ($conn != null) {
        $cmd = 'INSERT INTO `test`(`test`) VALUES ("' . $_POST["test"] . '");';
        $sqlData = $conn->query($cmd);
        if ($sqlData) {
            echo "OK";
        }
		
    }
}
