using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Web.Models;

namespace ExceedERP.Web.Controllers
{
    public class ErpUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ErpUsers_Read([DataSourceRequest]DataSourceRequest request)
        {
            AccountController account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            List<ApplicationUser> applicationUsers = account.GetUsers();
            List<RegisterViewModel> userList = new List<RegisterViewModel>();
            foreach (ApplicationUser user in applicationUsers)
            {
               RegisterViewModel registerViewModel = new RegisterViewModel();
                registerViewModel.Email = user.Email;
                registerViewModel.UserName = user.UserName;
                registerViewModel.FirstName = user.FirstName;
                registerViewModel.MiddleName = user.MiddleName;
                registerViewModel.LastName = user.LastName;
                registerViewModel.PhoneNo = user.PhoneNo; 
                userList.Add(registerViewModel);
            }
            IQueryable<RegisterViewModel> erpUsers = userList.AsQueryable() ;
            DataSourceResult result = erpUsers.ToDataSourceResult(request, user => new {
                user.Email,
                user.UserName,
                user.FirstName,
                user.MiddleName,
                user.LastName,
                user.PhoneNo
               
            });

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
