using Animescope.Anime;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Animescope.Datacollect
{
    public class AnimeEntry
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionLarge { get; set; }
        public string Labels { get; set; }
        public string State { get; set; }
        public string PicURL { get; set; }
        public string Link { get; set; }
        public string ID { get; set; }
        public string Subtitle { get; set; }

        public static AnimeEntry FromTopHtml(HtmlNode node) {
            return new AnimeEntry()
            {
                Title = node.SelectSingleNode("./h2").InnerText,
                Description = Regex.Replace(node.SelectSingleNode("./p").InnerText, "&.*?;", ""),
                State = node.SelectSingleNode("./span[1]").InnerText,
                Labels = node.SelectSingleNode("./span[2]").InnerText,
                PicURL = node.SelectSingleNode("./a/img").Attributes["src"].Value,
                Link = node.SelectSingleNode("./a").Attributes["href"].Value,
                ID = Regex.Match(node.SelectSingleNode("./a").Attributes["href"].Value, "\\d+").Value
            };
        }

        public void Enrich(Action callback)
        {
            Task.Factory.StartNew(() => {
                var doc = DataHandler.WEB.LoadFromWebAsync($"{DataHandler.URL}show/{ID}.html", Encoding.UTF8).Result;
                var node = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div[2]");
                Subtitle = node.SelectSingleNode("./div[2]/div[2]/p[1]").InnerText ?? "";
                DescriptionLarge = Regex.Replace(node.SelectSingleNode("./div[7]").InnerText, "&.*?;", "");
                callback.Invoke();
            });
        }

        public string FindMedia(string path)
        {
            var doc = DataHandler.WEB.LoadFromWebAsync($"{DataHandler.URL}v/{ID}-{path}.html", Encoding.UTF8).Result;
            var node = doc.DocumentNode.SelectSingleNode("/html/body/div[4]/div/div").FirstChild;
            return node.Attributes["data-vid"].Value.Replace("$", ".");
        }
    }
}
