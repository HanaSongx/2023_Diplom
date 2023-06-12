using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;




namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            //int b = 0;

            CorrectLogin(); a++;
            WrongData(); a++;
            NoDataAll(); a++;
            NoDataLogin(); a++;
            NoDataPassword(); a++;
            InvalidPassword1(); a++;
            InvalidPassword2(); a++;
            CorrectSignUp(); a++;
            CorrectSignUp_LogIn(); a++;
            WrongSignUpLessLogin(); a++;
            WrongSignUpMoreLogin(); a++;
            WrongSignUpLessName(); a++;
            WrongSignUpMoreName(); a++;
            WrongSignUpLessPassword(); a++;
            WrongSignUpMorePassword(); a++;

            Console.WriteLine("Выполнено тестов - " + a + "/" + a);
        }

        public static void CorrectLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "Hanasong";
            string password = "123123";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("name"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "Никита";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }

        public static void WrongData()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someUsername";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "There is no such user";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void NoDataAll()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "";
            string password = "";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "There is no such user";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");

        }
        public static void NoDataLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "You did not enter your username";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void NoDataPassword()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someUsername";
            string password = "";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "You did not enter your password";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void InvalidPassword1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someUsername";
            string password = "12";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "Invalid password";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void InvalidPassword2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someUsername";
            string password = "12345678901234567";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "Invalid password";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void CorrectSignUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "testUser1";
            string name = "someName";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            //btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("check"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "Войти";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public void FailedLogIn_NonSimilarUsernameLetterRegister() // Заводим нового юзера и пробуем залогиниться изменив регистр букв юзернейма
        {
            string username = "Username21";
            string password = "qwerty123";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username.ToUpper());                                 
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password);

            Thread.Sleep(1500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in ", driver.Title, "Login was successfull"); // должны остаться на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем ворнинг
        }
        public void FailedSignup_NonSimilarRegisterPasswordsSignUp()
        {
            string username = "Username10";
            string password = "qwerty123";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password.ToUpper());                             // все верхним регистром

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться нарушив регистр в подтверждлении пароля

       
        public void FailedSignup_ShortPasswordSignUp()
        {
            string username = "Username11";
            string password = "qw12";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("password must be 6 or more characters", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        }  // пробуем зарегистрироваться с паролем короче 6 символов

        
        public void FailedSignup_EmptyPasswordSignUp()
        {
            string username = "Username12";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("enter your username and password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться с пустым паролем

      
        public void SuccessSignup_LargePasswordSignUp()
        {
            string username = "Username13";
            string password = "qwerty123qwerty123qwerty123qwerty123";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up ", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string successMsg = driver.FindElement(By.Id("msg-success")).Text;
            StringAssert.Contains("your registration was successful!", successMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться с очень большим паролем
        public static void CorrectSignUp_LogIn()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "testUser22";
            string name = "someName";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebDriver idriver = new ChromeDriver();
            idriver.Navigate().GoToUrl(@"http://curse/validation.php");
            idriver.Manage().Window.Maximize();

            string username1 = "testUser22";
            string password1 = "somePassword";

            // Найти поле ввода Username
            IWebElement uu = driver.FindElement(By.Id("login2"));
            // Ввести в поле текст переменной username (someUsername)
            uu.SendKeys(username1);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement pp = driver.FindElement(By.Id("pass2"));
            // Ввести в поле текст переменной password (somePassword)
            pp.SendKeys(password1);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btnn = driver.FindElement(By.Id("submit2"));
            // Кликнуть по ней
            btnn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("name"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "someName";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void WrongSignUpLessLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "ss";
            string name = "someName";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "The data entered in registration form is incorrect";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void WrongSignUpMoreLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "ssssssssssssssssssssssssssssssssssssss";
            string name = "someName";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "The data entered in registration form is incorrect";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void WrongSignUpLessName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someLogin";
            string name = "s";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "The data entered in registration form is incorrect";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public void FailedSignup_ExistingUsernameSignUp() //пробуем зарегистрироваться по всем правилам из требований и зарегистрироваться еще раз с теми же данными
        {
            string username = "Username07";
            string password = "QWEasd123";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");
            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);

            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(1000);

            driver.Navigate().GoToUrl("http://curse/validation.php");
            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username);
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password);

            IWebElement z = driver.FindElement(By.Id("password-confirm"));
            z.SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(1000);

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("an account already exists with this username", errorMsg.ToLower(), "Error message"); //отслеживаем сообщение об ошибке
        }
        public void FailedSignup_NoPasswordConfirmSignUp() //пробуем зарегистрироваться не подтвердив пароль
        {
            string username = "Username08";
            string password = "qwerty123";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        }
        public static void WrongSignUpMoreName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someLogin";
            string name = "ssssssssssssssssssssssssssssssssssssssssss";
            string password = "somePassword";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "The data entered in registration form is incorrect";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void WrongSignUpLessPassword()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someLogin";
            string name = "someName";
            string password = "s";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "The data entered in registration form is incorrect";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public static void WrongSignUpMorePassword()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://curse/validation.php");
            driver.Manage().Window.Maximize();

            string username = "someLogin";
            string name = "someName";
            string password = "somePasswordddddddddddddddddddddddddddd";

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("login"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Name
            IWebElement n = driver.FindElement(By.Id("name"));
            // Ввести в поле текст переменной Name (someName)
            n.SendKeys(name);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("pass"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            IWebElement k = driver.FindElement(By.Id("error"));
            string kk = k.Text;
            //Console.WriteLine(kk);

            string msg = "The data entered in registration form is incorrect";

            Assert.AreEqual(msg, kk, "Тест не пройден");
            Console.WriteLine("Тест пройден");
        }
        public void FailedLogIn_CutLargePasswordToTenSymbols() //Заводим нового юзера с длинным паролем и пробуем залогиниться по первым 10 буквам пароля
        {
            string username = "Username23";
            string password = "qwerty123qwerty123qwerty123qwerty123"; // большой пароль

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://curse/validation.php");

            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username);
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password.Substring(0, password.Length - (password.Length - 10)));  // Отправляем подстроку, содержащую первые 10 символов большого пароля

            Thread.Sleep(2500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); // должны остаться на этой же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем ворнинг
        }
    }
}
