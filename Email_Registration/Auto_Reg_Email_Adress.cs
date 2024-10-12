using TextCopy;


namespace BUMBLEBEE
{
    internal static class Email_Registration
    {
        internal static void Run(Browser_Control BC)
        {
            BC.OpenUrl("https://app.tuta.com/");
            BC.SwitchToFirstTabAndCloseOthers();
            BC.FindWaitElement("//*[@id=\"login-view\"]/div[3]/div/div[1]/div[2]/button[1]")?.Click();
            BC.FindWaitElement("//*[@id=\"upgrade-account-dialog\"]/div/div[3]/div[1]/div[1]/div/div/div[5]/button")?.Click();
            BC.FindWaitElement("Ich besitze keinen anderen Free-Account.")?.Click();
            BC.FindWaitElement("Ich werde diesen Account nicht geschäftlich nutzen.")?.Click();
            BC.FindWaitElement("//*[@id=\"modal\"]/div[2]/div/div/div/div[3]/button[2]")?.Click();

            string email = Create_Email.Create(BC);
            string password = Create_Password.Create(BC);

            BC.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[3]/label")?.Click();
            BC.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[4]/label")?.Click();
            BC.FindWaitElement("//*[@id=\"signup-account-dialog\"]/div/div[5]/button")?.Click();
            BC.FindWaitElement("//button[@aria-label='Kopieren']")?.Click();
            string recovery_code = ClipboardService.GetText() ?? throw new Exception("Recovery Code not find.");

            string json_content = Export_To_Json.Conver_To_Json("email", "password", "recovery_code");
            Export_To_Json.WriteStringToFile(json_content, "!!!Path to Jason!!!");
        }


    }
}
