using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace HackappSimpleTests
{
    [TestFixture]
    public class SimpleLoginTests
    {
        protected ChromeDriverService service;
        protected IWebDriver driver;

        /// <summary>
        /// Init вызывается один раз перед запуском тестов.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            service = ChromeDriverService.CreateDefaultService();
        }

        /// <summary>
        /// BeforeTest вызывается перед запуском кажого тестов.
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// AfterTest вызывается после завершения каждого теста.
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            service.Dispose();
            Helpers.KillDanglingProcesses();
        }

        [Test]
        public void CantLogin_InvalidCredentials()
        {
            string username = "someUsername";
            string password = "somePassword";

            driver.Navigate().GoToUrl("http://examplePage/");
            Thread.Sleep(1000);

            // Найти поле ввода Username
            IWebElement u = driver.FindElement(By.Id("username"));
            // Ввести в поле текст переменной username (someUsername)
            u.SendKeys(username);
            // Сделать паузу на 1 секунду
            Thread.Sleep(1000);

            // Найти поле ввода Password
            IWebElement p = driver.FindElement(By.Id("password"));
            // Ввести в поле текст переменной password (somePassword)
            p.SendKeys(password);
            Thread.Sleep(1000);

            // Найти кнопку Login 
            IWebElement btn = driver.FindElement(By.Id("submit"));
            // Кликнуть по ней
            btn.Click();
            // Сделать паузу на 2 секунды
            Thread.Sleep(2000);

            // Получить заголовок текущей страницы
            string pageTitle = driver.Title;
            // Ожидаемый заголовок
            string expectedTitle = "Log in";
            // Сравнить ожидаемым с текущим заголовком
            Assert.AreEqual(expectedTitle, pageTitle, "Текущая страница");
            
            // Найти сообщение об ошибке
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            // Проверить, что сообщение содержит слово incorrect
            StringAssert.Contains("Incorrect username or password", errorMsg, "Сообщение об ошибке");
        } // Начальный тест

        [Test]
        public void CantLogin_EmptyCredentials()
        {
            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            // Очистить поле ввода
            u.Clear();
            IWebElement p = driver.FindElement(By.Id("password"));
            // Очистить поле ввода
            p.Clear();
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Текущая страница");
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            Assert.AreEqual("Incorrect username or password.", errorMsg, "Сообщение об ошибке");
        } // Начальный тест

        [Test]
        public void SuccessLogin_ValidCredentials()
        {
            string username = "testUser";
            string password = "password2019";

            // TODO: Написать код, зарегистрирующий нового пользователя

            // Войти на сайт с логином/паролем успешно загеристрированного пользователя
            driver.Navigate().GoToUrl("http://examplePage/");
            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "We're on Log in page");
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect", errorMsg.ToLower(), "Error message");
        } // Начальный тест

        //_____FailedLogIn_* - ожидаем провал______
        //_____SuccessLogIn_* - ожидаем успех______

        [Test]
        public void SuccessLogIn_FullyCorrectLogIn() // Заводим нового юзера по всем правилам требований и логинимся на сайт
        {
            string username = "Username17";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username);
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password);

            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(1500);

            var action = new Actions(driver).MoveToElement(driver.FindElement(By.CssSelector(".navbar-item.has-dropdown")));  //Драйвеп подводит курсор к выпадающему списку
            action.Perform();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string loggedInUser = wait.Until(drv =>
            {
                var elem = drv.FindElement(By.CssSelector(".navbar-dropdown .tag.is-dark"));
                return elem.Displayed ? elem.Text : null;
            });

            Assert.AreEqual("Products", driver.Title, "We're on the wrong start page"); //смотрим верная ли стартовая страница
            Assert.AreEqual(username, loggedInUser, "User on navbar"); //смотрим совпадает ли юзернейм из выпадающего элемента с фактическим
        }

        [Test]
        public void FailedLogIn_NoUsernameLogIn() // Заводим нового юзера и пробуем залогиниться без юзернейма
        {
            string username = "Username18";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password);

            Thread.Sleep(1500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); //должны остаться на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем ворнинг
        }

        [Test]
        public void FailedLogIn_NoPasswordLogIn() // Заводим нового юзера и пробуем залогиниться без пароля
        {
            string username = "Username19";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://examplePage/"); //переходим на страницу регистрации в систему ПК ПВД

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click(); //Найти кнопку подтверждения регистрации

            driver.Navigate().GoToUrl("http://examplePage/");  //переходим на страницу логина в систему ПК ПВД

            IWebElement x = driver.FindElement(By.Id("username")); 
            x.SendKeys(username);

            Thread.Sleep(1500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); //должны остаться на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем ворнинг
        }

        [Test]
        public void FailedLogIn_EmptyLogIn() // Заводим нового юзера и пробуем залогиниться с полностью пустой формой
        {
            string username = "Username20";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://examplePage/");

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); // должны остаться на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем ворнинг
        }

        [Test]
        public void FailedLogIn_NonSimilarUsernameLetterRegister () // Заводим нового юзера и пробуем залогиниться изменив регистр букв юзернейма
        {
            string username = "Username21";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username.ToUpper());                                 // Все верхним регистром
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password);

            Thread.Sleep(1500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); // должны остаться на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем ворнинг
        }

        [Test]
        public void FailedLogIn_NonSimilarPasswordLetterRegister() // Заводим нового юзера и пробуем залогиниться изменив регистр букв пароля
        {
            string username = "Username22";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username);
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password.ToUpper());                                 // все верхним регистром

            Thread.Sleep(1500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); // должны остаться на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем ворнинг
        }

        [Test]
        public void FailedLogIn_CutLargePasswordToTenSymbols() //Заводим нового юзера с длинным паролем и пробуем залогиниться по первым 10 буквам пароля
        {
            string username = "Username23";
            string password = "qwerty123qwerty123qwerty123qwerty123"; // большой пароль

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            driver.Navigate().GoToUrl("http://examplePage/");

            IWebElement x = driver.FindElement(By.Id("username"));
            x.SendKeys(username);
            IWebElement y = driver.FindElement(By.Id("password"));
            y.SendKeys(password.Substring(0, password.Length - (password.Length-10)));  // Отправляем подстроку, содержащую первые 10 символов большого пароля

            Thread.Sleep(2500);
            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Log in", driver.Title, "Login was successfull"); // должны остаться на этой же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("incorrect username or password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем ворнинг
        }
    }
}
