using ExceedERP.Core.Domain.Common;
using ExceedERP.DataAccess.Context;
using System;
using System.Globalization;

namespace ExceedERP.Web.Hubs
{
    public class Notify
    {
        public static readonly ExceedDbContext Db = new ExceedDbContext();
        public static void NotifyUser(NotifModels obj)
        {

            Notification objNotif = new Notification
            {
                SentTo = obj.UserId,
                Title = obj.Title,
                Details = obj.Message,
                Date = DateTime.Now,
                DetailsUrl = obj.URL,
                DeadLine = obj.DeadLine.ToString(CultureInfo.InvariantCulture)
            };

            Db.Configuration.ProxyCreationEnabled = false;
            Db.Notifications.Add(objNotif);
            Db.SaveChanges();



        }
    }
}
