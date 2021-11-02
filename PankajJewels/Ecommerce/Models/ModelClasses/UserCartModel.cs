using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class UserCartModel
    {
        public int CartId { get; set; }
        public int? CartUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }
        public List<CartDetailsModel> CartDetails { get; set; }

        public OrderModel orderModel { get; set; }
    }

    public class CartDetailsModel
    {

        public int CartDetailId { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int? ProductDetailId { get; set; }
        public int? NumberOfItems { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? GST { get; set; }
        public decimal? DaimondPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? MakingCharges { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public string ProductImage { get; set; }
        public decimal GoldPrice { get; set; }
        public decimal GoldWeight { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public decimal GoldRate { get; set; }
        public DateTime AddedOn { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }

        public decimal BankChareges { get; set; }
        public decimal BankTax { get; set; }
    }
}
