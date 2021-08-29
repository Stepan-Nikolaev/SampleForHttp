using System;
using System.Collections.Generic;
using System.Text;

namespace SampleForHttp.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        public int Team { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string AvatarUrl { get; set; }
        public int Id { get; set; }
        public string TeamName { get; set; }
    }
}
