using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal class Google_Operations
    {
        public static bool Login(Brwoser_Control browser, string userEmail, string password)
        {
            try
            {
                browser.OpenUrl("https://www.google.de/");
                IWebElement? buttonLogin = browser.FindWaitElement("//a[@aria-label='Anmelden']");
                buttonLogin?.Click();

                IWebElement? loginMail = browser.FindWaitElement("identifierId");
                loginMail?.SendKeys(userEmail);
                loginMail?.SendKeys(Keys.Enter);


                IWebElement? loginPassword = browser.FindWaitElement("Passwd");
                loginPassword?.SendKeys(password);
                loginPassword?.SendKeys(Keys.Enter);

                try
                {
                    IWebElement? nichtJetzt = browser.FindWaitElement("Nicht jetzt");
                    nichtJetzt?.Click();
                }
                catch { }

                IWebElement? checkLogin = browser.FindWaitElement("a[aria-label*='Google-Konto']");
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
                Console.WriteLine($"[LOG]> {ex.Message}");
                return false;
            }
        }
    }
}
