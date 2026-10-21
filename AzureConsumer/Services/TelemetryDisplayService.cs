public class TelemetryDisplayService
{
    public void Display(string json, DateTimeOffset? timestamp)
    {
        string time = timestamp.HasValue
            ? timestamp.Value.ToString("yyyy-MM-dd HH:mm:ss 'UTC'")
            : "Okänd tid";

        Console.WriteLine($"[{time}] Received: {json}");
    }
}
