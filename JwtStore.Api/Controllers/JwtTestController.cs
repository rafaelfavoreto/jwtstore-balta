using JwtStore.Api.Extensions;
using JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JwtTestController : ControllerBase
{
    [HttpPost("generate")]
    public IActionResult GenerateToken([FromBody] ResponseData data)
    {
        if (data == null || string.IsNullOrEmpty(data.Id) || string.IsNullOrEmpty(data.Name) || string.IsNullOrEmpty(data.Email))
            return BadRequest("Invalid user data.");

        var token = JwtExtension.Generate(data);
        return Ok(new { token });
    }
}