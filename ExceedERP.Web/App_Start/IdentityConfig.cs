using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ExceedERP.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace ExceedERP.Web
{

    public class ApplicationUserManager : UserManager<ApplicationUser, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, string> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Usermgr;

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(1);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            Usermgr = manager;
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public static ApplicationRoleManager RoleManager;
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            RoleManager = new ApplicationRoleManager(new ApplicationRoleStore(context.Get<ApplicationDbContext>()));
            return RoleManager;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }
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

        public static void InitializeIdentityForEf(ApplicationDbContext db)
        {
            db.Configuration.LazyLoadingEnabled = true;
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationRoleManager roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();


            AddRoles(roleManager);

            AddUsers(userManager);
            var groupManager = new ApplicationGroupManager();

            AddGroups(groupManager);
            AddRolesToGroups(groupManager);
            AddUsersToGroups(groupManager);

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
            #region General
             
            #endregion
           
            
            };

            foreach (ApplicationRole role in applicationRoles)
            {
                roleManager.Create(role);
            }


        }

        private static void AddRolesToGroups(ApplicationGroupManager groupManager)
        {
            // Add the Super-Admin Roles to the Super-Admin Group:
            IDbSet<ApplicationGroup> allGroups = _db.ApplicationGroups;
            ApplicationGroup superAdmins = allGroups.First(g => g.Name == "SuperAdmins");
            groupManager.SetGroupRoles(superAdmins.Id, _groupAdminRoleNames);


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

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public static ApplicationSignInManager SignInManager;

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool rememberMe, bool shouldLockout)
        {
            var user = UserManager.FindByNameAsync(userName).Result;
            if (user != null)
            {
                if (!user.IsEnabled)
                {
                    return Task.FromResult<SignInStatus>(SignInStatus.LockedOut);
                }
            }


            return base.PasswordSignInAsync(userName, password, rememberMe, shouldLockout);
        }
        /// <summary>
        /// user for Basic Authentication 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SimpleSignIn(string userName, string password, bool rem, bool canLock)
        {
            var stat = base.PasswordSignInAsync(userName, password, rem, canLock).Result;
            if (stat == SignInStatus.Success)
            {
                return true;
            }
            else return false;
        }
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            var signinmgr = new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            SignInManager = signinmgr;
            return signinmgr;
        }
    }
}