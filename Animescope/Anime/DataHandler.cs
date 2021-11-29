using Animescope.Datacollect;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animescope.Anime
{
    internal class DataHandler
    {
        static readonly string URL = "http://www.yinghuacd.com/";
        public static void LoadSuggestionYHDM()
        {
            if (MainWindow.Instance != null)
            {
                Task.Factory.StartNew(() => {
                    var doc = new HtmlWeb().LoadFromWebAsync(URL + "2021/", Encoding.UTF8).Result;
                    var list = doc.DocumentNode.SelectNodes("/html/body/div[4]/div[3]/div[1]/ul/li");
                    var entries = list.Select(node => AnimeEntry.FromTopHtml(node));
                    MainWindow.Instance.Dispatcher.Invoke(new Action(() => MainWindow.Instance.ViewSuggestion.UpdateListBox(entries.ToList())));
                });
            }
        }

        public static void SearchYHDM(string words)
        {
            if (MainWindow.Instance != null)
            {
                Task.Factory.StartNew(() => {
                    var doc = new HtmlWeb().LoadFromWebAsync(URL + "search/" + words, Encoding.UTF8).Result;
                    var list = doc.DocumentNode.SelectNodes("/html/body/div[4]/div[2]/div/ul/li");
                    var entries = list.Select(node => AnimeEntry.FromTopHtml(node));
                    MainWindow.Instance.Dispatcher.Invoke(new Action(() => MainWindow.Instance.ViewSuggestion.UpdateListBox(entries.ToList())));
                });
            }
        }
    }
}
