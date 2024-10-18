using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal static class ReadEmailCode
    {
        internal static string GetCodeFromEmail(Browser_Control BC)
        {
            BC.GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
            Google_Login.Login(BC, "kredobeats@gmail.com", "tolibasik-77");
            IWebDriver webdriver = BC.GetWebDriver();

            BC.OpenUrl("https://mail.google.com/");         
            IWebElement? emailTabelle =  BC.FindWaitElement("//table[@role='grid']");
            if (emailTabelle == null)
            {
                Console.WriteLine("Tabelle nicht gefunden!");
                return null!;
            }
            Thread.Sleep(10000);
            IList<IWebElement> emailListe = emailTabelle.FindElements(By.XPath("//tr[@role='row']"));
            foreach(IWebElement mail in emailListe)
            {

                // Entferne Leerzeichen und ignoriere Groß-/Kleinschreibung
                string mailText = mail.Text.Trim().ToUpper();
                Console.WriteLine(mailText);
                if (mailText.ToUpper().Contains("RUTUBE"))
                {
                    mail.Click();
                    break;
                }               
            }

            IWebElement code = BC.FindWaitElement("//div[@style=\"font-family:'Open Sans',Arial,sans-serif;color:#ffffff;font-size:17px;line-height:26px;font-weight:bold\"]") !;
            string confirmationCode = code.Text.Trim();

            Console.WriteLine($"Der Bestätigungscode lautet: {confirmationCode}");
            return confirmationCode;
        }
    }
}
