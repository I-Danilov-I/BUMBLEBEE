using BUMBLEBEE.RuTube;

namespace BUMBLEBEE
{
    internal static class Program
    {
        private static void Main()
        {
            Brwoser_Control BC = new();

            RuTube_Operations.Login(BC);
            
        }
    }
}