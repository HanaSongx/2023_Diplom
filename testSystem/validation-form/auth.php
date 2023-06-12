<?php
$login = filter_var(trim($_POST['login2']));
$pass1 = filter_var(trim($_POST['pass2']));
$pass = md5($pass1.'gdadgewqf234');

$mysql = new mysqli('localhost', 'root', '', 'Curse');
$result = $mysql->query("SELECT * FROM `users` WHERE `login` = '$login' AND `pass` = '$pass'");
$result1 = $mysql->query("SELECT * FROM `users` WHERE `id` = 1");
    $user = $result->fetch_assoc();
    $admin = $result1->fetch_assoc();

    if (empty($login) and empty($pass1)) {
      header('Location:/errors/NoUser.html');
      //header('Location:/errors/NullLogin.html');
      exit();
    }

    if (empty($login)) {
      header('Location:/errors/NullLogin.html');
      exit();
    }

    if (empty($pass1)) {
      header('Location:/errors/NullPassword.html');
      exit();
    }

    if (strlen($pass1)<6 or strlen($pass1)>16){
      header('Location:/errors/InvalidPass.html');
      exit();
    }

    if (count($user) == 0) {
      /*echo '<script language="javascript" id = "123">';
      echo 'alert("Такой пользователь не найден")';
      echo '</script>';
      //echo 'alert("Такой пользователь не найден")';*/
      header('Location:/errors/NoUser.html');
      exit();
    }

setcookie('user', $user['name'], time() + 3600, "/");
setcookie('login', $user['login'], time() + 3600, "/");


if (strpos($user['name'], 'Admin') !== false and strpos($user['pass'], 'e86f086487accb52ecfc9769cb1b888') !== false) {
  header('Location: /admin.php');
  exit();
}

$mysql->close();
header('Location: /');
?>
