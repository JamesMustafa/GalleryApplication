using System;
using System.Threading.Tasks;
using GalleryApplication.Data.Repositories;

namespace GalleryApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GalleryAppContext context;

        public UnitOfWork(GalleryAppContext context)
        {
            this.context = context;
            Arts = new ArtRepository(context);
            Artists = new ArtistRepository(context);
            Categories = new CategoryRepository(context);
            Contacts = new ContactRepository(context);
            Quotes = new QuotesRepository(context);
        }

        public IArtRepository Arts { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IArtistRepository Artists { get; private set; }

        public IContactRepository Contacts { get; private set; }

        public IQuotesRepository Quotes { get; private set; }

        public Task<int> Complete()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
