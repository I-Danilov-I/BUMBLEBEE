namespace BUMBLEBEE
{
    internal static class Console_Output
    {
        internal static void Colorprint(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
