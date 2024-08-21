using ExceedERP.Core.Domain.Global;
using ExceedERP.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ExceedERP.Helpers.Common
{
    public class UserHelper
    {

            public static void DeleteLog(string ip, string type, string status, string user, string description)
            { }

        public static void OperationLog(string ip, string type, string status, string user, string description, Modules module)
        {
            ExceedDbContext db = new ExceedDbContext();
            GlobalOperationLog log = new GlobalOperationLog
            {
                IpAddress = ip,
                UserName = user,
                TimeAccessed = DateTime.Now,
                Type = type,
                Status = status,
                Description = description,
                Module = module
            };
            db.GlobalOperationLogs.Add(log);
            db.SaveChanges();
        }
        public static List<string> GetUserBranchId(string user)
        {

            List<string> branchId = new List<string>();
            string strcon = ConfigurationManager.ConnectionStrings["ExceedERPUserManagment"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlDataReader myReader = null;
            try
            {
                string userId = GetUserId(user);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select UserBranchId from  [User].ApplicationUsersBranch where ApplicationUserId=@user", con);
                cmd.Parameters.AddWithValue("@user", userId);
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    branchId.Add(myReader[0].ToString());
                }
            }
            catch (Exception exe)
            {
                //log
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
            return branchId;
        }
        public static string GetUserId(string user)
        {
            string empid = "";
            string strcon = ConfigurationManager.ConnectionStrings["ExceedERPUserManagment"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlDataReader myReader = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Id from [User].AspNetUsers where UserName=@user", con);
                cmd.Parameters.AddWithValue("@user", user);
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    empid = (myReader[0].ToString());
                }
            }
            catch (Exception exe)
            {
                //log
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
            return empid;
        }
        public static int GetUserEmployeeId(string user)
        {
            int empid = 0;
            string strcon = ConfigurationManager.ConnectionStrings["ExceedERPUserManagment"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlDataReader myReader = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select EmployeeId from  [User].AspNetUsers where UserName=@user", con);
                cmd.Parameters.AddWithValue("@user", user);
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    empid = int.Parse(myReader[0].ToString());
                }
            }
            catch (Exception exe)
            {
                //log
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
            return empid;
        }
    }

}
