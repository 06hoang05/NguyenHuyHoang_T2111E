using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IConfiguration _config;
    protected readonly DemoDbContext _dbContext;
    protected readonly ILogger<T> _logger;
    public BaseController(DemoDbContext dbContext, ILogger<T> logger, IConfiguration config)
    {
        _dbContext = dbContext;
        _logger = logger;
        _config = config;
    }
    protected string[] GetStringArr(string str)
    {
        return str.SplitString();
    }

    protected string GenerateToken(string username)
    {
        var secretKey = _config.GetValue<string>("Authen:Secret");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, username)
    };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}