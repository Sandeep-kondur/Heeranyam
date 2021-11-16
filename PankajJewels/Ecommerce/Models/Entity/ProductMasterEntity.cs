using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Entity
{
    public class ProductMasterEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public int? NoofViews { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? DetailCategoryId { get; set; }

        public string Tags { get; set; }
        public string PrefferedGender { get; set; }
        public string IsAllGold { get; set; }
        public string IsHotDeal { get; set; }

        public int Stock { get; set; }
    }
}
