﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GalleryApplication.Web.Models;
using GalleryApplication.Services.DataServices;
using GalleryApplication.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.DataServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using GalleryApplication.Web.Models.Contact;
using Microsoft.Extensions.Localization;

namespace GalleryApplication.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IArtsService artsService;
        private readonly IArtistService artistService;
        private readonly IContactService contactService;
        private readonly ICategoriesService categoriesService;

        public HomeController(IArtsService artsService,
            ICategoriesService categoriesService,
            IArtistService artistService,
            IContactService contactService) : base(categoriesService,artistService)
        {
            this.artsService = artsService;
            this.artistService = artistService;
            this.contactService = contactService;
            this.categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Contact(
            [Bind("Name,Email,PhoneNumber,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await this.contactService.CreateAsync(contact);
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Contact()
        {
            this.ViewData["Messages"] = this.contactService.GetAll();

            return View();
        }

        [Route("/Home/Message/Delete/{id:int}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await this.contactService.DeleteContactByIdAsync(id);

            return this.RedirectToAction("Contact", "Home");
        }

        [HttpPost]
        [Route("/Home/AnswerMessage/{id:int}")]
        public async Task<IActionResult> AnswerMessage(int id,
            [Bind("Email,Answer")] IndexAnswerInputModel inputModel)
        {
            await this.contactService.AnswerAsync(id,inputModel.Email,inputModel.Answer);

            return this.RedirectToAction("Contact", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
