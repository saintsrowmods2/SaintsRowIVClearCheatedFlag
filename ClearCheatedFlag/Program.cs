using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThomasJepp.SaintsRow.Saves.SaintsRowIVMod;

namespace ClearCheatedFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: ClearCheatedFlag <filename>");
                return;
            }

            string filename = args[0];

            SaveFile file = null;

            using (Stream s = File.OpenRead(filename))
            {
                file = new SaveFile(s);
            }

            file.Player.HasCheated = false;
            Section cheatSection = file.Sections[SectionId.GSSI_CHEATS];
            cheatSection.Data[0] = 0;

            using (Stream s = File.Create(filename))
            {
                file.Save(s);
            }
        }
    }
}
