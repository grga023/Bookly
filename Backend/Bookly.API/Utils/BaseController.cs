using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Utils
{
    public abstract class BaseController : ControllerBase
    {
        protected Guid ID => Guid.Parse(HttpContext.User.Claims.ElementAt(0).Value);
    }
}
