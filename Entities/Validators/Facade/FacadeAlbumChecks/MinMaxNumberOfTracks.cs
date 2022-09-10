using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators.Facade.FacadeAlbumChecks
{
    public class MinMaxNumberOfTracks
    {
        private int _MinNumOfTracks = 2;
        public int MinNumOfTracks 
        {
            get
            {
                return _MinNumOfTracks;
            } 
        }

        private int _MaxNumOfTracks = 30;
        public int MaxNumOfTracks
        {
            get
            {
                return _MaxNumOfTracks;
            }
        }
    }
}
