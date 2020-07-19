<?
function ConnectDB()
{
    $DBNAME = "klionfr2_cashnote";
    $DBUSER = "klionfr2_app";
    $DBHOST = "192.168.2.200";
    $PASSWD = "NLQmeciGq";
    $conn = mysqli_connect($DBHOST, $DBUSER, $PASSWD, $DBNAME);
    if ($conn->connect_error) {
        print mysqli_error($conn);
        return null;
    }
    mysqli_query($conn, "set character set utf8");
    mysqli_query($conn, "SET CHARACTER_SET_database= utf8");
    mysqli_query($conn, "SET CHARACTER_SET_CLIENT= utf8");
    mysqli_query($conn, "SET CHARACTER_SET_RESULTS= utf8");
    return $conn;
}
function SqlCommit($conn, $cmd)
{
    $sqlData = $conn->query($cmd);
    if (is_bool($sqlData))
        return $sqlData;
    if ($sqlData->num_rows > 0) {
        return $sqlData;
    } else
        return null;
}