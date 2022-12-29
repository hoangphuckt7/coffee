using Newtonsoft.Json;
using System.Security;
using System.Text;

string service_host = "http://localhost:8000/";
string data_center_host = "http://localhost:8008/";

Console.Write("Enter application-service host (ignore to use default): ");
string new_service_host = Console.ReadLine()!;
if (!string.IsNullOrWhiteSpace(new_service_host))
{
    service_host = new_service_host;
}
Console.Write("Enter data-center host (ignore to use default): ");
string new_data_center_host = Console.ReadLine()!;
if (!string.IsNullOrWhiteSpace(new_data_center_host))
{
    data_center_host = new_data_center_host;
}

Console.Write("Enter admin username: ");
string username = Console.ReadLine()!;
Console.Write("Enter admin password: ");
string password = GetPassword();
Console.WriteLine();
HttpResponseMessage responseMessage = new();
HttpClient client = new();

try
{
    responseMessage = await client.PostAsync(service_host + "api/User/Login", BuildRequestBody(new { Phone = username, PassWord = password }));
}
catch (Exception)
{
    Console.WriteLine("Request to application-service failed, press any key to exit.");
    Console.ReadKey();
    return;
}

if (!responseMessage.IsSuccessStatusCode)
{
    Console.WriteLine("Login faild, press any key to exit.");
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

try
{

    responseMessage = await client.GetAsync(data_center_host + "api/Restore/ClearAndRestore");
}
catch (Exception)
{
    Console.WriteLine("Request to data-center-service failed, press any key to exit.");
    Console.ReadKey();
    return;
}

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
string GetPassword()
{
    string password = "";
    ConsoleKeyInfo cki;
    do
    {
        cki = Console.ReadKey(true);
        if (cki.Key != ConsoleKey.Enter)
        {
            password += (cki.KeyChar);
            Console.Write("*");
        }
    } while (cki.Key != ConsoleKey.Enter);
    return password;
}
public class LoginSuccessViewModel
{
    public object Token { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
}
#endregion