using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_number_share_idea
{
    public class Player
    {
        public string Name { get; set; }
        public string CharacterName { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int Str { get; set; }
        public int dex { get; set; }
        public int con { get; set; }
        public int Int { get; set; }
        public int wis { get; set; }
        public int cha { get; set; }
        public string Notes { get; set; }

        // Constructor for easy instantiation
        public Player(string name, string characterName, string playerClass, int level, int str, int Dex, int Con, int INt,int Wis, int Cha, String Featsbonus)
        {
            Name = name;
            CharacterName = characterName;
            Class = playerClass;
            Level = level;
            Str = str;
            dex = Dex;
            con = Con;
            Int = INt;
            wis = Wis;
            cha = Cha;
            Notes = Featsbonus;
        }
    }

}
