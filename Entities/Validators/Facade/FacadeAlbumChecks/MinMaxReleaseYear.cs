using System;

namespace Entities.Validators.Facade
{
    public class MinMaxReleaseYear
    {
        private int _MinReleaseYear = 1935;
        public int MinReleaseYear 
        {
            get
            {
                return _MinReleaseYear;
            }
        }

        private int _MaxReleaseYear = DateTime.Now.Year;
        public int MaxReleaseYear
        {
            get
            {
                return _MaxReleaseYear;
            }
        }
    }
}