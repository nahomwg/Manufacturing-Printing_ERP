﻿using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Web.Models;
using Microsoft.AspNet.Identity;

namespace ExceedERP.Web.Controllers
{
    public class ApplicationRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        private static AccountController account;
        public ActionResult RoleViewModels_Read([DataSourceRequest]DataSourceRequest request , string id)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            ApplicationGroup applicationGroup = account.GroupManager.FindById(id);
           
            List<ApplicationRole> applicationRoles = account.GetRoles();

            List<string> roleInGroup = new List<string>();
            if (id != null)
            {
              roleInGroup =   applicationGroup.ApplicationRoles.Where(x => x.ApplicationGroupId == id).Select(x =>x.ApplicationRoleId).ToList(); 
           
            }
                List<string> roleId = applicationRoles.Select(x => id).ToList(); 
          
            List<RoleViewModel> roleList = new List<RoleViewModel>();
            foreach (ApplicationRole role in applicationRoles)
            { 
                RoleViewModel viewModel = new RoleViewModel();
                if (roleInGroup.Contains(role.Id))
                {
                    viewModel.IsIngroup = true; 
                }
                else
                {
                    viewModel.IsIngroup = false; 
                }
              
                viewModel.Description = role.Description;
                viewModel.RoleViewModelId = role.Id;
                viewModel.Name = role.Name;
                viewModel.Category = role.Category;
                roleList.Add(viewModel);
            }
            IQueryable<RoleViewModel> roleviewmodels = roleList.AsQueryable();
            DataSourceResult result = roleviewmodels.ToDataSourceResult(request, roleViewModel => new {
                RoleViewModelId = roleViewModel.RoleViewModelId,
                Name = roleViewModel.Name,
                IsIngroup = roleViewModel.IsIngroup,
                
                Category = roleViewModel.Category,
                Description = roleViewModel.Description
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RoleViewModels_Create([DataSourceRequest]DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new RoleViewModel
                {
                    Name = roleViewModel.Name,
                    Description = roleViewModel.Description
                };

                db.RoleViewModels.Add(entity);
                db.SaveChanges();
                roleViewModel.RoleViewModelId = entity.RoleViewModelId;
            }

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RoleViewModels_Update([DataSourceRequest]DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new RoleViewModel
                {
                    RoleViewModelId = roleViewModel.RoleViewModelId,
                    Name = roleViewModel.Name,
                    Description = roleViewModel.Description
                };

                db.RoleViewModels.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));
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

        public ActionResult UserRole_Read([DataSourceRequest] DataSourceRequest request, string id)
        {
            account = new AccountController(ApplicationUserManager.Usermgr, ApplicationSignInManager.SignInManager);
            ApplicationUser user = account.UserManager.FindById(id);
            List<ApplicationGroup> userAppGroups = GroupManager.GetUserGroups(id).ToList();


            List<ApplicationRole> applicationRoles = new List<ApplicationRole>();
            foreach (ApplicationGroup group in userAppGroups)
            {
                List<ApplicationRole> roleIngroup = new List<ApplicationRole>();
                  roleIngroup =   GroupManager.GetGroupRoles(group.Id).ToList(); 
                  applicationRoles.AddRange(roleIngroup);
            }
            applicationRoles = applicationRoles.GroupBy(x => x.Id).Select(x => x.FirstOrDefault()).ToList(); 

            List<RoleViewModel> roleList = new List<RoleViewModel>();
            foreach (ApplicationRole role in applicationRoles)
            {
                RoleViewModel viewModel = new RoleViewModel();
                

                viewModel.Description = role.Description;
                viewModel.RoleViewModelId = role.Id;
                viewModel.Name = role.Name;
                roleList.Add(viewModel);
            }
            IQueryable<RoleViewModel> roleviewmodels = roleList.AsQueryable();
            DataSourceResult result = roleviewmodels.ToDataSourceResult(request, roleViewModel => new
            {
                RoleViewModelId = roleViewModel.RoleViewModelId,
                Name = roleViewModel.Name,
                IsIngroup = roleViewModel.IsIngroup,
                Description = roleViewModel.Description
            });

            return Json(result);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RoleViewModels_Destroy([DataSourceRequest]DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new RoleViewModel
                {
                    RoleViewModelId = roleViewModel.RoleViewModelId,
                    Name = roleViewModel.Name,
                    Description = roleViewModel.Description
                };

                db.RoleViewModels.Attach(entity);
                db.RoleViewModels.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));
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
