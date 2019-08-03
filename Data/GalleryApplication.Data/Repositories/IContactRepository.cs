using System;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IContactRepository : IDeletableRepository<Contact>
    {
        Task<Contact> GetContactByIdAsync(int id);
    }
}
