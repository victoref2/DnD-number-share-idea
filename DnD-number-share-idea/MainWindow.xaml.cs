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
using System.Collections.ObjectModel;

namespace DnD_number_share_idea
{


    public class SessionData
    {
        public ObservableCollection<Player> Players { get; set; } = new ObservableCollection<Player>();
        public ObservableCollection<NPC> NPCs { get; set; } = new ObservableCollection<NPC>();
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        // Additional properties as needed, e.g., session date, etc.
    }


    public partial class MainWindow : Window
    {
        public string currentSessionFilePath;
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentSessionFilePath) && this.DataContext is SessionData sessionData)
            {
                string json = JsonConvert.SerializeObject(sessionData, Formatting.Indented);
                File.WriteAllText(currentSessionFilePath, json);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            // Initialize your main view model or session data here
            this.DataContext = new MainViewModel();
        }

        // Event handler for the Load button
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Load D&D Session"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                currentSessionFilePath = openFileDialog.FileName;
                LoadSessionData(openFileDialog.FileName);
            }
        }


        private void LoadSessionData(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var sessionData = JsonConvert.DeserializeObject<SessionData>(json);
                var openedTxtWindow = new Openedtxt();
                openedTxtWindow.DataContext = sessionData; // Set DataContext to the loaded session
                openedTxtWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load session data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                currentSessionFilePath = saveFileDialog.FileName;

            }

        }

        private void CreateNewSession(string filePath)
        {
            var sessionData = new SessionData
            {
                // Initialize with default or empty data as needed
            };

            string json = JsonConvert.SerializeObject(sessionData, Formatting.Indented);
            File.WriteAllText(filePath, json);

            currentSessionFilePath = filePath;
            LoadSessionData(filePath); // Load the new session data into the application
        }

    }
}
