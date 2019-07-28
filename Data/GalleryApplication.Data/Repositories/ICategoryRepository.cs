using System;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        bool IsCategoryIdValid(int categoryId);

        Category GetCategoryById(int id);
    }
}
