namespace Meta_TV2_BusinessLayer;

public interface IKthAuth
{
    /// <summary>
    /// Verifies a token given by the user. Returns the id for said user, or null if it's not a valid token.
    /// </summary>
    /// <param name="token">Token to verify</param>
    public string VerifyToken(String token);
}
