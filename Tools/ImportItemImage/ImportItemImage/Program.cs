






using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Sessions;
using System.Net.Http;

O o = new O();

await o.AllFile();

public class O
{
    public async Task AllFile()
    {
        DirectoryInfo di = new DirectoryInfo("ItemImgs");
        FileInfo[] pngFiles = di.GetFiles("*.png");
        FileInfo[] jpgFiles = di.GetFiles("*.jpg");

        foreach (var item in pngFiles)
        {
            await PushData(item);
        }

        foreach (var item in jpgFiles)
        {
            await PushData(item);
        }
    }

    public async Task PushData(FileInfo file)
    {
        HttpClient client = new();
        HttpResponseMessage responseMessage = new();

        var multipartContent = new MultipartFormDataContent();

        var fileBytes = File.ReadAllBytes(file.FullName);

        client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIzZmM3MzE5OS1iMTYxLTQ0YzItODllMy04MGI1MDZiNTE3YjYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjlhY2M3YTFhLWFlODUtNGU1YS04Y2I3LTBiNDcwMjU0MThhYyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFETUlOIiwiZXhwIjoxNjY5NDc0NjYyLCJpc3MiOiJodHRwczovL2JsdWViaXJkeHgueHgiLCJhdWQiOiJodHRwczovL2JsdWViaXJkeHgueHgifQ.8mpD6EvwxhyX_N5DDuxbOo18BD2EgkCtZF9EXchVbdA");

        multipartContent.Add(new ByteArrayContent(fileBytes), "images", "filename");
        var postResponse = await client.PutAsync($"http://192.168.48.1:8000/api/Item/Image/{file.Name.Split(".")[0]}", multipartContent);

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