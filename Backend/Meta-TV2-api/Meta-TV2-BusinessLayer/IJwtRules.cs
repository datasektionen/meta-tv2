namespace Meta_TV2_BusinessLayer;

public interface IJwtRules
{
    /// <summary>
    /// Generates a new JWT (JSON Web Token)
    /// </summary>
    /// <param name="ExpiresIn">Token validity time (in minutes)</param>
    /// <returns>JWT string</returns>
    public string IssueNewToken(int ExpiresIn);
}
