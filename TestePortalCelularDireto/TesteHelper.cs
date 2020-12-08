using OpenQA.Selenium;
using System;
using System.Threading;

namespace TestePortalCelularDireto
{
    enum ElementType
    {
        XPATH = 1,
        ID = 2
    }

    class TesteHelper
    {
        private static int currentRetryNumber = 1;
        private static int maxRetryNumber = 10;

        public static void WhaitUntil(IWebDriver IWebDriver, ElementType ElementType, string ElementValue)
        {
            try
            {
                bool hasElement = false;
                switch (ElementType)
                {
                    case ElementType.XPATH:
                        hasElement = IWebDriver.FindElement(By.XPath(ElementValue)) != null;
                        break;
                    case ElementType.ID:
                        hasElement = IWebDriver.FindElement(By.Id(ElementValue)) != null;
                        break;
                }
                currentRetryNumber = 1;
                Thread.Sleep(1000);
                return;
            }
            catch(Exception ex)
            {
                if(currentRetryNumber < maxRetryNumber)
                {
                    currentRetryNumber++;
                    Thread.Sleep(1000);
                    WhaitUntil(IWebDriver, ElementType, ElementValue);
                }
                else
                {
                    currentRetryNumber = 1;
                    return;
                }
            }
        }
    }
}
