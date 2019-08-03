using System;
using System.ComponentModel.DataAnnotations;

namespace GalleryApplication.Web.Models.Contact
{
    public class IndexAnswerInputModel
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public DateTime AnswerDate { get; set; }
        public string Email { get; set; }
    }
}
