﻿using System;
using System.ComponentModel.DataAnnotations;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Contact : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsAnswered { get; set; }
        public string Answer { get; set; }
        public DateTime? AnsweredOn { get; set; }
    }
}
