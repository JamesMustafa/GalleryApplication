﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GalleryApplication.Web.Models;
using GalleryApplication.Services.DataServices;

namespace GalleryApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtsService artsService;

        public HomeController(IArtsService artsService)
        {
            this.artsService = artsService;
        }
        public IActionResult Index()
        {
            var art = this.artsService.GetOneRandomArt();
            return View(art);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
