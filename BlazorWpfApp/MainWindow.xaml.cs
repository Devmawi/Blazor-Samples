using BlazorWpfApp.BlazorApp;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlazorWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppState _appState = new();
        public MainWindow()
        {
            var services1 = new ServiceCollection();
            services1.AddBlazorWebView();
            services1.AddSingleton<AppState>(_appState);
            Resources.Add("services1", services1.BuildServiceProvider());

            InitializeComponent();
        }
    }

  
}
