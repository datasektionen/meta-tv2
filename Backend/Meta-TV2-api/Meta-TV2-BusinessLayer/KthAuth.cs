using System.Text.Json.Nodes;

namespace Meta_TV2_BusinessLayer;

public class KthAuth : IKthAuth
{
    public async Task<string> VerifyToken(string token)
    {
        using (var client = new HttpClient()){
            try
            {
                client.GetStringAsync("http://localhost:1337/hello");
                
                //Based on https://github.com/datasektionen/login/
                // This request should always return if valid, and if not a valid token (or api-key) return status code 4xx
                var request = await client.GetStringAsync("http://localhost:1337/verify/" + token);
                var details = JsonObject.Parse(request);
                string user = (string)details["user"];
                return user;
            }
            catch (NullReferenceException e){
                return null;        // Verification failed here
            }
            catch (Exception e)
            {
                // Temporary until logging is decided. The exception e should be included if/when logging
                Console.WriteLine("\nYou've not set up the test enviroment for login system. That is fine. Defaulting to user: 'turetek'\n");
                return "turetek";
            }
        }
    }

    public async Task<bool> IsAdmin(string user)
    {
        using (var client = new HttpClient()){
            try
            {
                var request = await client.GetStringAsync("https://dfunkt.datasektionen.se/api/role/d-sys/current");
                var details = JsonObject.Parse(request);
                string adminUser = (string)details["mandates"][0]["User"]["kthid"];
                
                return string.Equals(adminUser, user);
            }
            catch (Exception e)
            {
                // Temporary until logging is decided. The exception e should be included if/when logging
                Console.WriteLine("Couldn't connect to dfunkt api, or it has changed!");
                return false;
            }
        }
    }
}
