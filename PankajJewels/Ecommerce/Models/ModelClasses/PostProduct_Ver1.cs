using Ecommerce.Models.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class PostProduct_Ver1
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Title Required")]
        public string ProductTitle { get; set; }
        [Required(ErrorMessage = "Description Required")]
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
        public List<string> ProductMainImages_List { get; set; }

        public string DiscountMaster_IdName { get; set; }
        public decimal? DiscountAmount { get; set; }
        public GoldRateMasterEntity GoldRate { get; set; }
     
        public List<GSTMasterEntity> GST { get; set; }
        public PriceBreakUpModel priceBreakup { get; set; }
        public List<DiscountMasterEntity> discountMaster { get; set; }
        public List<CategoryMasterEntity> catMaster { get; set; }
        public List<SubCategoryMasterEntity> subCatMaster { get; set; }
        public List<DetailCategoryMasterEntity> detCatMaster { get; set; }
        public decimal currentGoldRate { get; set; }
        public string PrefferedGender { get; set; }
        public string IsAllGold  { get; set; }
        public string IsHotDeal { get; set; }
        public List<ProductImagesEntity> mainImages { get; internal set; }
    }
    public class ProductDetails_V1
    {
        // product details
        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
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
        public List<MetalMasterEntity> MetalMaster { get; set; }
        public List<MeasurementMasterEntity> measureMaster { get; set; }
        public List<DaimondTypeMasterEntity> DiamondRate { get; set; }
        public List<SizeMasterEntity> Sizes { get; set; }
        public List<DaimondCaratMasterEntity> dCaratMaster { get; set; }
        public List<DaimondClarityMasterEntity> dClarityMaster { get; set; }
        public List<DaimondCutMasterEntity> dCutMaster { get; set; }
        public List<DaimondSettingMasterEntity> dSettingMaster { set; get; }
        public List<DaimondShapeMasterEntity> dShapeMaster { get; set; }
        public decimal currentGoldRate { get; set; }

        [Required(ErrorMessage ="Making Charges required")]
        public decimal? MakingCharges { get; set; }
        public List<IFormFile> ProductDetailImages { get; set; }
        public List<string> ProductDetailImages_List { get; set; }
        public List<DaimondColorMasterEntity> dColorMaster { get; set; }
        public List<DaimondTypeMasterEntity> dTypeMaster { get; set; }

        public List<SolitaireShapeMasterEntity> sShapeMaster { get; set; }

        public List<SymmetryMasterEntity> sSymmetryMaster { get; set; }
        public List<FluorescenceMasterEntity> sFluroMaster { get; set; }
        public List<CertificateMasterEntity> sCertiMaster { get; set; }
        // daimond data
        public int[] daimondClarityId { get; set; }
        public int[] daimondColorId { get; set; }
        public int[] daimondShapeId { get; set; }
        public int[] daimondSettingId { get; set; }
        public int[] daimondLineTotal { get; set; }
        public decimal[] daimondLineWeight { get; set; }
        public int[] daimondTypeId { get; set; }

        public int[] daimondClarityId1 { get; set; }
        public int[] daimondColorId1 { get; set; }
        public int[] daimondShapeId1 { get; set; }
        public int[] daimondSettingId1 { get; set; }
        public int[] daimondLineTotal1 { get; set; }
        public decimal[] daimondLineWeight1 { get; set; }
        public int[] daimondTypeId1 { get; set; }


        //solitaire
        public int[] solClarityId { get; set; }
        public int[] solColorId { get; set; }
        public int[] solShapeId { get; set; }
        public int[] solSymmetryId { get; set; }
        public int[] solFluorescenceId { get; set; }
        public int[] solLineTotal { get; set; }
        public decimal[] solLineWeight { get; set; }
        public int[] solCertificateId { get; set; }



        public int[] solClarityId1 { get; set; }
        public int[] solColorId1 { get; set; }
        public int[] solShapeId1 { get; set; }
        public int[] solSymmetryId1 { get; set; }
        public int[] solFluorescenceId1 { get; set; }
        public int[] solLineTotal1 { get; set; }
        public decimal[] solLineWeight1 { get; set; }
        public int[] solCertificateId1 { get; set; }


        //perl
        public int[] perlLineTotal { get; set; }
        public int[] perlShapeId { get; set; }

        public decimal[] perlSize { get; set; }
        public int[] perlSettingId { get; set; }



        public int[] perlLineTotal1 { get; set; }
        public int[] perlShapeId1 { get; set; }
        public string[] perlSize1 { get; set; }
        public int[] perlSettingId1 { get; set; }

        //sruby
        public int[] srubylLineTotal { get; set; }
        public int[] srubyShapeId { get; set; }

        public string[] srubySize { get; set; }
        public int[] srubySettingId { get; set; }



        public int[] srubyLineTotal1 { get; set; }
        public int[] srubyShapeId1 { get; set; }
        public string[] srubySize1 { get; set; }
        public int[] srubySettingId1 { get; set; }

        public List<ProductDetailImagesEntity> detImages { get; set; }
        public List<DaimondsPerPrdDisplayModel> DList { get;  set; }
        public List<SolPerPrdDisplayModel> SList { get;  set; }
        public List<SRubyPerPrdDisplayModel> SRList { get;  set; }
        public List<PerlPerPrdDisplayModel> PList { get;  set; }
    }
}
