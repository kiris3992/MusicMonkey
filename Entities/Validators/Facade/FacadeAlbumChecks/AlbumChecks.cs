using Entities.Validators.Facade.FacadeAlbumChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators.Facade
{
    public class AlbumChecks
    {
        public MinMaxNumberOfTracks MinMaxNumOfTracks { get; set; }
        public MinMaxReleaseYear MinMaxReleaseYear { get; set; }
        public MinMaxTitleCharacters MinMaxTitleCharacters { get; set; }
    }
}
