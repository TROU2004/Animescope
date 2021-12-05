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

namespace Animescope.View
{
    /// <summary>
    /// ViewAnimeDetail.xaml 的交互逻辑
    /// </summary>
    public partial class ViewAnimeDetail : UserControl
    {
        public AnimeEntry AnimeEntry { get; set; }
        public ViewAnimeDetail(AnimeEntry animeEntry)
        {
            InitializeComponent();
            AnimeEntry = animeEntry;
            AnimeEntry.Enrich(() => {
                Dispatcher.Invoke(() => {
                    TextBlock_Description.Text = AnimeEntry.DescriptionLarge;
                    TextBlock_State.Text = AnimeEntry.State;
                    TextBlock_Subtitle.Text = AnimeEntry.Subtitle;
                    TextBlock_Title.Text = AnimeEntry.Title;
                    TextBlock_Labels.Text = AnimeEntry.Labels;
                    Image_Main.Source = new BitmapImage(new Uri(AnimeEntry.PicURL));
                });
            });
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Player(AnimeEntry).Show();
        }
    }
}
