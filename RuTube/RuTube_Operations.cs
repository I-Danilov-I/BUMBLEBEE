using OpenQA.Selenium;

namespace BUMBLEBEE.RuTube
{
    internal class RuTube_Operations
    {
        internal static void Login(Browser_Control BC)
        {

            BC.OpenUrl("https://rutube.ru/");

            IWebElement? loginButton = BC.FindWaitElement("//button[.//span[text()='Вход и регистрация']]");
            loginButton?.Click();

            IWebElement? iframe = BC.FindWaitElement("snake-popup"); // Suche nach dem Frame i ndem sich das Input Feld befindet
            BC.getWebDriver().SwitchTo().Frame(iframe); // Welche du dem Frame

            IWebElement? emailInputField = BC.FindWaitElement("phone-or-email-login");
            emailInputField?.SendKeys("kredobeats@gmail.com");

            IWebElement? loginContinieButton = BC.FindWaitElement("submit-login-continue");
            loginContinieButton?.Click();
            Thread.Sleep(3000);

            string code = ReadEmailCode.GetCodeFromEmail(BC);
                     
            string firstTabHandle = BC.getWebDriver().WindowHandles[0];        // Speichere den Handle des ersten Tabs (oder verwende WindowHandles[0] für den ersten Tab)
            BC.getWebDriver().SwitchTo().Window(firstTabHandle);               // Wechsel zurück zum ersten Tab

            BC.getWebDriver().SwitchTo().Frame(iframe); // Welche du dem Frame

            for (int i = 0; i < code.Length; i++)
            {
                string inputName = i.ToString(); // "0", "1", "2", "3"
                IWebElement? inputField = BC.FindWaitElement($"//input[@name='{inputName}']");
                inputField?.SendKeys(code[i].ToString()); // Füge die entsprechende Zahl ein
            }

            BC.getWebDriver().SwitchTo().DefaultContent(); // Zurück zu mHauptfenster wechseln

        }
    }
}
