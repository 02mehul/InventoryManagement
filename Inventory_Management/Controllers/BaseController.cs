using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace InventoryManagement.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        public Guid UserId
        {
            get
            {
                if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
                {
                    var userId = HttpContext.User.FindFirst("Id")?.Value;
                    if (!string.IsNullOrWhiteSpace(userId))
                        return new Guid(userId);
                }
                return Guid.Empty;
            }
        }
    }
}
