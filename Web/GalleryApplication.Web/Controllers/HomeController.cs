using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GalleryApplication.Web.Models;
using GalleryApplication.Services.DataServices;
using GalleryApplication.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GalleryApplication.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IArtsService artsService;
        private readonly IArtistService artistService;
        private readonly ICategoriesService categoriesService;

        public HomeController(IArtsService artsService,
            ICategoriesService categoriesService,
            IArtistService artistService) : base(categoriesService,artistService)
        {
            this.artsService = artsService;
            this.artistService = artistService;
            this.categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Contact()
        {
            if (ModelState.IsValid)
            {
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code = code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
