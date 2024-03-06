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
                    sessionData: vm.SessionData,
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
            Spell_maker spellMakerWindow = new Spell_maker(_mainViewModel);
            spellMakerWindow.Closed += SpellMakerWindow_Closed;
            spellMakerWindow.ShowDialog();
        }
        private void SpellMakerWindow_Closed(object sender, EventArgs e)
        {

            SpellsDataGrid.Items.Refresh();


            if (sender is Spell_maker spellMakerWindow)
            {
                spellMakerWindow.Closed -= SpellMakerWindow_Closed;
            }
        }



    }


}

