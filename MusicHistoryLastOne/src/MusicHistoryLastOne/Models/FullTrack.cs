using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHistoryLastOne.Models
{
    public class FullTrack
    {
        public string Artist { get; set; }
        public string YearReleased { get; set; }
        public string AlbumTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string TrackTitle { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
    }
}
