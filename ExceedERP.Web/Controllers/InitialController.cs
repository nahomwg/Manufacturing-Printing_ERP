using ExceedERP.Core.Domain.printing.JobCosting;
using ExceedERP.Core.Domain.printing.PrintingEstimation;
using ExceedERP.Core.Domain.Printing.ProductionFollowUp;
using ExceedERP.Core.Domain.Manufacturing.FurnitureEstimation;
using ExceedERP.Core.Domain.Manufacturing.ProductionFollowUp;
using ExceedERP.Core.Domain.Manufacturing.JobCosting;
using ExceedERP.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceedERP.Web.Controllers
{

    public class InitialController : BaseController
    {

        private const string InitialUserName = "tester";
        private const string InitialUserFirstName = "TestFirstName";
        private const string InitialUserLastName = "TestLastName";
        private const string InitialUserEmail = "test@test.com";
        private const string InitialUserPassword = "Password1";

        private const string VaniallaUserName = "VanillaUser";
        private const string VaniallaUserFirstName = "VanillaFirstName";
        private const string VaniallaUserLastName = "VanillaLastName";
        private const string VaniallaUserEmail = "vanilla@test.com";
        private const string VaniallaUserPassword = "Password1";
        private static readonly ApplicationDbContext _db = new ApplicationDbContext();

        private static readonly string[] _groupAdminRoleNames = { "CanEditUser", "CanEditGroup", "User" };


        private static readonly string[] _initialGroupNames = { "SuperAdmins", "GroupAdmins", "UserAdmins", "Users" };


        private static readonly string[] _superAdminRoleNames = { "Admin", "CanEditUser", "CanEditGroup", "CanEditRole", "User" };
        private static readonly string[] _userAdminRoleNames = { "CanEditUser", "User" };
        private static readonly string[] _userRoleNames = { "User" };


        public ActionResult AddRoles()
        {
            ApplicationUserManager userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationRoleManager roleManager = System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            AddRoles(roleManager);



            return View("Success");
        }

        public ActionResult Initial()
        {
            ApplicationUserManager userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationRoleManager roleManager = System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            AddRoles(roleManager);

            AddUsers(userManager);
            var groupManager = new ApplicationGroupManager();

            AddGroups(groupManager);
            AddRolesToGroups(groupManager);
            AddUsersToGroups(groupManager);

            return View("Success");
        }

        public static void AddGroups(ApplicationGroupManager _idManager)
        {
            foreach (var groupName in _initialGroupNames)
            {
                ApplicationGroup applicationGroup = new ApplicationGroup(groupName);

                _idManager.CreateGroup(applicationGroup);

            }
        }

        private static void AddRoles(ApplicationRoleManager roleManager)
        {
            List<ApplicationRole> applicationRoles = new List<ApplicationRole>
            {
                 #region APTS Roles
                new ApplicationRole("Admin_Module","Module Admin","APTS"),
                new ApplicationRole("Admin_Regional","Branch Admin","APTS"),
                 new ApplicationRole("APTS_Laboratory","User of APTS Laboratory","APTS"),
                new ApplicationRole("APTS_Emergency","User of APTS Emergency","APTS"),

                #endregion
                #region APTS Roles
                new ApplicationRole("APTS_Admin","Approve and see","APTS"),
                new ApplicationRole("APTS_Despensary","Request Drugs","APTS"),
                new ApplicationRole("APTS_DrugStore","Manage Drugs","APTS"),
                new ApplicationRole("APTS_Accountant","Manage balance","APTS"),
                new ApplicationRole("APTS_User","Apts User","APTS"), 

                #endregion

                   #region info desk
                    new ApplicationRole("HelpDeskAdmin", "HelpDeskAdmin", "HelpDesk"),
                    new ApplicationRole("OpenTicket", "OpenTicket", "HelpDesk"),
                    new ApplicationRole("AssignHandler", "AssignHandler", "HelpDesk"),
                    new ApplicationRole("Handler", "Handler", "HelpDesk"),
                    new ApplicationRole("HelpDesk_Report", "View Report", "HelpDesk"),
                    new ApplicationRole("HelpDesk_Setting", "Add Help desk settings", "HelpDesk"),
                    #endregion

                #region dashboard
                new ApplicationRole("Admin_Regional","To see dashboard reports","Administrator"),


                #endregion

                #region dashboard
            new ApplicationRole("Dashboard_HR","To see dashboard reports","Global"),
            new ApplicationRole("Dashboard_Finance","To see dashboard reports","Global"),
            new ApplicationRole("Dashboard_Inventory","To see dashboard reports","Global"),
            new ApplicationRole("Dashboard_Procurement","To see dashboard reports","Global"),


           #endregion
          
           
                #region HR roles
                 new ApplicationRole("GenerateDayAbsent", "GenerateDayAbsent", "HR"),
                 new ApplicationRole("SalaryStructure", "SalaryStructure", "HR"),
                 new ApplicationRole("Miscellaneous", "Miscellaneous", "HR"),
                 new ApplicationRole("ManPowerPlanning", "Man Power Planning", "HR"),
                new ApplicationRole("LeaveExpire", "Leave Expire", "HR"),
                new ApplicationRole("LeaveExpireReverse", "Leave Expire Reverse", "HR"),
                new ApplicationRole("HR_Performance_Approver","Approve employee performance","HR"),
                new ApplicationRole("HR_EmployeeArchive","Manage Employee Archive","HR"),
                new ApplicationRole("HR_InstitutionArchive","Manage Institution Archive","HR"),
                new ApplicationRole("HR_Admin","HR Configuration and settings","HR"),
                new ApplicationRole("HR_Department_Head","HR Department Heads","HR"),
                new ApplicationRole("HR_Report","HR Reports view and print","HR"),
                new ApplicationRole("HR_Leave_User","Manage leave functionality by HR personnel","HR"),
                new ApplicationRole("HR_Leave_Admin","Manage leave setting functionality by HR personnel administrator","HR"),
                new ApplicationRole("HR_Leave_Approver","Approve , pend or reject all leave requests","HR"),
                new ApplicationRole("HR_Leave_Report","View leave reports","HR"),
                new ApplicationRole("HR_Employee_SelfService","Employees can view information or fill request","HR"),
                new ApplicationRole("HR_Manager_SelfService","Managers can view information or request from employees","HR"),
                new ApplicationRole("HR_Company_Admin","Manage company structure setting functionalities","HR"),
                new ApplicationRole("HR_Company_User","Manage company stricture functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Profile_Admin","Manage basic employee profile  setting functionalities","HR"),
                new ApplicationRole("HR_Profile_User","Manage basic employee profile  setting functionalities","HR"),
                new ApplicationRole("HR_Recruitment_Admin","Manage recruitment settings of HR recruitment functionalities","HR"),
                new ApplicationRole("HR_Recruitment_User","Manage recruitment functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Recruitment_Approver","Approve , pend or reject all recruitment requests","HR"),
                new ApplicationRole("HR_Recruitment_Report","View recruitment  reports","HR"),
                new ApplicationRole("HR_Placement_Admin","Manage placement functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Placement_User","Manage placement functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Attendance_User","Manage attendance functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Benefit_Admin","Manage benefit functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Benefit_User","Manage benefit functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Training_User","Manage training functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Training_Need_Approver","approve training functionalities by HR training  depart Need","HR"),
                new ApplicationRole("HR_Training_Approver","Approve , pend or reject all training  requests","HR"),
                new ApplicationRole("HR_Performance_Admin","Manage all performance settings and functionalities","HR"),
                new ApplicationRole("HR_Performance_User","Manage performance functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Performance_Report","View performance  reports","HR"),
                new ApplicationRole("HR_Discipline_User","Manage discipline functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Termination_User","Manage termination functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Letters_User","Manage letters functionalities by HR archiver","HR"),
                new ApplicationRole("HR_PrintableDocuments_User","Manage printable documents functionalities by HR personnel","HR"),
                new ApplicationRole("HR_Recruitment_Requester", "Request Recruitment", "HR"),
                new ApplicationRole("HR_Training_Requester", "Request Training", "HR"),
                new ApplicationRole("Announcement", "Announcement", "HR"),
                new ApplicationRole("PlacementDeActivateByBranch","De-Activate Employees Based on Branch","HRM"),


                 #endregion

                #region Archive
                new ApplicationRole("Archive_Admin","Manage archive Settings and configurations by Archive administrator","Archive "),
                new ApplicationRole("Archive_User","Manage archive functionalities by Archiver","Archive "),
                new ApplicationRole("Archive_Report","View archive  reports","Archive "),
                  #endregion

                #region Health
                new ApplicationRole("Health_Admin","Manage settings and configurations","Health"),
                new ApplicationRole("Health_User","Manage health and insurance functionalities","Health"),
                new ApplicationRole("Health_Approver","Approve , pend or reject all health  requests","Health"),
                #endregion

                #region insurance
                 new ApplicationRole("Insurance_Admin", "Manage settings and configurations", "Insurance"),
                 new ApplicationRole("Insurance_User", "Manage Insurance functionalities", "Insurance")
                #endregion

                #region 
                #endregion
               #region Printing
                #region Printing Estimation
                     ,new ApplicationRole(PrintingEstimationRoles.PrintingEstimationAdmin, "Printing Estimation Administrator", "Printing"),
                     new ApplicationRole(PrintingEstimationRoles.PrintingEstimationFormUser, "Printing Estimation Form User", "Printing"),
				    #endregion
		        #region Production FollowUp
				     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionAdmin, "Production FollowUp Administrator", "Printing"),
                     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionSetting, "Production FollowUp Setting", "Printing"),
                     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionReport, "Production FollowUp Report", "Printing"),
                     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionProformaUser, "Production FollowUp Proforma User", "Printing"),
                     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionJobOrderUser, "Production FollowUp Job Order User", "Printing"),
                     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionFinishedGoodUser, "Production FollowUp Finished Good User", "Printing"),
                     new ApplicationRole(ProductionFollowUpRoles.PrintingProductionDeliveryUser, "Production FollowUp Delivery User", "Printing"),
				    #endregion
			    #region Job Costing FollowUp
				     new ApplicationRole(JobCostingRoles.JobCostingAdmin, "Job Costing Administrator", "Printing"),
                     new ApplicationRole(JobCostingRoles.JobCostingJobCostUser, "Job Costing Job Cost User", "Printing"),
                     new ApplicationRole(JobCostingRoles.JobCostingDailyLaborRateUser, "Job Costing Daily Labor RateUser", "Printing"),
                     new ApplicationRole(JobCostingRoles.JobCostingIdleTimeUser, "JobCosting Idle Time User", "Printing")
                #endregion
             #endregion
               #region Manufucturing
                #region Furniture Estimation
                     ,new ApplicationRole(FurnitureEstimationRoles.FurnitureEstimationAdmin, "Furniture Estimation Administrator", "Manufucturing"),
                     new ApplicationRole(FurnitureEstimationRoles.FurnitureEstimationUser, "Furniture Estimation Form User", "Manufucturing"),
				    #endregion
		        #region Production FollowUp
				     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionAdmin, "Production FollowUp Administrator", "Manufucturing"),
                     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionSetting, "Production FollowUp Setting", "Manufucturing"),
                     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionReport, "Production FollowUp Report", "Manufucturing"),
                     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionProformaUser, "Production FollowUp Proforma User", "Manufucturing"),
                     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionJobOrderUser, "Production FollowUp Job Order User", "Manufucturing"),
                     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionFinishedGoodUser, "Production FollowUp Finished Good User", "Manufucturing"),
                     new ApplicationRole(ManufacturingProductionFollowUpRoles.ManufacturingProductionDeliveryUser, "Production FollowUp Delivery User", "Manufucturing"),
				    #endregion
			    #region Job Costing FollowUp
				     new ApplicationRole(ManufacturingJobCostingRoles.ManufacturingJobCostingAdmin, "JobCosting_Admin", "Manufucturing"),
                     new ApplicationRole(ManufacturingJobCostingRoles.ManufacturingJobCostingJobCostUser, "JobCosting_JobCost_User", "Manufucturing"),
                     new ApplicationRole(ManufacturingJobCostingRoles.ManufacturingJobCostingIdleTimeUser, "JobCosting_IdleTime_User", "Manufucturing"),
                     new ApplicationRole(ManufacturingJobCostingRoles.ManufacturingJobCostingDailyLaborRateUser, "JobCosting_DailyLaborRate_User", "Manufucturing"),
                #endregion
             #endregion
                //#region Planning Roles
                //    new ApplicationRole("Planning_Admin","Create data, Upload panning Data","Planning"),
                //    new ApplicationRole("Planning_User","See, dowload","Planning"),
                //    new ApplicationRole("Planning_Risk_User","See, risk","Planning")

                //#endregion
            };
            //List<ApplicationRole> planningRoles = new List<ApplicationRole>
            //{
            //    #region Planning Roles
            //    new ApplicationRole(PlanningRoles.Planning_Admin,"Create data, Upload panning Data","Planning"),
            //    new ApplicationRole(PlanningRoles.Planning_User,"See, dowload","Planning"),
            //    new ApplicationRole(PlanningRoles.Planning_Risk_User,"See, risk","Planning")

            //    #endregion

            //};

            foreach (ApplicationRole role in applicationRoles)
            {
                roleManager.Create(role);
            }
            //foreach (ApplicationRole role in planningRoles)
            //{
            //    roleManager.Create(role);
            //}

        }

        private static void AddRolesToGroups(ApplicationGroupManager groupManager)
        {
            // Add the Super-Admin Roles to the Super-Admin Group:
            IDbSet<ApplicationGroup> allGroups = _db.ApplicationGroups;
            ApplicationGroup superAdmins = allGroups.First(g => g.Name == "SuperAdmins");
            groupManager.SetGroupRoles(superAdmins.Id, _superAdminRoleNames);


            // Add the Group-Admin Roles to the Group-Admin Group:
            ApplicationGroup groupAdmins = _db.ApplicationGroups.First(g => g.Name == "GroupAdmins");
            groupManager.SetGroupRoles(groupAdmins.Id, _groupAdminRoleNames);


            // Add the User-Admin Roles to the User-Admin Group:
            ApplicationGroup userAdmins = _db.ApplicationGroups.First(g => g.Name == "UserAdmins");
            groupManager.SetGroupRoles(userAdmins.Id, _userAdminRoleNames);


            // Add the User Roles to the Users Group:
            ApplicationGroup users = _db.ApplicationGroups.First(g => g.Name == "Users");
            groupManager.SetGroupRoles(users.Id, _userRoleNames);

        }

        // Change these to your own:

        private static void AddUsers(ApplicationUserManager userManager)
        {
            var newUser = new ApplicationUser
            {
                UserName = InitialUserName,
                FirstName = InitialUserFirstName,
                LastName = InitialUserLastName,
                Email = InitialUserEmail
            };


            var userCreationResult = userManager.Create(newUser, InitialUserPassword);
            if (!userCreationResult.Succeeded)
            {
                throw new DbEntityValidationException("Could not create InitialUser because: " + String.Join(", ", userCreationResult.Errors));
            }

            var newVaniallaUser = new ApplicationUser
            {
                UserName = VaniallaUserName,
                FirstName = VaniallaUserFirstName,
                LastName = VaniallaUserLastName,
                Email = VaniallaUserEmail
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            userCreationResult = userManager.Create(newVaniallaUser, VaniallaUserPassword);
            if (!userCreationResult.Succeeded)
            {
                // warn the user that it's seeding went wrong
                throw new DbEntityValidationException("Could not create VaniallaUser because: " + String.Join(", ", userCreationResult.Errors));
            }
        }

        // Configure the initial Super-Admin user:
        private static void AddUsersToGroups(ApplicationGroupManager groupManager)
        {

            ApplicationUser user = _db.Users.First(u => u.UserName == InitialUserName);
            IDbSet<ApplicationGroup> allGroups = _db.ApplicationGroups;
            foreach (ApplicationGroup group in allGroups)
            {
                groupManager.SetUserGroups(user.Id, group.Id);
            }

            user = _db.Users.FirstOrDefault(u => u.UserName == VaniallaUserName);
            var plainUsers = allGroups.FirstOrDefault(g => g.Name == "Users");
            groupManager.SetUserGroups(user.Id, plainUsers.Id);
        }

    }
}
