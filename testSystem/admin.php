<?php
$mysql = new mysqli('localhost', 'root', '', 'Curse');
ob_start();
?>
<!DOCTYPE html>
<link rel="icon" type="image/x-icon" href="img/logo.ico">
<html>
<head>
	<title>Админка</title>
</head>
<body>
<!--
1) отображение - SELECT
2) добавление - INSERT INTO
3) редактирование - UPDATE
4) удаление - DELETE
-->

<table border="1" cellspacing="0" cellpadding="10">
	<tr>
		<td>id</td>
		<td>name</td>
		<td>about</td>
		<td>photo</td>
		<td>edit</td>
	</tr>
	<?php
		$adds = mysqli_query($mysql, "SELECT * FROM `department`");
		while ($row = mysqli_fetch_assoc($adds)) { ?>
			<tr>
				<td><?php echo $row['id']; ?></td>
				<td><?php echo $row['name']; ?></td>
				<td><?php echo $row['about']; ?></td>
				<td><?php echo $row['photo']; ?></td>
				<td>
					<form method="post">
						<input type="text" name="name" value="<?php echo $row['name']; ?>">
						<input type="text" name="about" value="<?php echo $row['about']; ?>">
						<input type="text" name="photo" value="<?php echo $row['photo']; ?>">
						<input type="number" name="idedit" value="<?php echo $row['id']; ?>"
						style="display: none;">
						<input type="submit" name="edit" value="Изменить">
					</form>
					<?php
						if (isset($_POST['edit'])) {
							$name = $_POST['name'];
							$about = $_POST['about'];
							$photo = $_POST['photo'];
							$id = $_POST['idedit'];

							mysqli_query($mysql, "UPDATE `department`
								SET `about`='$about', `name`='$name', `photo`='$photo'
								WHERE `id`='$id'");
							header("location: admin.php");
						}
					?>
				</td>
			</tr>
		<?php }

	?>
</table>


<!-- Удаление данных -->
<form method="post">
	<br>
	<input type="number" name="iddel"><br>
	<input type="submit" value="Удалить запись" name="delnews"><br><hr>
</form>
<?php
	if (isset($_POST['delnews'])) {
		$idfordel = $_POST['iddel'];

		mysqli_query($mysql, "DELETE FROM `department`
			WHERE `id`='$idfordel'");
		header("location: admin.php");
	}
?>

<!-- Ввод данных в БД -->
<!-- Составим форму -->
<form method="post">
	Название: <input type="text" name="name"><br>
	Описание: <input type="text" name="about"><br>
	Фото: <input type="text" name="photo">
	<input type="submit" name="addnews">
</form>
<?php
	if (isset($_POST['addnews'])) {
		$name = $_POST['name'];
		$about = $_POST['about'];
		$photo = $_POST['photo'];
		// Если ничего не введено, то
		if ($name=="" or $about=="" or $photo=="") {
			echo "вы не ввели текст или заголовок";
		// Иначе добавляем запись (INSERT INTO)
		}else{
		mysqli_query($mysql, "INSERT INTO `department`
			SET `name`='$name',`about`='$about',`photo`='$photo'");
		header("location: admin.php");
		}
	}

?>


</body>
</html>
<?php ob_end_flush(); ?>


<!-- https://www.youtube.com/watch?v=6q4YQ5p8vnc  -->
<!-- https://www.youtube.com/watch?v=Uazr6_08D00 -->
