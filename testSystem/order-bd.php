<?php
    $department = filter_var(trim($_POST['department']));
    $description = filter_var(trim($_POST['description']));
    $mail = filter_var(trim($_POST['mail']));
    $login = $_COOKIE['login'];

    /*print_r($department);
    exit();*/

    $mysql = new mysqli('localhost', 'root', '', 'Curse');
    $mysql->query("INSERT INTO `reserv` (`department`, `user`, `description`, `mail`, `status`)
    VALUES('$department', '$login', '$description', '$mail', '0')");

    $mysql->close();

    header('Location: /order.php');
?>
