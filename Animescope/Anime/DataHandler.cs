using Animescope.Datacollect;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animescope.Anime
{
    public class DataHandler
    {
        public static readonly string URL = "http://www.yinghuacd.com/";
        public static readonly HtmlWeb WEB = new();
        public static void InitWeb()
        {
            WEB.AutoDetectEncoding = true;
            WEB.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.55 Safari/537.36 Edg/96.0.1054.43";
            WEB.UseCookies = true;
            WEB.CaptureRedirect = true;
        }
        public static void LoadSuggestionYHDM()
        {
            if (MainWindow.Instance != null)
            {
                Task.Factory.StartNew(() => {
                    var doc = WEB.LoadFromWebAsync(URL + "2021/", Encoding.UTF8).Result;
                    var list = doc.DocumentNode.SelectNodes("/html/body/div[4]/div[3]/div[1]/ul/li");
                    if (list != null) 
                    {
                        var entries = list.Select(node => AnimeEntry.FromTopHtml(node));
                        MainWindow.Instance.Dispatcher.Invoke(new Action(() => MainWindow.Instance.ViewSuggestion.UpdateListBox(entries.ToList())));
                    }
                });
            }
        }

        public static void SearchYHDM(string words)
        {
            if (MainWindow.Instance != null)
            {
                Task.Factory.StartNew(() => {
                    var doc = WEB.LoadFromWebAsync(URL + "search/" + words, Encoding.UTF8).Result;
                    var list = doc.DocumentNode.SelectNodes("/html/body/div[4]/div[2]/div/ul/li");
                    if (list != null)
                    {
                        var entries = list.Select(node => AnimeEntry.FromTopHtml(node));
                        MainWindow.Instance.Dispatcher.Invoke(new Action(() => MainWindow.Instance.ViewSuggestion.UpdateListBox(entries.ToList())));
                    }
                });
            }
        }
    }
}
