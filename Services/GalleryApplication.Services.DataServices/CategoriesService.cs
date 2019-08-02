using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.Mapping;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Categories;
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
            var category = await this.categoryRepository.GetCategoryByIdAsync(id);

            var categoryArts = arts.Select(x => new IndexArtsViewModel
            {
                Id = x.Id,
                Path = x.Path,
                Title = x.Title,
                CategoryName = x.Category.Name
            })
            .ToList(); //Should make it with custom mappings

            var details = new CategoryDetailsViewModel
            {
                Name = category.Name,
                Description = category.Description,
                Arts = categoryArts
            };

            return await Task.FromResult(details);
        }

        public IEnumerable<IdAndNameViewModel> GetAll()
        {
            var categories = this.categoryRepository.AllEnum()
                .OrderBy(x => x.Name)
                .Select(x => new IdAndNameViewModel
	                {
	                    Id = x.Id,
	                    Name = x.Name
	                })
                .ToList(); //should put something in this

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoryRepository.IsCategoryIdValid(categoryId);
        }
    }
}
