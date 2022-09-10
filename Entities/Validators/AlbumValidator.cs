using Entities.Models;
using Entities.Validators.Facade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class AlbumValidator : AbstractValidator<Album>
    {
        public FacadeMusicValidators facadeMusicValidators;
        public AlbumValidator()
        {
            facadeMusicValidators = new FacadeMusicValidators();
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title can not be null")
                .MinimumLength(facadeMusicValidators.AlbumChecks.MinMaxTitleCharacters.MinTitleChars)
                .WithMessage($"Title cannot be less than {facadeMusicValidators.AlbumChecks.MinMaxTitleCharacters.MinTitleChars} characters long.")
                .MaximumLength(facadeMusicValidators.AlbumChecks.MinMaxTitleCharacters.MaxTitleChars)
                .WithMessage($"Title cannot be more than {facadeMusicValidators.AlbumChecks.MinMaxTitleCharacters.MaxTitleChars} characters long");
            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .WithMessage("Release Date can not be null");
            RuleFor(x => x.ReleaseDate.Year)
                .GreaterThanOrEqualTo(facadeMusicValidators.AlbumChecks.MinMaxReleaseYear.MinReleaseYear)
                .WithMessage($"Relase Year cannot be less than {facadeMusicValidators.AlbumChecks.MinMaxReleaseYear.MinReleaseYear}");
            RuleFor(x => x.ReleaseDate.Year).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(x => x.Artist).NotNull().WithMessage("Artist cannot be null");
            RuleFor(x => x.AlbumGenres).NotNull().WithMessage("Album Genres cannot be null");
            RuleFor(x => x.Tracks).NotNull().WithMessage("Tracks cannot be null");
            RuleFor(x => x.Tracks).Must(BeValidNumberOfTracks).WithMessage($"Number of tracks must be between {facadeMusicValidators.AlbumChecks.MinMaxNumOfTracks.MinNumOfTracks} " +
                $"and {facadeMusicValidators.AlbumChecks.MinMaxNumOfTracks.MaxNumOfTracks} number of tracks");

                
      
        }

        #region Custom Validation
        private bool BeValidNumberOfTracks(ICollection<Track> tracks)
        {
            int numberOfTracks = tracks.Count;
            Func<int, bool> checkNumOfTracks = CheckNumberOfTracks;
            if (checkNumOfTracks.Invoke(numberOfTracks))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        

        #region Delegate Function for custom validation
        private bool CheckNumberOfTracks(int numberOfTracks)
        {
            if (numberOfTracks < facadeMusicValidators.AlbumChecks.MinMaxNumOfTracks.MinNumOfTracks || numberOfTracks > facadeMusicValidators.AlbumChecks.MinMaxNumOfTracks.MaxNumOfTracks)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        


    }
}
