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
    /// Interaction logic for Openedtxt.xaml
    /// this window is the Loaded info from the .json file or the new File made as a .Json
    /// </summary>
    public partial class Openedtxt : Window
    {
        public Openedtxt()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

        }

        private void AddNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                // Example of creating a new Player with default values for all constructor parameters
                Player newPlayer = new Player(
                    name: "New Player",
                    characterName: "Unknown Character",
                    CLass: "Class Placeholder",
                    maxHP: 10,
                    currentHP: 10,
                    level: 1,
                    str: 10,
                    Dex: 10,
                    Con: 10,
                    Int: 10,
                    Wis: 10,
                    Cha: 10,
                    pnotes: "Notes Placeholder"
                );
                vm.SessionData.Players.Add(newPlayer);
            }
        }



        private void AddNewNPC_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                vm.SessionData.NPCs.Add(new NPC
                {
                    NPCName = "New NPC",
                    NPCDescription = "Description"
                });
            }
        }

        private void AddNewNote_Click(object sender, RoutedEventArgs e)
        {
            // Assuming there's a similar method for adding a new Note
            // and the SessionData property in MainViewModel properly exposes the Notes collection
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                vm.SessionData.Notes.Add(new Note
                {
                    Title = "New Note",
                    Content = "Note content"
                });
            }
        }
        private void AddNewSpell_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm == null) return; // Guard clause to ensure vm is not null

            Spell_maker spellMakerWindow = new Spell_maker();
            // Remove the Closed event subscription, as we'll rely on ShowDialog result
            // spellMakerWindow.Closed += SpellMakerWindow_Closed;
            var result = spellMakerWindow.ShowDialog();
            if (result == true)
            {
                // Assuming NewSpell is a public property in Spell_maker that holds the newly created spell
                Spell newSpell = spellMakerWindow.NewSpell;
                if (newSpell != null)
                {
                    // Add the new spell to the session data and refresh the data grid
                    vm.SessionData.Spells.Add(newSpell);
                    SpellsDataGrid.Items.Refresh(); // Refresh the grid to show the new spell
                }
            }
        }

        // Removed SpellMakerWindow_Closed method as it's no longer needed with this approach



        private void AssignSpellToPlayer_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                // Assuming you have a way to get the selected spell from your UI, for example:
                Spell selectedSpell = SpellsDataGrid.SelectedItem as Spell; // Example for getting selected spell from a DataGrid
                if (selectedSpell != null)
                {
                    var players = viewModel.Players.ToList(); // Convert ObservableCollection to List
                    var assignSpellWindow = new AssignSpellWindow(players, selectedSpell);
                    bool? result = assignSpellWindow.ShowDialog();
                    if (result == true)
                    {
                        // If the dialog result is true, it means a spell was assigned. You may need to refresh your UI or perform other actions.
                        // For example, refresh a players list or details view if it displays spells for the selected player.
                        RefreshPlayersListOrDetailsView();
                    }
                }
            }
        }

        // This method is a placeholder for whatever mechanism you use to refresh your UI elements that display player details or spells.
        private void RefreshPlayersListOrDetailsView()
        {
            // Implementation depends on your specific UI

        }


    }
}

