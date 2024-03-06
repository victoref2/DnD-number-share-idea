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
    /// <summary>
    /// Interaction logic for AssignSpellWindow.xaml
    /// </summary>
    public partial class AssignSpellWindow : Window
    {
        private readonly List<Player> _players;
        private readonly Spell _selectedSpell;

        public Player SelectedPlayer { get; private set; }



        public AssignSpellWindow(List<Player> players, Spell selectedSpell)
        {
            InitializeComponent();
            _players = players;
            _selectedSpell = selectedSpell;

            PlayersListBox.ItemsSource = _players;
        }

        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedPlayer = PlayersListBox.SelectedItem as Player;
            if (SelectedPlayer != null)
            {
                SelectedPlayer.SpellIds.Add(_selectedSpell.Id);
                this.DialogResult = true;
            }
        }
    }

}
