namespace BUMBLEBEE
{
    internal class Odnoklasniki
    {
        private string user_email;
        private string user_password;
        private string url;


        internal Odnoklasniki(string user_email, string user_password)
        {
            url = "https://ok.ru/";
            this.user_email = user_email;
            this.user_password = user_password;
        }

        internal void Run(Brwoser_Control BC)
        {
            Login(BC);
            Navigate(BC);
        }

        private void Login(Brwoser_Control BC)
        {
            try {BC.OpenUrl(url); }catch (Exception ex){Console.WriteLine(ex.Message);}
            try {BC.FindWaitElement("field_email")?.SendKeys(user_email); }catch (Exception ex){Console.WriteLine(ex.Message);}
            try {BC.FindWaitElement("field_password")?.SendKeys(user_password); }catch(Exception ex) { Console.WriteLine(ex.Message);}
        }

        private void Navigate(Brwoser_Control BC)
        {
            try { BC.FindWaitElement("   ")?.SendKeys(user_email); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { BC.FindWaitElement("   ")?.SendKeys(user_password); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
