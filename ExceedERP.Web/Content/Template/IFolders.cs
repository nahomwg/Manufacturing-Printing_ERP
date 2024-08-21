using System.Collections.Generic;
using Fisharoo.DataAccess;

namespace Fisharoo.Web.Mail.UserControls.Interfaces
{
    public interface IFolders
    {
        void LoadFolders(List<MessageFolder> Folders);
    }
}
