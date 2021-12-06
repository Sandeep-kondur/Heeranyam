using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class POMasterModel
    {
        public int POId { get; set; }
        public int? CartId { get; set; }
        public string TransactionId { get; set; }
        public int? UserId { get; set; }
        public string PONumber { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal? PaidAmount { get; set; }
        public string InstrumentDetails { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? RefundedOn { get; set; }
        public decimal? RefundedAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public List<PODetailsModel> poDetails { get; set; }
        public string UserName { get; set; }
        public string UserMobile { get; set; }
        public string UserAddress { get; set; }
        public decimal BankCharges { get; set; }
        public decimal BankTaxes { get; set; }
        public decimal Taxes { get; set; }
        public decimal OrderAmount { get; set; }
    }


    public class APIPOMasterModel
    {
        public int POId { get; set; }
        public int? CartId { get; set; }
        public string TransactionId { get; set; }
        public int? UserId { get; set; }
        public string PONumber { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal? PaidAmount { get; set; }
        public string InstrumentDetails { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? RefundedOn { get; set; }
        public decimal? RefundedAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public List<PODetailsModel> poDetails { get; set; }
        public List<APIPODetailsModel> APIpoDetails { get; set; }

        public string UserName { get; set; }
        public string UserMobile { get; set; }
        public string UserAddress { get; set; }
        public decimal BankCharges { get; set; }
        public decimal BankTaxes { get; set; }
        public decimal Taxes { get; set; }
        public decimal OrderAmount { get; set; }
    }
    public class APIPODetailsModel
    {
        public int PODetailId { get; set; }

        public int? ProductId { get; set; }
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
        public decimal? GoldPrice { get; set; }
        public decimal? GoldWeight { get; set; }
        public int? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? GoldRate { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }
        public string ProductName { get; set; }
        public string ImageURL  { get; set; }
    }

    public class PODetailsModel
    {
        public int PODetailId { get; set; }
      
        public int? ProductId { get; set; }
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
        public decimal? GoldPrice { get; set; }
        public decimal? GoldWeight { get; set; }
        public int? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? GoldRate { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }
    }
}
