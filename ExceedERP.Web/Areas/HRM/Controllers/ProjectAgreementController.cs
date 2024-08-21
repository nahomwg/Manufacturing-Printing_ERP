﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.ProjectManagement;
using ExceedERP.DataAccess.Context;

namespace ExceedERP.Web.Areas.ProjectManagement.Controllers
{
    public class ProjectAgreementController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            var projectInfo = db.ProjectInfos.Select(s => new
            {
                s.ProjectInfoId,
                s.ProjectName
            }).ToList();

            ViewData["ProjectInfo"] = projectInfo;
            return View();
        }

        public ActionResult ProjectAgreements_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ProjectAgreement> projectagreements = db.ProjectAgreements;
            DataSourceResult result = projectagreements.ToDataSourceResult(request, projectAgreement => new {
                ProjectAgreementId = projectAgreement.ProjectAgreementId,
                ProjectName = projectAgreement.ProjectName,
                Currency = projectAgreement.Currency,
                AgreedPrice = projectAgreement.AgreedPrice,
                PaymentRound = projectAgreement.PaymentRound,
                TaxType = projectAgreement.TaxType,
                ProjectInfoId = projectAgreement.ProjectInfoId

            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectAgreements_Create([DataSourceRequest]DataSourceRequest request, ProjectAgreement projectAgreement)
        {
            if (ModelState.IsValid)
            {
                var projectInfo = db.ProjectInfos.FirstOrDefault(x => x.ProjectInfoId == projectAgreement.ProjectInfoId);
                var entity = new ProjectAgreement
                {
                    ProjectName = projectInfo.ProjectName,
                    Currency = projectAgreement.Currency,
                    AgreedPrice = projectAgreement.AgreedPrice,
                    PaymentRound = projectAgreement.PaymentRound,
                    TaxType = projectAgreement.TaxType,
                    ProjectInfoId = projectAgreement.ProjectInfoId,
                    ProjectInfo = projectAgreement.ProjectInfo
                    
                };
              
                db.ProjectAgreements.Add(entity);
                db.SaveChanges();
                projectAgreement.ProjectAgreementId = entity.ProjectAgreementId;

                // 
                GeneratePaymentSchedule(projectAgreement);
            }

            return Json(new[] { projectAgreement }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectAgreements_Update([DataSourceRequest]DataSourceRequest request, ProjectAgreement projectAgreement)
        {
            if (ModelState.IsValid)
            {
                var entity = new ProjectAgreement
                {
                    ProjectAgreementId = projectAgreement.ProjectAgreementId,
                    ProjectName = projectAgreement.ProjectName,
                    Currency = projectAgreement.Currency,
                    AgreedPrice = projectAgreement.AgreedPrice,
                    PaymentRound = projectAgreement.PaymentRound,
                    TaxType = projectAgreement.TaxType,
                    ProjectInfoId = projectAgreement.ProjectInfoId,
                    ProjectInfo = projectAgreement.ProjectInfo
                };

                db.ProjectAgreements.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();

                ReGeneratePaymentSchedule(projectAgreement);
            }

            return Json(new[] { projectAgreement }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectAgreements_Destroy([DataSourceRequest]DataSourceRequest request, ProjectAgreement projectAgreement)
        {
            if (ModelState.IsValid)
            {
                var exPaymentSchedules = db.ProjectPaymentSchedules.Where(x => x.ProjectAgreementId == projectAgreement.ProjectAgreementId);
                if (exPaymentSchedules.Any())
                {
                    db.ProjectPaymentSchedules.RemoveRange(exPaymentSchedules);
                    db.SaveChanges();
                }
                
                var exProjectAgreement = db.ProjectAgreements.Find(projectAgreement.ProjectAgreementId);
                if (exProjectAgreement != null)
                {
                    db.ProjectAgreements.Remove(exProjectAgreement);
                    db.SaveChanges();
                }
                      
               
            }

            return Json(new[] { projectAgreement }.ToDataSourceResult(request, ModelState));
        }


        private void GeneratePaymentSchedule(ProjectAgreement projectAgreement)
        {
           
            if(projectAgreement != null)
            {
                List<ProjectPaymentSchedule> paymentSchedules = new List<ProjectPaymentSchedule>();

                var numberOfItems = (decimal)projectAgreement.PaymentRound;
                decimal dividedAmount = projectAgreement.AgreedPrice / numberOfItems;
                decimal percentage = dividedAmount / projectAgreement.AgreedPrice;
                decimal percent = CalculatePercentage(dividedAmount, projectAgreement.AgreedPrice);
                decimal p = 100.0m / projectAgreement.PaymentRound;
                if (projectAgreement != null)
                {
                    for (int i = 0; i < projectAgreement.PaymentRound; i++)
                    {

                        var paymentSchedule = new ProjectPaymentSchedule
                        {
                            ProjectAgreementId = projectAgreement.ProjectAgreementId,
                            Percentage = 0.0m,
                            Amount = 0.0m,
                            Description = "",
                            DueDate = DateTime.Now,
                            PaymentRoundName = i == 0 ? "Advance Payment" : i == 1 ? i + "st Payment" : i == 2 ? i + "nd Payment" : i == 3 ? i + "rd Payment" : i + "th Payment"
                        };

                        db.ProjectPaymentSchedules.Add(paymentSchedule);
                        db.SaveChanges();
                    }

                }
                
            }
            
        }
        private void ReGeneratePaymentSchedule(ProjectAgreement projectAgreement)
        {
            var exSchedules = db.ProjectPaymentSchedules.Where(x => x.ProjectAgreementId == projectAgreement.ProjectAgreementId);
            db.ProjectPaymentSchedules.RemoveRange(exSchedules);
            db.SaveChanges();
            GeneratePaymentSchedule(projectAgreement);

        }
        private decimal CalculatePercentage(decimal value, decimal total)
        {
            return (value / total) * 100.0m;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
