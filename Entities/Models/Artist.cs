using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Artist : MusicEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CareerStartDate { get; set; }
        public List<Genre> ArtistGenres { get; set; }

        // Navigation Properties
        public ICollection<Album> Albums { get; set; }

        public Artist()
        {
            ArtistGenres = new List<Genre>();
            Albums = new HashSet<Album>();
        }
    }
}
