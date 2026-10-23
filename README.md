# Azure Event Hubs-konsument för sensordata

## Beskrivning
Applikationen tar emot sensordata från Azure Event Hubs och skriver ut inkommande meddelanden i konsolen tillsammans med en tidsstämpel. Meddelandena läses som JSON-data.

## Lösningens delar
- **AzureConsumerService:** Ansluter till Azure Event Hubs och läser inkommande händelser.
- **TelemetryDisplayService:** Visar mottagna meddelanden och tidsstämplar i konsolen.
- **Programstart:** Läser konfigurationen från `appsettings.json`, skapar tjänsterna och startar konsumenten.

## Teknik och beroenden
- **.NET 10:** Ramverk som applikationen körs på.
- **Azure.Messaging.EventHubs:** Bibliotek för kommunikation med Azure Event Hubs.
- **Microsoft.Extensions.Configuration.Json:** Används för att läsa konfiguration från `appsettings.json`.

## Konfiguration
Skapa en lokal `appsettings.json` med följande inställningar:

- **Event Hub connection string:** Anslutningssträngen för Azure Event Hubs.
- **Consumer group:** Anger vilken konsumentgrupp som används. Om inget värde anges används `$Default`.

Anslutningssträngen måste vara giltig och ha behörighet att läsa händelser från Event Hub.

Filen `appsettings.json` ingår inte i versionshanteringen och behöver konfigureras lokalt innan applikationen startas.

## Starta applikationen
1. Installera .NET 10 SDK.
2. Kontrollera att en Event Hub finns i Azure och att `appsettings.json` innehåller rätt anslutningsuppgifter.
3. Öppna en terminal i projektets katalog.
4. Kör `dotnet run` för att starta applikationen.
5. När anslutningen lyckats visas ett meddelande i konsolen och applikationen börjar vänta på inkommande händelser.

## Dataflöde
Sensor eller annan producent → Azure Event Hubs → Azure-konsument → Konsolutskrift.
