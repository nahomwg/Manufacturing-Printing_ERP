using ExceedERP.Core.Domain.CheckPrint;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceedERP.DataAccess.Context
{
    public class CPBankEntityTypeConfiguration : EntityTypeConfiguration<CPBank>
    {

        public CPBankEntityTypeConfiguration()
        {
            this.ToTable("CPBanks", "CheckPrint");
            this.HasKey<int>(t => t.CPBankId);

        }
    }
    public class CPBankAccountEntityTypeConfiguration : EntityTypeConfiguration<CPBankAccount>
    {

        public CPBankAccountEntityTypeConfiguration()
        {
            this.ToTable("CPBankAccounts", "CheckPrint");
            this.HasKey<int>(t => t.CPBankAccountId);

        }
    }
    public class CPCheckBookEntityTypeConfiguration : EntityTypeConfiguration<CPCheckBook>
    {

        public CPCheckBookEntityTypeConfiguration()
        {
            this.ToTable("CPCheckBooks", "CheckPrint");
            this.HasKey<int>(t => t.CPCheckBookId);

        }
    }
    public class CPCheckBookCheckNumberEntityTypeConfiguration : EntityTypeConfiguration<CPCheckBookCheckNumber>
    {

        public CPCheckBookCheckNumberEntityTypeConfiguration()
        {
            this.ToTable("CPCheckBookCheckNumbers", "CheckPrint");
            this.HasKey<int>(t => t.CPCheckBookCheckNumberId);

        }
    }
    //public class CheckTemplateEntityTypeConfiguration : EntityTypeConfiguration<CheckTemplate>
    //{

    //    public CheckTemplateEntityTypeConfiguration()
    //    {
    //        this.ToTable("CheckTemplate", "CheckPrint");
    //        this.HasKey<int>(t => t.CheckTemplateId);

    //    }
    //}
    public class CheckEntityTypeConfiguration : EntityTypeConfiguration<Check>
    {

        public CheckEntityTypeConfiguration()
        {
            this.ToTable("Checks", "CheckPrint");
            this.HasKey<int>(t => t.CheckId);

        }
    }
    public class CPPaymentVoucherEntityTypeConfiguration : EntityTypeConfiguration<CPPaymentVoucher>
    {

        public CPPaymentVoucherEntityTypeConfiguration()
        {
            this.ToTable("CPPaymentVouchers", "CheckPrint");
            this.HasKey<int>(t => t.CPPaymentVoucherId);

        }
    }
}
