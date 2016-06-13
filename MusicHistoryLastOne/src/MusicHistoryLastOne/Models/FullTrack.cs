using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHistoryLastOne.Models
{
    public class FullTrack
    {
        public string TrackTitle { get; set; }
        public string Artist { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
    }
}
