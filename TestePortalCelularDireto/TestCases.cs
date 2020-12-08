using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestePortalCelularDireto
{
    [TestClass]
    public class TestCases
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestContratacaoPlano()
        {
            _driver.Navigate().GoToUrl("https://www.celulardireto.com.br/");
            Assert.AreEqual("Celular Direto: Tudo sobre Celulares e Planos", _driver.Title);

            _driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/a")).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            TesteHelper.WhaitUntil(_driver, ElementType.XPATH, "/html/body/div[5]/wza-vrj-mobile-plan-comparison/main/div/section/div[1]/mpc-card-plan/section/div[3]/div/button");

            _driver.FindElement(By.XPath("/html/body/div[5]/wza-vrj-mobile-plan-comparison/main/div/section/div[1]/mpc-card-plan/section/div[3]/div/button")).Click();
            _driver.SwitchTo().Frame("iframeModalCD");
            TesteHelper.WhaitUntil(_driver, ElementType.XPATH, "/html/body/div[1]/div/ui-view/inner/main/div[2]/section/ui-view/personal-data/section/form/div[1]/div[2]/wza-checkbox-radio/label/div/span");

            _driver.FindElement(By.XPath("/html/body/div[1]/div/ui-view/inner/main/div[2]/section/ui-view/personal-data/section/form/div[1]/div[2]/wza-checkbox-radio/label/div/span")).Click();
            TesteHelper.WhaitUntil(_driver, ElementType.ID, "lineContact");
            
            _driver.FindElement(By.Id("lineContact")).SendKeys("(21) 98911-1111");
            _driver.FindElement(By.Id("email")).SendKeys("giorlanajr@gmail.com");
            _driver.FindElement(By.Id("cpf")).SendKeys("590.992.500-88");
            _driver.FindElement(By.Id("btnLead")).Click();
            TesteHelper.WhaitUntil(_driver, ElementType.ID, "name");

            _driver.FindElement(By.Id("name")).SendKeys("Giorlana Olivia");
            _driver.FindElement(By.Id("birth")).SendKeys("10/10/1982");
            _driver.FindElement(By.Id("motherName")).SendKeys("Giorlana Olivia Mãe");
            _driver.FindElement(By.Id("btnPersonalData")).Click();
            TesteHelper.WhaitUntil(_driver, ElementType.ID, "cep");

            _driver.FindElement(By.Id("cep")).SendKeys("06528071");
            TesteHelper.WhaitUntil(_driver, ElementType.ID, "number");

            _driver.FindElement(By.Id("number")).SendKeys("11");
            _driver.FindElement(By.Id("btnAddress")).Click();
            TesteHelper.WhaitUntil(_driver, ElementType.XPATH, "/html/body/div[1]/div/ui-view/inner/main/div[2]/section/ui-view/payment-page/section/tabs/div/ul/li[2]/h1");
            
            _driver.FindElement(By.XPath("/html/body/div[1]/div/ui-view/inner/main/div[2]/section/ui-view/payment-page/section/tabs/div/ul/li[2]/h1")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("$('body > div._hj - widget - container._hj - widget - theme - dark > div > div').remove()");
            js.ExecuteScript("$('#field-group-term > span').click();");
            TesteHelper.WhaitUntil(_driver, ElementType.ID, "btnTicket");

            _driver.FindElement(By.Id("btnTicket")).Click();
            TesteHelper.WhaitUntil(_driver, ElementType.XPATH, "/html/body/div[1]/div/ui-view/congratulations/section/div[2]/congrats/section/div[1]/h2/span");

            string valor = _driver.FindElement(By.XPath("/html/body/div[1]/div/ui-view/congratulations/section/div[2]/congrats/section/div[1]/h2/span")).Text;
            Assert.AreEqual("Pedido finalizado, parabéns pelo seu novo plano!", valor);
        }




        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
