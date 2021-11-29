using Animescope.Anime;
using Animescope.Datacollect;
using Animescope.View.Control;
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

namespace Animescope.View
{
    /// <summary>
    /// ViewSuggestion.xaml 的交互逻辑
    /// </summary>
    public partial class ViewSuggestion : UserControl
    {
        public ViewSuggestion()
        {
            InitializeComponent();
        }

        public void UpdateListBox(List<AnimeEntry> entries)
        {
            AnimeList.UpdateSource(entries);
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text == "")
            {
                DataHandler.LoadSuggestionYHDM();
            }
            else
            {
                DataHandler.SearchYHDM(TextBox_Search.Text);
            }
            
        }
    }
}
