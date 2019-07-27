using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Artist;
using GalleryApplication.Services.Models.Home;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.DataServices
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Arts> artsRepository;
        private readonly IRepository<Artist> artistRepository;
        private readonly IRepository<Quotes> quotesRepository;

        public ArtistService(IRepository<Artist> artistRepository,
            IRepository<Quotes> quotesRepository,
            IRepository<Arts> artsRepository)
        {
            this.artistRepository = artistRepository;
            this.quotesRepository = quotesRepository;
            this.artsRepository = artsRepository;
        }

        public IEnumerable<IdAndNameViewModel> GetAll()
        {
            var artists = this.artistRepository.All()
                .OrderBy(x => x.Name)
                .Select(x => new IdAndNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(); //should put something in this

            return artists;
        }

        public ArtistDetailsViewModel GetArtistByid(int id)
        {
            var arts = this.artsRepository.All().Where(x => x.ArtistId == id)
                .Select(x => new IndexArtsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Path = x.Path,
                    CategoryName = x.Category.Name
                    
                }).ToList();

            var quotes = this.quotesRepository.All().Where(x => x.ArtistId == id)
                .Select(x => new ArtistQuotesViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    ArtistName = x.Artist.Name
                }).ToList();

            var artist = this.artistRepository.All().Where(x => x.Id == id)
                .Select(x => new ArtistDetailsViewModel
                {
                    Name = x.Name,
                    ShortBiography = x.shortBiography,
                    Quotes = quotes,
                    Arts = arts

                }).FirstOrDefault();

            return artist;
        }

        public bool IsArtistIdValid(int artistId)
        {
            return this.artistRepository.All().Any(x => x.Id == artistId);
        }
    }
}
