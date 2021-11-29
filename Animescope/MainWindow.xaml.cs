using Animescope.Anime;
using Animescope.Datacollect;
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

namespace Animescope
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            DataHandler.LoadSuggestionYHDM();
        }

        private void Button_Suggestion(object sender, RoutedEventArgs e)
        {
            Transitioner_Main.SelectedIndex = 0;
        }

        private void Button_Following(object sender, RoutedEventArgs e)
        {
            Transitioner_Main.SelectedIndex = 1;
        }

        private void Button_History(object sender, RoutedEventArgs e)
        {
            Transitioner_Main.SelectedIndex = 2;
        }
    }
}
