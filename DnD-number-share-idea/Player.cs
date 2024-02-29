using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
        private string Class;
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
        public string CLass
        {
            get => Class;
            set
            {
                Class = value;
                OnPropertyChanged(nameof(CLass));
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
        public Player(string name, string characterName, string Class, int level, int str, int Dex, int Con, int INt,int Wis, int Cha, String Featsbonus)
        {
            Name = name;
            CharacterName = characterName;
            Class = CLass;
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
