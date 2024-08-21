using ExceedERP.DataAccess.Context;
using ExceedERP.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExceedERP.Helpers.Common;

namespace ExceedERP.Web.Helpers
{

    public static class IdentityHelper
    {
    //    public static async Task<string> GetEmployeeFullNameAsync(string userName)
    //    {
    //        ExceedDbContext db = new ExceedDbContext();
    //        string fullName = "";

    //        var userdetail = new ApplicationDbContext();
    //        var userempId = await userdetail.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
    //        if (userempId != null)
    //        {

    //            var employee = await db.Person_Employee.Where(x => x.EmployeeId.ToString() == userempId.EmployeeId)
    //                .FirstOrDefaultAsync();
    //            if (employee != null)
    //            {
    //                fullName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
    //            }

    //        }

    //        return fullName;

    //    }
    }
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {

       
        public AuthorizeRolesAttribute(params string[] roles)
            : base()
        {
            Roles = string.Join(",", roles);
        }
      
    }
}
