using Scrap_Mechanic_Mod_Helper;
using Scrap_Mechanic_Mod_Helper.data;
using Scrap_Mechanic_Mod_Helper.enums;
using Scrap_Mechanic_Mod_Helper.parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scrap_Mechanic game = new Scrap_Mechanic("C:\\Scrap Mechanic");
            foreach (var item in game.craftbotParser.crafts)
            {
                InventoryDescription inventoryDescription = item.item.GetInventoryLanguage(Language.English);
                if (inventoryDescription != null)
                {
                    Console.WriteLine("==================");
                    Console.WriteLine("Рецепт придмета: " + inventoryDescription.Title + " x" + item.quantity);
                    Console.WriteLine("Время изготовления: " + item.craftTime + "s");
                }
            }
            Console.ReadKey();
        }
    }
}
