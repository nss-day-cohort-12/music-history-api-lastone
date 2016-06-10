using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHistoryLastOne.Models
{
    public class Tracks
    {
        [Key]
        public int TrackId { get; set; }
        public string TrackTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        
        public int AlbumId { get; set; }
        public int UserId { get; set; }

        public Albums Albums { get; set; }
        public LastOneUsers LastOneUser { get; set; }
    }
}
