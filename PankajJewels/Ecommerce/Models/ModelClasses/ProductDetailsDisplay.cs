using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class ProductDetailsDisplay
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string ProductCode { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public int? HeightMeasurementId { get; set; }
        public int? WeightMeasurementId { get; set; }
        public int? MetalMasterId { get; set; }
        public decimal? MetalWeight { get; set; }
        public int? MetailWeightMesuremetnId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string SubTitleText { get; set; }
        public decimal? ProductWeight { get; set; }
        public int? ProductWeightMeasurement { get; set; }
        public int? SizeMasterId { get; set; }

        public string SizeMasterId_Name { get; set; }

        public List<string> ProductImages_List { get; set; }
    }
}
