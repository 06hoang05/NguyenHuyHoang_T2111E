﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

public class AuthController : BaseController<AuthController>
{
    private object _dbContext;

    public AuthController(DemoDbFirstContext dbContext,
       ILogger<AuthController> logger,
       IConfiguration config)
       : base(dbContext, logger, config)
    {
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] AuthenticationModel model)
    {
        var data = _dbContext.Students.FirstOrDefault(m => m.Username == model.Username);
        if (data == null) return BadRequest("Username/password incorrect");

        var isValid = model.Username.ValidPassword(data.Salt, model.Password, data.Password);
        if (!isValid) return BadRequest("Username/password incorrect");

        var accessToken = GenerateToken(model.Username);
        return Ok(accessToken);
    }

    private object GenerateToken(string username)
    {
        throw new NotImplementedException();
    }
}
