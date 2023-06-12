<?php
$mysql = new mysqli('localhost', 'root', '', 'Curse');
$name = $mysql->query("SELECT `name` FROM `department` ORDER BY `id`");
$about = $mysql->query("SELECT `about` FROM `department`");
$photo = $mysql->query("SELECT `photo` FROM `department`");
?>

<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="utf8mb4_general_ci">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Главная</title>
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
          <li class="nav-item"><a href="validation.php" id="name" class="nav-link"> <?=$_COOKIE['user']?></a></li>
        <?php endif; ?>
      </ul>
    </header>




<div class="row row-cols-1 row-cols-md-3 mb-3 text-center">
  <?php
  while($result = mysqli_fetch_assoc($name) and $result1 = mysqli_fetch_assoc($about) and $result2 = mysqli_fetch_assoc($photo)){
  ?>
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm">
          <div class="card-header py-3">
<h4 class="my-0 fw-normal"><?php echo $result['name']; ?></h4>
</div>
<div class="card-body">
<img src="img/<?php echo $result2['photo']; ?>.png" alt=""/>
<br>
<?php echo $result1['about']; ?>
<br>
<?php
$gg = $result['name'];
echo "Выполненных заказов:";
$total = $mysql->query("SELECT COUNT(*) FROM `reserv` INNER JOIN `department` ON `reserv`.`department` = `department`.`name` where `status` = 1 and `department` = '$gg'");
$result4 = mysqli_fetch_row($total);
$rep = $result4[0];
print_r($rep);
?>
<br>
      </div>
    </div>
  </div>
    <?php } ?>
</div>
</body>
</html>
