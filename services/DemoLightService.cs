public class DemoLightService : IDisposable
{
    private string apiUrl = "http://192.168.15.5:5000";
    private HttpClient client;
    
    public DemoLightService()
    {
        client = new HttpClient();
    }

    public async Task<string> TurnOnTheLight()
    {
        var response = await client.PostAsync($"{apiUrl}/on", null); 
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> TurnOffTheLight()
    {
        var response = await client.PostAsync($"{apiUrl}/off", null);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetLightStatus()
    {
        var response = await client.GetAsync($"{apiUrl}/status");
        return await response.Content.ReadAsStringAsync();
    }

    public void Dispose()
    {
        client.Dispose(); 
    }
}