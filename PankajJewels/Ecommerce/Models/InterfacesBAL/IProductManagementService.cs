using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;


namespace Ecommerce.Models.InterfacesBAL
{
    public interface IProductManagementService
    {
        List<APIProductListDisplay> APIGetProductsByDetId(int userid, string url, int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "");
        List<APIProductListDisplay> APISearchGetProductsByCatId(int userid, string url, int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        List<APIProductListDisplay> APIGetProductsBySearch(int userid,string url, int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        List<APIProductListDisplay> APIGetProductsBySearchforUser(int userid, int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        List<ProductListDisplay> APIGetProductsBySearch(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        APIPostProductModel APIGetProductDetails(int productId,int userid);
        List<UserReviewMaster> GetProductReviews(int productId, int userid);
        int isInWishList(int productid, int userid);
        List<ProductImagesEntity> GetMainImages(int id);
        void DeleteMainImage(int imageid);
        List<ProductDetailImagesEntity> GetDetialImages(int id);
        void DeleteDetailImage(int imageid);
        List<POFollowUpEntity> GetPOFollowups(int poid);
        ProcessResponse SaveFollowUp(POFollowUpEntity request);

        POFollowUpEntity GetPOFollowUpById(int id);
        int GetProductsByFilter_count(string query);
        List<ProductListDisplay> GetProductsByFilter(string query);
        List<ProductListDisplay> GetProductsBySearch(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        public int GetProductsBySearch_count(int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "");
        List<ProductDetailsDisplay> GetSubProducts(int pid);
        PriceBreakUpModel CalculatePrice(int prid, int pdid = 0);
        ProductMasterEntity GetProductMasterByid(int id);
        decimal GetGSTRate();
        decimal GetDisocuntRate(int id);
        PostProductModel_Web GetProductDetails_Web(int productId, int pdid = 0);
        int GetProductsByDetId_Count(int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "");
        int GetProductsByCatId_Count(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        List<ProductListDisplay> GetProductsByCatId(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "");
        List<ProductListDisplay> GetProductsByDetId(int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "");
        ProcessResponse SaveProductMaster(ProductMasterEntity request);
        ProcessResponse SaveProductDetail(ProductDetailsEntity request);
        ProcessResponse SaveDaimondsMain(DaimondsPerProductEntity request);
        ProcessResponse SaveDaimondsDetails(DaimondsPerPrdDetailsEntity request);
        ProcessResponse SavePerlMain(PerlPerProductEntity request);
        ProcessResponse SavePerlDeail(PerlPerPrdDetailsEntity request);

        ProcessResponse SaveSolitaireMain(SolitairePerProductEntity request);
        ProcessResponse SaveSolitaireDetails(SolitairePerPrdDetailsEntity request);

        ProcessResponse SaveSRubyMain(SRubyPerProductEntity request);
        ProcessResponse SaveSRubyDetails(SRubyPerPrdDetailsEntity request);

        ProcessResponse SaveProductMainImage(ProductImagesEntity request);

        ProcessResponse SaveDetailImages(ProductDetailImagesEntity request);

        PostProductModel GetProductDetails(int productId);
        List<ProductListDisplay> GetMyProducts(int postedBy);
        GoldRateMasterEntity GetGoldRate();

        ProcessResponse UpdateGoldRate(GoldRateMasterEntity request);
        List<ProductListDisplay> SearchProducts(int catId, int scatId, int detCatId, string search = "", int pageNumber = 1, int pageSize = 10);

        List<APIProductListDisplay> APIGetLatestProducts(string src = "0");
        List<ProductListDisplay> GetLatestProducts(string src = "0");
        decimal GetGoldTodayRate();
        decimal GetMetalTypeRate(int metalId);
        decimal GetDaimondRate(int typeid);
        void UpdateProductPrice(ProductDetailsEntity request);
        ProductDetailsEntity GetProductDetailById(int id);
        List<SolPerPrdDisplayModel> GetSolPerList(int detailid);
        List<PerlPerPrdDisplayModel> GetPerlPerList(int detailid);
        List<DaimondsPerPrdDisplayModel> GetDaimondPerList(int detailid);
        List<SRubyPerPrdDisplayModel> GetSRubyPerList(int detailid);

        void DeleteDaimondPerPrd(int id);
        void DeleteSRubyPerPrd(int id);
        void DeletePerlPerPrd(int id);
        void DeleteSolPerPrd(int id);


        List<APIProductListDisplay> APIGetProductsByCatId(ProductDetailsRequest request, string url, int userId);
    }
}
