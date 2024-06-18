/*
using OpenQA.Selenium;


namespace BUBLEBEE
{
    internal class Google_Operations
    {
        public static bool Login(IWebDriver driver, string userEmail, string password)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.google.de/");

                IWebElement? buttonLogin = Tools.Wait(driver, By.XPath("//span[text()='Anmelden']"), "Login");
                buttonLogin?.Click();

                IWebElement? loginMail = Tools.Wait(driver, By.Id("identifierId"), "E-Mail input");
                loginMail?.SendKeys(userEmail);
                loginMail?.SendKeys(Keys.Enter);

                Tools.RandomSleep(10, 20);
                IWebElement? loginPassword = Tools.Wait(driver, By.Name("Passwd"), "Passwort input");
                loginPassword?.SendKeys(password);
                loginPassword?.SendKeys(Keys.Enter);

                try
                {
                    IWebElement? nichtJetzt = Tools.Wait(driver, By.XPath("//span[text()='Nicht jetzt']"), "Nicht Jetzt");
                    nichtJetzt?.Click();
                }
                catch { }

                IWebElement? checkLogin = Tools.Wait(driver, By.CssSelector("a[aria-label*='Google-Konto']"), "Check Login");
                if (checkLogin != null)
                {
                    Thread.Sleep(1000);
                    string ariaLabel = checkLogin.GetAttribute("aria-label");
                    if (ariaLabel.Contains(userEmail))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Tools.Print($"[LOG]> {ex.Message}", ConsoleColor.Red);
                return false;
            }
        }
    }
}
*/