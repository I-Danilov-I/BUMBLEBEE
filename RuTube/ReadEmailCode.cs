using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal static class ReadEmailCode
    {
        internal static string GetCodeFromEmail(Brwoser_Control BC)
        {
            BC.getWebDriver().SwitchTo().NewWindow(WindowType.Tab);

            Google_Operations.Login(BC, "kredobeats@gmail.com", "tolibasik-77");
            IWebDriver webdriver = BC.getWebDriver();
            BC.OpenUrl("https://mail.google.com/");
            
            IWebElement? emailtabelle =  BC.FindWaitElement("//table[@role='grid']");
            Thread.Sleep(8000);
            IList<IWebElement?> emailListe = emailtabelle.FindElements(By.XPath("//tr[@role='row']"));
            foreach(IWebElement mail in emailListe)
            {
                mail.Click();
            }
            IWebElement? code = BC.FindWaitElement("//div[@style=\"font-family:'Open Sans',Arial,sans-serif;color:#ffffff;font-size:17px;line-height:26px;font-weight:bold\"]");
            string confirmationCode = code.Text.Trim();

        

            Console.WriteLine($"Der Bestätigungscode lautet: {confirmationCode}");
            return confirmationCode;
        }
    }
}
