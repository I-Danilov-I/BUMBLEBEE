using OpenQA.Selenium;
using System;
using System.IO;

namespace BUMBLEBEE.WOSurvivor
{
    internal class AutoGiftCode
    {
        public static void Start(Browser_Control IBC)
        {
            Console.WriteLine("Bitte geben Sie einmalig Ihre ID ein: ");
            string id_input = Console.ReadLine()!;
            Console.WriteLine("Bitte geben Sie einmalig Ihren Namen ein: ");
            string name_input = Console.ReadLine()!;

            string currentPath = Path.Combine(Directory.GetCurrentDirectory().Replace("bin\\Debug\\net8.0", ""));
            string fullPath = Path.Combine(currentPath, "WOSurvivor\\IDs.txt");
            string save = $"ID: {id_input}, Name: {name_input}";
            AppendIDToFile(fullPath, save);

            string gift_code = GetGiftCode(IBC);
            InputID(IBC, id_input);
            InputGiftCode(IBC, gift_code);
        }

        private static string GetGiftCode(Browser_Control IBC)
        {
            IBC.OpenUrl("https://lootbar.gg/blog/en/whiteout-survival-newest-codes.html");
            IWebDriver driver = IBC.GetWebDriver();

            IList<IWebElement> listItems = driver.FindElements(By.XPath("//ul/li"));
            foreach (var item in listItems)
            {
                string codeText = item.Text;
                if (!string.IsNullOrEmpty(codeText) && codeText.ToUpper().Contains("NEW"))
                {
                    string code = codeText.Substring(0, 12);
                    Console.WriteLine("Extrahierter Code: " + code);
                    return code;
                }
            }
            return null!;
        }

        private static void InputID(Browser_Control IBC, string id_input)
        {
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

        // Methode zum Anhängen der ID in einer Textdatei
        private static void AppendIDToFile(string filePath, string id)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {
                    sw.WriteLine(id);
                }
                Console.WriteLine("ID erfolgreich gespeichert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern der ID: " + ex.Message);
            }
        }
    }
}
