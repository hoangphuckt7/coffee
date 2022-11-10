






using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Sessions;
using System.Net.Http;

O o = new O();

await o.AllFile();

public class O
{
    public async Task AllFile()
    {
        Console.WriteLine("Enter host or skip to use default host: ");
        string? hostRead = Console.ReadLine();
        var host = "http://localhost:8000";
        if (!string.IsNullOrEmpty(hostRead))
        {
            host = hostRead;
        }

        Console.WriteLine("Enter token or skip to use default token: ");
        string? tokenRead = Console.ReadLine();
        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJjNTRlNTljMi1kZTc5LTRhNzctODI1ZC03ZjYyYzQ1NGYyZmIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjlhY2M3YTFhLWFlODUtNGU1YS04Y2I3LTBiNDcwMjU0MThhYyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFETUlOIiwiZXhwIjoxNjY5OTY2NjIxLCJpc3MiOiJodHRwczovL2JsdWViaXJkeHgueHgiLCJhdWQiOiJodHRwczovL2JsdWViaXJkeHgueHgifQ.x9YEGwwSWwty5CeK-nAsK6a3M60oKJ4IRyplIJ9R9_o";
        if (!string.IsNullOrEmpty(tokenRead))
        {
            token = tokenRead;
        }
        DirectoryInfo di = new DirectoryInfo("ItemImgs");
        FileInfo[] pngFiles = di.GetFiles("*.png");
        FileInfo[] jpgFiles = di.GetFiles("*.jpg");

        foreach (var item in pngFiles)
        {
            await PushData(item, host, token);
        }
        foreach (var item in jpgFiles)
        {
            await PushData(item, host, token);
        }

        Console.WriteLine("Completed!");
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();
    }

    public async Task PushData(FileInfo file, string host, string token)
    {
        HttpClient client = new();

        var multipartContent = new MultipartFormDataContent();

        var fileBytes = File.ReadAllBytes(file.FullName);

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        multipartContent.Add(new ByteArrayContent(fileBytes), "images", "filename");
        var postResponse = await client.PutAsync($"{host}/api/Item/Image/{file.Name.Split(".")[0]}", multipartContent);

        if (!postResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Import " + file.Name + " faild");
        }
        else
        {
            Console.WriteLine("Import " + file.Name);
        }
    }
}