using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal class Create_Password
    {
        // Methode zum Generieren eines zufälligen Passworts
        private static string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
            Random random = new Random();
            return new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal static string Create(Browser_Control BC)
        {
            string password = GenerateRandomPassword(12); // Generiere ein zufälliges Passwort mit 12 Zeichen

            while (true)
            {
                IWebElement? password_field = BC?.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[2]/div[1]/div/div/div/div[1]/input");
                password_field?.SendKeys(Keys.Control + "a");
                password_field?.SendKeys(Keys.Delete);
                password_field?.Click();
                password_field?.SendKeys(password); // Verwende das generierte Passwort
                password_field?.SendKeys(Keys.Tab);

                IWebElement? passwordWarning = BC?.FindWaitElement("//div[@class='flex items-center']//div[contains(@style, 'border: 1px solid rgb(112, 112, 112); width: 100px; height: 10px;')]");
                if (passwordWarning?.Text.Trim().Equals("Passwort ok.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine($"First password: {passwordWarning?.Text}");
                }
                else
                {
                    Console.WriteLine($"First password: {passwordWarning?.Text}");
                }

                IWebElement? password_field_replay = BC?.FindWaitElement("//input[@aria-label='Passwort wiederholen']");
                password_field_replay?.SendKeys(Keys.Control + "a");
                password_field_replay?.SendKeys(Keys.Delete);
                password_field_replay?.Click();
                password_field_replay?.SendKeys(password);
                IWebElement? second_passwort_warning = BC?.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[2]/div[2]/small");
                if (second_passwort_warning?.Text.Equals("Passwort ok.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine($"Second password: {second_passwort_warning.Text}");
                    return password;
                }
                else
                {
                    Console.WriteLine($"Second password: {second_passwort_warning?.Text}");
                }
            }
        }
    }
}
