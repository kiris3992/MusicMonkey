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
    public class ArtistValidator : AbstractValidator<Artist>
    {
        public FacadeMusicValidators facadeMusicValidators { get; set; }
        public ArtistValidator()
        {
            facadeMusicValidators = new FacadeMusicValidators();
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name Of Artist cannot be empty");
            RuleFor(x => x.Name)
                .Must(BeValidLengthName)
                .WithMessage(
                $"Characters of Artist Name must be between " +
                $"{facadeMusicValidators.ArtistChecks.minMaxNumberOfNameChars.MinNumberOfNameChars} and " +
                $"{facadeMusicValidators.ArtistChecks.minMaxNumberOfNameChars.MaxNumberOfNameChars} characters long.");
            RuleFor(x => x.CareerStartDate.Year)
                .Must(BeValidCarrerYearStart)
                .WithMessage($"Min Carrer Year Start must be bigger than {facadeMusicValidators.ArtistChecks.minMaxArtistCarrerStart.MinYearCarrerStart}" +
                $"and less than {facadeMusicValidators.ArtistChecks.minMaxArtistCarrerStart.MaxYearCarrerStart}");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country cannot be empty");
            

        }


        #region Custom Validations
        private bool BeValidLengthName(string name)
        {
            int numberOfLetters = name.Length;
            Func<int, bool> checkNameLength = CheckValidLengthName;
            if (checkNameLength.Invoke(numberOfLetters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool BeValidCarrerYearStart(int StartCarrerYear)
        {
            Func<int, bool> checkCarrerYear = CheckCarrerYearStart;
            if (checkCarrerYear.Invoke(StartCarrerYear))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        private bool CheckValidLengthName(int numberOfLetters)
        {
            if (numberOfLetters < facadeMusicValidators.ArtistChecks.minMaxNumberOfNameChars.MinNumberOfNameChars 
                || numberOfLetters > facadeMusicValidators.ArtistChecks.minMaxNumberOfNameChars.MaxNumberOfNameChars)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckCarrerYearStart(int startCarrerYear)
        {
            if (startCarrerYear < facadeMusicValidators.ArtistChecks.minMaxArtistCarrerStart.MinYearCarrerStart 
                || startCarrerYear > facadeMusicValidators.ArtistChecks.minMaxArtistCarrerStart.MaxYearCarrerStart) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
