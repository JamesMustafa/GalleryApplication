using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.Models.Arts;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public class ArtsServices : IArtsService
    {
        private readonly IArtRepository artsRepository;

        public ArtsServices(IArtRepository artsRepository)
        {
            this.artsRepository = artsRepository;
        }

        public async Task<Guid> CreateAsync(Arts arts,
            DateTime uploadedOn,string extension)
        {
            var art = new Arts
            {
                Title = arts.Title,
                Description = arts.Description,
                UploadedOn = uploadedOn,
                CategoryId = arts.CategoryId,
                ArtistId = arts.ArtistId,
                Path = extension
            };

            await this.artsRepository.AddAsync(art);

            return art.Id;
        }

        public async Task<ArtDetailsViewModel> GetArtByIdAsync(Guid id)
        {
            var art = await this.artsRepository.GetArtByIdAsync(id);

            var details = new ArtDetailsViewModel
            {
                Id = art.Id,
                Title = art.Title,
                Path = art.Path,
                Description = art.Description,
                CategoryName = art.Category.Name,
                CategoryId = art.Category.Id,
                ArtistName = art.Artist.Name,
                ArtistId = art.Artist.Id,
                UploadedOn = art.UploadedOn
            };

            return details;
        }

        public int GetCount()
        {
            return this.artsRepository.All().Count();
        }

        public async Task<IEnumerable<IndexArtsViewModel>> GetRandomArtsAsync(int count)
        {
            var oldArts = await this.artsRepository.GetRandomArtsAsync(count);

            var arts = oldArts
              .OrderBy(x => Guid.NewGuid())
              .Select(x => new IndexArtsViewModel
              {
                  Id = x.Id,
                  Title = x.Title,
                  CategoryName = x.Category.Name,
              });

            return arts;
        }
    }
}
