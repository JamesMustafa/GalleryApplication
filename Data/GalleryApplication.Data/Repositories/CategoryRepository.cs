using System;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class CategoryRepository : DbRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GalleryAppContext context)
            :base(context)
        {
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var category = await this.GetByIdAsync(categoryId);
            return category;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.All().Any(x => x.Id == categoryId);
        }
    }
}
