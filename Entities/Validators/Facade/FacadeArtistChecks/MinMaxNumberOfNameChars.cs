namespace Entities.Validators.Facade.FacadeArtistChecks
{
    public class MinMaxNumberOfNameChars
    {
        private int _minNumberOfNameChars = 2;
        public int MinNumberOfNameChars
        {
            get
            {
                return _minNumberOfNameChars;
            }
        }

        private int _maxNumberOfNameChars = 100;
        public int MaxNumberOfNameChars
        {
            get
            {
                return _maxNumberOfNameChars;
            }
        }
    }
}