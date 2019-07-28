using System;
using System.Threading.Tasks;
using GalleryApplication.Data.Repositories;

namespace GalleryApplication.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IArtRepository Arts { get; }
        ICategoryRepository Categories { get; }
        IArtistRepository Artists { get; }
        IContactRepository Contacts { get; }
        IQuotesRepository Quotes { get; }
        Task<int> Complete();

    }
}
