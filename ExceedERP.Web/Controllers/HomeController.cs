using System.Web.Mvc;
using ExceedERP.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Collections.Generic;

namespace ExceedERP.Web.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            #region Role Insert

            ApplicationRoleManager roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();

            List<ApplicationRole> roles = new List<ApplicationRole>
            {
                //new ApplicationRole(CRMRoles.CRMAdmin, "CRM Administrator - Manages all CRM Settings. Can Create, Edit and Delete CRM Settings", "CRM"),
                //new ApplicationRole(CRMRoles.SalesReport, "Sales Report - Can see all CRM Reports.", "CRM"),
                //new ApplicationRole(CRMRoles.SalesQuoteUser, "Sales Quote User - Create, Edit and Delete Sales Quote records", "CRM"),
                //new ApplicationRole(CRMRoles.SalesQuoteApprover, "Sales Quote Approver - Approve and Reject Sales Quotes", "CRM"),
                //new ApplicationRole(CRMRoles.SalesOrderUser, "Sales Order User - Create, Edit and Delete Sales Order records", "CRM"),
                //new ApplicationRole(CRMRoles.SalesOrderApprover, "Sales Order Approver - Approve and Reject Sales Orders", "CRM"),
                //new ApplicationRole(CRMRoles.CashSalesUser, "Cash Sales User - Create, Edit and Delete CASH SALES", "CRM"),
                //new ApplicationRole(CRMRoles.CashSalesApprover, "Cash Sales Approver - Approve and Reject CASH SALES", "CRM"),
                //new ApplicationRole(CRMRoles.CreditSalesUser, "Credit Sales User - Create, Edit and Delete CREDIT SALES", "CRM"),
                //new ApplicationRole(CRMRoles.CreditSalesApprover, "Credit Sales Approver - Approve and Reject CREDIT SALES", "CRM"),
                //new ApplicationRole(CRMRoles.CRMQueueSetting, "Responsible for Queue Related Settings (queue types, investment types and location mapping)", "CRM"),
                //new ApplicationRole(CRMRoles.CRMQueueUser, "Creating and Modifying Queue Records", "CRM"),
                //new ApplicationRole(CRMRoles.CRMQueueApprover, "Queue Records approver", "CRM"),
                //new ApplicationRole(CRMRoles.CustomerRegistrationUser, "Add and Modify Organization Customers", "CRM"),
                //new ApplicationRole(CRMRoles.ShipmentUser, "Shipment User. Can Create and Modify Shipment Records", "CRM"),
                //new ApplicationRole(CRMRoles.ShipmentApprover, "Shipment Approver. Can Approver, Reject Shipment Records", "CRM"),
                //new ApplicationRole(CRMRoles.CreditSettlementUser, "Credit Settlement User - Create, Edit and Delete Credit Settlements", "CRM"),
                //new ApplicationRole(CRMRoles.CreditSettlementApprover, "Credit Settlement Approver - Approve and Reject Credit Settlements", "CRM"),
                //new ApplicationRole(CRMRoles.AdvancePaymentUser, "Advance Payment User - Create, Edit and Delete Advance Payments", "CRM"),
                //new ApplicationRole(CRMRoles.AdvancePaymentApprover, "Advance Payment Approver - Approve and Reject Advance Payments", "CRM"),
                //new ApplicationRole(CRMRoles.CRMVoid, "Void sales quote, sales order, sales invoice, shipment and other vouchers", "CRM"),
                //new ApplicationRole(CRMRoles.SalesPlanUser, "Sales plan user - Create, Edit and Delete Sales Plan", "CRM"),
                //new ApplicationRole(CRMRoles.SalesPlanApprover, "Sales plan approver - Approve and Reject Sales Plan", "CRM"),

                //new ApplicationRole(CRMRoles.CRMBatchTransfer, "CRM Batch Transfer - batch transfer Cash Sales, Credit Sales, Shipment, Credit Settlements and Deposit", "CRM"),
                //new ApplicationRole(CRMRoles.IncompleteShipmentAdmin, "Incomplete and Partially Incomplete shipment admin", "CRM")

            };

            foreach (var role in roles)
            {
                if (roleManager.RoleExists(role.Name))
                {
                    roleManager.Update(role);
                }
                else
                {
                    roleManager.Create(role);
                }
            }

            //ApplicationRole b1 = new ApplicationRole("Budget_Admin", "Budget Administrator", "Budget");
            //ApplicationRole b2 = new ApplicationRole("Budget_Approver", "Budget Approver", "Budget");
            //ApplicationRole b3 = new ApplicationRole("Budget_Report", "Budget Report", "Budget");
            //ApplicationRole b4 = new ApplicationRole("Budget_Requestor", "Budget Requester", "Budget");
            //ApplicationRole b5 = new ApplicationRole("Budget_User", "Budget User", "Budget");
            //ApplicationRole b6 = new ApplicationRole("Budget_Transfer", "Budget Transfer", "Budget");
            //roleManager.Create(b6);




            //roleManager.Create(b1);
            //roleManager.Create(b2);
            //roleManager.Create(b3);
            //roleManager.Create(b4);
            //roleManager.Create(b5);

            //ApplicationRole planUser = new ApplicationRole(CRMRoles.SalesPlanUser, "Sales plan user", "CRM");
            //ApplicationRole planApprover = new ApplicationRole(CRMRoles.SalesPlanApprover, "Sales plan approver", "CRM");

            //ApplicationRole crmvoid = new ApplicationRole(CRMRoles.CRMVoid, "Void sales quote, sales order, sales invoice, shipment and other vouchers", "CRM");

            //ApplicationRole queueSetting = new ApplicationRole(CRMRoles.CRMQueueSetting, "Responsible for Queue Related Settings", "CRM");
            //ApplicationRole queueUser = new ApplicationRole(CRMRoles.CRMQueueUser, "Creting and Modifying Queue Records", "CRM");
            //ApplicationRole queueApprover = new ApplicationRole(CRMRoles.CRMQueueApprover, "Queue Records approver", "CRM");

            //ApplicationRole customerRegistrationUser = new ApplicationRole(CRMRoles.CustomerRegistrationUser, "Add and Modify Organization Customers", "CRM");

            //ApplicationRole shipmentUser = new ApplicationRole(CRMRoles.ShipmentUser, "Shipment User. Can Create and Modify Shipment Records", "CRM");
            //ApplicationRole shipmentApprover = new ApplicationRole(CRMRoles.ShipmentApprover, "Shipment Approver. Can Approver, Reject Shipment Records", "CRM");
            //ApplicationRole creditSettlementUser = new ApplicationRole(CRMRoles.CreditSettlementUser, "Credit Settlement User", "CRM");
            //ApplicationRole creditSettlementApprover = new ApplicationRole(CRMRoles.CreditSettlementApprover, "Credit Settlement Approver", "CRM");
            //ApplicationRole advancePaymentUser = new ApplicationRole(CRMRoles.AdvancePaymentUser, "Advance Payment User", "CRM");
            //ApplicationRole advancePaymentApprover = new ApplicationRole(CRMRoles.AdvancePaymentApprover, "Advance Payment Approver", "CRM");


            //ApplicationRole c1 = new ApplicationRole("CRM_Admin", "CRM Administrator", "CRM");
            //ApplicationRole c2 = new ApplicationRole("Sales_Report", "Sales Report", "CRM");
            //ApplicationRole c3 = new ApplicationRole("Marketing_Report", "Marketing Report", "CRM");
            //ApplicationRole c4 = new ApplicationRole("Service_Support_report", "Service Support_report", "CRM");
            //ApplicationRole c5 = new ApplicationRole("Sales_Quote_User", "Sales Quote User", "CRM");
            //ApplicationRole c6 = new ApplicationRole("Sales_Order_User", "Sales Order User", "CRM");
            //ApplicationRole c7 = new ApplicationRole("Cash_Sales_User", "Cash Sales User", "CRM");
            //ApplicationRole c8 = new ApplicationRole("Sales_Quote_Approver", "Sales Quote Approver", "CRM");
            //ApplicationRole c9 = new ApplicationRole("Sales_Order_Approver", "Sales Order Approver", "CRM");
            //ApplicationRole c10 = new ApplicationRole("Cash_Sales_Approver", "Cash Sales Approver", "CRM");
            //ApplicationRole c11 = new ApplicationRole("Marketing_User", "Marketing User", "CRM");
            //ApplicationRole c12 = new ApplicationRole("Service_Support_User", "Service_Support_User", "CRM");
            //ApplicationRole c13 = new ApplicationRole("Inventory_Issue_User", "Inventory Issue User", "CRM");
            //ApplicationRole c14 = new ApplicationRole("Inventory_Issue_Approver", "Inventory Issue Approver", "CRM");
            //ApplicationRole c15 = new ApplicationRole("Customer_Service_User", "Customer Service User", "CRM");
            //ApplicationRole c16 = new ApplicationRole("Customer_Service_Approver", "Customer Service Approver", "CRM");
            //ApplicationRole c17 = new ApplicationRole("Customer_Service_Report", "Customer Service Report", "CRM");
            //ApplicationRole c18 = new ApplicationRole("Credit_Settlement_User", "Credit Settlement User", "CRM");


            //roleManager.Create(queueSetting);
            //roleManager.Create(queueUser);
            //roleManager.Create(queueApprover);

            //roleManager.Create(shipmentUser);
            //roleManager.Create(shipmentApprover);
            //roleManager.Create(creditSettlementUser);
            //roleManager.Create(creditSettlementApprover);
            //roleManager.Create(advancePaymentUser);
            //roleManager.Create(advancePaymentApprover);

            //roleManager.Create(customerRegistrationUser);

            //roleManager.Create(planUser);
            //roleManager.Create(planApprover);
            //roleManager.Create(crmvoid);
            //roleManager.Create(c1);
            //roleManager.Create(c2);
            //roleManager.Create(c3);
            //roleManager.Create(c4);
            //roleManager.Create(c5);
            //roleManager.Create(c6);
            //roleManager.Create(c7);
            //roleManager.Create(c8);
            //roleManager.Create(c9);
            //roleManager.Create(c10);
            //roleManager.Create(c11);
            //roleManager.Create(c12);
            //roleManager.Create(c13);
            //roleManager.Create(c14);
            //roleManager.Create(c15);
            //roleManager.Create(c16);
            //roleManager.Create(c17);
            //roleManager.Create(c18);

            //ApplicationRole f1 = new ApplicationRole("Fleet_Admin", "Fleet Administrator", "FLEET");
            //ApplicationRole f2 = new ApplicationRole("Registration_User", "Registration User", "FLEET");
            //ApplicationRole f3 = new ApplicationRole("Registration_Approver", "Registration Approver", "FLEET");
            //ApplicationRole f4 = new ApplicationRole("Rent_Requestor", "Rent Requester", "FLEET");
            //ApplicationRole f5 = new ApplicationRole("Rent_User", "Rent User", "FLEET");
            //ApplicationRole f6 = new ApplicationRole("Rent_Approver", "Rent Approver", "FLEET");
            //ApplicationRole f7 = new ApplicationRole("Maintenance_Requestor", "Maintenance Requester", "FLEET");
            //ApplicationRole f8 = new ApplicationRole("Maintenance_Request_Approver", "Maintenance Request Approver", "FLEET");
            //ApplicationRole f9 = new ApplicationRole("Maintenance_Order_User", "Maintenance Order User", "FLEET");
            //ApplicationRole f10 = new ApplicationRole("Maintenance_Service_Approver", "Maintenance Service Approver", "FLEET");
            //ApplicationRole f11 = new ApplicationRole("Service_User", "Service User", "FLEET");
            //ApplicationRole f12 = new ApplicationRole("Fuel_Requestor", "Fuel Requester", "FLEET");
            //ApplicationRole f13 = new ApplicationRole("Fuel_Approver", "Fuel Approver", "FLEET");
            //ApplicationRole f14 = new ApplicationRole("Fuel_User", "Fuel User", "FLEET");
            //ApplicationRole f15 = new ApplicationRole("Inspection_User", "Inspection User", "FLEET");
            //ApplicationRole f16 = new ApplicationRole("Inspection_Approver", "Inspection Approver", "FLEET");
            //ApplicationRole f17 = new ApplicationRole("Resource_Requestor", "Resource Requester", "FLEET");
            //ApplicationRole f18 = new ApplicationRole("Resource_Distributor", "Resource Distributor", "FLEET");
            //ApplicationRole f19 = new ApplicationRole("Resource_Return_User", "Resource Return_User", "FLEET");
            //ApplicationRole f20 = new ApplicationRole("Resource_User", "Resource User", "FLEET");
            //ApplicationRole f21 = new ApplicationRole("Resource_Request_Approver", "Resource Request Approver", "FLEET");
            //ApplicationRole f22 = new ApplicationRole("Resource_Approver", "Resource Approver", "FLEET");
            //ApplicationRole f23 = new ApplicationRole("Tyre_Requestor", "Tyre Requester", "FLEET");
            //ApplicationRole f24 = new ApplicationRole("Tyre_Approver", "Tyre Approver", "FLEET");
            //ApplicationRole f25 = new ApplicationRole("Tyre_User", "Tyre User", "FLEET");
            //ApplicationRole f26 = new ApplicationRole("Fleet_Training_user", "Fleet Training user", "FLEET");
            //ApplicationRole f27 = new ApplicationRole("Fleet_Maintenance_Report", "Fleet Maintenance Report", "FLEET");
            //ApplicationRole f28 = new ApplicationRole("Fleet_Report", "Fleet Report", "FLEET");
            //ApplicationRole f29 = new ApplicationRole("Fleet_Resource_Report", "Fleet Resource Report", "FLEET");
            //ApplicationRole f30 = new ApplicationRole("Equipment_Plan_User", "Equipment Plan User", "FLEET");
            //ApplicationRole f31 = new ApplicationRole("Equipment_Plan_Approver", "Equipment Plan Approver", "FLEET");
            //ApplicationRole f32 = new ApplicationRole("Salvage_Store_Issue_User", "Salvage Store Issue User", "FLEET");
            //ApplicationRole f33 = new ApplicationRole("Salvage_Store_Issue_Approver", "Salvage Store Issue Approver", "FLEET");
            //ApplicationRole f34 = new ApplicationRole("Store_Good_Receiving_User", "Store Good Receiving User", "FLEET");
            //ApplicationRole f35 = new ApplicationRole("Store_Good_Receiving_Approver", "Store Good Receiving Approver", "FLEET");
            //ApplicationRole f36 = new ApplicationRole("Fleet_Registration_Report", "Fleet Registration Report", "FLEET");

            //roleManager.Create(f1);
            //roleManager.Create(f2);
            //roleManager.Create(f3);
            //roleManager.Create(f4);
            //roleManager.Create(f5);
            //roleManager.Create(f6);
            //roleManager.Create(f7);
            //roleManager.Create(f8);
            //roleManager.Create(f9);
            //roleManager.Create(f10);
            //roleManager.Create(f11);
            //roleManager.Create(f12);
            //roleManager.Create(f13);
            //roleManager.Create(f14);
            //roleManager.Create(f15);
            //roleManager.Create(f16);
            //roleManager.Create(f17);
            //roleManager.Create(f18);
            //roleManager.Create(f19);
            //roleManager.Create(f20);
            //roleManager.Create(f21);
            //roleManager.Create(f22);
            //roleManager.Create(f23);
            //roleManager.Create(f24);
            //roleManager.Create(f25);
            //roleManager.Create(f26);
            //roleManager.Create(f27);
            //roleManager.Create(f28);
            //roleManager.Create(f29);
            //roleManager.Create(f30);
            //roleManager.Create(f31);
            //roleManager.Create(f32);
            //roleManager.Create(f33);
            //roleManager.Create(f34);
            //roleManager.Create(f35);
            //roleManager.Create(f36);


            #endregion


            return View();
        }


        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}