using System.Collections.Generic;

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
    }
}
