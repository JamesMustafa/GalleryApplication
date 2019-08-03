using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices.Interfaces
{
    public interface IContactService
    {
        IEnumerable<IndexMessagesViewModel> GetAll();
        Task<Contact> CreateAsync(Contact contact);
        Task DeleteContactByIdAsync(int contactId);
        Task<Contact> GetContactByIdAsync(int contactId);
        Task AnswerAsync(int Id, string Email, string Answer);
    }
}
