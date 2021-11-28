using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animescope.Datacollect
{
    internal class DataSourceYHDM
    {
        static readonly string URL = "http://www.yinghuacd.com/";
        public IEnumerable<AnimeEntry> GetTopData()
        {
            var doc = new HtmlWeb().LoadFromWebAsync(URL, Encoding.UTF8).Result;
            var list = doc.DocumentNode.SelectNodes("/html/body/div[9]/div[2]/div[3]/div[2]/ul");
            return list.Select(node => AnimeEntry.FromTopHtml(node));
        }
    }
}
