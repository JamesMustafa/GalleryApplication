using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Services.DataServices;
using GalleryApplication.Web.Models.Quotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApplication.Web.Controllers
{
    public class AuthorsController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArtistService artistService;
        private readonly IQuotesService quotesService;

        public AuthorsController(ICategoriesService categoriesService,
            IArtistService artistService, IQuotesService quotesService) : base(categoriesService, artistService)
        {
            this.categoriesService = categoriesService;
            this.artistService = artistService;
            this.quotesService = quotesService;
        }

        [Authorize]
        [Route("/Authors/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var artist = this.artistService.GetArtistByid(id);
            return this.View(artist);
        }

        [Authorize]
        [Route("/Authors/Create/Quotes", Name = "createquotes")]
        public IActionResult CreateQuotes()
        {
            return View();
        }

        [HttpPost]
        [Route("/Authors/Create/Quotes", Name = "createquotes")]
        public async Task<IActionResult> CreateQuotes(CreateQuoteInputModel inputModel)
        {
            if(!this.ModelState.IsValid)
            {
                return View(inputModel);
            }

            await this.quotesService
                .CreateAsync(inputModel.Content, inputModel.ArtistId);

            return this.RedirectToAction("Index", "Home");
        }

    }
}
//TODO: Make paths in the database to all the arts uploaded -- done
//Make artists view much much better
//Make create view much much better
//Make users have only 5 creates a day
//make admin roles and can add categories and authors view. can put remove too
//make index/contact view with functional email
//can write something in index/about
//can make quotes to change for seconds !!! with the first template where the pictures change but i can try it without pictures only plain text.
//make sure that the responsive design is alright
//upload lot more information like all of them(arts,categories)
//can make mappings with automapper
//find a better way to spread the information than shitty viewbags
//learn about tests in .net core
//can make a username instead email in registration form
//make it 3 languages
//can put a serach form
