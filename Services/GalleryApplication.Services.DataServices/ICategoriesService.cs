using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Categories;

namespace GalleryApplication.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<IdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        Task<CategoryDetailsViewModel> GetCategoryByIdAsync(int id);
    }
}
