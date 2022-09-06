using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public Country Country { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CareerStartDate { get; set; }

    }
}
