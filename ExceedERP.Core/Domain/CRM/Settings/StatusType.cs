﻿using ExceedERP.Core.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExceedERP.Core.Domain.CRM
{
    public class StatusType : TrackUserSettingOperation
    {
         [DisplayName(" Id")]
        public int StatusTypeId { get; set; }
           [Required]
        public string Name { get; set; }
        public string Description { get; set; }
           [Required]
        public string Color { get; set; }
           public FinalizeType Status { get; set; }
        public string Remark { get; set; }
        [NotMapped]
        [DefaultValue("")]
        [DisplayName("Color")]
        public string ColorHolder { get; set; }
    }
  
}
