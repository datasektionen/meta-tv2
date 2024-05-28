using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Meta_TV2_BusinessLayer;

public class JwtRules : IJwtRules
{
    private readonly string _Issuer;
    private readonly string _Key;
    private readonly bool _IsAdmin;
    private readonly string _DsektToken;

    public JwtRules(string Issuer, string Key, bool IsAdmin, string DsektToken){
        _Issuer = Issuer;
        _Key = Key;
        _IsAdmin = IsAdmin;
        _DsektToken = DsektToken;
    }

    public string IssueNewToken(int ExpiresIn){
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(_Issuer,
            _Issuer,
            new List<Claim>{
                new Claim("IssuedAt", DateTime.Now.ToString()),
                new Claim("DsektToken", _DsektToken),
                new Claim("Admin", _IsAdmin.ToString())
            }.AsEnumerable(),
            expires: DateTime.Now.AddMinutes(ExpiresIn),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(Sectoken);
    }
}
