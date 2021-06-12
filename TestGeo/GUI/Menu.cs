using System;
using System.IO;
using TestGeo.Entity;

namespace TestGeo.GUI
{
    public class Menu
    {
        public void StartMenu()
        {
            
            GUIHelper.GreenText(File.ReadAllText(@".\GUI\StartMenu.txt"));
            string sity = Console.ReadLine().ToLower();
            GUIHelper.GreenText("Введи частоту точек: ");
            int pass = Convert.ToInt32(Console.ReadLine());
            GUIHelper.GreenText("Введи имя файла: ");
            string fileName = Console.ReadLine();
            GUIHelper.GreenText("Процесс пошел... \n");
            try
            {
                var osmMap = new OSM.OsmMap();
                SelectMapService(osmMap, sity, pass, fileName);
                Console.Clear();
                GUIHelper.GreenText(File.ReadAllText(@".\GUI\Success.txt"));
                Console.ReadLine();
            }
            catch
            {
                Console.Clear();
                GUIHelper.GreenText(File.ReadAllText(@".\GUI\Fail.txt"));
                Console.ReadKey();
                StartMenu();
            }
        }   
        private void SelectMapService (IMapService map, string sity, int pass, string fileName)
        {
            var info = map.GetInfo(sity);
            map.WriteCoordinateToFile(@$".\{fileName}.txt", info, pass);
        }
    }
}
