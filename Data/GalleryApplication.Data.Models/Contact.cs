using System;
using GalleryApplication.Data.Common;

namespace GalleryApplication.Data.Models
{
    public class Contact : BaseModel<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime ArrivedOn { get; set; }
        public bool? IsAnswered { get; set; }
        public string Answer { get; set; }
        public DateTime? AnsweredOn { get; set; }
    }
}
