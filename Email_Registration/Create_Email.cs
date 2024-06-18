using OpenQA.Selenium;


namespace BUMBLEBEE
{
    internal class Create_Email
    {
        internal static string Create(Brwoser_Control BC)
        {
            int stringLong = 1;
            int count = 0;
            int count3 = 0;

            while (true)
            {
                Tools.Print($"\n________________________________________________________________", ConsoleColor.Magenta);
                if (count >= 3) { stringLong++; }
                if (count3 >= 7) { stringLong++; }

                string random_email = GenerateRandomString(stringLong);

                IWebElement? email_endet = BC?.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[1]/div/div/div/div[2]");
                Tools.Print($"Try: [{random_email}{email_endet?.Text}]", ConsoleColor.Blue);

                IWebElement? email_field = BC?.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[1]/div/div/div/div[1]/input");
                email_field?.SendKeys(Keys.Control + "a");
                email_field?.SendKeys(Keys.Delete);
                email_field?.Click();
                email_field?.SendKeys(random_email);

                IWebElement? warning_field = BC?.FindWaitElement("//*[@id='signup-account-dialog']/div/div[1]/small");
                if (warning_field?.Text.Trim().Equals("E-Mail-Adresse wird überprüft ...", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Tools.Print($"Warning field: {warning_field?.Text}", ConsoleColor.DarkYellow);
                    Thread.Sleep(5000);
                }
                if (warning_field?.Text.Trim().Equals("E-Mail-Adresse ist bereits vergeben.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    count3++;
                    Tools.Print($"Warning field: {warning_field?.Text}", ConsoleColor.Yellow);
                }
                if (warning_field?.Text.Trim().Equals("Ungültige E-Mail-Adresse.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    count++;
                    Tools.Print($"Warning field: {warning_field?.Text}", ConsoleColor.Yellow);
                }
                if (warning_field?.Text.Trim().Equals("E-Mail-Adresse ist verfügbar.", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Tools.Print($"Warning field: {warning_field?.Text}", ConsoleColor.Green);
                    return random_email;
                }
            }
        }


        internal static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
