using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Genre : MusicEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }


        //Navigation Properties
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Track> Tracks { get; set; }

        public Genre()
        {
            Artists = new HashSet<Artist>();
            Albums = new HashSet<Album>();
            Tracks = new HashSet<Track>();
        }

        public Genre(string type)
        {
            Type = type;
            Artists = new HashSet<Artist>();
            Albums = new HashSet<Album>();
            Tracks = new HashSet<Track>();
        }
    }
}
