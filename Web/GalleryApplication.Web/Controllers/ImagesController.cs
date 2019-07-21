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
    public class ImagesController : Controller
    {
        private readonly IFileProvider fileProvider;
        private readonly IHostingEnvironment enviroment;
        private readonly ICategoriesService categoriesService;
        private readonly IArtistService artistService;
        private readonly IArtsService artsService;

        public ImagesController(IFileProvider fileProvider, IHostingEnvironment enviroment,
            ICategoriesService categoriesService,
            IArtistService artistService,
            IArtsService artsService)
        {
            this.fileProvider = fileProvider;
            this.enviroment = enviroment;
            this.categoriesService = categoriesService;
            this.artistService = artistService;
            this.artsService = artsService;
        }

        // GET: Products/Create
        public IActionResult Create()
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
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Title,Description,UploadedOn,CategoryId,ArtistId")] Arts arts, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                if(file != null && file.Length != 0)
                {
                     var art = await artsService.CreateAsync(arts,DateTime.Now);

                    //Create a File Info
                    FileInfo fi = new FileInfo(file.FileName);

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

                    //This save the path to the record

                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
