using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using GalleryApplication.Data.Models;
using System.IO;
using GalleryApplication.Services.DataServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalleryApplication.Web.Controllers
{
    [Authorize]
    public class ImagesController : BaseController
    {
        private readonly IFileProvider fileProvider;
        private readonly IHostingEnvironment enviroment;
        private readonly ICategoriesService categoriesService;
        private readonly IArtistService artistService;
        private readonly IArtsService artsService;

        public ImagesController(IFileProvider fileProvider, IHostingEnvironment enviroment,
            ICategoriesService categoriesService,
            IArtistService artistService,
            IArtsService artsService) : base(categoriesService,artistService)
        {
            this.fileProvider = fileProvider;
            this.enviroment = enviroment;
            this.categoriesService = categoriesService;
            this.artistService = artistService;
            this.artsService = artsService;
        }

        //[HttpGet]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Title,Description,UploadedOn,CategoryId,ArtistId")] Arts arts, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                if(file != null && file.Length != 0)
                {
                    //Create a File Info
                    FileInfo fi = new FileInfo(file.FileName);

                    var art = await artsService.CreateAsync(arts,DateTime.Now,fi.Extension);

                    //This code creates a unique file name to prevent duplications
                    //stored at the file location
                    var newFileName = art.ToString() + fi.Extension;
                    var webPath = enviroment.WebRootPath;
                    var path = Path.Combine("", webPath + @"/images/arts/" + newFileName);

                    //IMPORTANT: the pathToSave variable will be save on the column in the database
                    //var pathToSave = @"/images/" + newFileName;

                    //This stream the physical file to the allocate wwwroot/images folder
                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult Details(Guid Id)
        {
            var art = this.artsService.GetArtByid(Id);
            return View(art);
        }
    }
}
