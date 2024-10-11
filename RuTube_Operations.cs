using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace BUMBLEBEE
{
    internal class RuTube_Operations
    {
        internal static void Login(Brwoser_Control BC)
        {
            BC.OpenUrl("https://rutube.ru/");

            IWebElement? loginButton = BC.FindWaitElement("//button[.//span[text()='Вход и регистрация']]");
            loginButton?.Click();

            IWebElement? iframe = BC.FindWaitElement("snake-popup"); // Suche nach dem Frame i ndem sich das Input Feld befindet
            BC.getWebDriver().SwitchTo().Frame(iframe); // Welche du dem Frame

            IWebElement? emailInputField = BC.FindWaitElement("phone-or-email-login");
            emailInputField?.SendKeys("YEsasawef");
        }
    }
}
