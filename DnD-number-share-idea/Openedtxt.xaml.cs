﻿using System;
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
        

    }
}
