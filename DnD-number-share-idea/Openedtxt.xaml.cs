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
            if (vm == null) return;

            Spell_maker spellMakerWindow = new Spell_maker();
            var result = spellMakerWindow.ShowDialog();
            if (result == true)
            {
                Spell newSpell = spellMakerWindow.NewSpell;
                if (newSpell != null)
                {
                    vm.SessionData.Spells.Add(newSpell);
                    SpellsDataGrid.Items.Refresh(); 
                }
            }
        }

        private void AssignSpellToPlayer_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                Spell selectedSpell = SpellsDataGrid.SelectedItem as Spell; 
                if (selectedSpell != null)
                {
                    var players = viewModel.Players.ToList();
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
            var button = sender as Button;
            var stackPanel = button?.Parent as StackPanel;
            var dataGrid = stackPanel?.Children.OfType<DataGrid>().FirstOrDefault(dg => dg.Name == "ItemsDataGrid");

            if (dataGrid?.SelectedItem is Item selectedItem && button.DataContext is Player player)
            {
                player.UnassignItem(selectedItem);
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
                }
            }
        }
        private void DeleteSelectedSpell_Click(object sender, RoutedEventArgs e)
        {
            var selectedSpell = SpellsDataGrid.SelectedItem as Spell;
            if (selectedSpell != null)
            {
                var vm = DataContext as MainViewModel;
                vm?.SessionData.Spells.Remove(selectedSpell);
            }
        }
        private void DeleteSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as Item;
            if (selectedItem != null)
            {
                var vm = DataContext as MainViewModel;
                vm?.SessionData.Items.Remove(selectedItem);
            }
        }
    }
}