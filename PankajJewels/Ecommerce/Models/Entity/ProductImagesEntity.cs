using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class ProductImagesEntity
    {
        [Key]
        public int PrImageId { get; set; }
        public int? ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageType { get; set; }
        public string ImagePage { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
