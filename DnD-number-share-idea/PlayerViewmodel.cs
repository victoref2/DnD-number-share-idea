using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        public Spell FindSpellById(int id) => Spells.FirstOrDefault(spell => spell.Id == id);

        public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            

        }
    
    
        public class MainViewModel : INotifyPropertyChanged
        {
        public SessionData SessionData { get; set; } = new SessionData();

        // Assuming SessionData has ObservableCollection properties for Players, NPCs, and Notes
        public ObservableCollection<Player> Players => SessionData.Players;
        public ObservableCollection<NPC> NPCs => SessionData.NPCs;
        public ObservableCollection<Note> Notes => SessionData.Notes;

        public event PropertyChangedEventHandler PropertyChanged;


            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            


            public List<Spell> GetPlayerSpells(Player player) =>
                player.SpellIds.Select(id => SessionData.Spells.FirstOrDefault(s => s.Id == id)).Where(spell => spell != null).ToList();


            public void AddSpell(Spell spell)
            {
                SessionData.Spells.Add(spell);
                OnPropertyChanged(nameof(SessionData.Spells)); // This line might not be necessary since ObservableCollection already notifies on add/remove.
            }

            public void AssignSpellToPlayer(Player player, int spellId)
            {
                var spell = SessionData.Spells.FirstOrDefault(s => s.Id == spellId);
                if (spell != null && !player.SpellIds.Contains(spellId))
                {
                    player.SpellIds.Add(spellId);
                    // If your UI is directly bound to the Players collection and reflects changes in the SpellIds,
                    // you might need to explicitly notify that the player's data has changed.
                    OnPropertyChanged($"Players[{SessionData.Players.IndexOf(player)}]");
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
        
        
            private readonly SessionData _sessionData; // Assuming this is initialized elsewhere

            public PlayerViewModel(SessionData sessionData)
            {
                _sessionData = sessionData;
            }

            public IEnumerable<Spell> GetPlayerSpells(Player player)
            {
                return player.SpellIds.Select(id => _sessionData.FindSpellById(id)).Where(spell => spell != null);
            }
        

    }


}

