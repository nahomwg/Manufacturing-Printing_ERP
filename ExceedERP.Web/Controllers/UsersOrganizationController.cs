
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.Common;
using ExceedERP.DataAccess.Context;

namespace ExceedERP.Web.Controllers
{
    public class UsersOrganizationController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrgBranchUserMappings_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<OrgBranchUserMapping> orgbranchusermappings = db.OrgBranchUserMappings;
            DataSourceResult result = orgbranchusermappings.ToDataSourceResult(request, orgBranchUserMapping => new {
                OrgBranchUserMappingID = orgBranchUserMapping.OrgBranchUserMappingID,
                Branch = orgBranchUserMapping.Branch,
                User = orgBranchUserMapping.User,
                IsDefault = orgBranchUserMapping.IsDefault
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrgBranchUserMappings_Create([DataSourceRequest]DataSourceRequest request, OrgBranchUserMapping orgBranchUserMapping)
        {
            if (ModelState.IsValid)
            {
                var entity = new OrgBranchUserMapping
                {
                    Branch = orgBranchUserMapping.Branch,
                    User = orgBranchUserMapping.User,
                    IsDefault = orgBranchUserMapping.IsDefault
                };

                db.OrgBranchUserMappings.Add(entity);
                db.SaveChanges();
                orgBranchUserMapping.OrgBranchUserMappingID = entity.OrgBranchUserMappingID;
            }

            return Json(new[] { orgBranchUserMapping }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrgBranchUserMappings_Update([DataSourceRequest]DataSourceRequest request, OrgBranchUserMapping orgBranchUserMapping)
        {
            if (ModelState.IsValid)
            {
                var entity = new OrgBranchUserMapping
                {
                    OrgBranchUserMappingID = orgBranchUserMapping.OrgBranchUserMappingID,
                    Branch = orgBranchUserMapping.Branch,
                    User = orgBranchUserMapping.User,
                    IsDefault = orgBranchUserMapping.IsDefault
                };

                db.OrgBranchUserMappings.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { orgBranchUserMapping }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrgBranchUserMappings_Destroy([DataSourceRequest]DataSourceRequest request, OrgBranchUserMapping orgBranchUserMapping)
        {
            if (ModelState.IsValid)
            {
                var entity = new OrgBranchUserMapping
                {
                    OrgBranchUserMappingID = orgBranchUserMapping.OrgBranchUserMappingID,
                    Branch = orgBranchUserMapping.Branch,
                    User = orgBranchUserMapping.User,
                    IsDefault = orgBranchUserMapping.IsDefault
                };

                db.OrgBranchUserMappings.Attach(entity);
                db.OrgBranchUserMappings.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { orgBranchUserMapping }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
