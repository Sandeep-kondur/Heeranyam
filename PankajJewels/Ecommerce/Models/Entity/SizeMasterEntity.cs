using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Entity
{
    public class SizeMasterEntity
    {
        [Key]
        public int SizeMasterId { get; set; }
        public string SizeName { get; set; }
        public int? SubCategoryId { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class SizeMasterForDeailPage
    {
        [Key]
        public int SizeMasterId { get; set; }
        public string SizeName { get; set; }
        public int? SubCategoryId { get; set; }
        public bool? IsDeleted { get; set; }
        public int ProductDetailId { get; set; }
    }

    public class SizeMasterDisplay
    {
        
        public int SizeMasterId { get; set; }
        public string SizeName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
