using Newtonsoft.Json;
using System.Text;

string service_host = "http://localhost:8000/";
string data_center_host = "http://localhost:8008/";

Console.Write("Enter application-api host (press enter to use default): ");
string new_service_host = Console.ReadLine()!;
if (!string.IsNullOrWhiteSpace(new_service_host))
{
    service_host = new_service_host;
}
Console.Write("Enter data-center host (press enter to use default): ");
string new_data_center_host = Console.ReadLine()!;
if (!string.IsNullOrWhiteSpace(new_data_center_host))
{
    data_center_host = new_data_center_host;
}

Console.Write("Enter admin username: ");
string username = Console.ReadLine()!;
Console.Write("Enter admin password: ");
string password = Console.ReadLine()!;

HttpResponseMessage responseMessage;
HttpClient client = new();
responseMessage = await client.PostAsync(service_host + "api/User/Login", BuildRequestBody(new { Phone = username, PassWord = password }));

if (!responseMessage.IsSuccessStatusCode)
{
    Console.WriteLine("Login faild!");
    Console.ReadKey();
    return;
}

Console.WriteLine("Login successfully.");
Console.WriteLine("This action will clear all data and can't be undone. Press 'y' to continue, any key to exit.");
var confirm = Console.ReadKey();
if (confirm.KeyChar != 'y')
{
    return;
}
Console.WriteLine();
Console.WriteLine("Processing...");
var data = await ParseToData<LoginSuccessViewModel>(responseMessage);
client.DefaultRequestHeaders.Add("Authorization", "Bearer " + data?.Token.ToString()!);
responseMessage = await client.GetAsync(data_center_host + "api/Restore/ClearAndRestore");

if (!responseMessage.IsSuccessStatusCode)
{
    Console.WriteLine("Restore faild!");
}
else
{
    Console.WriteLine("Completed!");
}
Console.WriteLine("Press any key to exit!");
Console.ReadKey();
#region helper
static StringContent BuildRequestBody<T>(T data)
{
    var dataConvert = JsonConvert.SerializeObject(data);
    return new StringContent(dataConvert, Encoding.UTF8, "application/json");
}

async Task<T> ParseToData<T>(HttpResponseMessage responseMessage)
{
    string json = await responseMessage.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<T>(json)!;
}

public class LoginSuccessViewModel
{
    public object Token { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
}
#endregion