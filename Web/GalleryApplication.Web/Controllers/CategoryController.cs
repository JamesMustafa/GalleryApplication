using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Services.DataServices;
using GalleryApplication.Services.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApplication.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArtistService artistService;

        public CategoryController(ICategoriesService categoriesService,
            IArtistService artistService) :base(categoriesService,artistService)
        {
            this.categoriesService = categoriesService;
            this.artistService = artistService;
        }

        [Authorize]
        [Route("/Category/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var category = await this.categoriesService.GetCategoryByIdAsync(id);
            return this.View(category);
        }

    }
}
