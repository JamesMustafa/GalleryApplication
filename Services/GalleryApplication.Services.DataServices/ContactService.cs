using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApplication.Data.Models;
using GalleryApplication.Data.Repositories;
using GalleryApplication.Services.DataServices.Interfaces;
using GalleryApplication.Services.Models.Home;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GalleryApplication.Services.DataServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IEmailSender emailSender;

        public ContactService(IContactRepository contactRepository,
            IEmailSender emailSender)
        {
            this.contactRepository = contactRepository;
            this.emailSender = emailSender;
        }

      /*  public async Task<Contact> AnswerAsync(Contact contact)
        {

            await emailSender.SendEmailAsync(contact.Email, "Answer of your message",
                        $"");
        } */

        public async Task<Contact> CreateAsync(Contact contact)
        {
            var message = new Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
                IsAnswered = false,
                Answer = null,
                AnsweredOn = null
            };

            await this.contactRepository.AddAsync(message);

            return await Task.FromResult(message);
        }

        public HomeContactViewModel GetAll()
        {
            var messages = this.contactRepository.AllEnum()
                .OrderBy(x => x.CreatedOn)
                .Select(x => new IndexMessagesViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    IsAnswered = x.IsAnswered
                }); //should put something in this

            return new HomeContactViewModel { Messages = messages};
        }

        public async Task DeleteContactByIdAsync(int contactId)
        {
            var contact = await this.contactRepository.GetContactByIdAsync(contactId);
            await this.contactRepository.DeleteAsync(contact);
        }
    }
}
