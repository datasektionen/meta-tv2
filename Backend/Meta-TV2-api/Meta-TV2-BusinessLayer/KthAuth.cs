
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

            return (string)details["user"];
        }
        catch (Exception)
        {
            return null;
        }
    }
}
