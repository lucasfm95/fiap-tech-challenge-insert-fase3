using AutoFixture;
using Fiap.TechChallenge.Application.Repositories;
using Fiap.TechChallenge.Application.Services;
using Fiap.TechChallenge.Application.Services.Interfaces;
using Fiap.TechChallenge.Domain.Entities;
using Fiap.TechChallenge.LibDomain.Entities;
using Fiap.TechChallenge.LibDomain.Events;
using Fiap.TechChallenge.Worker.Consumers;
using FluentAssertions;
using MassTransit.Testing;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestProject1.Worker;

public class ContactInsertConsumerTests
{
    private readonly Mock<IContactService> _mockContactService;
    private readonly ContactInsertConsumer _consumer;
    private readonly Fixture _fixture = new();
    private readonly InMemoryTestHarness _harness = new();
    private readonly Mock<ILogger<ContactInsertConsumer>> _mockLogger = new();

    public ContactInsertConsumerTests()
    {
        _mockContactService = new Mock<IContactService>();
        _consumer = new ContactInsertConsumer(_mockLogger.Object, _mockContactService.Object);
    }
    
    [Fact]
    public async void ShouldProcessMessage_ContactDeleted_Success()
    {
        var contactResult = _fixture.Create<Contact>();
        var consumerHarness = _harness.Consumer(() => _consumer);
        _mockContactService.Setup(x =>
                x.InsertAsync(It.IsAny<ContactInsertEvent>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(contactResult);

        await _harness.Start();
        try
        {
            var message =  _fixture.Create<ContactInsertEvent>();
            await _harness.InputQueueSendEndpoint.Send(message);
            (await _harness.Sent.Any<ContactInsertEvent>()).Should().BeTrue();
            (await consumerHarness.Consumed.Any<ContactInsertEvent>()).Should().BeTrue();
        }
        finally
        {
            await _harness.Stop();
        }
    }
   
}