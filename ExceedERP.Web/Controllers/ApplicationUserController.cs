using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Web.Models;

using ExceedERP.DataAccess.Context;

namespace ExceedERP.Web.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
            public ActionResult Index()
        {

           
            return View();
        }

        private AccountController account;
        
        public ActionResult ApplicationUsers_Read([DataSourceRequest]DataSourceRequest request)
        {
            account  = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            List<ApplicationUser> applicationUsers = account.GetUsers();
            List<RegisterViewModel> userList = new List<RegisterViewModel>();
            foreach (ApplicationUser user in applicationUsers)
            {
                RegisterViewModel registerViewModel = new RegisterViewModel();
                registerViewModel.Id = user.Id;
                registerViewModel.Email = user.Email;
                registerViewModel.UserName = user.UserName;
                registerViewModel.FirstName = user.FirstName;
                registerViewModel.MiddleName = user.MiddleName;
                registerViewModel.LastName = user.LastName;
                registerViewModel.PhoneNo = user.PhoneNo;
                  registerViewModel.EmployeeId = user.EmployeeId;
                userList.Add(registerViewModel);
            }
            IQueryable<RegisterViewModel> erpUsers = userList.AsQueryable();
            DataSourceResult result = erpUsers.ToDataSourceResult(request, user => new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.FirstName,
                user.MiddleName,
                user.LastName,
                user.PhoneNo,
                user.EmployeeId

            });
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Create([DataSourceRequest]DataSourceRequest request, RegisterViewModel applicationUser)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            applicationUser.MiddleName = "KKK";
            applicationUser.FirstName = "KKK";
           // if (ModelState.IsValid)
           // {

                var checkExistance = db.Users.Where(x => x.EmployeeId == applicationUser.EmployeeId).FirstOrDefault();
                if (checkExistance != null)
                {
                    ModelState.AddModelError("", "The Employee is already exist!!");
                }
                else
                {
                    account.Register(applicationUser);
                }

          //  }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Update([DataSourceRequest]DataSourceRequest request, RegisterViewModel applicationUser)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
               
                account.Edit(applicationUser);
            }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Destroy([DataSourceRequest]DataSourceRequest request, RegisterViewModel applicationUser)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                account.DeleteConfirmed(applicationUser.Id);
            }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }
        private ApplicationGroupManager _groupManager;
        public ApplicationGroupManager GroupManager
        {
            get
            {
                return _groupManager ?? new ApplicationGroupManager();
            }
            private set
            {
                _groupManager = value;
            }
        }
        //private ApplicationBranchManager _branchManager;
        //public ApplicationBranchManager BranchManager
        //{
        //    get
        //    {
        //        return _branchManager ?? new ApplicationBranchManager();
        //    }
        //    private set
        //    {
        //        _branchManager = value;
        //    }
        //}
        public ActionResult Groups(GroupViewModel[] result)
        {
            var model = result[result.Length - 1];
            result = result.Where(x => x.Id != model.Id && x.Name != "masterGridParameter").ToArray();

            string[] groupIds = result.Select(x => x.Id).ToArray();

            if (model.Id != null)
            {
                GroupManager.SetUserGroups(model.Id, groupIds); 
            }
           
            return Json(result); 
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingBranches_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BranchVm> products, string id)
        {
            db = new ApplicationDbContext();
            var results = new List<BranchVm>();
            BranchVm branchVm = new BranchVm();
            ExceedDbContext dbs = new ExceedDbContext();

            UserBranchGroup userBranches = new UserBranchGroup();


         
            int Count = 0;

            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {

                   
                    dbs = new ExceedDbContext();
                    var userBranch = db.UserBranches .Where(x => x.UserBranchId == product.BranchId.ToString() && x.ApplicationUserId == id).FirstOrDefault();
                    userBranches = new UserBranchGroup();
                    if (userBranch != null)
                    {                        
                        db.UserBranches.Remove(userBranch);
                        db.SaveChanges();
                    }
                    
                        userBranches.ApplicationUserId = id;
                        userBranches.UserBranchId = product.BranchId;
                    if (product .IsDefault  && Count ==0)
                    {
                        Count = 1;
                        userBranches.IsDefault = product.IsDefault;
                        db.UserBranches.Add(userBranches);
                        db.SaveChanges();
                        continue;
                    }                                         
                  
                    if (product.IsAllowed)
                    {

                        db.UserBranches.Add(userBranches);                        
                        db.SaveChanges();
                       
                    }
                }
            }


            return Json(results.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Branches(BranchVm result, string id)
        {
            //var model = result[result.Length - 1];
            //result = result.Where(x => x.BranchId != model.BranchId && x.BranchName != "masterGridParameter").ToArray();

            //string[] branchId = result.Select(x => x.BranchId).Distinct().ToArray();

            //if (model.BranchId != null)
            //{
           // BranchManager.SetUsersBranch(id,result); 
            //}
           
            return Json(result); 
        }
        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        public string GetFullName(int empId)
        {

            return "";
        }
        public ActionResult Branch_Read([DataSourceRequest]DataSourceRequest request, int Id)

        {
            List<BranchVm> modelList = new List<BranchVm>();
            var usersBranch = db.UserBranches;
            BranchVm branchVm = new BranchVm();
            ExceedDbContext dbExceed = new ExceedDbContext();
            //var branchList = dbExceed.Branch;
            //foreach (var b in branchList)
            //{
            //    branchVm = new BranchVm();
            //    branchVm.BranchName = b.Name;
            //    var check = usersBranch.Where(x => x.UserBranchId == b.BranchId.ToString () && x.ApplicationUserId == Id.ToString ()).FirstOrDefault();
            //    if (check !=null)
            //    {
            //        branchVm.IsAllowed = true;
            //        branchVm.IsDefault = check.IsDefault;
            //    }
            //    else
            //    {
            //        branchVm.IsAllowed = false;
            //    }
            //    modelList.Add(branchVm);
                
            //}
            IQueryable<BranchVm> branchs = modelList.AsQueryable ();
            DataSourceResult result = branchs.ToDataSourceResult(request, branch => new
            {

                BranchName = branch.BranchName,
                Remark = branch.Remark,
                IsAllowed = branch.IsAllowed,
                IsDeafult = branch.IsDefault,
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
