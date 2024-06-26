﻿using System;
using Microsoft.Win32;
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

    public partial class MainWindow : Window
    {
        public string currentSessionFilePath;
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentSessionFilePath))
            {
                var viewModel = this.DataContext as MainViewModel;
                if (viewModel != null)
                {
                    string json = JsonConvert.SerializeObject(viewModel.SessionData, Formatting.Indented);
                    File.WriteAllText(currentSessionFilePath, json);
                }
            }   
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            this.DataContext = new MainViewModel();
            Main_grid.Background = System.Windows.Media.Brushes.Black;
        }

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
            string json = File.ReadAllText(filePath);
            var sessionData = JsonConvert.DeserializeObject<SessionData>(json);

            var viewModel = this.DataContext as MainViewModel;
            if (viewModel != null && sessionData != null)
            {
                viewModel.SessionData = sessionData;
                Openedtxt openedTxtWindow = new Openedtxt();
                openedTxtWindow.DataContext = viewModel;
                openedTxtWindow.Show();
            }
        }
        
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
                
            };

            string json = JsonConvert.SerializeObject(sessionData, Formatting.Indented);
            File.WriteAllText(filePath, json);

            currentSessionFilePath = filePath;
            LoadSessionData(filePath); 
        }
        

    }
}
