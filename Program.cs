namespace BUMBLEBEE
{
    internal static class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Browser_Control BC = new();
            RuTube_Operations.Login(BC);            
        }
    }
}