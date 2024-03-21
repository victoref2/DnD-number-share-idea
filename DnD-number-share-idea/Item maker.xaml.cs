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
    /// Interaction logic for Item_maker.xaml
    /// </summary>
    public partial class Item_maker : Window
    {
        public Item_maker()
        {
            InitializeComponent();
        }
        public Item NewItem { get; private set; }

        private void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new Item
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Quality = QualityTextBox.Text,
                Type = TypeTextBox.Text,
                Weight = double.TryParse(WeightTextBox.Text, out double weight) ? weight : 0,
                Damage = DamageTextBox.Text,
                Category = CategoryTextBox.Text
            };
                        
            this.DialogResult = true;
            this.Close();
        }

    }
}
