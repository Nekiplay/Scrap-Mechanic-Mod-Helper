using Scrap_Mechanic_Mod_Helper.parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrap_Mechanic_Mod_Helper
{
    public class Scrap_Mechanic
    {
        public ItemsParser itemParser;
        public CraftbotParser craftbotParser;

        public string gameDirectory;
        public Scrap_Mechanic(string gameDirectory)
        {
            Starup(gameDirectory);
        }
        public Scrap_Mechanic(DirectoryInfo gameDirectory)
        {
            Starup(gameDirectory.FullName);
        }
        private void Starup(string gameDirectory)
        {
            this.gameDirectory = gameDirectory;
            itemParser = new ItemsParser(this);
            craftbotParser = new CraftbotParser(this);
        }
    }
}
