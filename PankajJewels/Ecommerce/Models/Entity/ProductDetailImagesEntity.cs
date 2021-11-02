using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class ProductDetailImagesEntity
    {
        [Key]
        public int PrDetailImageId { get; set; }
        public int? ProductDetailId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageType { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
