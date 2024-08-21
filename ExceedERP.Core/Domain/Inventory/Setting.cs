﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceedERP.Core.Domain.Common;

namespace ExceedERP.Core.Domain.Inventory
{
    public enum AveragePriceLvel
    {
        PerStore,
        PerBranch,
        PerCompany
    }

    public enum InventorySettingCategories
    {
        ITEM_CODE_LENGTH,
        PRINT_COPY_QTY,
        PRINT_COPY_MEMBER,
        ITEM_CODE_AUTO_GENERATE,
        BINCARD_SORT_ORDER,
        ALLOW_BINCARD_RECALCULATE,
        RECALCULATE_SOURCE_TRANSACTION_ON_BINCARD_UPDATE,
        REPLACE_COSTCENTER_ON_ISSUE_DEBIT,
        HIDE_PRICE_ON_PRINT,
        APPLY_ELECTRONIC_SIGNATURE
    }

    public enum BincardSortOrderAttributes
    {
        SequencialId,
        DateOfTransaction
    }
    public enum ItemCodeLengthAttributes
    {
        Quantity
    }
    public enum PrintCopyAttributes
    {
        GOOD_RECEIVE_NOTE,
        STORE_ISSUE_VOUCHER,
        STORE_REQUISITION,
        STORE_RETURN,
        STORE_TRANSFER_SEND,
        STORE_TRANSFER_RECEIVE,
        GOOD_SALES_DONATION,
        PURCHASE_REQUISITION
    }
    public enum BooleanTypeAttributes
    {
        TRUE,
        FALSE
    }
    public class FuelItemSetting : TrackUserSettingOperation
    {
        public int FuelItemSettingId { get; set; }
        [Required]
        [DisplayName("Item Category")]
        public string ItemCategoryCode { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        [Required]
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
    }

    public class AveragePriceSetting : TrackUserSettingOperation
    {
        public int AveragePriceSettingId { get; set; }
        [Required]
        [DisplayName("Averaging Level")]
        public AveragePriceLvel Level { get; set; }

    }

   
}
