<?
	$host = "localhost";
	$username = "root";
	$password = "";
	$database = "db_ocorrencia";
	$connection = mysql_connect($host, $username, $password) or die(mysql_error());
	mysql_select_db($database) or die(mysql_error());

?>