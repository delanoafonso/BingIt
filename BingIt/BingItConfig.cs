using System.Collections.Generic;
using System.Globalization;

namespace BingIt
{
    public class Url
    {
        public string Link { get; set; }
    }

    public class BingItConfig
    {
        public string EdgeName { get; set; }

        public string EdgeProcessName { get; set; }

        public int WaitAfterClick { get; set; }

        public List<Url> Urls { get; set; }

        public string BingSearchUrl { get; set; }
    }
}
