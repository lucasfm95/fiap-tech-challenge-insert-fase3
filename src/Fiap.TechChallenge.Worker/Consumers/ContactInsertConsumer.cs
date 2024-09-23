using Fiap.TechChallenge.Application.Services.Interfaces;
using Fiap.TechChallenge.LibDomain.Events;
using MassTransit;
using Prometheus;

namespace Fiap.TechChallenge.Worker.Consumers;

public class ContactInsertConsumer(ILogger<ContactInsertConsumer> logger, IContactService contactService)
    : IConsumer<ContactInsertEvent>
{
    private static readonly Counter ProcessedJobsCounter =
        Metrics.CreateCounter("inserted_contact_total_processed", "Number of Contact Inserted consumed.");
    
    public async Task Consume(ConsumeContext<ContactInsertEvent> context)
    {
        try
        {
            var result = await contactService.InsertAsync(context.Message, context.CancellationToken);
            
            //Prometheus metrics
            ProcessedJobsCounter.Inc();
            
            logger.LogInformation("Inserted contact: {@contact}", result);
        }
        catch (Exception e)
        {
            logger.LogError("Error inserting contact {@messageBody}: {Message}", context.Message, e.Message);
        }
    }
}