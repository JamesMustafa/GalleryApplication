using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Category;
using GalleryApplication.Services.Models.Home;

namespace GalleryApplication.Services.DataServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Arts> artsRepository;

        public CategoriesService(IRepository<Category> categoryRepository
            ,IRepository<Arts> artsRepository)
        {
            this.categoryRepository = categoryRepository;
            this.artsRepository = artsRepository;
        }

        public IEnumerable<IdAndNameViewModel> GetAll()
        {
            var categories = this.categoryRepository.All()
                .OrderBy(x => x.Name)
                .Select(x => new IdAndNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(); //should put something in this

            return categories;
        }

        public CategoryDetailsViewModel GetCategoryById(int id)
        {
            var allCategoryArts = this.artsRepository.All()
                .Where(x => x.CategoryId == id)
                .Select(x => new IndexArtsViewModel
                {
                    Id = x.Id,
                    Path = x.Path,
                    Title = x.Title,
                    CategoryName = x.Category.Name
                }).ToList();

            var category = this.categoryRepository.All().Where(x => x.Id == id)
                .Select(x => new CategoryDetailsViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Arts = allCategoryArts
                }).FirstOrDefault();

            return category;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoryRepository.All().Any(x => x.Id == categoryId);
        }
    }
}
