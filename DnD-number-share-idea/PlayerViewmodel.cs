using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace DnD_number_share_idea
{
        public class SessionData : INotifyPropertyChanged
        {

            private ObservableCollection<Player> _players = new ObservableCollection<Player>();
            public ObservableCollection<Player> Players
            {
                get => _players;
                set
                {
                    _players = value;
                    OnPropertyChanged(nameof(Players));
                }
            }

            private ObservableCollection<NPC> _npcs = new ObservableCollection<NPC>();
            public ObservableCollection<NPC> NPCs
            {
                get => _npcs;
                set
                {
                    _npcs = value;
                    OnPropertyChanged(nameof(NPCs));
                }
            }

            private ObservableCollection<Item> _items = new ObservableCollection<Item>();
            public ObservableCollection<Item> Items
            {
                get => _items;
                set { _items = value; OnPropertyChanged(nameof(Items)); }
            }   

            private ObservableCollection<Note> _notes = new ObservableCollection<Note>();
            public ObservableCollection<Note> Notes
            {
                get => _notes;
                set
                {
                    _notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
            private ObservableCollection<Spell> _spells = new ObservableCollection<Spell>();
            public ObservableCollection<Spell> Spells
            {
                get => _spells;
                set
                {
                    _spells = value;
                    OnPropertyChanged(nameof(Spells));
                }
            }

        public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }
        
    public class MainViewModel : INotifyPropertyChanged
    {
        public SessionData SessionData { get; set; } = new SessionData();
        public ObservableCollection<Player> Players => SessionData.Players;

        
        public ObservableCollection<NPC> NPCs => SessionData.NPCs;
        public ObservableCollection<Note> Notes => SessionData.Notes;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Spell> Spells => SessionData.Spells;

        public void AddSpell(Spell spell)
        {
            Spells.Add(spell);
        }

        public void RemoveSpell(Spell spell)
        {
                Spells.Remove(spell);
        }

        public ICommand ToggleDetailsCommand { get; private set; }

        public MainViewModel()
        {
            ToggleDetailsCommand = new RelayCommand(ToggleDetails);
            
        }

        private void ToggleDetails(object parameter)
        {
            if (parameter is Player player)
            {
                player.DetailsVisibility = player.DetailsVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        

    }



    public class NPCViewModel
    {
        public ObservableCollection<NPC> NPCs { get; set; }

        public NPCViewModel()
        {
            NPCs = new ObservableCollection<NPC>();
            // Optionally, initialize with some default NPCs
        }
        public void AddNPC(NPC nPC)
        {
            NPCs.Add(nPC);
        }

        public void RemovePlayer(NPC nPC)
        {
            NPCs.Remove(nPC);
        }
        // Add methods to add, remove, or update NPCs as needed


    }

    public class NoteViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }

        public NoteViewModel()
        {
            Notes = new ObservableCollection<Note>();
            // Optionally, initialize with some default notes
        }
        public void AddPlayer(Note note)
        {
            Notes.Add(note);
        }

        public void RemovePlayer(Note note)
        {
            Notes.Remove(note);
        }
        // Add methods to add, remove, or update notes as needed
    }
    public class PlayerViewModel
    {
        public ObservableCollection<Player> Players { get; set; }

        

        public void AddPlayer(Player player)
        {
            Players.Add(player);

        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}

