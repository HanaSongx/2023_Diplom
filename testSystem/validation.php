<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Вход</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css">
    <link rel="icon" type="image/x-icon" href="img/logo.ico">
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
  <header class="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
      <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
        <svg class="bi me-2" width="40" height="32"><use xlink:href="#bootstrap"></use></svg>
        <span class="fs-4">IT Helper</span>
      </a>

      <ul class="nav nav-pills">
        <li class="nav-item"><a href="/" class="nav-link active" aria-current="page">Главная</a></li>
        <li class="nav-item"><a href="order.php" class="nav-link">Оформить заказ</a></li>
        <li class="nav-item"><a href="about.php" class="nav-link">О нас</a></li>
        <li class="nav-item"><a href="faq.php" class="nav-link">FAQs</a></li>
        <?php
         if ($_COOKIE['user'] == ''):
          ?>
          <li class="nav-item"><a href="validation.php" id = "check" class="nav-link">Войти</a></li>
        <?php else: ?>
          <li class="nav-item"><a href="validation.php" class="nav-link"> <?=$_COOKIE['user']?></a></li>
        <?php endif; ?>
      </ul>
    </header>

    <div class="container mt-4">


        <div class="row">
          <div class="col">
            <h1>Зарегистрироваться</h1>
            <form action="validation-form/check.php" method="post">
                <input type="text" class="form-control" name="login"
                id="login" placeholder="Введите логин"><br>
                <input type="name" class="form-control" name="name"
                id="name" placeholder="Введите имя"><br>
                <input type="password" class="form-control" name="pass"
                id="pass" placeholder="Пароль"><br>
                <button class="btn btn-primary btn-lg px-4 me-md-2" id="submit" type="submit">Зарегистрироваться</button>
            </form>
          </div>
          <div class="col">
            <h1>Уже зарегистрированы? Войти </h1>
            <form action="validation-form/auth.php" method="post">
                <input type="text" class="form-control" name="login2"
                id="login2" placeholder="Введите логин"><br>
                <input type="password" class="form-control" name="pass2"
                id="pass2" placeholder="Пароль"><br>
                <button class="btn btn-primary btn-lg px-4 me-md-2" id="submit2" type="submit">Авторизоваться</button>
            </form>
          </div>
        </div>


    </div>
</body>
</html>
