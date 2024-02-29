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
            AddPlayer(new Player("John Doe", "Eldrin", "Wizard", 5, 10, 14, 15, 18, 12, 10, "Quick learner"));
            // Assuming DataContext is of type MainViewModel which contains Players collection
            var vm = DataContext as MainViewModel;
            vm?.Players.Add(new Player
            {
                Name = "New Player",
                CharacterName = "Unknown",
                CLass = "Class",
                Level = 1,
                            AddPlayer(new Player("John Doe", "Eldrin", "Wizard", 5, 10, 14, 15, 18, 12, 10, "Quick learner"));
                // Add other default properties as needed
            });
        }

        private void AddNewNPC_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            vm?.NPCs.Add(new NPC
            {
                NPCName = "New NPC",
                NPCDescription = "Description"
            });
        }

        private void AddNewNote_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            vm?.Notes.Add(new Note
            {
                Title = "New Note",
                Content = "Content"
            });
        }

    }
}
