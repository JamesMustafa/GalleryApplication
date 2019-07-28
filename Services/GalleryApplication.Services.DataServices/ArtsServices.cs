using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models.Arts;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public class ArtsServices : IArtsService
    {
        private readonly IRepository<Arts> artsRepository;
        private readonly IRepository<Category> categoriesRepository;

        public ArtsServices(IRepository<Arts> artsRepository,
            IRepository<Category> categoriesRepository)
        {
            this.artsRepository = artsRepository;
            this.categoriesRepository = categoriesRepository;
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
            //await this.artsRepository.SaveChangesAsync();

            return art.Id;
        }

        public ArtDetailsViewModel GetArtByid(Guid id)
        {
            var art = this.artsRepository.All().Where(x => x.Id == id)
                .Select(x => new ArtDetailsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Path = x.Path,
                    Description = x.Description,
                    CategoryName = x.Category.Name,
                    CategoryId = x.Category.Id,
                    ArtistName = x.Artist.Name,
                    ArtistId = x.Artist.Id,
                    UploadedOn = x.UploadedOn

                }).FirstOrDefault();

            return art;
        }

        public int GetCount()
        {
            return this.artsRepository.All().Count();
        }

        public IEnumerable<IndexArtsViewModel> GetRandomArts(int count)
        {
            var arts = this.artsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new IndexArtsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                }).Take(count).ToList();

            return arts;
        }
    }
}
