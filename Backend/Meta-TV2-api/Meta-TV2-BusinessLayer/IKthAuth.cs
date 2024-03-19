namespace Meta_TV2_BusinessLayer;

public interface IKthAuth
{
    /// <summary>
    /// Verifies a token given by the user.
    /// </summary>
    /// <param name="token">Token to verify</param>
    /// <returns>
    /// Kthid for the user. If verification failed null is returned
    /// </returns>
    public string VerifyToken(String token);

    /// <summary>
    /// Checks if the user is d-sys and therefore has admin priviliges
    /// </summary>
    /// <param name="user">Kthid of user</param>
    /// <returns>
    /// True if user is d-sys, otherwise false
    /// </returns>
    public bool IsAdmin(String user);
}
