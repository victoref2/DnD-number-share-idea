using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DnD_number_share_idea
{
    public class Player : INotifyPropertyChanged
    {
        private string name;
        private string characterName;
        private string playerClass;
        private int level;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string CharacterName
        {
            get => characterName;
            set
            {
                characterName = value;
                OnPropertyChanged(nameof(CharacterName));
            }
        }
        public string PlayerClass
        {
            get => playerClass;
            set
            {
                playerClass = value;
                OnPropertyChanged(nameof(PlayerClass));
            }
        }
        private int str;
        public int Str
        {
            get => str;
            set
            {
                str = value;
                OnPropertyChanged(nameof(Str));
            }
        }

        private int dex; // Adjust naming convention to Dex for consistency
        public int Dex
        {
            get => dex;
            set
            {
                dex = value;
                OnPropertyChanged(nameof(Dex));
            }
        }

        private int con; // Adjust naming convention to Con for consistency
        public int Con
        {
            get => con;
            set
            {
                con = value;
                OnPropertyChanged(nameof(Con));
            }
        }

        private int intelligence; // Already correctly named
        public int Int
        {
            get => intelligence;
            set
            {
                intelligence = value;
                OnPropertyChanged(nameof(Int));
            }
        }

        private int wis; // Adjust naming convention to Wis for consistency
        public int Wis
        {
            get => wis;
            set
            {
                wis = value;
                OnPropertyChanged(nameof(Wis));
            }
        }

        private int cha; // Adjust naming convention to Cha for consistency
        public int Cha
        {
            get => cha;
            set
            {
                cha = value;
                OnPropertyChanged(nameof(Cha));
            }
        }

        public int Level
        {
            get => level;
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        private string notes;
        public string Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        // Constructor for easy instantiation
        public Player(string name, string characterName, string playerClass, int level, int str, int Dex, int Con, int INt,int Wis, int Cha, String Featsbonus)
        {
            Name = name;
            CharacterName = characterName;
            PlayerClass = playerClass;
            Level = level;
            Str = str;
            dex = Dex;
            con = Con;
            Int = INt;
            wis = Wis;
            cha = Cha;
            notes = Featsbonus;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
