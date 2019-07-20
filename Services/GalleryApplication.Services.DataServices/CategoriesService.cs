using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models;

namespace GalleryApplication.Services.DataServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoriesService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
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

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoryRepository.All().Any(x => x.Id == categoryId);
        }
    }
}
