using System;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        bool IsCategoryIdValid(int categoryId);

        Task<Category> GetCategoryByIdAsync(int categoryId);
    }
}
