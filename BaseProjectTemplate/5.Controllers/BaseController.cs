using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BaseProjectTemplate._5.Controllers
{
    
    public abstract class BaseController : ControllerBase
    {
        protected string? GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        }
    }
}
