using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected Guid ID => Guid.Parse(HttpContext.User.Claims.ElementAt(0).Value);
    }
}
