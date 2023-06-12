<?php
$mysql = new mysqli('localhost', 'root', '', 'Curse');
$name = $mysql->query("SELECT `name` FROM `department` ORDER BY `id`");
?>


<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Оформить заказ</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css">
    <link rel="icon" type="image/x-icon" href="img/logo.ico">
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
          <li class="nav-item"><a href="validation.php" class="nav-link">Войти</a></li>
        <?php else: ?>
          <li class="nav-item"><a href="validation.php" class="nav-link"> <?=$_COOKIE['user']?></a></li>
        <?php endif; ?>
      </ul>
    </header>


  <main>
    <form class="modal-body p-5" action="order-bd.php" method="post">
    <div class="col-md-7 col-lg-8">
      <div class="col-md-5">
        <div class="row g-3">
          <label for="country" class="form-label">Услуга</label>
          <select class="form-select" name="department" id="department">
            <option value="">Выберите...</option>
            <?php while($result = mysqli_fetch_assoc($name)){ ?>
            <option><?php echo $result['name']; ?></option>
            <?php } ?>
            </select>
            <div class="invalid-feedback">
              Пожалуйста выберете услугу.
            </div>
            <div class="col-12">
                <label for="address" class="form-label">Подробности (все детали вашего заказа)</label>
                <input type="text" class="form-control" name="description" id="description" placeholder="В работе я хочу...">
                  <br>
                <label for="address" class="form-label">Email для обратной свзяи</label>
                <input type="mail" class="form-control" name="mail"
                id="mail" placeholder="you@example.com"><br>
                <div class="invalid-feedback">
                  Пожалуйста впишите свой email.
                </div>
            </div>
            <button class="btn btn-primary btn-lg px-4 me-md-2" type="submit">Оформить заказ</button>
      </div>
    </div>
  </div>
</form>
  </main>
</body>
</html>
