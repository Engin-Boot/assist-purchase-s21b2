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

namespace AssistToPurchase.View
{
    /// <summary>
    /// Interaction logic for ModelCatalogPage.xaml
    /// </summary>
    public partial class ModelCatalogPage : Page
    {
        ViewModel.ModelCatalogViewModel ModelCatalogViewModel = new ViewModel.ModelCatalogViewModel();
        public ModelCatalogPage()
        {
            InitializeComponent();
            this.DataContext = ModelCatalogViewModel;
        }
    }
}
