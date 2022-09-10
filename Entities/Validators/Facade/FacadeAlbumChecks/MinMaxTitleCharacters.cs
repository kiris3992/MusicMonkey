namespace Entities.Validators.Facade
{
    public class MinMaxTitleCharacters
    {
        private int _minTitleChars = 2;

        public int MinTitleChars 
        { 
            get
            {
                return _minTitleChars;
            } 
        }

        private int _maxTitleChars = 300;

        public int MaxTitleChars
        {
            get
            {
                return _maxTitleChars;
            }
        }
    }
}