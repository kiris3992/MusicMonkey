using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators.Facade.FacadeArtistChecks
{
    public class ArtistChecks
    {
        public MinMaxNumberOfNameChars minMaxNumberOfNameChars { get; set; }

        public MinMaxArtistCarrerStart minMaxArtistCarrerStart { get; set; }
    }
}
