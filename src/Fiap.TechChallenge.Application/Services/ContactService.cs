using Fiap.TechChallenge.Application.Repositories;
using Fiap.TechChallenge.Application.Services.Interfaces;
using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.LibDomain.Entities;
using Fiap.TechChallenge.LibDomain.Events;

namespace Fiap.TechChallenge.Application.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    public async Task<Contact> InsertAsync(ContactInsertEvent message, CancellationToken cancellationToken)
    {
        var contact = new Contact(message.Name, message.Email, message.PhoneNumber, message.DddNumber);
        await contactRepository.InsertAsync(contact,cancellationToken);
        return contact;
    }
}