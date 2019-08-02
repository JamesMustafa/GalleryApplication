using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Artists;
using GalleryApplication.Services.Models.Arts;
using GalleryApplication.Services.Models.Categories;
using GalleryApplication.Services.Models.Home;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Art,IndexArtsViewModel>();
            CreateMap<Artist,ArtistDetailsViewModel>();
            CreateMap<Art, ArtDetailsViewModel>();
            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<Category, IdAndNameViewModel>();
            CreateMap<Quote, ArtistQuotesViewModel>();
        }
    }
}