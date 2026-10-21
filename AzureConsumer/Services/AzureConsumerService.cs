
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Extensions.Configuration;

public class AzureConsumerService
{
    private readonly TelemetryDisplayService _displayService;
    private readonly IConfiguration _configuration;

    public AzureConsumerService(
        TelemetryDisplayService displayService,
        IConfiguration configuration)
    {
        _displayService = displayService;
        _configuration = configuration;
    }

    public async Task StartAsync()
    {
        string connectionString =
            _configuration["Azure:EventHubConnectionString"]
            ?? throw new InvalidOperationException(
                "Azure-anslutningen saknas i appsettings.json.");

        string consumerGroup =
            _configuration["Azure:ConsumerGroup"] ?? "$Default";

        await using var consumer = new EventHubConsumerClient(
            consumerGroup,
            connectionString);

        Console.WriteLine("Ansluten till Azure-konsumenten.");
        Console.WriteLine("Väntar på värden\n");

        try
        {
            await foreach (var receivedEvent in consumer.ReadEventsAsync(false))
            {
                if (receivedEvent.Data is null)
                    continue;

                string json = receivedEvent.Data.EventBody.ToString();
                DateTimeOffset timestamp = receivedEvent.Data.EnqueuedTime;

                _displayService.Display(json, timestamp);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid läsning från Azure: {ex.Message}");
        }
    }
}
