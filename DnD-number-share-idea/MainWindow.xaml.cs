using System;
using Microsoft.Win32; // Add this for OpenFileDialog
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnD_number_share_idea
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Load button
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*", // Filters to only show JSON files or all files
                Title = "Load D&D Session"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Here, you would add your logic to handle the file.
                // For example, loading the JSON data into your application.
                MessageBox.Show($"Loading: {openFileDialog.FileName}", "File Loaded");
            }
        }

        // Event handler for the New button
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Save New D&D Session"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                CreateNewSession(saveFileDialog.FileName);
                var openedTxtWindow = new Openedtxt();
                openedTxtWindow.Show();

            }

        }

        private void CreateNewSession(string filePath)
        {
            // Example session data structure
            var sessionData = new
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Notes = "",
                Players = new object[] { }, // Empty array, to be filled with player data
                NPCs = new object[] { } // Empty array, for NPC data
            };

            string json = JsonConvert.SerializeObject(sessionData, Formatting.Indented);
            File.WriteAllText(filePath, json);

            MessageBox.Show($"New session created at: {filePath}", "Session Created");
        }
    }
}
