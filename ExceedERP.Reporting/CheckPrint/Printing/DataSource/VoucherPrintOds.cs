using ExceedERP.DataAccess.Context;
using System.ComponentModel;
using System.Linq;
using System.IO;
using XAPI;
using ExceedERP.Reporting.CheckPrint.Printing.ViewModel;
using System.Drawing;

namespace ExceedERP.Reporting.CheckPrint.Printing.DataSource
{
    [DataObject]
    public class VoucherPrintOds
    {
        private readonly ExceedDbContext db = new ExceedDbContext();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public VoucherPrintViewModel GetVoucher(string code)
        {
            return null;
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return null;

        }
    }
}
