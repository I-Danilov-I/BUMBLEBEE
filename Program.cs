namespace BUMBLEBEE
{
    internal static class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Browser_Control IBC = new();
            
            AutoGiftCode.Start(IBC);
               
            //RuTube_Operations.Login(BC);            
        }
    }
}