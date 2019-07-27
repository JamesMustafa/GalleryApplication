using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GalleryApplication.Web.Models
{
    public class NavViewModel
    {
        public IEnumerable<SelectListItem> Artists { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
