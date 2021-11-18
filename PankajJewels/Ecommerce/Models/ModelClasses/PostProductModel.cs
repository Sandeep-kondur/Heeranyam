using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Models.ModelClasses
{

    public class APIPostProductModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryId_name { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryId_name { get; set; }
        public int? DetailCategoryId { get; set; }
        public string DetailCategoryId_name { get; set; }

        public List<IFormFile> ProductMainImages { get; set; }
        public string ProductMainImages_List { get; set; }

        public List<APIProductDetailsModel> ProductDetails { get; set; }

        public WishListEntity WishList { get; set; }
        public string DiscountMaster_IdName { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string PrefferedGender { get; set; }
        public int Stock { get; set; }
    }
    public class PostProductModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; } 
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }  
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryId_name { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryId_name { get; set; }
        public int? DetailCategoryId { get; set; }
        public string DetailCategoryId_name { get; set; }

        public List<IFormFile> ProductMainImages { get; set; }
        public string ProductMainImages_List { get; set; }

        public List<ProductDetailsModel> ProductDetails { get; set; }

        public WishListEntity WishList { get; set; }
        public string DiscountMaster_IdName { get; set; }
        public decimal? DiscountAmount { get;   set; }
        public string PrefferedGender { get; set; }
    }


    public class APIProductDetailsModel
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string ProductCode { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public int? HeightMeasurementId { get; set; }
        public string HeightMeasurementId_name { get; set; }
        public int? WeightMeasurementId { get; set; }
        public string WeightMeasurementId_Name { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }
        public decimal? MetalWeight { get; set; }
        public int? MetailWeightMesuremetnId { get; set; }
        public string MetailWeightMesuremetnId_Name { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string SubTitleText { get; set; }
        public decimal? ProductWeight { get; set; }
        public int? ProductWeightMeasurement { get; set; }
        public string ProductWeightMeasurement_Name { get; set; }
        public List<SizeMasterEntity> SizeMasterEntity { get; set; }

        public DaimondsPerProductEntity DaimondsMain { get; set; }
        public List<DaimondsPerPrdDetailsEntity> DaimondsDetail { get; set; }

        public PerlPerProductEntity PerlMain { get; set; }
        public List<PerlPerPrdDetailsEntity> PerlDetails { get; set; }
        public List<IFormFile> ProductDetailImages { get; set; }
        public string ProductDetailImages_List { get; set; }
        public SolitairePerProductEntity SolitaireMain { get; set; }
        public List<SolitairePerPrdDetailsEntity> SolitaireDetails { get; set; }
        public SRubyPerProductEntity SRubyMain { get; set; }
        public List<SRubyPerPrdDetailsEntity> SRubyDetails { get; set; }
        public decimal? MakingCharges { get; set; }

    }
    public class ProductDetailsModel
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string ProductCode { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public int? HeightMeasurementId { get; set; }
        public string HeightMeasurementId_name { get; set; }
        public int? WeightMeasurementId { get; set; }
        public string WeightMeasurementId_Name { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }
        public decimal? MetalWeight { get; set; }
        public int? MetailWeightMesuremetnId { get; set; }
        public string MetailWeightMesuremetnId_Name { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string SubTitleText { get; set; }
        public decimal? ProductWeight { get; set; }
        public int? ProductWeightMeasurement { get; set; }
        public string ProductWeightMeasurement_Name { get; set; }
        public int? SizeMasterId { get; set; }
        public string SizeMasterId_name { get; set; }

        public DaimondsPerProductEntity  DaimondsMain { get; set; }
        public List<DaimondsPerPrdDetailsEntity> DaimondsDetail { get; set; }

        public PerlPerProductEntity PerlMain { get; set; }
        public List<PerlPerPrdDetailsEntity> PerlDetails { get; set; }
        public List<IFormFile> ProductDetailImages { get; set; }
        public  string ProductDetailImages_List { get; set; }
        public SolitairePerProductEntity SolitaireMain { get; set; }
        public List<SolitairePerPrdDetailsEntity> SolitaireDetails { get; set; }
        public SRubyPerProductEntity SRubyMain { get; set; }
        public List<SRubyPerPrdDetailsEntity> SRubyDetails { get; set; }
        public decimal? MakingCharges { get; set; }

    }

    public class APIProductListDisplay
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryId_name { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryId_name { get; set; }
        public int? DetailCategoryId { get; set; }
        public string DetailCategoryId_name { get; set; }
        public int? DiscountMasterId { get; set; }
        public string ProductMainImages_List { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public int IsInWishList { get; set; }

        public int Stock { get; set; }
    }
    public class ProductListDisplay
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryId_name { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryId_name { get; set; }
        public int? DetailCategoryId { get; set; }
        public string DetailCategoryId_name { get; set; }
        public int? DiscountMasterId { get; set; }
        public string ProductMainImages_List { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }

    }


    public class PostProductModel_Web
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }
        public string Tags { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryId_name { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryId_name { get; set; }
        public int? DetailCategoryId { get; set; }
        public string DetailCategoryId_name { get; set; }

        public List<IFormFile> ProductMainImages { get; set; }
        public string ProductMainImages_List { get; set; }

        public List<ProductDetailsModel_Web> ProductDetails { get; set; }

        public string DiscountMaster_IdName { get; set; }
        public decimal? DiscountAmount { get; set; }
        public GoldRateMasterEntity GoldRate { get; set; }
        public List<MetalMasterEntity> MetalMaster { get; set; }
        public List<DaimondTypeMasterEntity> DiamondRate { get; set; }
        public List<GSTMasterEntity> GST { get; set; }
        public  PriceBreakUpModel priceBreakup {get;set;}
        public List<DiscountMasterEntity> discountMaster { get; set; }
        public List<SizeMasterEntity> Sizes { get;   set; }
        public List<SizeMasterForDeailPage> MySizes { get;   set; }
        public string PrefferedGender { get; set; }
    }
    public class ProductDetailsModel_Web
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string ProductCode { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public int? HeightMeasurementId { get; set; }
        public string HeightMeasurementId_name { get; set; }
        public int? WeightMeasurementId { get; set; }
        public string WeightMeasurementId_Name { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }
        public decimal? MetalWeight { get; set; }
        public int? MetailWeightMesuremetnId { get; set; }
        public string MetailWeightMesuremetnId_Name { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string SubTitleText { get; set; }
        public decimal? ProductWeight { get; set; }
        public int? ProductWeightMeasurement { get; set; }
        public string ProductWeightMeasurement_Name { get; set; }
        public int? SizeMasterId { get; set; }
        public string SizeMasterId_name { get; set; }

        public DaimondsPerProductEntity DaimondsMain { get; set; }
        

        public PerlPerProductEntity PerlMain { get; set; }
        public List<IFormFile> ProductDetailImages { get; set; }
        public List<string> ProductDetailImages_List { get; set; }
        public SRubyPerProductEntity SRubyMain { get; set; }
        public SolitairePerProductEntity SolitaireMain { get; set; }

        public List<PerlPerPrdDetailsEntity_Web> PerlDetails { get; set; }
        public List<DaimondsPerPrdDetailsEntity_Web> DaimondsDetail { get; set; }
        public List<SRubyPerPrdDetailsEntity_Web> SRubyDetails { get; set; }
        public List<SolitairePerPrdDetailsEntity_Web> SolitaireDetails { get; set; }
        public decimal? MakingCharges { get;   set; }
    }
    public class ProductListDisplay_Web
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public bool? IsCustomizable { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public int? MaxDelivaryDays { get; set; }
        public int? DiscountApplicableId { get; set; }
        public bool? IsSizeApplicable { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryId_name { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryId_name { get; set; }
        public int? DetailCategoryId { get; set; }
        public string DetailCategoryId_name { get; set; }
        public int? DiscountMasterId { get; set; }
        public List<string> ProductMainImages_List { get; set; }
        public decimal? ActualPrice { get; set; }
        public decimal? SellingPrice { get; set; }

    }


}
