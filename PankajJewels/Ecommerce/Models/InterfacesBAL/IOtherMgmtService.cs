using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
   public interface IOtherMgmtService
    {
        int GetAllCategories_Count(PaginationRequest request);
        int GetAllDetailCategories_Count(GenericRequest request);
        bool CheckDetailCategoryType(string rquest, int catid = 0, int detcatid = 0);
        bool CheckSubCategoryType(string rquest, int catid = 0, int subcatid = 0);

        bool CheckCategoryType(string rquest, int typeId = 0);
        List<CategoryMasterEntity> GetAllCategories(PaginationRequest request);
        CategoryMasterEntity GetCategoryById(int categoryId);
        ProcessResponse SaveCategory(CategoryMasterEntity request);
        ProcessResponse UpdateCategory(CategoryMasterEntity request);



        /// <summary>
        /// Sub category management
        /// </summary>
        /// <returns></returns>
        List<SubCategoryMasterEntity> GetAllSubCategories(GenericRequest request);
        int GetAllSubCategories_Count(GenericRequest request);
        SubCategoryMasterEntity GetSubCategoryById(int subCategoryId);
        ProcessResponse SaveSubCategory(SubCategoryMasterEntity request);
        ProcessResponse UpdateSubCategory(SubCategoryMasterEntity request);

        /// <summary>
        /// Detail category management
        /// </summary>
        /// <returns></returns>
        List<DetailCategoryMasterEntity> GetAllDetailCategories(GenericRequest request);
        DetailCategoryMasterEntity GetDetailCategoryById(int detailCategoryId);
        ProcessResponse SaveDetailCategory(DetailCategoryMasterEntity request);
        ProcessResponse UpdateDetailCategory(DetailCategoryMasterEntity request);

        List<CountryMasterEntity> GetAllCountries(int pageNumber = 1, int pagesize = 10, string search="");
        int GetCountryCount(string search = "");
        CountryMasterEntity GetCountryById(int countryId);
        ProcessResponse SaveCountryMaster(CountryMasterEntity request);
        public ProcessResponse UpdateCountryMaster(CountryMasterEntity request);
        bool CheckCountryName(string request, int counryId = 0);

        List<StateMasterEntity> GetAllStates(int pageNumber = 1, int pagesize = 10, string search = "", int countryId = 0);


        int GetStateCount(string search = "", int countryId = 0);

        List<CityMasterEntity> GetAllCities(int pageNumber = 1, int pagesize = 10, string search = "", int stateId = 0);


        int GetCityCount(string search = "", int stateId = 0);

        ProcessResponse SaveBannerAdd(BannerAdsEntity request);

        BannerAdsEntity GetBannerById(int id);
        List<BannerAdsDisplayModel> GetAllBanners(string page);
        List<BannerPageMaster> GetBannerPages();
        List<BannerPageSection> GetBannerSections();

    }
}
