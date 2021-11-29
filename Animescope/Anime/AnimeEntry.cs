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
        public string Labels { get; set; }
        public string State { get; set; }
        public string PicURL { get; set; }
        public string Link { get; set; }
        public string ID { get; set; }

        public static AnimeEntry FromTopHtml(HtmlNode node) {
            return new AnimeEntry()
            {
                Title = node.SelectSingleNode("./h2").InnerText,
                Description = Regex.Replace(node.SelectSingleNode("./p").InnerText, "&.*?;", ""),
                State = node.SelectSingleNode("./span[1]").InnerText,
                Labels = node.SelectSingleNode("./span[2]").InnerText,
                PicURL = node.SelectSingleNode("./a/img").Attributes["src"].Value,
                Link = node.SelectSingleNode("./a").Attributes["href"].Value,
                ID = Regex.Match(node.SelectSingleNode("./a").Attributes["href"].Value, @"/\d+/g").Value
            };
        }
    }
}
