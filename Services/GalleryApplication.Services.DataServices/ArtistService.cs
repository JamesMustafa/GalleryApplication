﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Common;
using GalleryApplication.Data.Models;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.Models;
using GalleryApplication.Services.Models.Artist;
using GalleryApplication.Services.Models.Home;
using GalleryApplication.Services.Models.Quotes;

namespace GalleryApplication.Services.DataServices
{
    public class ArtistService : IArtistService
    {
        private readonly IArtRepository artsRepository;
        private readonly IArtistRepository artistRepository;
        private readonly IQuotesRepository quotesRepository;

        public ArtistService(IArtistRepository artistRepository,
            IQuotesRepository quotesRepository,
            IArtRepository artsRepository)
        {
            this.artistRepository = artistRepository;
            this.quotesRepository = quotesRepository;
            this.artsRepository = artsRepository;
        }

        public IEnumerable<IdAndNameViewModel> GetAll() //should make async too
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

        public async Task<ArtistDetailsViewModel> GetArtistByIdAsync(int id)
        {
            var arts = await this.artsRepository.GetArtsByArtistIdAsync(id);

            var artistArts = arts.Select(x => new IndexArtsViewModel
            {
                Id = x.Id,
                Path = x.Path,
                Title = x.Title,
                CategoryName = x.Category.Name

            }).ToList();

            var quotes = this.quotesRepository.GetQuotesByArtistId(id);
            var artistQuotes = quotes.Select(x => new ArtistQuotesViewModel
            {
                Id = x.Id,
                Content = x.Content,
                ArtistName = x.Artist.Name
            }).ToList();

            var artist = await this.artistRepository.GetArtistByIdAsync(id);

            var details = new ArtistDetailsViewModel
            {
                Name = artist.Name,
                ShortBiography = artist.shortBiography,
                Arts = artistArts,
                Quotes = artistQuotes
            };

            return details;
        }

        public bool IsArtistIdValid(int artistId)
        {
            return this.artistRepository.IsArtistIdValid(artistId);
        }
    }
}
