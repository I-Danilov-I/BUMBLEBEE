using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal class AutoGiftCode
    {

        public static void Start(Browser_Control IBC)
        {
            string gift_code = GetGiftCode(IBC);
            InputID(IBC);
            InputGiftCode(IBC, gift_code);
        }

        private static string GetGiftCode(Browser_Control IBC)
        {
            IBC.OpenUrl("https://lootbar.gg/blog/en/whiteout-survival-newest-codes.html");
            IWebDriver driver = IBC.GetWebDriver();

            // Alle <li>-Elemente auswählen
            IList<IWebElement> listItems = driver.FindElements(By.XPath("//ul/li"));

            // Schleife durch alle <li>-Elemente und extrahiere den Text
            foreach (var item in listItems)
            {
                string codeText = item.Text;
                if (!string.IsNullOrEmpty(codeText))
                {
                    if (codeText.ToUpper().Contains("NEW"))
                    {
                        Console.WriteLine("Code: " + codeText);

                        string code = codeText.Substring(0, 12);
                        Console.WriteLine(code);
                        return code;
                    }
                }
            }
            return null!;
        }

        private static void InputID(Browser_Control IBC)
        {
            Console.WriteLine("Bitte geben sie einmalig ihre ID ein: ");
            string id_input = Console.ReadLine()!;

            IBC.OpenUrl("https://wos-giftcode.centurygame.com/");

            IWebElement id = IBC.FindWaitElement("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[1]/div[1]/div[1]/input")!;
            id.SendKeys(id_input);

            IWebElement anmelden = IBC.FindWaitElement("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[1]/div[1]/div[2]/span")!;
            anmelden.Click();

        }

        private static void InputGiftCode(Browser_Control IBC, string gift_code)
        {
            IWebElement CodeFieldInput = IBC.FindWaitElement("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[2]/div[1]/input")!;
            CodeFieldInput.SendKeys(gift_code);

            IWebElement absenden = IBC.FindWaitElement("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[3]")!;
            absenden.Click();
        }

    }
}



