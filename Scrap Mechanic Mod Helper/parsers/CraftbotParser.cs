using Newtonsoft.Json;
using Scrap_Mechanic_Mod_Helper.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scrap_Mechanic_Mod_Helper.parsers.CraftbotParser;

namespace Scrap_Mechanic_Mod_Helper.parsers
{
    public class CraftbotParser
    {
        public readonly List<Craft> crafts = new List<Craft>();
        public CraftbotParser(Scrap_Mechanic scrap)
        {
            string path = scrap.gameDirectory + "\\Survival\\CraftingRecipes\\craftbot.json";
            string json = File.ReadAllText(path);
            List<CraftRaw> craftsRaw = JsonConvert.DeserializeObject<List<CraftRaw>>(json);
            Console.WriteLine(craftsRaw.Count);
            foreach (var rawCraft in craftsRaw)
            {
                Craft craft = new Craft();
                craft.ingredientList = new List<IngredientList>();
                craft.extras = new List<Extra>();
                craft.quantity = rawCraft.quantity;
                craft.craftTime = rawCraft.craftTime;
                craft.item = scrap.itemParser.items[rawCraft.itemId];

                foreach (var rawIngredient in rawCraft.ingredientList)
                {
                    IngredientList ingredientList = new IngredientList();
                    ingredientList.quantity = rawIngredient.quantity;
                    ingredientList.item = scrap.itemParser.items[rawIngredient.itemId];
                    craft.ingredientList.Add(ingredientList);
                }

                if (rawCraft.extras != null)
                {
                    foreach (var rawExtreas in rawCraft.extras)
                    {
                        Extra ingredientList = new Extra();
                        ingredientList.quantity = rawExtreas.quantity;
                        ingredientList.item = scrap.itemParser.items[rawExtreas.itemId];
                        craft.extras.Add(ingredientList);
                    }
                }

                crafts.Add(craft);

            }
            Console.WriteLine(crafts.Count);
        }
        public class ExtraRaw
        {
            public string itemId { get; set; }
            public int quantity { get; set; }
        }

        public class IngredientListRaw
        {
            public int quantity { get; set; }
            public string itemId { get; set; }
        }

        public class CraftRaw
        {
            public string itemId { get; set; }
            public int quantity { get; set; }
            public int craftTime { get; set; }
            public List<IngredientListRaw> ingredientList { get; set; }
            public List<ExtraRaw> extras { get; set; }
        }

        #region Non raw
        public class Extra
        {
            public Item item { get; set; }
            public int quantity { get; set; }
        }

        public class IngredientList
        {
            public int quantity { get; set; }
            public Item item { get; set; }
        }

        public class Craft
        {
            public Item item { get; set; }
            public int quantity { get; set; }
            public int craftTime { get; set; }
            public List<IngredientList> ingredientList { get; set; }
            public List<Extra> extras { get; set; }
        }
        #endregion
    }
}
