using Fiap.TechChallenge.Domain.Entities;

namespace Fiap.TechChallenge.Application.Repositories;

public interface IContactRepository
{
    /// <summary>
    /// Insert a contact asynchronously in database.
    /// </summary>
    /// <param name="contact">Entity to insert in database</param>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public Task InsertAsync(Contact contact, CancellationToken cancellationToken);
}