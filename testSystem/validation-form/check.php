<?php
    $login = filter_var(trim($_POST['login']));
    $name = filter_var(trim($_POST['name']));
    $pass = filter_var(trim($_POST['pass']));

    if(mb_strlen($login) < 5 || mb_strlen($login) > 15) {
        //echo "Недопустимая длинна логина";
        header('Location:/errors/InvalidSignUp.html');
        exit();
    } else if (mb_strlen($name) < 3 || mb_strlen($name) > 15) {
        header('Location:/errors/InvalidSignUp.html');
        //echo "Недопустимая длинна имени";
        exit();
    }
    else if (mb_strlen($pass) < 3 || mb_strlen($pass) > 15) {
        //echo "Недопустимая длинна пароля";
        header('Location:/errors/InvalidSignUp.html');
        exit();
    }

    $pass = md5($pass.'gdadgewqf234');

    /*print_r($name);
    exit();*/

    $mysql = new mysqli('localhost', 'root', '', 'Curse');
    $mysql->query("INSERT INTO `users` (`login`, `name`, `pass`)
    VALUES('$login', '$name', '$pass')");

    $mysql->close();

    header('Location: /validation.php');
?>
