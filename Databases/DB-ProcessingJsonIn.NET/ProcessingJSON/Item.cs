using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessingJSON
{
    public class Item
    {
        public Item(string title, string link, string desc, string category, string pub)
        {
            this.Title = title;
            this.Link = link;
            this.Description = desc;
            this.Category = category;
            this.PubDate = pub;
        }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string PubDate { get; set; }
    }
}
