using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                    }
                }
            }
        }

        
        

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm == null) return;

            Item_maker itemMakerWindow = new Item_maker();
            var result = itemMakerWindow.ShowDialog();
            if (result == true)
            {
                Item newItem = itemMakerWindow.NewItem;
                if (newItem != null)
                {
                    vm.SessionData.Items.Add(newItem);
                    ItemsDataGrid.Items.Refresh(); 
                }
            }
        }

        private void AssignItemToPlayer_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm == null || ItemsDataGrid.SelectedItem == null) return;

            Item selectedItem = ItemsDataGrid.SelectedItem as Item;
            assign_item assignItemWindow = new assign_item(vm.Players.ToList(), selectedItem);

            if (assignItemWindow.ShowDialog() == true)
            {
                ItemsDataGrid.Items.Refresh();
            }
        }
        private void UnassignSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            // Assuming your button is within the same DataTemplate as your DataGrid
            var button = sender as Button;
            var stackPanel = button?.Parent as StackPanel;
            var dataGrid = stackPanel?.Children.OfType<DataGrid>().FirstOrDefault(dg => dg.Name == "ItemsDataGrid");

            if (dataGrid?.SelectedItem is Item selectedItem && button.DataContext is Player player)
            {
                player.UnassignItem(selectedItem);
                // Assuming you have some way to refresh or notify the UI to update
                (dataGrid.ItemsSource as ObservableCollection<Item>)?.Remove(selectedItem);
            }
        }

        private void UnassignSelectedSpell_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var stackPanel = button?.Parent as StackPanel;
            var dataGrid = stackPanel?.Children.OfType<DataGrid>().FirstOrDefault(dg => dg.Name == "ItemsDataGrid");

            if (dataGrid?.SelectedItem is Spell selectedspell && button.DataContext is Player player)
            {
                player.UnassignSpell(selectedspell);
                // Assuming you have some way to refresh or notify the UI to update
                (dataGrid.ItemsSource as ObservableCollection<Spell>)?.Remove(selectedspell);
            }
        }
        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Player player)
            {
                var viewModel = DataContext as MainViewModel;
                if (viewModel != null && viewModel.Players.Contains(player))
                {
                    viewModel.Players.Remove(player);
                    // Optional: Confirm deletion with the user before removing
                }
            }
        }
        private void DeleteNPC_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is NPC npc)
            {
                var viewModel = DataContext as MainViewModel;
                if (viewModel != null && viewModel.NPCs.Contains(npc))
                {
                    viewModel.NPCs.Remove(npc);
                    // Optional: Confirm deletion with the user before removing
                }
            }
        }
        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Note note)
            {
                var viewModel = DataContext as MainViewModel;
                if (viewModel != null && viewModel.Notes.Contains(note))
                {
                    viewModel.Notes.Remove(note);
                    // Optional: Confirm deletion with the user before removing
                }
            }
        }
        private void DeleteSelectedSpell_Click(object sender, RoutedEventArgs e)
        {
            var selectedSpell = SpellsDataGrid.SelectedItem as Spell;
            if (selectedSpell != null)
            {
                // Assuming Spells is an ObservableCollection in your ViewModel
                var vm = DataContext as MainViewModel;
                vm?.SessionData.Spells.Remove(selectedSpell);
            }
        }
        private void DeleteSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as Item;
            if (selectedItem != null)
            {
                // Assuming Items is an ObservableCollection in your ViewModel
                var vm = DataContext as MainViewModel;
                vm?.SessionData.Items.Remove(selectedItem);
            }
        }
    }
}