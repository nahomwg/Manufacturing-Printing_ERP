using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Web.Models;

namespace ExceedERP.Web.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        private AccountController account;
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

        public ActionResult Roles(RoleViewModel[] result )
        {
            var model = result[result.Length - 1];
            result = result.Where(x => x.RoleViewModelId != model.RoleViewModelId && x.Name != "masterGridParameter").ToArray(); 
            
            string[] roles = result.Select(x => x.Name).ToArray();
            var group =    GroupManager.FindById(model.RoleViewModelId);
           GroupManager.SetGroupRoles(model.RoleViewModelId , roles);
            return Json(result);

        }

        public ActionResult ApplicationGroups_Read([DataSourceRequest]DataSourceRequest request)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            List<ApplicationGroup> applicationGroups = account.GetApplicationGroups();
            List<GroupViewModel> groupList = new List<GroupViewModel>();
            foreach (ApplicationGroup applicationGroup in applicationGroups)
            {
                GroupViewModel registerViewModel = new GroupViewModel();
                registerViewModel.Id = applicationGroup.Id;
                registerViewModel.Name = applicationGroup.Name;
                registerViewModel.Description = applicationGroup.Description;
                 
                groupList.Add(registerViewModel);
            }
            IQueryable<GroupViewModel> groups = groupList.AsQueryable();
            DataSourceResult result = groups.ToDataSourceResult(request, group => new {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                 
            });

            return Json(result);
        }

        public ActionResult ApplicationUserGroups([DataSourceRequest] DataSourceRequest request, string id)
        {
            var userGroups =   GroupManager.GetUserGroups(id).ToList();
            List<string> userGroupId = userGroups.Select(x => x.Id).ToList(); 
             account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            List<ApplicationGroup> applicationGroups = account.GetApplicationGroups();
            List<GroupViewModel> groupList = new List<GroupViewModel>();
            foreach (ApplicationGroup applicationGroup in applicationGroups)
            {
                GroupViewModel registerViewModel = new GroupViewModel();
                if (userGroupId.Contains(applicationGroup.Id))
                {
                    registerViewModel.IsAllowed = true; 

                }
                else
                {
                    registerViewModel.IsAllowed = false;
                }
                registerViewModel.Id = applicationGroup.Id;
                registerViewModel.Name = applicationGroup.Name;
                registerViewModel.Description = applicationGroup.Description;
                 
                groupList.Add(registerViewModel);
            }
            IQueryable<GroupViewModel> groups = groupList.AsQueryable();
            DataSourceResult result = groups.ToDataSourceResult(request, group => new {
                Id = group.Id,
                IsAllowed = group.IsAllowed,
                Name = group.Name,
                Description = group.Description,
                 
            });

            return Json(result);
          
        }
        
        public ActionResult ApplicationGroups_Create([DataSourceRequest]DataSourceRequest request, GroupViewModel groupView)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                ApplicationGroup applicationGroup = new ApplicationGroup
                    {
                        Name = groupView.Name,
                        Description = groupView.Description
                    };
                bool value = account.Create(applicationGroup);
                if (value)
                {
                    return Json(new[] { groupView }.ToDataSourceResult(request, ModelState));  
                }
            }

            return Json(new[] { groupView }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationGroups_Update([DataSourceRequest]DataSourceRequest request, GroupViewModel groupView)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);

            if (ModelState.IsValid)
            {
                var group =    GroupManager.FindById(groupView.Id);
            if (group == null)
            {
                return HttpNotFound();
            }
             
                group.Name = groupView.Name;
                group.Description = groupView.Description;
                GroupManager.UpdateGroup(group); 
            
               

                
            }

            return Json(new[] { groupView }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationGroups_Destroy([DataSourceRequest]DataSourceRequest request, GroupViewModel groupView)
        {
            if (ModelState.IsValid)
            {
                
 
           GroupManager.DeleteGroup(groupView.Id);
              
            }

            return Json(new[] { groupView }.ToDataSourceResult(request, ModelState));
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
