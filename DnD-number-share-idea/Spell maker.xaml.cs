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
    /// Interaction logic for Spell_maker.xaml
    /// </summary>
    public partial class Spell_maker : Window
    {
        public Spell_maker()
        {
            InitializeComponent();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var spellName = SpellNameTextBox.Text;
            bool verbalComponent = VerbalComponentCheckBox.IsChecked ?? false;
            bool somaticComponent = SomaticComponentCheckBox.IsChecked ?? false;

            // Placeholder for collecting additional components
            List<string> additionalComponents = new List<string>();
            foreach (var child in AdditionalComponentsStackPanel.Children)
            {
                if (child is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    additionalComponents.Add(textBox.Text);
                }
            }
        }
    }
}