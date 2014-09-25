using System.Collections.Generic;
namespace ProcessingJSON
{
    public class Channel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public List<Item> Item { get; set; } // !!! IF IT'S ITEMS -> JSON WILL NOT RECOGNIZED IT
    }
}
