using System;
using System.Linq;
using GalleryApplication.Data.Models;

namespace GalleryApplication.Data.Repositories
{
    public class CategoryRepository : DbRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GalleryAppContext context)
            :base(context)
        {
        }

        public Category GetCategoryById(int id)
        {
            return this.Get(id);
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.All().Any(x => x.Id == categoryId);
        }
    }
}
