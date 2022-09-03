using Entities.Models;
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
        public AlbumValidator()
        {

        }
    }
}
