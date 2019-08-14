using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Services.DataServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApplication.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArtistService artistService;

        public BaseController()
        {

        }

        public BaseController(ICategoriesService categoriesService,
            IArtistService artistService)
        {
            this.categoriesService = categoriesService;
            this.artistService = artistService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            this.ViewData["Artists"] = this.artistService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }
    }
}
