using OpenQA.Selenium;

namespace BUMBLEBEE
{
    internal class Create_Password
    {
        private static string password = "Tolibasik-77";


        internal static string Create(Brwoser_Control BC)
        {
            while (true)
            {
                IWebElement? password_field = BC?.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[2]/div[1]/div/div/div/div[1]/input");
                password_field?.SendKeys(Keys.Control + "a");
                password_field?.SendKeys(Keys.Delete);
                password_field?.Click();
                password_field?.SendKeys(password); // PASSWORD DONT MUST BE HARD CODET  AND CAN BE RANDOM!!!
                password_field?.SendKeys(Keys.Tab);

                IWebElement? passwordWarning = BC?.FindWaitElement("//div[@class='flex items-center']//div[contains(@style, 'border: 1px solid rgb(112, 112, 112); width: 100px; height: 10px;')]");
                if (passwordWarning?.Text.Trim().Equals("Passwort ok.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Tools.Print($"First password: {passwordWarning?.Text}", ConsoleColor.Green);
                }
                else
                {
                    Tools.Print($"First password: {passwordWarning?.Text}", ConsoleColor.Yellow);
                }


                IWebElement? password_field_replay = BC?.FindWaitElement("//input[@aria-label='Passwort wiederholen']");
                password_field_replay?.SendKeys(Keys.Control + "a");
                password_field_replay?.SendKeys(Keys.Delete);
                password_field_replay?.Click();
                password_field_replay?.SendKeys(password);
                IWebElement? second_passwort_warning = BC?.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[2]/div[2]/small");
                if (second_passwort_warning?.Text.Equals("Passwort ok.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Tools.Print($"Second password: {second_passwort_warning.Text}", ConsoleColor.Green);
                    return password;
                }
                else
                {
                    Tools.Print($"Second password: {second_passwort_warning?.Text}", ConsoleColor.Yellow);
                }

            }
        }
    }
}
