using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DnD_number_share_idea
{
    public class MainViewModel
    {
        public PlayerViewModel PlayerViewModel { get; set; }
        public NPCViewModel NPCViewModel { get; set; }
        public NoteViewModel NoteViewModel { get; set; }

        public MainViewModel()
        {
            PlayerViewModel = new PlayerViewModel();
            NPCViewModel = new NPCViewModel();
            NoteViewModel = new NoteViewModel();
        }

        // Add any application-wide logic or methods needed
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

        public PlayerViewModel()
        {
            Players = new ObservableCollection<Player>();
            AddPlayer(new Player("John Doe", "Eldrin", "Wizard", 5, 10, 14, 15, 18, 12, 10, "Quick learner"));
        }

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

