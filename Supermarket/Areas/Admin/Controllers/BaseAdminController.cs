using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Shared.Constants;

namespace Supermarket.Web.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = RoleNames.AdminRoleName)]
    public class BaseAdminController: Controller
    {
    }
}
