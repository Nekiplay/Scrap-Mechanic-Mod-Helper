using Newtonsoft.Json.Linq;
using Scrap_Mechanic_Mod_Helper.enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Scrap_Mechanic_Mod_Helper.data
{
    public class Item
    {
        public Item(string game)
        {
            this.gameDirectory = game;
        }
        private InventoryDescription GetInventoryDescriptionSurvival(string itemId, Language language)
        {
            string filePath = gameDirectory + @"\Survival\Gui\Language\" + language.ToString() + @"\inventoryDescriptions.json";
            string text = File.ReadAllText(filePath);
            JObject googleSearch = JObject.Parse(text);
            var itemT = googleSearch[itemId];
            if (itemT != null)
            {
                InventoryDescription inventoryDescription = new InventoryDescription();
                if (itemT["title"] != null)
                {
                    string title = itemT["title"].ToString();
                    inventoryDescription.Title = title;
                }
                if (itemT["description"] != null)
                {
                    string description = itemT["description"].ToString();
                    inventoryDescription.Description = description;
                }
                return inventoryDescription;
            }
            return null;
        }
        private InventoryDescription GetInventoryDescriptionCreative(string itemId, Language language)
        {
            string filePath = gameDirectory + @"\Data\Gui\Language\" + language.ToString() + @"\InventoryItemDescriptions.json";
            string text = File.ReadAllText(filePath);
            JObject googleSearch = JObject.Parse(text);
            var itemT = googleSearch[itemId];
            if (itemT != null)
            {
                InventoryDescription inventoryDescription = new InventoryDescription();
                if (itemT["title"] != null)
                {
                    string title = itemT["title"].ToString();
                    inventoryDescription.Title = title;
                }
                if (itemT["description"] != null)
                {
                    string description = itemT["description"].ToString();
                    inventoryDescription.Description = description;
                }
                return inventoryDescription;
            }
            return null;
        }
        public InventoryDescription GetInventoryLanguage(Language language)
        {
            var survival = GetInventoryDescriptionSurvival(Id, language);
            if (survival == null)
            {
                return GetInventoryDescriptionCreative(Id, language);
            }
            return survival;
        }

        public string ItemIdName;
        public string Id;

        private string gameDirectory;

        public static Item FromTitle(Scrap_Mechanic game, string title, Language language)
        {
            foreach (var item in game.itemParser.items)
            {
                InventoryDescription inventoryDescription = item.Value.GetInventoryLanguage(language);
                if (inventoryDescription != null && inventoryDescription.Title.Equals(title))
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}
