using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnD_number_share_idea
{

    public partial class assign_item : Window
    {
        private readonly List<Player> _players;
        private readonly Item _selecteditem;
        public Player SelectedPlayer { get; private set; }
        public assign_item(List<Player> players, Item selectedItem)
        {
            _players = players;
            
            _selecteditem = selectedItem;

            PlayersListBox.ItemsSource = _players;
            
            InitializeComponent();
        }

        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedPlayer = PlayersListBox.SelectedItem as Player;
            
            if (SelectedPlayer != null)
            {
                SelectedPlayer.Itemlist.Add(_selecteditem);
                this.DialogResult = true;
            }
        }
    }
}
