using System;
using System.Threading.Tasks;

namespace GalleryApplication.Services.Messaging
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
