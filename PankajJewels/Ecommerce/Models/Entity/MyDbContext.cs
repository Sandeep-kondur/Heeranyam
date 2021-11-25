using Ecommerce.Models.ModelClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserMasterEntity>().ToTable("UserMaster");
            modelBuilder.Entity<UserTypeMasterEnity>().ToTable("UserTypeMaster");
            modelBuilder.Entity<EmailTemplateEntity>().ToTable("EmailTemplates");
            modelBuilder.Entity<CountryMasterEntity>().ToTable("CountryMaster");
            modelBuilder.Entity<StateMasterEntity>().ToTable("StateMaster");
            modelBuilder.Entity<CityMasterEntity>().ToTable("CityMaster");
            modelBuilder.Entity<UserVerificationEntity>().ToTable("UserVerification");
            modelBuilder.Entity<ResetPasswordEntity>().ToTable("ResetPassword");
            modelBuilder.Entity<CategoryMasterEntity>().ToTable("CategoryMaster");
            modelBuilder.Entity<SubCategoryMasterEntity>().ToTable("SubCategoryMaster");
            modelBuilder.Entity<DetailCategoryMasterEntity>().ToTable("DetailCategoryMaster");
            modelBuilder.Entity<BannerAdsEntity>().ToTable("BannerAds");
            modelBuilder.Entity<ApplicationErrorLogEntity>().ToTable("ApplicationErrorLog");
            modelBuilder.Entity<DaimondCaratMasterEntity>().ToTable("DaimondCaratMaster");
            modelBuilder.Entity<DaimondClarityMasterEntity>().ToTable("DaimondClarityMaster");
            modelBuilder.Entity<DaimondColorMasterEntity>().ToTable("DaimondColorMaster");
            modelBuilder.Entity<DaimondCutMasterEntity>().ToTable("DaimondCutMaster");
            modelBuilder.Entity<DaimondSettingMasterEntity>().ToTable("DaimondSettingMaster");
            modelBuilder.Entity<DaimondShapeMasterEntity>().ToTable("DaimondShapeMaster");
            modelBuilder.Entity<FluorescenceMasterEntity>().ToTable("FluorescenceMaster");
            modelBuilder.Entity<GoldMasterEntity>().ToTable("GoldMaster");
            modelBuilder.Entity<GoldRateMasterEntity>().ToTable("GoldRateMaster");
            modelBuilder.Entity<GSTMasterEntity>().ToTable("GSTMaster");
            modelBuilder.Entity<MetalMasterEntity>().ToTable("MetalMaster");
            modelBuilder.Entity<PolishMasterEntity>().ToTable("PolishMaster");
            modelBuilder.Entity<RubyShapeMasterEntity>().ToTable("RubyShapeMaster");
            modelBuilder.Entity<SolitaireShapeMasterEntity>().ToTable("SolitaireShapeMaster");
            modelBuilder.Entity<SymmetryMasterEntity>().ToTable("SymmetryMaster");
            modelBuilder.Entity<TagMasterEntity>().ToTable("TagMaster");
            modelBuilder.Entity<DaimondTypeMasterEntity>().ToTable("DaimondTypeMaster");
            modelBuilder.Entity<CertificateMasterEntity>().ToTable("CertificateMaster");
            modelBuilder.Entity<SizeMasterEntity>().ToTable("SizeMaster");
            modelBuilder.Entity<DiscountMasterEntity>().ToTable("DiscountMaster");
            modelBuilder.Entity<MeasurementMasterEntity>().ToTable("MeasurementMaster");
            modelBuilder.Entity<ProductMasterEntity>().ToTable("ProductMaster");
            modelBuilder.Entity<ProductDetailsEntity>().ToTable("ProductDetails");
            modelBuilder.Entity<ProductMasterEntity>().ToTable("ProductMaster");
            modelBuilder.Entity<DaimondsPerPrdDetailsEntity>().ToTable("DaimondsPerPrdDetails");
            modelBuilder.Entity<DaimondsPerProductEntity>().ToTable("DaimondsPerProduct");
            modelBuilder.Entity<PerlPerProductEntity>().ToTable("PerlPerProduct");
            modelBuilder.Entity<PerlPerPrdDetailsEntity>().ToTable("PerlPerPrdDetails");
            modelBuilder.Entity<ProductImagesEntity>().ToTable("ProductImages");
            modelBuilder.Entity<ProductDetailImagesEntity>().ToTable("ProductDetailImages");
            modelBuilder.Entity<SolitairePerPrdDetailsEntity>().ToTable("SolitairePerPrdDetails");
            modelBuilder.Entity<SolitairePerProductEntity>().ToTable("SolitairePerProduct");
            modelBuilder.Entity<SRubyPerPrdDetailsEntity>().ToTable("SRubyPerPrdDetails");
            modelBuilder.Entity<SRubyPerProductEntity>().ToTable("SRubyPerProduct");
            modelBuilder.Entity<CartMasterEntity>().ToTable("CartMaster");
            modelBuilder.Entity<CartDetailsEntity>().ToTable("CartDetails");
            modelBuilder.Entity<POMasterEntity>().ToTable("POMaster");
            modelBuilder.Entity<PODetailsEntity>().ToTable("PODetails");
            modelBuilder.Entity<ProductListDisplay>().HasNoKey();
            modelBuilder.Entity<SingleQueryCountModel>().HasNoKey();
            modelBuilder.Entity<WishListEntity>().ToTable("WishList");
            modelBuilder.Entity<AddressEntity>().ToTable("Address");
            modelBuilder.Entity<AddressTypesEntity>().ToTable("AddressTypes");
            modelBuilder.Entity<POFollowUpEntity>().ToTable("POFollowUp");
            modelBuilder.Entity<RazorPaymentResultEntity>().ToTable("RazorPaymentResult");
            modelBuilder.Entity<BannerPageMaster>().ToTable("BannerPageMaster");
            modelBuilder.Entity<BannerPageSection>().ToTable("BannerPageSection");
            modelBuilder.Entity<BannerType>().ToTable("BannerType");
            modelBuilder.Entity<CustomizeOrderEntity>().ToTable("CustomizeOrder");
            modelBuilder.Entity<LoginTrack>().ToTable("LoginTrack");
            modelBuilder.Entity<ContactUs>().ToTable("ContactUs");
            modelBuilder.Entity<UserReviewMaster>().ToTable("UserReviewMaster");
            modelBuilder.Entity<LoginTypeEntity>().ToTable("LoginType");
            modelBuilder.Entity<DaimondsPerPrdDisplayModel>().HasNoKey();
            modelBuilder.Entity<PerlPerPrdDisplayModel>().HasNoKey();
            modelBuilder.Entity<SRubyPerPrdDisplayModel>().HasNoKey();
            modelBuilder.Entity<SolPerPrdDisplayModel>().HasNoKey();


        }

        public DbSet<UserReviewMaster> UserReviewMasters { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<LoginTrack> loginTracks { get; set; }
        public DbSet<CustomizeOrderEntity>  customizeOrderEntities { get; set; }
        public DbSet<BannerPageMaster> bannerPageMasters { get; set; }
        public DbSet<BannerPageSection> bannerPageSections { get; set; }
        public DbSet<BannerType> bannerTypes { get; set; }
        public DbSet<RazorPaymentResultEntity> razorPaymentResultEntities { get; set; }
        public DbSet<POFollowUpEntity> pOFollowUpEntities { get; set; }
        public DbSet<AddressTypesEntity> addressTypesEntities { get; set; }
        public DbSet<AddressEntity> addressEntities { get; set; }
        public DbSet<WishListEntity> wishListEntities { get; set; }
        public DbSet<POMasterEntity> pOMasterEntities { get; set; }
        public DbSet<PODetailsEntity> pODetails { get; set; }
        public DbSet<UserMasterEntity> userMasters { get; set; }

        public DbSet<LoginTypeEntity> logInTypes { get; set; }
        public DbSet<ResetPasswordEntity> resetPasswordEntities { get; set; }
        public DbSet<UserVerificationEntity> userVerificationEntities { get; set; }
        public DbSet<UserTypeMasterEnity> userTypeMasters { get; set; }
        public DbSet<CountryMasterEntity> countryMasterEntities { get; set; }
        public DbSet<StateMasterEntity> stateMasterEntities { get; set; }
        public DbSet<CityMasterEntity> cityMasterEntities { get; set; }
        public DbSet<OtpTransactionsEntity> OtpTransactions { get; set; }
        public DbSet<EmailTemplateEntity> emailTemplateEntities { get; set; }
        public DbSet<CategoryMasterEntity> categoryMasterEntities { get; set; }
        public DbSet<SubCategoryMasterEntity> subCategoryMasters { get; set; }
        public DbSet<DetailCategoryMasterEntity> detailCategoryMasters { get; set; }
        public DbSet<BannerAdsEntity> bannerAdsEntities { get; set; }
        public DbSet<ApplicationErrorLogEntity> applicationErrorLogEntities { get; set; }
        public DbSet<DaimondCaratMasterEntity> daimondCaratMasterEntities { get; set; }
        public DbSet<DaimondClarityMasterEntity> daimondClarityMasterEntities { set; get; }
        public DbSet<DaimondColorMasterEntity> daimondColorMasterEntities { get; set; }
        public DbSet<DaimondCutMasterEntity> daimondCutMasterEntities { get; set; }
        public DbSet<DaimondSettingMasterEntity> daimondSettingMasterEntities { get; set; }
        public DbSet<DaimondShapeMasterEntity> daimondShapeMasterEntities { get; set; }
        public DbSet<FluorescenceMasterEntity> fluorescenceMasterEntities { get; set; }
        public DbSet<GoldMasterEntity> goldMasterEntities { get; set; }
        public DbSet<GoldRateMasterEntity> goldRateMasterEntities { get; set; }
        public DbSet<GSTMasterEntity> gSTMasterEntities { get; set; }
        public DbSet<MetalMasterEntity> metalMasterEntities { get; set; }
        public DbSet<PolishMasterEntity> polishMasterEntities { get; set; }
        public DbSet<RubyShapeMasterEntity> rubyShapeMasterEntities { get; set; }
        public DbSet<SolitaireShapeMasterEntity> solitaireShapeMasterEntities { get; set; }
        public DbSet<SymmetryMasterEntity> symmetryMasterEntities { get; set; }
        public DbSet<TagMasterEntity> tagMasterEntities { get; set; }
        public DbSet<DaimondTypeMasterEntity> daimondTypeMasterEntities { get; set; }
        public DbSet<CertificateMasterEntity> certificateMasterEntities { get; set; }
        public DbSet<SizeMasterEntity> sizeMasterEntities { get; set; }
        public DbSet<DiscountMasterEntity> discountMasterEntities { get; set; }
        public DbSet<MeasurementMasterEntity> measurementMasterEntities { get; set; }
        public DbSet<ProductMasterEntity> productMasterEntities { get; set; }
        public DbSet<ProductDetailsEntity> productDetailsEntities { get; set; }
        public DbSet<DaimondsPerPrdDetailsEntity> daimondsPerPrdDetailsEntities { get; set; }
        public DbSet<DaimondsPerProductEntity> daimondsPerProductEntities { get; set; }
        public DbSet<PerlPerPrdDetailsEntity> perlPerPrdDetailsEntities { set; get; }
        public DbSet<PerlPerProductEntity> perlPerProductEntities { get; set; }
        public DbSet<ProductImagesEntity> productImagesEntities { get; set; }
        public DbSet<ProductDetailImagesEntity> productDetailImagesEntities { get; set; }
        public DbSet<SolitairePerPrdDetailsEntity> solitairePerPrdDetailsEntities { get; set; }
        public DbSet<SolitairePerProductEntity> solitairePerProductEntities { get; set; }
        public DbSet<SRubyPerPrdDetailsEntity> sRubyPerPrdDetailsEntities { get; set; }
        public DbSet<SRubyPerProductEntity> sRubyPerProductEntities { get; set; }
        public DbSet<CartMasterEntity> cartMasterEntities { get; set; }
        public DbSet<CartDetailsEntity> cartDetailsEntities { get; set; }
    }
}
