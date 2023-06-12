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
    public class SimpleSignupTests
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


        //_____FailedSignUp_* - ожидаем провал______
        //_____SuccessSignUp_* - ожидаем успех______


        [Test]
        public void SuccessSignUp_FullAndCorrectData()
        {
            string name = "Name01";
            string username = "Username01";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");

            IWebElement r = driver.FindElement(By.Id("name"));
            r.SendKeys(name);
            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);

            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up - PVD", driver.Title, "We're redirected somewhere"); // проверяем что остались на той же странице
            string successMsg = driver.FindElement(By.Id("msg-success")).Text;
            StringAssert.Contains("your registration was successful!", successMsg.ToLower(), "SuccessMessage"); // отслеживаем сообщение об успешной регистрации
        } //пробуем зарегистрироваться по всем правилам из требований (+ используем Name)

        [Test]
        public void SuccessSignup_NoNameSignUp() //пробуем зарегистрироваться по всем правилам из требований (+ не используем Name, проверяем обязательно оно или нет)

        {
            string username = "Username02";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up - PVD", driver.Title, "We're redirected somewhere"); // проверяем что остались на той же странице
            string successMsg = driver.FindElement(By.Id("msg-success")).Text;
            StringAssert.Contains("your registration was successful!", successMsg.ToLower(), "SuccessMessage"); // отслеживаем сообщение об успешной регистрации
        }

        [Test]
        public void FailedSignup_NonLatinUsernameSignUp() //пробуем зарегистрироваться с юзернеймом, не содержащим латинских букв
        {
            string username = "ИмяПользователя03";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up - PVD", driver.Title, "We're redirected somewhere"); // отслеживаем , что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("username must consist of latin characters only", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем сообщение об ошибке
        }

        [Test]
        public void FailedSignup_EmptyUsernameSignUp() //пробуем зарегистрироваться с пустым юзернеймом
        {
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");

            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up - PVD", driver.Title, "We're redirected somewhere"); // отслеживаем , что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("enter your username and password", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем сообщение об ошибке
        }


        [Test]
        public void FailedSignup_ShortUsernameSignUp() //пробуем зарегистрироваться с юзернеймом короче 3 символов
        {
            string username = "u5";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up - PVD", driver.Title, "We're redirected somewhere"); // отслеживаем, что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("username must be between 3 and 30 characters", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем сообщение об ошибке
        }

        [Test]
        public void FailedSignup_LargeUsernameSignUp() //пробуем зарегистрироваться с юзернеймом длиннее 30 символов
        {
            string username = "EnnormousLargeUsernameBiggerThanADinosaur06";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up - PVD", driver.Title, "We're redirected somewhere"); // отслеживаем, что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("username must be between 3 and 30 characters", errorMsg.ToLower(), "ErrorMessage"); // отслеживаем сообщение об ошибке
        }

        [Test]
        public void FailedSignup_ExistingUsernameSignUp() //пробуем зарегистрироваться по всем правилам из требований и зарегистрироваться еще раз с теми же данными
        {
            string username = "Username07";
            string password = "QWEasd123";

            driver.Navigate().GoToUrl("http://pvd-stage.mos.ru/signup");
            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);

            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(1000);

            driver.Navigate().GoToUrl("http://example/");
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

        [Test]
        public void FailedSignup_NoPasswordConfirmSignUp() //пробуем зарегистрироваться не подтвердив пароль
        {
            string username = "Username08";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://example/");

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


        [Test]
        public void FailedSignup_NonSimilarPasswordsSignUp()
        {
            string username = "Username09";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://example/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(username);                                           // отправляем сюда юзернейм вместо пароля

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться подтвердив пароль некрорректно

        [Test]
        public void FailedSignup_NonSimilarRegisterPasswordsSignUp()
        {
            string username = "Username10";
            string password = "qwerty123";

            driver.Navigate().GoToUrl("http://example/");

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

        [Test]
        public void FailedSignup_ShortPasswordSignUp()
        {
            string username = "Username11";
            string password = "qw12";

            driver.Navigate().GoToUrl("http://example/");

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

        [Test]
        public void FailedSignup_EmptyPasswordSignUp()
        {
            string username = "Username12";

            driver.Navigate().GoToUrl("http://example/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string errorMsg = driver.FindElement(By.Id("msg-error")).Text;
            StringAssert.Contains("enter your username and password", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться с пустым паролем

        [Test]
        public void SuccessSignup_LargePasswordSignUp()
        {
            string username = "Username13";
            string password = "qwerty123qwerty123qwerty123qwerty123";

            driver.Navigate().GoToUrl("http://example/");

            IWebElement u = driver.FindElement(By.Id("username"));
            u.SendKeys(username);
            IWebElement p = driver.FindElement(By.Id("password"));
            p.SendKeys(password);
            IWebElement f = driver.FindElement(By.Id("password-confirm"));
            f.SendKeys(password);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual("Sign up", driver.Title, "We're redirected somewhere"); //проверяем что остались на той же странице
            string successMsg = driver.FindElement(By.Id("msg-success")).Text;
            StringAssert.Contains("your registration was successful!", successMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться с очень большим паролем

        [Test]
        public void FailedSignup_LatinLetterButNoNumberPasswordSignUp()
        {
            string username = "Username14";
            string password = "qwerty";

            driver.Navigate().GoToUrl("http://example/");

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
            StringAssert.Contains("Password must contain at least 1 latin character and 1 number", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться с паролем, содержащим латинские символы, но не содержащим цифры

        [Test]
        public void FailedSignup_NumberButNoLatinLetterPasswordSignUp()
        {
            string username = "Username15";
            string password = "123456";

            driver.Navigate().GoToUrl("http://example/");

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
            StringAssert.Contains("Password must contain at least 1 latin character and 1 number", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        } //пробуем зарегистрироваться с паролем, содержащим цифры, но не содержащим латинские символы

        [Test]
        public void FailedSignup_NonLatinLetterNonNumberPasswordSignUp()
        {
            string username = "Username16";
            string password = "пароль";

            driver.Navigate().GoToUrl("http://example/");

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
            StringAssert.Contains("Password must contain at least 1 latin character and 1 number", errorMsg.ToLower(), "ErrorMessage"); //отслеживаем сообщение об ошибке
        }  //пробуем зарегистрироваться с паролем, не содержащим ни цифры, ни латинские символы
    }
}


