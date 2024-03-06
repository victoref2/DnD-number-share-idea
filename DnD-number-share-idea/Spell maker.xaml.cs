using System;
using System.Linq;
using System.Windows;

namespace DnD_number_share_idea
{
    /// <summary>
    /// Interaction logic for Spell_maker.xaml
    /// </summary>
    public partial class Spell_maker : Window
    {
        
        public Spell NewSpell { get; private set; } // Property to access the created spell

        private MainViewModel _mainViewModel;

        public Spell_maker(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Spell newSpell = new Spell(); // Populate spell details
            // Create the new Spell object
            newSpell = new Spell
            {
                // ID assignment is managed by the collection or upon addition
                Name = SpellNameTextBox.Text,
                Level = int.TryParse(SpellLevelTextBox.Text, out int level) ? level : 0,
                casting_time = CastingTimeTextBox.Text,
                duration = DurationTextBox.Text,
                Range = RangeTextBox.Text,
                Damage = DamageTextBox.Text,
                Components = ComponentsTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            
            _mainViewModel.AddSpell(newSpell);

            // Signal the dialog result as true and close the window
            this.DialogResult = true;
            this.Close();
        }
    }
}
