using System;
using System.ComponentModel.DataAnnotations;
using GalleryApplication.Services.DataServices;

namespace GalleryApplication.Web.Models
{
    public class ValidArtistIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IArtistService)validationContext
                .GetService(typeof(IArtistService));

            if (service.IsArtistIdValid((int)value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid category id!");
            }
        }
    }
}
