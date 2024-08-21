using System.Web.Mvc;
using ExceedERP.DataAccess.Context;
using ExceedERP.Helpers.Common;

namespace ExceedERP.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DashboardHelper _dashboardHelper = new DashboardHelper();

        ExceedDbContext _db = new ExceedDbContext();

        
    }
}