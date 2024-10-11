namespace BUMBLEBEE
{
    internal static class Program
    {
        private static void Main()
        {
            Brwoser_Control BC = new();
            // Google_Operations.Login(BC, "kredobeats@gmail.com", "tolibasik-77");
            RuTube_Operations.Login(BC);
        }
    }
}