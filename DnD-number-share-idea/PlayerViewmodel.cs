using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DnD_number_share_idea
{
    public class PlayerViewModel
    {
        public ObservableCollection<Player> Players { get; set; }

        public PlayerViewModel()
        {
            Players = new ObservableCollection<Player>();
            // Optionally, add some default players for testing
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

