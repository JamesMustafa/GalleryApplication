using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.Mapping;
using GalleryApplication.Services.Models.Arts;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public class ArtsServices : IArtsService
    {
        private readonly IArtRepository artsRepository;
        private readonly IArtistRepository artistRepository;
        private readonly ICategoryRepository categoriesRepository;

        public ArtsServices(IArtRepository artsRepository,
            IArtistRepository artistRepository,
            ICategoryRepository categoriesRepository)
        {
            this.artsRepository = artsRepository;
            this.artistRepository = artistRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<Guid> CreateAsync(Art arts,
            DateTime uploadedOn,string extension)
        {
            var art = new Art
            {
                Title = arts.Title,
                Description = arts.Description,
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
            var category = await this.categoriesRepository.GetByIdAsync(art.CategoryId);
            var artist = await this.artistRepository.GetByIdAsync(art.ArtistId);
            //example of mapping with automapper.
            //var details = Mapper.Map<Art, ArtDetailsViewModel>(art);

            var details = new ArtDetailsViewModel()
            {
                Id = art.Id,
                Title = art.Title,
                Path = art.Path,
                Description = art.Description,
                CategoryName = category.Name,
                CategoryId = art.CategoryId,
                ArtistName = artist.Name,
                ArtistId = art.ArtistId
            }; 

            return await Task.FromResult(details);
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
