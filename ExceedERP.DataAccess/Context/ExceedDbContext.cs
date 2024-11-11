
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Address = ExceedERP.Core.Domain.Common.HRM.Address;
using Bank = ExceedERP.Core.Domain.Common.HRM.Bank;
using BankReference = ExceedERP.Core.Domain.Common.HRM.BankReference;
//using BinCardLine = ExceedERP.Core.Domain.Inventory.BinCardLine;
using Configuration = ExceedERP.Core.Domain.Common.HRM.Configuration;
//using ContractManagement = ExceedERP.Core.Domain.Procurement.Contract.ContractManagement;
using Country = ExceedERP.Core.Domain.Common.HRM.Country;
using Identification = ExceedERP.Core.Domain.Common.HRM.Identification;
using IndustryInvolved = ExceedERP.Core.Domain.Common.HRM.IndustryInvolved;
using Language = ExceedERP.Core.Domain.Common.HRM.Language;
using LanguageProficiency = ExceedERP.Core.Domain.Common.HRM.LanguageProficiency;
using Lookup = ExceedERP.Core.Domain.Common.HRM.Lookup;
using Period = ExceedERP.Core.Domain.Common.HRM.Period;
using Relation = ExceedERP.Core.Domain.Common.HRM.Relation;
using ExceedERP.Core.Domain.Common;
using ExceedERP.Core.Domain.Global;
using ExceedERP.Core.Domain.HRM.Payroll.MissingPayrollBackPays;
using ExceedERP.Core.Domain.Finance.GL;
using ExceedERP.Core.Domain.Common.HRM;
using ExceedERP.Core.Domain.FixedAsset;
using ExceedERP.Core.Domain.Printing;
using ExceedERP.Core.Domain.printing.JobCosting.Setting;
using ExceedERP.Core.Domain.Manufacturing.JobCosting.Setting;
using ExceedERP.Core.Domain.Manufacturing;
//using ExceedERP.Core.Domain.PrintingEstimation;
using ExceedERP.Core.Domain.CRM;
using ExceedERP.Core.Domain.Inventory;
using ExceedERP.Core.Domain.Inventory.ArchiveModel;
using ExceedERP.Core.Domain.HRM.Company;
using ExceedERP.Core.Domain.Procurement;
using ExceedERP.Core.Domain.FixedAsset.Depreciation;
using ExceedERP.Core.Domain.HRM.EmployeeDetail;
using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using ExceedERP.Core.Domain.HRM.PerformanceManagment;
using ExceedERP.Core.Domain.FixedAsset.Setting;
using ExceedERP.Core.Domain.printing.PrintingEstimation;
using ExceedERP.Core.Domain.Manufacturing.FurnitureEstimation;
using ExceedERP.Core.Domain.Printing.ProductionFollowUp;
using ExceedERP.Core.Domain.printing.JobCosting;
using ExceedERP.Core.Domain.Manufacturing.ProductionFollowUp;
using ExceedERP.Core.Domain.Manufacturing.JobCosting;
using System.Linq;
using System.Collections.Generic;
using ExceedERP.Core.Domain.Printing.PrintingEstimation;
using ExceedERP.Core.Domain.Manufacturing.Setting;
using ExceedERP.Core.Domain.Manufacturing.Production;

namespace ExceedERP.DataAccess.Context
{
    public class ExceedDbContext : DbContext
    {
        public object indexingCount;

        public ExceedDbContext()
            : base("ExceedDbContext")
        {
        }

        #region global

        //public DbSet<Core.Domain.Global.OrgBranchUserMapping> OrgBranchUserMappings { get; set; }
        public DbSet<Core.Domain.Global.GlobalUserAccessLog> GlobalUserAccessLog { get; set; }
        public DbSet<Core.Domain.Global.GlobalDeleteLog> GlobalDeleteLogs { get; set; }
        public DbSet<Core.Domain.Global.GlobalExportLog> GlobalExportLog { get; set; }
        public DbSet<Core.Domain.Global.GlobalBranchsetup> GlobalBranchsetups { get; set; }
        public DbSet<Core.Domain.Global.GlobalNotification> GlobalNotifications { get; set; }

        public DbSet<DefaultBranch> DefaultBranches { get; set; }
        //public System.Data.Entity.DbSet<Branch> Branches { get; set; }
        public DbSet<UserBusinessUnitMap> UserBusinessUnitMaps { get; set; }
       public DbSet<OrgBranchUserMapping> OrgBranchUserMappings { get; set; }
        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Configure default schema
            //  modelBuilder.HasDefaultSchema("EXCEED");

            // other code 
            Database.SetInitializer<ExceedDbContext>(null);

            #region common
            modelBuilder.Configurations.Add(new ConfigurationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new AddressEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new LookupEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PeriodEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new IndustryInvolvedEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new AttachmentEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new IdentificationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new LanguageEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new LanguageProficiencyEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new RelationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new CountryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new BankEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new BankReferenceEntityTypeConfiguration());
            #endregion



           
            #region Check print
            modelBuilder.Configurations.Add(new Context.CPBankEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.CPBankAccountEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.CPCheckBookEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.CPCheckBookCheckNumberEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new Context.CheckTemplateEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.CheckEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.CPPaymentVoucherEntityTypeConfiguration());
            #endregion
            #region printing 
                #region  Estimation
                #region Printing Estimation
                modelBuilder.Configurations.Add(new Context.PrintingStepEntityConfiguration());
                modelBuilder.Configurations.Add(new Context.EstimationFormEntityConfiguration());
                modelBuilder.Configurations.Add(new Context.MaterialCostEntityConfiguration());
                modelBuilder.Configurations.Add(new Context.LaborCostEntityConfiguration());
                modelBuilder.Configurations.Add(new Context.OverallCostEntityConfiguration());
                #endregion
                //#region Furniture
                //modelBuilder.Configurations.Add(new Context.FurnitureCategoryEntityConfiguration());
                //modelBuilder.Configurations.Add(new Context.FurnitureCostEstimationEntityConfiguration());
                //modelBuilder.Configurations.Add(new Context.FurnitureMaterialCostEntityConfiguration());
                //modelBuilder.Configurations.Add(new Context.DirectLaborCostEntityConfiguration());
                //modelBuilder.Configurations.Add(new Context.FurnitureOverallCostEntityConfiguration());
                ////modelBuilder.Configurations.Add(new Context.OverallCostEntityConfiguration());

                //#endregion
                #endregion

                #region Production Follow UP Entity Configuration
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.YearlyProductionPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.HalfYearlyProductionPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.QuarterlyProductionPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.MonthlyProductionPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.WeeklyProductionPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductionJobTypePlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductionCustomerTypeEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductionMonthlyJobTypePlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductionMonthlyPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductionYearlyPlanEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobCategoryEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProformaEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.GraphicEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobStatusEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.SettingsEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobOrderMaterialEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.PrintingProductionFinishedGoodsStoreReceiveEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.PrintingProductionFinishedGoodsStoreReceiveItemEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.PrintingProductionFinishedGoodsStoreReceiveValidationEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.PrintingProductionFinishedGoodsStoreReceiveDistributionEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FinishedGoodsEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductDeliveryEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.ProductDeliveryItemsEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.PFProformaItemsEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobStatusLineItemEntityTypeConfiguration());
                #endregion                         
                #region Job Costing Entity ConfiguraExceedERP.DataAccess.Contexttion
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JcPensionEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.IdleTimeCategoryEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobOrderTimeSheetEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobOrderTimeRegistrationEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobOrderSummaryEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.YearlyOverHeadRateEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.MachineEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.IdleTimeEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.IdleTimeProductiveEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.IdleTimeOTEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.IdleTimeNonProductiveControllableEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.IdleTimeNonProductiveNonControllableEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobCostEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobChangeOfOrderEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobMaterialCostEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobMaterialreturnEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobLaborCostEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FinishedJobEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.DeliveredJobEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.DailyLaborRateEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.DLRSalaryEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.DLRHourEntityTypeConfiguration());
                modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.JobOrderSummaryCostCenterDetailEntityTypeConfiguration());
            #endregion
            
            modelBuilder.Configurations.Add(new PrintCostCenterEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingMachineTypeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingProcessEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintItemCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintLabourRateEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintMachinePaperListEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintWorkOrderTypeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingCostEstimationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingProductProcessEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingPaperSizeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingJobTypeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingBindingStyleEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingMaterialCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingMaterialCategoryItemEntityTypeConfiguration());

            modelBuilder.Configurations.Add(new PrintingOverAllCostEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingEstimationLaborCostEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PrintingEstimationMaterialCostsEntityTypeConfiguration());
            #endregion
            #region Manufucturing 
            #region  Estimation
            #region Furniture Estimation
            modelBuilder.Configurations.Add(new Context.FurnitureStepEntityConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureLaborCostEntityConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureOverallCostEntityConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureCategoryEntityConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureCostEstimationEntityConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureMaterialCostEntityConfiguration());
            modelBuilder.Configurations.Add(new Context.DirectLaborCostEntityConfiguration());

            #endregion
            #endregion

            #region Production Follow UP
            modelBuilder.Configurations.Add(new Context.FurnitureYearlyProductionPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureHalfYearlyProductionPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureQuarterlyProductionPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureMonthlyProductionPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureWeeklyProductionPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductionJobTypePlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductionCustomerTypeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductionMonthlyJobTypePlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductionMonthlyPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductionYearlyPlanEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureJobCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProformaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureGraphicEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureJobEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureJobStatusEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureSettingsEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureJobOrderMaterialEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new Context.FurniturePrintingProductionFinishedGoodsStoreReceiveEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new Context.FurniturePrintingProductionFinishedGoodsStoreReceiveItemEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new Context.FurniturePrintingProductionFinishedGoodsStoreReceiveValidationEntityTypeConfiguration());
            //modelBuilder.Configurations.Add(new Context.FurniturePrintingProductionFinishedGoodsStoreReceiveDistributionEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureFinishedGoodsEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductDeliveryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureProductDeliveryItemsEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurniturePFProformaItemsEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new Context.FurnitureJobStatusLineItemEntityTypeConfiguration());
            #endregion                                  Furniture

            #region Job Costing 
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJcPensionEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureIdleTimeCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobOrderTimeSheetEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobOrderTimeRegistrationEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobOrderSummaryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureYearlyOverHeadRateEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureMachineEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureIdleTimeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureIdleTimeProductiveEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureIdleTimeOTEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureIdleTimeNonProductiveControllableEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureIdleTimeNonProductiveNonControllableEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobCostEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobChangeOfOrderEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobMaterialCostEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobMaterialreturnEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobLaborCostEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureFinishedJobEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureDeliveredJobEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureDailyLaborRateEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureDLRSalaryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureDLRHourEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.FurnitureJobOrderSummaryCostCenterDetailEntityTypeConfiguration());
            #endregion
            modelBuilder.Configurations.Add(new ManifucturingTaskCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ManufacturingMaterialCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ManufacturingMaterialCategoryItemEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureBillOfQuantityEntityConfiguration());
            modelBuilder.Configurations.Add(new FurnitureBOQMaterialEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureBOQLaborEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureProformaInvoiceEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureProformaInvoiceItemEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureJobOrderFormEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureJobOrderItemEntityTypeConfiguration());

            modelBuilder.Configurations.Add(new StandardBillOfLaborEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new StandardBillOfMaterialEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureStandardJobTypeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureJobOrderProductionEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureProductionBillOfMaterialEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureProductionBillOfLaborEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureJobAssignmentEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureDailyProductionFollowUpEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureProductionDailyFollowUpDelayReasonEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new FurnitureUnfinishedMaterialTransferFormEntityTypeConfiguration());
            #endregion
        }
        #region Common

        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Lookup> Lookups { get; set; }

        public DbSet<Period> Periods { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public System.Data.Entity.DbSet<BusinessUnit> BusinessUnits { get; set; }

        public DbSet<IndustryInvolved> IndustryInvolveds { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Identification> Identifications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageProficiency> LanguageOfProficiencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<BankReference> BankReferences { get; set; }
        public DbSet<Person_Employee> Person_Employee { get; set; }
        public System.Data.Entity.DbSet<MainCompany> Companies { get; set; }
        public System.Data.Entity.DbSet<MainCompanyStructure> MainCompanyStructures { get; set; }
        public System.Data.Entity.DbSet<BranchCostCenter> BranchCostCenter { get; set; }

        #endregion



        #region Check print
        public DbSet<Core.Domain.CheckPrint.CPBank> CPBanks { get; set; }
        public DbSet<Core.Domain.CheckPrint.CPBankAccount> CPBankAccounts { get; set; }
        public DbSet<Core.Domain.CheckPrint.CPCheckBook> CPCheckBooks { get; set; }
        public DbSet<Core.Domain.CheckPrint.CPCheckBookCheckNumber> CPCheckBookCheckNumbers { get; set; }
        public DbSet<Core.Domain.CheckPrint.Check> Checks { get; set; }
        public DbSet<Core.Domain.CheckPrint.CPPaymentVoucher> CPPaymentVouchers { get; set; }
        public DbSet<GlobalOperationLog> GlobalOperationLogs { get; set; }
        #endregion
        #region Printing
            #region  Estimation
            #region Printimg Estimation
            public DbSet<PrintingStep> PrintingSteps { get; set; }
            public DbSet<EstimationForm> EstimationForms { get; set; }
            public DbSet<MaterialCost> MaterialCosts { get; set; }
            public DbSet<LaborCost> LaborCosts { get; set; }
            public DbSet<OverallCost> OverallCosts { get; set; }
            public DbSet<PrintingCriteriaCategory> PrintingCriteriaCatagorys { get; set; }
            #endregion
            #endregion
            #region Production Follow UP
            public DbSet<YearlyProductionPlan> YearlyProductionPlans { get; set; }
            public DbSet<HalfYearlyProductionPlan> HalfYearlyProductionPlans { get; set; }
            public DbSet<QuarterlyProductionPlan> QuarterlyProductionPlans { get; set; }
            public DbSet<MonthlyProductionPlan> MonthlyProductionPlans { get; set; }
            public DbSet<WeeklyProductionPlan> WeeklyProductionPlans { get; set; }
            public DbSet<ProductionJobTypePlan> ProductionJobTypePlans { get; set; }
            public DbSet<ProductionCustomerType> ProductionCustomerTypes { get; set; }
            public DbSet<Proforma> Proformas { get; set; }
            public DbSet<ProductionYearlyPlan> ProductionYearlyPlans { get; set; }
            public DbSet<ProductionMonthlyPlan> ProductionMonthlyPlans { get; set; }
            public DbSet<ProductionMonthlyJobTypePlan> ProductionMonthlyJobTypePlans { get; set; }
            public DbSet<PFProformaItems> PFProformaItems { get; set; }
            public DbSet<JobCategory> JobCategories { get; set; }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<JobStatus> JobStatuses { get; set; }
            public DbSet<ChangeOrder> ChangeOrders { get; set; }
            public DbSet<JobOrderMaterial> JobOrderMaterials { get; set; }
            public DbSet<PrintingProductionFinishedGoodsStoreReceive> PrintingProductionFinishedGoodsStoreReceives { get; set; }
            public DbSet<PrintingProductionFinishedGoodsStoreReceiveItem> PrintingProductionFinishedGoodsStoreReceiveItems { get; set; }
            public DbSet<PrintingProductionFinishedGoodsStoreReceiveValidation> PrintingProductionFinishedGoodsStoreReceiveValidations { get; set; }
            public DbSet<PrintingProductionFinishedGoodsStoreReceiveDistribution> PrintingProductionFinishedGoodsStoreReceiveDistributions { get; set; }
            public DbSet<FinishedGoods> FinishedGoods { get; set; }
            public DbSet<ProductDelivery> ProductDeliveries { get; set; }
            public DbSet<ProductDeliveryItems> ProductDeliveryItems { get; set; }
            public DbSet<JobStatusLineItem> JobStatusLineItems { get; set; }
            #endregion
            #region Job Costing
            public DbSet<IdleTimeCategory> IdleTimeCategories { get; set; }
            public DbSet<JcPension> JcPensions { get; set; }
            public DbSet<YearlyOverHeadRate> YearlyOverHeadRates { get; set; }
            public DbSet<Machine> Machines { get; set; }
            public DbSet<Unit> Units { get; set; }
            public DbSet<IdleTime> IdleTimes { get; set; }
            public DbSet<IdleTimeOT> IdleTimeOTs { get; set; }
            public DbSet<IdleTimeProductive> IdleTimeProductives { get; set; }
            public DbSet<IdleTimeNonProductiveControllable> IdleTimeNonProductiveControllables { get; set; }
            public DbSet<PrintingIdleTimeNonProductiveNonControllable> PrintingIdleTimeNonProductiveNonControllables { get; set; }
            public DbSet<JobCost> JobCosts { get; set; }
            public DbSet<JobChangeOfOrder> JobChangeOfOrders { get; set; }
            public DbSet<JobLaborCost> JobLaborCosts { get; set; }
            public DbSet<JobMaterialCost> JobMaterialCosts { get; set; }
            public DbSet<JobMaterialReturn> JobMaterialReturns { get; set; }
            public DbSet<FinishedJob> FinishedJobs { get; set; }
            public DbSet<DeliveredJob> DeliveredJobs { get; set; }
            public DbSet<DailyLaborRate> DailyLaborRates { get; set; }
            public DbSet<DLRSalary> DLRSalaries { get; set; }
            public DbSet<DLRHour> DLRHours { get; set; }
            public DbSet<JobOrderTimeSheet> JobOrderTimeSheets { get; set; }
            public DbSet<JobOrderTimeRegistration> JobOrderTimeRegistrations { get; set; }
            public DbSet<JobOrderSummary> JobOrderSummarys { get; set; }
            public DbSet<JobOrderSummaryCostCenter> JobOrderSummaryCostCenters { get; set; }
            public DbSet<JobOrderSummaryCostCenterDetail> JobOrderSummaryCostCenterDetails { get; set; }
        //public DbSet<PrintingIdleTimeNonProductiveNonControllable> PrintingIdleTimeNonProductiveNonControllable { get; set; }


        #endregion
        public DbSet<PrintCostCenter> PrintCostCenters { get; set; } 
        public DbSet<PrintingMachineType> PrintingMachineTypes { get; set; }  
        public DbSet<PrintingProcess> PrintingProcesses { get; set; }  
        public DbSet<PrintItemCategory> PrintItemCategorys { get; set; }  
        public DbSet<PrintLabourRate> PrintLabourRates { get; set; }  
        public DbSet<PrintMachinePaperList> PrintMachinePaperLists { get; set; }  
        public DbSet<PrintWorkOrderType> PrintWorkOrderTypes { get; set; }   
        public DbSet<PrintingCostEstimation> PrintingCostEstimations { get; set; }   
        public DbSet<PrintingProductProcess> PrintingProductProcesses { get; set; }   
        public DbSet<PrintingPaperSize> PrintingPaperSizes { get; set; }   
        public DbSet<PrintingJobType> PrintingJobTypes { get; set; }    
        public DbSet<PrintingBindingStyle> PrintingBindingStyles { get; set; }
        public DbSet<PrintingMaterialCategory> PrintingMaterialCategories { get; set; }
        public DbSet<PrintingMaterialCategoryItem> PrintingMaterialCategoryItems { get; set; }

        public DbSet<PrintingEstimationMaterialCost> PrintingEstimationMaterialCosts { get; set; }
        public DbSet<PrintingEstimationLaborCost> PrintingEstimationLaborCosts { get; set; }
        public DbSet<PrintingOverAllCost> PrintingOverAllCosts { get; set; }
        #endregion
        #region Manufucturing
        #region  Estimation
        #region Production
        public DbSet<FurnitureJobOrderProduction> FurnitureJobOrderProductions { get; set; } 
        public DbSet<FurnitureProductionBillOfMaterial> FurnitureProductionBillOfMaterials { get; set; }  
        public DbSet<FurnitureProductionBillOfLabor> FurnitureProductionBillOfLabors { get; set; }  
        public DbSet<FurnitureJobAssignment> FurnitureJobAssignments { get; set; }
        public DbSet<FurnitureDailyProductionFollowUp> FurnitureDailyProductionFollowUps { get; set; }
        public DbSet<FurnitureProductionDailyFollowUpDelayReason> FurnitureProductionDailyFollowUpDelayReasons { get; set; }
        public DbSet<FurnitureUnfinishedMaterialTransferForm> FurnitureUnfinishedMaterialTransferForms { get; set; }

        #endregion
        #region Furniture Estimation
        public DbSet<FurnitureStep> FurnitureSteps { get; set; }
        public DbSet<FurnitureMaterialCost> FurnitureMaterialCosts { get; set; }
        public DbSet<FurnitureEstimationForm> FurnitureEstimationForms { get; set; }
        public DbSet<FurnitureLaborCost> FurnitureLaborCosts { get; set; }
        public DbSet<FurnitureOverallCost> FurnitureOverallCosts { get; set; }
        public DbSet<FurnitureCategory> FurnitureCategories { get; set; }
        public DbSet<DirectLaborCost> DirectLaborCosts { get; set; }
        //------------
        public DbSet<FurnitureBillOfQuantity> FurnitureBillOfQuantities { get; set; }
        public DbSet<FurnitureBOQMaterial> FurnitureBOQMaterials { get; set; }
        public DbSet<FurnitureBOQLabor> FurnitureBOQLabors { get; set; }

        public DbSet<FurnitureProformaInvoice> FurnitureProformaInvoices { get; set; }
        public DbSet<FurnitureProformaInvoiceItem> FurnitureProformaInvoiceItems { get; set; }
        public DbSet<FurnitureJobOrderForm> FurnitureJobOrderForms { get; set; }
        public DbSet<FurnitureJobOrderItem> FurnitureJobOrderItems { get; set; }

        // Setting
        public DbSet<FurnitureStandardJobType> FurnitureStandardJobTypes { get; set; }
        public DbSet<StandardBillOfMaterial> StandardBillOfMaterials { get; set; }
        public DbSet<StandardBillOfLabor> StandardBillOfLabors { get; set; }
        public DbSet<EstimationSummary> EstimationSummaries { get; set; }
        public DbSet<EstimationDetail> EstimationDetails { get; set; }
        public DbSet<EstimationCostSummary> EstimationCostSummaries { get; set; } 


        #endregion
        #endregion
        #region Production Follow UP
        public DbSet<FurnitureYearlyProductionPlan> FurnitureYearlyProductionPlans { get; set; }


        public DbSet<FurnitureJobProcuctionPlan> FurnitureJobProcuctionPlans { get; set; }
        public DbSet<FurnitureHalfYearlyProductionPlan> FurnitureHalfYearlyProductionPlans { get; set; }
        public DbSet<FurnitureQuarterlyProductionPlan> FurnitureQuarterlyProductionPlans { get; set; }
        public DbSet<FurnitureMonthlyProductionPlan> FurnitureMonthlyProductionPlans { get; set; }
        public DbSet<FurnitureWeeklyProductionPlan> FurnitureWeeklyProductionPlans { get; set; }
        public DbSet<FurnitureProductionJobTypePlan> FurnitureProductionJobTypePlans { get; set; }
        public DbSet<FurnitureProductionCustomerType> FurnitureProductionCustomerTypes { get; set; }
        public DbSet<FurnitureProforma> FurnitureProformas { get; set; }
        public DbSet<FurnitureProductionYearlyPlan> FurnitureProductionYearlyPlans { get; set; }
        public DbSet<FurnitureProductionMonthlyPlan> FurnitureProductionMonthlyPlans { get; set; }
        public DbSet<FurnitureProductionMonthlyJobTypePlan> FurnitureProductionMonthlyJobTypePlans { get; set; }
        public DbSet<FurniturePFProformaItems> FurniturePFProformaItems { get; set; }
        public DbSet<FurnitureJobCategory> FurnitureJobCategories { get; set; }
        public DbSet<FurnitureJob> FurnitureJobs { get; set; }
        public DbSet<FurnitureJobStatus> FurnitureJobStatuses { get; set; }
        public DbSet<FurnitureChangeOrder> FurnitureChangeOrders { get; set; }
        public DbSet<FurnitureJobOrderMaterial> FurnitureJobOrderMaterials { get; set; }
        public DbSet<FurnitureProductionFinishedGoodsStoreReceive> FurnitureProductionFinishedGoodsStoreReceives { get; set; }
        public DbSet<FurnitureProductionFinishedGoodsStoreReceiveItem> FurnitureProductionFinishedGoodsStoreReceiveItems { get; set; }
        public DbSet<FurnitureProductionFinishedGoodsStoreReceiveValidation> FurnitureProductionFinishedGoodsStoreReceiveValidations { get; set; }
        public DbSet<FurnitureProductionFinishedGoodsStoreReceiveDistribution> FurnitureProductionFinishedGoodsStoreReceiveDistributions { get; set; }
        public DbSet<FurnitureFinishedGoods> FurnitureFinishedGoods { get; set; }
        public DbSet<FurnitureProductDelivery> FurnitureProductDeliveries { get; set; }
        public DbSet<FurnitureProductDeliveryItems> FurnitureProductDeliveryItems { get; set; }
        public DbSet<FurnitureJobStatusLineItem> FurnitureJobStatusLineItems { get; set; }

        //--//
        public DbSet<ManifucturingTaskCategory> ManifucturingTaskCategories { get; set; }
        public DbSet<ManufacturingMaterialCategory> ManufacturingMaterialCategories { get; set; }
        public DbSet<ManufacturingMaterialCategoryItem> ManufacturingMaterialCategoryItems { get; set; }
        #endregion


        #region Job Costing
        public DbSet<FurnitureIdleTimeCategory> FurnitureIdleTimeCategories { get; set; }
        public DbSet<FurnitureJcPension> FurnitureJcPensions { get; set; }
        public DbSet<FurnitureYearlyOverHeadRate> FurnitureYearlyOverHeadRates { get; set; }
        public DbSet<FurnitureMachine> FurnitureMachines { get; set; }
        public DbSet<FurnitureUnit> FurnitureUnits { get; set; }
        public DbSet<FurnitureIdleTime> FurnitureIdleTimes { get; set; }
        public DbSet<FurnitureIdleTimeOT> FurnitureIdleTimeOTs { get; set; }
        public DbSet<FurnitureIdleTimeProductive> FurnitureIdleTimeProductives { get; set; }
        public DbSet<FurnitureIdleTimeNonProductiveControllable> FurnitureIdleTimeNonProductiveControllables { get; set; }
        public DbSet<FurnitureIdleTimeNonProductiveNonControllable> FurnitureIdleTimeNonProductiveNonControllables { get; set; }
        public DbSet<FurnitureJobCost> FurnitureJobCosts { get; set; }
        public DbSet<FurnitureJobChangeOfOrder> FurnitureJobChangeOfOrders { get; set; }
        public DbSet<FurnitureJobLaborCost> FurnitureJobLaborCosts { get; set; }
        public DbSet<FurnitureJobMaterialCost> FurnitureJobMaterialCosts { get; set; }
        public DbSet<FurnitureJobMaterialReturn> FurnitureJobMaterialReturns { get; set; }
        public DbSet<FurnitureFinishedJob> FurnitureFinishedJobs { get; set; }
        public DbSet<FurnitureDeliveredJob> FurnitureDeliveredJobs { get; set; }
        public DbSet<FurnitureDailyLaborRate> FurnitureDailyLaborRates { get; set; }
        public DbSet<FurnitureDLRSalary> FurnitureDLRSalaries { get; set; }
        public DbSet<FurnitureDLRHour> FurnitureDLRHours { get; set; }
        public DbSet<FurnitureJobOrderTimeSheet> FurnitureJobOrderTimeSheets { get; set; }
        public DbSet<FurnitureJobOrderTimeRegistration> FurnitureJobOrderTimeRegistrations { get; set; }
        public DbSet<FurnitureJobOrderSummary> FurnitureJobOrderSummarys { get; set; }
        public DbSet<FurnitureJobOrderSummaryCostCenter> FurnitureJobOrderSummaryCostCenters { get; set; }
        public DbSet<FurnitureJobOrderSummaryCostCenterDetail> FurnitureJobOrderSummaryCostCenterDetails { get; set; }

        #endregion
        #endregion
        public DbSet<MissingPayrollBackPay> MissingPayrollBackPays { get; set; }
        public DbSet<MissingPayrollBackPaymentLine> MissingPayrollBackPaymentLines { get; set; }
        public DbSet<MissingPayrollBackPaymentDetailPeriod> MissingPayrollBackPaymentDetailPeriods { get; set; }
        public DbSet<MissingPayrollBackPaymentDetail> MissingPayrollBackPaymentDetails { get; set; }
        public DbSet<MissingPayrollBackPaymentDistribution> MissingPayrollBackPaymentDistributions { get; set; }
        //public DbSet<PrintingStep> FurnitureSteps { get; set; }
        #region fixed Asset
        public DbSet<IndexingCount> IndexingCount { get; set; }
        public DbSet<FixedAssetSubCategoryName> FixedAssetSubCategoryNames { get; set; }

        #endregion
        #region CRM
        public DbSet<OrganizationCustomer> OrganizationCustomers { get; set; }

        #endregion
        #region  Inventory

        public DbSet<BranchItemAssignment> BranchItemAssignments { get; set; }
        public DbSet<FuelItemSetting> FuelItemSettings { get; set; }
        public DbSet<AveragePriceSetting> AveragePriceSettings { get; set; }
        //public DbSet<ServiceReceive> ServiceReceives { get; set; }
        //public DbSet<ServiceReceiveItem> ServiceReceiveItems { get; set; }
        //public DbSet<ServiceReceiveValidation> ServiceReceiveValidations { get; set; }
        //public DbSet<ServiceReceiveDistribution> ServiceReceiveDistributions { get; set; }
        public DbSet<InventoryPeriod> InventoryPeriods { get; set; }
        public DbSet<ReceiveType> ReceiveTypes { get; set; }
        public DbSet<UoM> UoMs { get; set; }
        public DbSet<GoodReceive> GoodReceives { get; set; }
        public DbSet<GoodReceiveItem> GoodReceiveItems { get; set; }
        public DbSet<GoodReceiveDonationItem> GoodReceiveDonationItems { get; set; }
        public DbSet<GoodReceiveValidation> GoodReceiveValidations { get; set; }
        public DbSet<GoodReciveDonationValidation> GoodReciveDonationValidations { get; set; }
        public DbSet<GoodReciveDonationDistribution> GoodReciveDonationDistributions { get; set; }
        //public DbSet<IssueFuel> IssueFuels { get; set; }
        //public DbSet<IssueFuelItem> IssueFuelItems { get; set; }
        public DbSet<GoodReceiveDistribution> GoodReceiveDistributions { get; set; }
        public DbSet<GoodSellingAndLending> GoodSellingAndLendings { get; set; }
        public DbSet<GoodSellingAndLendingItem> GoodSellingAndLendingItems { get; set; }
        public DbSet<GoodSellingAndLendingValidation> GoodSellingAndLendingValidations { get; set; }
        public DbSet<GoodSellingAndLendingDistribution> GoodSellingAndLendingDistributions { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueItem> IssueItems { get; set; }
        public DbSet<IssueValidation> IssueValidations { get; set; }
        public DbSet<IssueDistribution> IssueDistributions { get; set; }
        //public DbSet<IssueFuelValidation> IssueFuelValidations { get; set; }
        //public DbSet<IssueFuelDistribution> IssueFuelDistributions { get; set; }
        public DbSet<ItemCategory> ItemCategorys { get; set; }
        public DbSet<ItemCategoryUserRole> ItemCategoryUserRoles { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<ItemPerStoreBalance> ItemPerStoreBalances { get; set; }
        public DbSet<ItemInspection> ItemInspections { get; set; }
        //public DbSet<ItemInspectionItem> ItemInspectionItems { get; set; }
        //public DbSet<ItemInspectionValidation> ItemInspectionValidations { get; set; }
        public DbSet<ItemTransfer> ItemTransfers { get; set; }
        public DbSet<ItemTransferItem> ItemTransferItems { get; set; }
        public DbSet<ItemTransferValidation> ItemTransferValidations { get; set; }
        public DbSet<ItemTransferReciverValidation> ItemTransferReciverValidations { get; set; }
        public DbSet<ItemTransferDistribution> ItemTransferDistributions { get; set; }
        //public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        //public DbSet<PurchaseRequisitionItem> PurchaseRequisitionItems { get; set; }
        //public DbSet<PurchaseRequisitionItemSpecification> PurchaseRequisitionItemSpecifications { get; set; }
        //public DbSet<PurchaseRequisitionAssignment> PurchaseRequisitionAssignments { get; set; }
        //public DbSet<PurchaseRequisitionReassignmentValidation> PurchaseRequisitionReassignmentValidations { get; set; }
        //public DbSet<PurchaseRequisitionReassignmentItem> PurchaseRequisitionReassignmentItems { get; set; }
        //public DbSet<PurchaseRequisitionUserDepartmentValidation> PurchaseRequisitionUserDepartmentValidations { get; set; }
        //public DbSet<PurchaseRequisitionPurchaseDepartmentValidation> PurchaseRequisitionPurchaseDepartmentValidations { get; set; }
        //// public DbSet<PurchaseRequisitionDistribution> PurchaseRequisitionDistributions { get; set; }
        //  public DbSet<PurchaseRequisitionAttachment> PurchaseRequisitionAttachments { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<PurchaseReturnItems> PurchaseReturnItemss { get; set; }
        public DbSet<PurchaseReturnValidation> PurchaseReturnValidations { get; set; }
        public DbSet<PurchaseReturnDistribution> PurchaseReturnDistributions { get; set; }
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockAdjustmentItems> StockAdjustmentItemss { get; set; }
        public DbSet<StockAdjustmentValidation> StockAdjustmentValidations { get; set; }
        public DbSet<StockAdjustmentDistribution> StockAdjustmentDistributions { get; set; }
        public DbSet<InventoryStore> InventoryStores { get; set; }
        public DbSet<InventoryStorePeriodStatus> InventoryStorePeriodStatuses { get; set; }
        public DbSet<ProjectStores> ProjectStores { get; set; }
        public DbSet<StoreKeeperAssignment> StoreKeeperAssignments { get; set; }
        public DbSet<StoreItemAssignment> StoreItemAssignments { get; set; }
        public DbSet<BinCardLine> BinCardLines { get; set; }
        public DbSet<StoreRequisition> StoreRequisitions { get; set; }
        public DbSet<StoreRequisitionItem> StoreRequisitionItems { get; set; }
        public DbSet<StoreRequisitionValidation> StoreRequisitionValidations { get; set; }
        public DbSet<StoreRequisitionPropertyValidation> StoreRequisitionPropertyValidations { get; set; }
        //public DbSet<StoreRequisitionAttachment> StoreRequisitionAttachments { get; set; }
        public DbSet<StoreReturn> StoreReturns { get; set; }
        public DbSet<StoreReturnItems> StoreReturnItemss { get; set; }
        public DbSet<StoreReturnValidation> StoreReturnValidations { get; set; }
        public DbSet<StoreReturnDistribution> StoreReturnDistributions { get; set; }
        public DbSet<StoreReturnAttachment> StoreReturnAttachments { get; set; }
        public DbSet<PropertyCount> PropertyCounts { get; set; }
        public DbSet<PropertyCountItem> PropertyCountItems { get; set; }
        //public DbSet<InventoryPeriod> InventoryPeriods { get; set; }
        public DbSet<TempGoodReceive> TempGoodReceives { get; set; }
        public DbSet<TempGoodReceiveItem> TempGoodReceiveItems { get; set; }
        public DbSet<TempGoodReceiveValidation> TempGoodReceiveValidations { get; set; }
        public DbSet<DepartmentCostCenter> DepartmentCostCenters { get; set; }
        public DbSet<GoodReceiveDonation> GoodReceiveDonations { get; set; }
        public DbSet<EvaluatedPrice> EvaluatedPrices { get; set; }
        public DbSet<RevaluationItem> RevaluationItems { get; set; }
        public DbSet<Revaluation> Revaluations { get; set; }
        public DbSet<RevaluationValidation> RevaluationValidations { get; set; }
        public DbSet<ItemTransferReceive> ItemTransferReceive { get; set; }
        public DbSet<ItemTransferItemReceive> ItemTransferItemReceive { get; set; }
        public DbSet<ItemTransferReceiverValidation> ItemTransferReceiverValidation { get; set; }
        public DbSet<ItemTransferReceiveDistribution> ItemTransferReceiveDistribution { get; set; }

        #region inventory_archive
        public DbSet<StoreRequisitionArchive> StoreRequisitionArchive { get; set; }
        public DbSet<StoreRequisitionItemArchive> StoreRequisitionItemArchive { get; set; }
        public DbSet<StoreRequisitionValidationArchive> StoreRequisitionValidationArchive { get; set; }
        public DbSet<StoreRequisitionPropertyValidationArchive> StoreRequisitionPropertyValidationArchive { get; set; }
        public DbSet<BinCardLineArchive> BinCardLineArchive { get; set; }
        #endregion


        #endregion
        #region Fiance
        public DbSet<GLPeriod> GLPeriods { get; set; }
        public DbSet<GlFiscalYear> GLFiscalYears { get; set; }
        public DbSet<GLTaxRate> GLTaxRates { get; set; }
        public System.Data.Entity.DbSet<GLChartOfAccountCostCenter> GLChartOfAccountCostCenters { get; set; }
        public System.Data.Entity.DbSet<ExceedERP.Core.Domain.Finance.GL.Dynamic.GLSegmentSetup> GlSegmentSetups { get; set; }
        public System.Data.Entity.DbSet<ExceedERP.Core.Domain.Finance.GL.Dynamic.GLChartOfAccountSegment> GlChartOfAccountSegments { get; set; }

        #endregion
        #region Procurement
        public DbSet<Appreciation> Appreciations { get; set; }
        public DbSet<ItemPriceIndex> ItemPriceIndexes { get; set; }

        #endregion
        #region HRM
        public System.Data.Entity.DbSet<Placement> Placements { get; set; }
        #endregion
        #region FleetManagement


        #region 1 - Fleet Module
        public DbSet<OwningandOperatingCost> OwningandOperatingCosts { get; set; }
        public DbSet<FleetPettyCashType> FleetPettyCashTypes { get; set; }
        public DbSet<OwningandOperatingCostConstant> OwningandOperatingCostConstants { get; set; }
        public DbSet<LicenseLevel> LicenseLevels { get; set; }
        public DbSet<FleetPettyCash> FleetPettyCashes { get; set; }
        public DbSet<FleetIFuelConsumption> FleetIFuelConsumptions { get; set; }
        //public DbSet<Accident> Accident { get; set; }
        public DbSet<FleetInsuranceTypeDetail> FleetInsuranceTypeDetails { get; set; }
        //public DbSet<Accessories> FleetAccessories { get; set; }
        public DbSet<EquipmentIdentity> EquipmentIdentity { get; set; }
        public DbSet<EquipmentType> EquipmentType { get; set; }
        public DbSet<EquipmentApproval> EquipmentApproval { get; set; }
        public DbSet<Fleets> Fleets { get; set; }

        public DbSet<EquipmentBattery> EquipmentBattery { get; set; }
        public DbSet<EquipmentArrival> EquipmentArrival { get; set; }
        public DbSet<EquipmentArrivalApproval> EquipmentArrivalApproval { get; set; }
        public DbSet<EquipmentBatteryLog> EquipmentBatteryLog { get; set; }
        public DbSet<EquipmentTyreLog> EquipmentTyreLog { get; set; }
        public DbSet<FuelConsumptionAlertLevel> FuelConsumptionAlertLevel { get; set; }
        public DbSet<FleetHistory> FleetHistorys { get; set; }
        public DbSet<FleetInsurance> FleetInsurance { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
        public DbSet<EquipmentTyre> EquipmentTyres { get; set; }
        public DbSet<EquipmentLocation> EquipmentLocations { get; set; }
        public DbSet<TimeSheetApproval> TimeSheetApprovals { get; set; }
        //public DbSet<DriverAssignment> DriverAssignments { get; set; }
        public DbSet<EquipmentName> EquipmentName { get; set; }
        //public DbSet<FuelInventory> FuelInventorys { get; set; }
        public DbSet<OperatorPosition> OperatorPosition { get; set; }
        public DbSet<Educationallevel> Educationallevel { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        // public DbSet<AssignedEquipment> AssignedEquipment { get; set; }
        public DbSet<EquipmentAttachment> EquipmentAttachment { get; set; }
        public DbSet<HRFleetMapping> HRFleetMapping { get; set; }
        public DbSet<FleetCondition> FleetConditions { get; set; }
        public DbSet<OperatorLicense> OperatorLicense { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<FleetReturn> FleetReturns { get; set; }
        public DbSet<FleetReturnItem> FleetReturnItems { get; set; }
        public DbSet<FleetReturnApproval> FleetReturnApprovals { get; set; }
        public System.Data.Entity.DbSet<CriteriaCategory> CriteriaCategories { get; set; }
        //public IQueryable<FurnitureIdleTime> FurnitureIdleTimes { get; set; }


        #endregion


        #region 2 - Fuel Module

        //public DbSet<Fuel> Fuel { get; set; }
        //public DbSet<FuelIssueApproval> FuelIssueApproval { get; set; }
        //public DbSet<FuelType> FuelTypes { get; set; }

        #endregion


        #region 3 - Inspection And Recommendation Module
        //public DbSet<CheckList> CheckLists { get; set; }
        //public DbSet<LineCheckList> LineCheckLists { get; set; }
        //public DbSet<CheckListLog> CheckListLogs { get; set; }
        //public DbSet<InspectionLog> InspectionLogs { get; set; }
        //public DbSet<InspectionApproval> InspectionApprovals { get; set; }

        //public DbSet<AnnualEquipmentInventoryInspection> AnnualEquipmentInventoryInspection { get; set; }
        //public DbSet<EquipmentPlanandEvaluations> EquipmentPlanandEvaluation { get; set; }
        //public DbSet<EquipmentPlanEvaluationApproval> EquipmentPlanEvaluationApprovals { get; set; }

        //public DbSet<AnnualInventoryInspectionApproval> AnnualInventoryInspectionApproval { get; set; }

        #endregion

        #region 5 - Recycle Module

        //public DbSet<Cannibalization> Cannibalization { get; set; }
        //public DbSet<SalvageStore> SalvageStore { get; set; }
        //public DbSet<SalvageStoreGoodReceiving> SalvageStoreGoodReceiving { get; set; }
        //public DbSet<CannibalizationDetail> CannibalizationDetails { get; set; }
        //public DbSet<CannibalizationApproval> CannibalizationApproval { get; set; }
        //public DbSet<GoodRecivingNoteApproval> GoodRecivingNoteApproval { get; set; }
        //public DbSet<SalvageStoreApproval> SalvageStoreApproval { get; set; }

        //public DbSet<AdvanceMeasure> AdvanceMeasures { get; set; }
        //public DbSet<DailyCare> DailyCares { get; set; }
        //public DbSet<DailyCareCategory> DailyCareCategories { get; set; }
        //public DbSet<DailyCareDetailLog> DailyCareDetailLogs { get; set; }
        //public DbSet<DailyCareLog> DailyCareLogs { get; set; }
        //public DbSet<FailureReason> FailureReasons { get; set; }
        #endregion



        #region 6 - Rent Management


        //public DbSet<ExternalRentedEquipmentCheckList> ExternalRentedEquipmentCheckList { get; set; }
        //public DbSet<RentInternalProject> RentInternalProject { get; set; }
        //public DbSet<ExternalRentedEquipment> ExternalRentedEquipments { get; set; }
        //public DbSet<RentToExternal> RentToExternals { get; set; }
        //public DbSet<RentRequest> RentRequest { get; set; }
        //public DbSet<RentFromExternal> RentFromExternal { get; set; }
        //public DbSet<RentForInternalApproval> RentForInternalApproval { get; set; }
        //public DbSet<RentFromExternalApproval> RentFromExternalApproval { get; set; }
        //public DbSet<RentRequestApproval> RentRequestApproval { get; set; }
        //public DbSet<RentToExternalApproval> RentOtherSupplierApproval { get; set; }

        #endregion


        #region 7 Fleet Resource
        //public DbSet<SiteVechicleTransferTyreDetail> SiteVechicleTransferTyreDetailes { get; set; }
        //public DbSet<RequestedEquipment> RequestedEquipments { get; set; }
        //public DbSet<VehicleDemand> VehicleDemand { get; set; }
        //public DbSet<VehicleDistribution> VehicleDistribution { get; set; }
        //public DbSet<VehicleReturn> VehicleReturn { get; set; }
        //public DbSet<SitesVehicleTransfer> SitesVehicleTransfer { get; set; }
        //public DbSet<SiteVechicleTransferDetail> SiteVechicleTransferDetails { get; set; }
        //public DbSet<DriverVehicleTransfer> DriverVehicleTransfer { get; set; }
        //public DbSet<AssignEquipmentApproval> AssignEquipmentApproval { get; set; }
        //public DbSet<DriverTransferApproval> DriverVehicleTransferApproval { get; set; }
        //public DbSet<SiteVehicleApproval> SiteVehicleApproval { get; set; }
        //public DbSet<VehicleDemandApproval> VehicleDemandApproval { get; set; }
        //public DbSet<VehicleDistributionApproval> VehicleDistributionApproval { get; set; }
        //public DbSet<VehicleReturnApproval> VehicleReturnApproval { get; set; }

        #endregion


        #region 8 Tire
        //public DbSet<TireIssue> TireIssue { get; set; }
        //public DbSet<TireReturn> TireReturn { get; set; }
        //public DbSet<TireIssueApproval> TireIssueApproval { get; set; }
        //public DbSet<TireReturnApproval> TireReturnApproval { get; set; }
        //public DbSet<TyreTransfer> TyreTransfers { get; set; }

        //public DbSet<TyreTransferApproval> TyreTransferApprovals { get; set; }

        #endregion


        #region 9 Battery
        //public DbSet<BatteryIssue> BatteryIssue { get; set; }
        //public DbSet<BatteryReturn> BatteryReturn { get; set; }
        //public DbSet<BatteryApproval> BatteryApproval { get; set; }

        #endregion


        #endregion
    }
}
