using System;
using System.Linq;
using System.Windows;

namespace DnD_number_share_idea
{
    public partial class Spell_maker : Window
    {
        public Spell NewSpell { get; private set; }

        public Spell_maker()
        {
            InitializeComponent();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            NewSpell = new Spell
            {
                Name = NameTextBox.Text,
                Level = int.TryParse(LevelTextBox.Text, out int level) ? level : 0,
                casting_time = Casting_time.Text,
                duration = Duration.Text,
                Range = RangeTextBox.Text,
                Damage = DamageTextBox.Text,
                Components = ComponentsTextBox.Text,
                Description = DescriptionTextBox.Text
            };
            this.DialogResult = true;
            this.Close();
        }
    }
}
