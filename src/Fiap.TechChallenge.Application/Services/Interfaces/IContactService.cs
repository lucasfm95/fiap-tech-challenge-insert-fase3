using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.LibDomain.Entities;

namespace Fiap.TechChallenge.Application.Services.Interfaces;

public interface IContactService
{
    Task<Contact> InsertAsync(ContactEntity message, CancellationToken cancellationToken);
}