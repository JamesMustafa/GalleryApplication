using System;
namespace GalleryApplication.Services.Models.Home
{
    public class IndexMessagesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsAnswered { get; set; }
        public string Answer { get; set; }
    }
}
