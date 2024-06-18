namespace BUMBLEBEE
{
    internal static class Program
    {
        private static void Main()
        {
            Brwoser_Control BC = new();
            Email_Registration.Run(BC);
            Odnoklasniki OK = new("maxmustermann@gmail.com", "123passefreregdg");
            OK.Run(BC);
        }
    }
}