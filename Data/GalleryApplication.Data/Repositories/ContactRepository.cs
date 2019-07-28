using System;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class ContactRepository : DbRepository<Contact>, IContactRepository
    {
        public ContactRepository(GalleryAppContext context)
            : base(context)
        {
        }
    }
}
