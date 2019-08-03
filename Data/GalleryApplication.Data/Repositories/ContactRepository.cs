using System;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ContactRepository : DbDeletableRepository<Contact>, IContactRepository
    {
        public ContactRepository(GalleryAppContext context)
            : base(context)
        {
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = await this.GetByIdAsync(id);
            return contact;
        }
    }
}
