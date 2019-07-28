using System;
using System.Collections.Generic;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface IArtRepository : IRepository<Arts>
    {
        IEnumerable<Arts> GetRandomArts(int count);

        IEnumerable<Arts> GetArtsByCategoryId(int id);

        Arts GetArtByid(Guid id);
    }
}
