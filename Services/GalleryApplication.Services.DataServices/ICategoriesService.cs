using System;
using System.Collections.Generic;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Category;

namespace GalleryApplication.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<IdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        CategoryDetailsViewModel GetCategoryById(int id);
    }
}
