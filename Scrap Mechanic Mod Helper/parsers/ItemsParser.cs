using Newtonsoft.Json.Linq;
using Scrap_Mechanic_Mod_Helper.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scrap_Mechanic_Mod_Helper.parsers
{
    public class ItemsParser
    {
        public readonly Dictionary<string, Item> items = new Dictionary<string, Item>();
        private string game;
        public ItemsParser(Scrap_Mechanic scrap)
        {
            game = scrap.gameDirectory;
            string filePath = game + @"\Survival\Scripts\game\survival_items.lua";
            Console.WriteLine(filePath);
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var item = parseLine(line);
                if (item != null)
                {
                    items.Add(item.Id, item);
                }
            }
        }

        private Item parseLine(string line)
        {
            Match match = Regex.Match(line, "(.*)=.*new(.*)");
            if (match.Success)
            {
                string id = match.Groups[2].Value.Replace("(", "").Replace(")", "").Replace("\"", "").Trim();
                string name = match.Groups[1].Value.Trim();
                Item item = new Item(game);
                item.Id = id;
                item.ItemIdName = name;
                return item;
            }
            return null;
        }
    }
}
