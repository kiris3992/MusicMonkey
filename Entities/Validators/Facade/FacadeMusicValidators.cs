using Entities.Validators.Facade.FacadeArtistChecks;
using Entities.Validators.Facade.FacadeTrackChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators.Facade
{
    public class FacadeMusicValidators
    {
        public AlbumChecks AlbumChecks { get; set; }
        public ArtistChecks ArtistChecks { get; set; }
        public TrackChecks TrackChecks { get; set; }
    }
}
