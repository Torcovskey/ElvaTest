using System;
namespace TestGeo.GUI
{
    public static class GUIHelper
    {
        public static void GreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
