using System;
using System.Collections.Generic;
using System.Text;

namespace SampleForHttp.Models
{
    public class PlayerResponce
    {
        public IEnumerable<Player> Data { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
