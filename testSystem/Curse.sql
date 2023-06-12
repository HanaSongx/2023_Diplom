-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 24 2023 г., 03:03
-- Версия сервера: 8.0.30
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Curse`
--

-- --------------------------------------------------------

--
-- Структура таблицы `department`
--

CREATE TABLE `department` (
  `id` int UNSIGNED NOT NULL,
  `name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `about` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `photo` varchar(250) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `department`
--

INSERT INTO `department` (`id`, `name`, `about`, `photo`) VALUES
(1, 'Web приложение', 'Нужен красивый и удобный сайт в ближайшие сроки? Специалисты своего дела напишут вам качественное веб приложение как можно быстрее. Получится лучше, чем наш сайт!', 'web'),
(7, 'Desktop приложение', 'Напишем приложение под любую операционную систему на любом популярно языке программирования на любую интересующую вас тематику (почти). ', 'Desktop'),
(8, 'Gamedev', 'Поможем вам в создании игры вашей мечты. От левел дизайна и моделек персонажей, до прописывания механик.', 'gamedev'),
(9, 'Тестирование приложения', 'Рядовые специалисты из сферы QA готовы помочь вам с любым из возможных видов тестирования. Можем провести как и мануальные так и автоматизированные тесты.', 'test'),
(10, 'Работа с бд', 'Никогда раньше не слышали об SQL? Мы поможем создать вам готовую к использованию под любые нужды базу данных и даже готовы импортировать её в ваши готовые приложения.', 'database'),
(11, 'Мобильное приложение ', 'Приложение на Android/IOS будет у вас ещё раньше, чем вы успеете сказать Kotlin.', 'mobile');

-- --------------------------------------------------------

--
-- Структура таблицы `Executor`
--

CREATE TABLE `Executor` (
  `id` int NOT NULL,
  `Name` varchar(32) COLLATE utf8mb4_general_ci NOT NULL,
  `Surname` varchar(32) COLLATE utf8mb4_general_ci NOT NULL,
  `Department` varchar(15) COLLATE utf8mb4_general_ci NOT NULL,
  `Prog_lang` varchar(100) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `reserv`
--

CREATE TABLE `reserv` (
  `order_id` int NOT NULL,
  `department` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `user` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `description` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `mail` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `reserv`
--

INSERT INTO `reserv` (`order_id`, `department`, `user`, `description`, `mail`, `status`) VALUES
(5, 'Web приложение', NULL, '87567', '777', 1),
(6, 'Desktop приложение', 'SSSSSSSS', 'Хачу черешню', 'a@lina', 1),
(7, 'Web приложение', 'SSSSSSSS', 'выфв', '321321', 1),
(8, 'Web приложение', 'HanaSong', 'Отмена черешни', 'уцйу', 1),
(9, 'Desktop приложение', 'Darknight', 'Хочу зачет', 'Гыыы', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int UNSIGNED NOT NULL,
  `login` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `pass` varchar(32) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `name`, `pass`) VALUES
(1, 'Admin', 'Admin', 'e86f086487accb52ecfc9769cb1b8885'),
(18, 'SSSSSSSS', 'Алина', 'b8e7dc613d91d18e2dbb56a6b479d3e8'),
(17, 'HanaSong', 'Никита', '3070e0b49513372c4729b36b85fadeda'),
(20, 'Clown', 'Ярослав', 'f914467dec16c5b502c784d5cb3c0952'),
(22, 'Darknight', 'ЖЕНЕК', 'f914467dec16c5b502c784d5cb3c0952');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`id`),
  ADD KEY `index2` (`name`);

--
-- Индексы таблицы `Executor`
--
ALTER TABLE `Executor`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Department` (`Department`);

--
-- Индексы таблицы `reserv`
--
ALTER TABLE `reserv`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `department` (`department`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `index1` (`login`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `department`
--
ALTER TABLE `department`
  MODIFY `id` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `reserv`
--
ALTER TABLE `reserv`
  MODIFY `order_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
