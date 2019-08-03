using System;
using System.ComponentModel.DataAnnotations;

namespace GalleryApplication.Web.Models.Contact
{
    public class IndexMessageInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
