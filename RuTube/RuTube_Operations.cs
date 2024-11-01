﻿using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal class RuTube_Operations
    {
        internal static void Login(Browser_Control BC)
        {

            BC.OpenUrl("https://rutube.ru/");

            IWebElement? loginButton = BC.FindWaitElement("//button[.//span[text()='Вход и регистрация']]");
            loginButton?.Click();

            IWebElement? iframe = BC.FindWaitElement("snake-popup"); // Suche nach dem Frame i ndem sich das Input Feld befindet
            BC.GetWebDriver().SwitchTo().Frame(iframe); // Welche du dem Frame

            IWebElement? emailInputField = BC.FindWaitElement("phone-or-email-login");
            emailInputField?.SendKeys("kredobeats@gmail.com");

            IWebElement? loginContinieButton = BC.FindWaitElement("submit-login-continue");
            loginContinieButton?.Click();
            Thread.Sleep(5000);

            string code = ReadEmailCode.GetCodeFromEmail(BC);
                     
            string firstTabHandle = BC.GetWebDriver().WindowHandles[0];        // Speichere den Handle des ersten Tabs (oder verwende WindowHandles[0] für den ersten Tab)
            BC.GetWebDriver().SwitchTo().Window(firstTabHandle);               // Wechsel zurück zum ersten Tab
            Thread.Sleep(3000);
            BC.GetWebDriver().SwitchTo().Frame(iframe); // Welche du dem Frame
      
            for (int i = 0; i < code.Length; i++)
            {
                string inputName = i.ToString(); // "0", "1", "2", "3"
                IWebElement? inputField = BC.FindWaitElement($"//input[@name='{inputName}']");
                inputField?.SendKeys(code[i].ToString()); // Füge die entsprechende Zahl ein
            }

            BC.GetWebDriver().SwitchTo().DefaultContent(); // Zurück zu mHauptfenster wechseln

        }
    }
}
