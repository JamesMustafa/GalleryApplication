using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Category;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IArtRepository artsRepository;

        public CategoriesService(ICategoryRepository categoryRepository
            ,IArtRepository artsRepository)
        {
            this.categoryRepository = categoryRepository;
            this.artsRepository = artsRepository;
        }

        public async Task<CategoryDetailsViewModel> GetCategoryByIdAsync(int id)
        {
            var arts = await this.artsRepository.GetArtsByCategoryIdAsync(id);

                var categoryArts =arts.Select(x => new IndexArtsViewModel
                {
                    Id = x.Id,
                    Path = x.Path,
                    Title = x.Title,
                    CategoryName = x.Category.Name
                }).ToList();

            var category = await this.categoryRepository.GetCategoryByIdAsync(id);

            var details = new CategoryDetailsViewModel
            {
                Name = category.Name,
                Description = category.Description,
                Arts = categoryArts
            };

            return details;
        }

        public IEnumerable<IdAndNameViewModel> GetAll()
        {
            var categories = this.categoryRepository.All()
                .OrderBy(x => x.Name)
                .Select(x => new IdAndNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoryRepository.IsCategoryIdValid(categoryId);
        }
    }
}
