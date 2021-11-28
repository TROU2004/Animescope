using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animescope.Datacollect
{
    internal class AnimeEntry
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CreateMethods CreateMethod { get; private set; }
        public string Labels { get; set; }
        public string State { get; set; }
        public string PicURL { get; set; }

        private AnimeEntry() { }
        public static AnimeEntry FromTopHtml(HtmlNode node) {
            return new AnimeEntry()
            {
                CreateMethod = CreateMethods.TOP,
                Title = node.SelectSingleNode("./h2").InnerText,
                Description = node.SelectSingleNode("./p").InnerText,
                State = node.SelectSingleNode("./span[1]").InnerText,
                Labels = node.SelectSingleNode("./span[2]").InnerText,
                PicURL = node.SelectSingleNode("./a/img").Attributes["src"].Value,
            };
            
        }

        public enum CreateMethods { TOP }
    }
}
