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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntitiesLayer;
using JediTournamentWPF.ViewModel;

namespace JediTournamentWPF.UserControls {
    /// <summary>
    /// Logique d'interaction pour JediReadUserControl.xaml
    /// </summary>
    public partial class JediReadUserControl : UserControl {

        public JediReadUserControl() {
            InitializeComponent();
        }

        public JediReadUserControl(JediViewModel jvm)
        {
            InitializeComponent();
            DataContext = jvm;
        }
    }
}
