using Animescope.Datacollect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Animescope.View.Control
{
    /// <summary>
    /// AnimeList.xaml 的交互逻辑
    /// </summary>
    public partial class AnimeList : UserControl
    {
        public AnimeList()
        {
            InitializeComponent();
        }

        public void UpdateSource(List<AnimeEntry> entries)
        {
            ListBox_Main.ItemsSource = entries;
        }
    }
}
