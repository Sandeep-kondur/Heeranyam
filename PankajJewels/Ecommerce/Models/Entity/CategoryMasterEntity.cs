using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class CategoryMasterEntity
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage ="Category Name required")]
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public bool? IsDeleted { get; set; }
        public bool DisplayInHome { get; set; } = false;
        public int? SequenceNumber { get; set; }
    }
    public class SubCategoryMasterEntity
    {
        [Key]
        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = "Sub Category Name required")]
        public string SubCategoryName { get; set; }
        public string SubCategoryCode { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CategoryId { get; set; }
    }


    public class DetailCategoryMasterEntity
    {
        [Key]
        public int DetailCategoryId { get; set; }
        [Required(ErrorMessage = "Detail Category Name required")]
        public string DetailCategoryName { get; set; }
        public string DetailCategoryCode { get; set; }
        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage ="Subcategory required")]
        public int? SubCategoryId { get; set; }
        [Required(ErrorMessage = "Category required")]
        public int? CategoryId { get; set; }
    }

}
