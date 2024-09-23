using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.LibDomain.Entities;
using Fiap.TechChallenge.LibDomain.Events;

namespace Fiap.TechChallenge.Application.Services.Interfaces;

public interface IContactService
{
    Task<Contact> InsertAsync(ContactInsertEvent message, CancellationToken cancellationToken);
}