using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DnD_number_share_idea
{
    public class SessionData
    {
        public ObservableCollection<Player> Players { get; set; } = new ObservableCollection<Player>();
        public ObservableCollection<NPC> NPCs { get; set; } = new ObservableCollection<NPC>();
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        // Additional properties as needed, e.g., session date, etc.
    }
    public class MainViewModel
    {
        public SessionData SessionData { get; set; } = new SessionData();
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

