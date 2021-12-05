using Animescope.Anime;
using Animescope.Datacollect;
using LibVLCSharp.Shared;
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
using System.Windows.Shapes;
using MediaPlayer = LibVLCSharp.Shared.MediaPlayer;

namespace Animescope.View
{
    /// <summary>
    /// Player.xaml 的交互逻辑
    /// </summary>
    public partial class Player : Window
    {
        public Player(AnimeEntry animeEntry)
        {
            InitializeComponent();
            Core.Initialize();
            var libvlc = new LibVLC();
            var media = new Media(libvlc, new Uri(animeEntry.FindMedia("1")));
            var player = new MediaPlayer(media);
            VlcPlayer.MediaPlayer = player;
            player.Play();
        }
    }
}
