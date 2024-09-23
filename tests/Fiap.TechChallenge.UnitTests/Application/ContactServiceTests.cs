using AutoFixture;
using Fiap.TechChallenge.Application.Repositories;
using Fiap.TechChallenge.Application.Services;
using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.LibDomain.Entities;
using Fiap.TechChallenge.LibDomain.Events;
using FluentAssertions;
using Moq;

namespace TestProject1.Application;

public class ContactServiceTests
{
    [Fact]
    public async Task ShouldInsertWithSuccess()
    {
        //Arrange
        var fixture = new Fixture();
        var message = fixture.Create<ContactInsertEvent>();
        var contactRepository = new Mock<IContactRepository>();
        
        contactRepository.Setup(c => c.InsertAsync(It.IsAny<Contact>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var contactService = new ContactService(contactRepository.Object);

        //Act
        var result = await contactService.InsertAsync(message, CancellationToken.None);

        //Assert
        result.DddNumber.Should().Be(message.DddNumber);
        result.Email.Should().Be(message.Email);
        result.PhoneNumber.Should().Be(message.PhoneNumber);
        result.Name.Should().Be(message.Name);
        contactRepository.Verify(c =>
            c.InsertAsync(It.IsAny<Contact>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}