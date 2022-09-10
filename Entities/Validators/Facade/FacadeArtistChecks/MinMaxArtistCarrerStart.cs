using System;

namespace Entities.Validators.Facade.FacadeArtistChecks
{
    public class MinMaxArtistCarrerStart
    {
        private int _minYearCarrerStart;

        public int MinYearCarrerStart
        {
            get
            {
                return _minYearCarrerStart;
            }
        }

        private int _maxYearCarrerStart = DateTime.Now.Year - 15;
        public int MaxYearCarrerStart
        {
            get
            {
                return _maxYearCarrerStart;
            }
        }
        

        
    }
}