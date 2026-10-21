using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var displayService = new TelemetryDisplayService();

var azureConsumerService = new AzureConsumerService(
    displayService,
    configuration);

await azureConsumerService.StartAsync();