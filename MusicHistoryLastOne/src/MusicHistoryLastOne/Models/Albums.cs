using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHistoryLastOne.Models
{
    public class Albums
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string Artist { get; set; }
        public string YearReleased { get; set; }
        public ICollection<Tracks> Tracks { get; set; }
    }
}
