using System;
using System.Collections.Generic;
using GalleryApplication.Services.Models;

namespace GalleryApplication.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<IdAndNameViewModel> GetAll();
        bool IsCategoryIdValid(int categoryId);
    }
}
