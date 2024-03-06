using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DnD_number_share_idea
{
    public class NPC : INotifyPropertyChanged
    {
        private string name;
        private string description;

        public string NPCName
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(NPCName));
            }
        }

        public string NPCDescription
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(NPCDescription));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Note : INotifyPropertyChanged
    {
        private string title;
        private string content;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
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
        public string PlayerClass // Corrected to match common naming conventions
        {
            get => playerClass;
            set
            {
                playerClass = value;
                OnPropertyChanged(nameof(PlayerClass)); // Changed to "PlayerClass"
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
        public int INt
        {
            get => intelligence;
            set
            {
                intelligence = value;
                OnPropertyChanged(nameof(INt));
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
        private string pnotes;
        public string Pnotes // Renamed from 'Notes' to 'Pnotes'
        {
            get => pnotes;
            set
            {
                pnotes = value;
                OnPropertyChanged(nameof(Pnotes)); // Reflect the property name change
            }
        }
        private int _currentHP;
        public int CurrentHP
        {
            get => _currentHP;
            set
            {
                _currentHP = value;
                OnPropertyChanged(nameof(CurrentHP));
            }
        }

        private int _maxHP;
        public int MaxHP
        {
            get => _maxHP;
            set
            {
                _maxHP = value;
                OnPropertyChanged(nameof(MaxHP));
            }
        }
        private List<int> spellIds = new List<int>();
        public List<int> SpellIds
        {
            get => spellIds;
            set
            {
                spellIds = value;
                OnPropertyChanged(nameof(SpellIds));
            }
        }
        // Constructor for easy instantiation


        


        public Player(string name, string characterName, string CLass, int level, int str, int Dex, int Con, int Int,int Wis, int Cha, String pnotes, int currentHP, int maxHP)
        {
            Name = name;
            CharacterName = characterName;
            PlayerClass = CLass;
            Level = level;
            CurrentHP = currentHP;
            MaxHP = maxHP;
            Str = str;
            dex = Dex;
            con = Con;
            INt = Int;
            wis = Wis;
            cha = Cha;
            Pnotes = pnotes;

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        

    }


}
