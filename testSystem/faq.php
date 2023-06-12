<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>FAQs</title>
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

<div class="container col-xxl-8 px-4 py-5">
    <div class="col-lg-6">
        <h1 class="display-5 fw-bold lh-1 mb-3">Какие услуги по написанию программного обеспечения вы предлагаете? </h1>
        <p class="lead"> Мы предлагаем широкий спектр услуг по написанию программного обеспечения, включая веб-разработку, разработку мобильных приложений, тестирование программного обеспечения, обслуживание программного обеспечения, обновления программного обеспечения и настройку программного обеспечения.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3">Как мне начать пользоваться вашими услугами? </h1>
        <p class="lead"> Чтобы начать, просто заполните контактную форму на нашем веб-сайте или отправьте нам электронное письмо с деталями вашего проекта. Затем мы свяжемся с вами, чтобы обсудить ваш проект и предоставить вам ценовое предложение.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3"> На каких языках программирования вы специализируетесь?</h1>
        <p class="lead">  Мы специализируемся на широком спектре языков программирования, включая Java, Python, Ruby on Rails, PHP, JavaScript и многие другие. Наша команда разработчиков обладает высокой квалификацией и опытом работы с различными языками программирования.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3"> Как вы обеспечиваете качество своей работы?</h1>
        <p class="lead"> Мы следуем строгому процессу обеспечения качества, который включает тестирование, обзоры кода и непрерывную интеграцию. Наша команда разработчиков обладает высокой квалификацией и опытом в производстве высококачественного программного обеспечения, отвечающего требованиям наших клиентов.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3"> Можете ли вы работать над существующим проектом?</h1>
        <p class="lead"> Да, мы можем работать над существующими проектами. Наша команда разработчиков обладает высокой квалификацией и опытом работы с существующими кодовыми базами и может помочь вам внести необходимые изменения и усовершенствования в ваше программное обеспечение.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3"> С какими отраслями вы работаете?</h1>
        <p class="lead">  Мы работаем с широким спектром отраслей, включая здравоохранение, финансы, розничную торговлю, образование и многие другие. Наша команда разработчиков имеет опыт работы с различными отраслями и может помочь вам разработать программное обеспечение, соответствующее вашим конкретным отраслевым требованиям.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3"> Какова ваша модель ценообразования?</h1>
        <p class="lead"> Наша модель ценообразования зависит от сложности проекта, количества времени, необходимого для его завершения, и требуемого уровня поддержки. Мы предоставляем конкурентоспособные цены и всегда стремимся предоставить нашим клиентам наилучшую отдачу от их инвестиций.</p>
        <br><br><h1 class="display-5 fw-bold lh-1 mb-3"> Как вы обращаетесь с интеллектуальной собственностью? </h1>
        <p class="lead"> Мы уважаем интеллектуальную собственность наших клиентов и всегда гарантируем, что любой код, который мы разрабатываем для них, принадлежит им. Мы рады подписать соглашения о неразглашении для защиты интеллектуальной собственности наших клиентов.</p>
        </div>
      </div>

</body>
</html>
