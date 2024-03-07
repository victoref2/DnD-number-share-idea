using System;
using System.Linq;
using System.Windows;

namespace DnD_number_share_idea
{
    public partial class Spell_maker : Window
    {
        // Property to access the newly created spell
        public Spell NewSpell { get; private set; }

        public Spell_maker()
        {
            InitializeComponent();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Spell instance from input fields
            NewSpell = new Spell
            {
                // Assuming ID is auto-generated or not needed immediately
                Name = NameTextBox.Text,
                Level = int.TryParse(LevelTextBox.Text, out int level) ? level : 0,
                casting_time = Casting_time.Text,
                duration = Duration.Text,
                Range = RangeTextBox.Text,
                Damage = DamageTextBox.Text,
                Components = ComponentsTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            // Close the spell maker window
            this.DialogResult = true;
            this.Close();
        }
    }
}
