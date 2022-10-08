






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

        multipartContent.Add(new ByteArrayContent(fileBytes), "images", "filename");
        var postResponse = await client.PutAsync($"https://localhost:7244/api/Item/Image/{file.Name.Split(".")[0]}", multipartContent);

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