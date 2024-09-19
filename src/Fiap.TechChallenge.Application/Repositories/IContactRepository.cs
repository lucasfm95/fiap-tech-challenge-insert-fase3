using Fiap.TechChallenge.Domain.Entities;

namespace Fiap.TechChallenge.Application.Repositories;

public interface IContactRepository
{
    /// <summary>
    /// Insert a contact asynchronously in database.
    /// </summary>
    /// <param name="contact">Entity to insert in database</param>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A Task that represents the asynchronous operation. The task result contains a boolean value that specifies whether the contact was successfully deleted.</returns>
    public Task<Contact> InsertAsync(Contact contact, CancellationToken cancellationToken);
}