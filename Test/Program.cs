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
            Language language = Language.Russian;
            Scrap_Mechanic game = new Scrap_Mechanic("C:\\Scrap Mechanic");
            Item item = Item.FromTitle(game, "Электроплата", language);
            Console.WriteLine(item.Id);
            //foreach (var craft in game.craftbotParser.crafts)
            //{
            //    InventoryDescription inventoryDescription = craft.item.GetInventoryLanguage(language);
            //    if (inventoryDescription != null)
            //    {
            //        Console.WriteLine("==================");
            //        Console.WriteLine("Рецепт придмета: " + inventoryDescription.Title);
            //        Console.WriteLine("Количество: " + craft.quantity);
            //        Console.WriteLine("Время изготовления: " + craft.craftTime + "s");
            //        Console.WriteLine("Ингридиенты:");
            //        foreach (var ingridient in craft.ingredientList)
            //        {
            //            Console.WriteLine("\tПридмет: " + ingridient.item.GetInventoryLanguage(language).Title);
            //            Console.WriteLine("\tКоличество: " + ingridient.quantity);
            //        }
            //    }
            //}
            Console.ReadKey();
        }
    }
}
