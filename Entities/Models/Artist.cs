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

        // Navigation Properties
        public ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public Artist(string name, Country country, string photoUrl, DateTime careerStartDate)
        {
            Name = name;
            Country = country;
            PhotoUrl = photoUrl;
            CareerStartDate = careerStartDate;
            Albums = new HashSet<Album>();
        }
    }
}
