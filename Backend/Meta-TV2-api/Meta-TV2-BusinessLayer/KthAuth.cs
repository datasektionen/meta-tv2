
using System.Text.Json.Nodes;

namespace Meta_TV2_BusinessLayer;

public class KthAuth : IKthAuth
{
    public string VerifyToken(String token)
    {
        HttpClient client = new();

        try
        {
            client.GetStringAsync("http://localhost:1337/hello");
        }
        catch (Exception)
        {
            Console.WriteLine("\nYou've not set up the test enviroment for login system. That is fine. Defaulting to user: 'turetek'\n");
            return "turetek";
        }

        try
        {
            // Based on https://github.com/datasektionen/login/
            // This request should always return if valid, and if not a valid token (or api-key) return status code 4xx
            Task<String> task = client.GetStringAsync("http://localhost:1337/verify/" + token);
            String request = task.Result;
            var details = JsonObject.Parse(request);
            String user = (string)details["user"];
            return user;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool IsAdmin(String user)
    {
        HttpClient client = new();
        try
        {
            Task<String> task = client.GetStringAsync("https://dfunkt.datasektionen.se/api/role/d-sys/current");
            String request = task.Result;   
            var details = JsonObject.Parse(request);
            String adminUser = (String)details["mandates"][0]["User"]["kthid"];
            
            return String.Equals(adminUser, user);
        }
        catch (Exception)
        {
            Console.WriteLine("Couldn't connect to dfunkt api, or it has changed!");
            return false;
        }
    }
}
