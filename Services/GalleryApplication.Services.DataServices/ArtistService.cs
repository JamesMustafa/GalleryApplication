using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Artist;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.DataServices
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> artistRepository;
        private readonly IRepository<Quotes> quotesRepository;

        public ArtistService(IRepository<Artist> artistRepository, IRepository<Quotes> quotesRepository)
        {
            this.artistRepository = artistRepository;
            this.quotesRepository = quotesRepository;
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
                    shortBiography = x.shortBiography,
                    Quotes = quotes
                }).FirstOrDefault();

            return artist;
        }

        public bool IsArtistIdValid(int artistId)
        {
            return this.artistRepository.All().Any(x => x.Id == artistId);
        }
    }
}
