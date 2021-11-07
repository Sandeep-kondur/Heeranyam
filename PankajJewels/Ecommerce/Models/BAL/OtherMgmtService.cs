using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.BAL
{
    public class OtherMgmtService : IOtherMgmtService
    {
        private readonly MyDbContext context;
        private readonly ILogApplicationErrorService _logService;
        public OtherMgmtService(MyDbContext context, ILogApplicationErrorService logService)
        {
            this.context = context;
            _logService = logService;
        }

        /// <summary>
        /// category management
        /// </summary>
        /// <returns></returns>
        public List<CategoryMasterEntity> GetAllCategories(PaginationRequest request)
        {
            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<CategoryMasterEntity> result = new List<CategoryMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.categoryMasterEntities
                        .Where(a => a.IsDeleted == false && a.CategoryName.StartsWith(request.search)).OrderBy(b => b.CategoryName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.categoryMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.CategoryName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }

                
            }
            catch (Exception ex)
            { 
            
            }
            return result;
        }
        public int GetAllCategories_Count(PaginationRequest request)
        {
            int totalCount = 0;

            if (!string.IsNullOrEmpty(request.search))
            {

                totalCount = context.categoryMasterEntities
                       .Where(a => a.IsDeleted == false && a.CategoryName.StartsWith(request.search)).Count();
            }
            else
            {
                totalCount = context.categoryMasterEntities
                        .Where(a => a.IsDeleted == false).Count();

            }
            return totalCount;
        }
        public CategoryMasterEntity GetCategoryById(int categoryId)
        {
            return context.categoryMasterEntities.Where(a => a.CategoryId == categoryId).FirstOrDefault();
        }
        public ProcessResponse SaveCategory(CategoryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.categoryMasterEntities.Add(request);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Save Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }

            return response;
        }
        public ProcessResponse UpdateCategory(CategoryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.categoryMasterEntities.Where(a => a.CategoryId == request.CategoryId).FirstOrDefault();
                catObj.CategoryCode = request.CategoryCode;
                catObj.CategoryName = request.CategoryName;
                catObj.DisplayInHome = request.DisplayInHome;
                catObj.IsDeleted = request.IsDeleted;
                catObj.SequenceNumber = request.SequenceNumber;
                context.Entry(catObj).CurrentValues.SetValues(catObj);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Update Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }

            return response;
        }
        public bool CheckCategoryType(string rquest, int typeId = 0)
        {
            bool res = true;
            if (typeId == 0)
            {
                var check = context.categoryMasterEntities
                    .Where(a => a.CategoryName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.categoryMasterEntities
                    .Where(a => a.CategoryName.Trim().ToLower() == rquest.Trim().ToLower() && a.CategoryId != typeId)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }


        /// <summary>
        /// Sub category management
        /// </summary>
        /// <returns></returns>
        public List<SubCategoryMasterEntity> GetAllSubCategories(GenericRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<SubCategoryMasterEntity> result = new List<SubCategoryMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.subCategoryMasters
                        .Where(a => a.IsDeleted == false && a.SubCategoryName.StartsWith(request.search) 
                        && a.CategoryId == request.Id).OrderBy(b => b.SubCategoryName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.subCategoryMasters.Where(a => a.IsDeleted == false 
                    && a.CategoryId == request.Id)
                        .OrderBy(b => b.SubCategoryName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetAllSubCategories_Count(GenericRequest request)
        {
            int totalCount = 0;

            if (!string.IsNullOrEmpty(request.search))
            {

                totalCount = context.subCategoryMasters
                       .Where(a => a.IsDeleted == false && a.CategoryId == request.Id &&
                       a.SubCategoryName.StartsWith(request.search)).Count();
            }
            else
            {
                totalCount = context.subCategoryMasters
                        .Where(a => a.IsDeleted == false && a.CategoryId == request.Id).Count();

            }
            return totalCount;
        }
        public SubCategoryMasterEntity GetSubCategoryById(int subCategoryId)
        {
            return context.subCategoryMasters.Where(a => a.SubCategoryId == subCategoryId).FirstOrDefault();
        }
        public ProcessResponse SaveSubCategory(SubCategoryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.subCategoryMasters.Add(request);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Save Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }

            return response;
        }
        public ProcessResponse UpdateSubCategory(SubCategoryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.subCategoryMasters.Where(a => a.SubCategoryId== request.SubCategoryId).FirstOrDefault();
                catObj.SubCategoryCode = request.SubCategoryCode;
                catObj.SubCategoryName = request.SubCategoryName;
                catObj.IsDeleted = request.IsDeleted;
                catObj.CategoryId = request.CategoryId;
                context.Entry(catObj).CurrentValues.SetValues(catObj);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Update Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }
            return response;
        }
        public bool CheckSubCategoryType(string rquest, int catid = 0, int subcatid=0)
        {
            bool res = true;
            if (subcatid == 0)
            {
                var check = context.subCategoryMasters  
                    .Where(a => a.SubCategoryName.Trim().ToLower() == rquest.Trim().ToLower() && a.CategoryId == catid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.subCategoryMasters
                    .Where(a => a.SubCategoryName.Trim().ToLower() == rquest.Trim().ToLower() && a.SubCategoryId!= subcatid && a.CategoryId == catid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }

        /// <summary>
        /// Detail category management
        /// </summary>
        /// <returns></returns>
        public List<DetailCategoryMasterEntity> GetAllDetailCategories(GenericRequest request)
        {
            List<DetailCategoryMasterEntity> response = new List<DetailCategoryMasterEntity>();
            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    response = context.detailCategoryMasters
                        .Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id &&
                        a.DetailCategoryName.StartsWith(request.search))
                        .OrderBy(b => b.DetailCategoryName)
                        .Skip(skipSize).Take(request.pageSize)
                        .ToList();
                }
                else
                {
                    response = context.detailCategoryMasters
                            .Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id)
                            .OrderBy(b => b.DetailCategoryName)
                            .Skip(skipSize).Take(request.pageSize)
                            .ToList();
                }
            }
            catch (Exception ex)
            { 
            
            }
            return response;
        }
        public int GetAllDetailCategories_Count(GenericRequest request)
        {
            int totalCount = 0;

            if (!string.IsNullOrEmpty(request.search))
            {

                totalCount = context.detailCategoryMasters
                       .Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id &&
                       a.DetailCategoryName.StartsWith(request.search)).Count();
            }
            else
            {
                totalCount = context.detailCategoryMasters
                        .Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id).Count();

            }
            return totalCount;
        }
        public DetailCategoryMasterEntity GetDetailCategoryById(int detailCategoryId)
        {
            return context.detailCategoryMasters .Where(a => a.DetailCategoryId == detailCategoryId).FirstOrDefault();
        }
        public ProcessResponse SaveDetailCategory(DetailCategoryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.detailCategoryMasters.Add(request);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Save Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }

            return response;
        }
        public ProcessResponse UpdateDetailCategory(DetailCategoryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.detailCategoryMasters.Where(a => a.SubCategoryId == request.SubCategoryId).FirstOrDefault();
                catObj.DetailCategoryCode = request.DetailCategoryCode;
                catObj. DetailCategoryName = request.DetailCategoryName;
                catObj.IsDeleted = request.IsDeleted;
                catObj.SubCategoryId = request.SubCategoryId;
                catObj.CategoryId = request.CategoryId;
                context.Entry(catObj).CurrentValues.SetValues(catObj);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Update Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }
            return response;
        }
        public bool CheckDetailCategoryType(string rquest, int catid = 0, int detcatid = 0)
        {
            bool res = true;
            if (detcatid == 0)
            {
                var check = context.detailCategoryMasters
                    .Where(a => a.DetailCategoryName.Trim().ToLower() == rquest.Trim().ToLower() && a.SubCategoryId== catid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.detailCategoryMasters
                    .Where(a => a.DetailCategoryName.Trim().ToLower() == rquest.Trim().ToLower() && a.DetailCategoryId != detcatid && a.SubCategoryId== catid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }

        /// <summary>
        /// Detail category management
        /// </summary>
        /// <returns></returns>
        public List<CountryMasterEntity> GetAllCountries(int pageNumber=1, int pagesize=10, string search="")
        {
            List<CountryMasterEntity> response = new List<CountryMasterEntity>();
            int skipSize = pageNumber == 1 ? 0 : (pageNumber - 1) * pagesize;
            if (!string.IsNullOrEmpty(search))
            {
                 response = context.countryMasterEntities.Where(a => a.IsDeleted == false && a.CountryName.StartsWith(search)).
                OrderBy(b => b.CountryName)
                .Skip(skipSize).Take(pagesize)
                .ToList();

            }
            else
            {
                 response = context.countryMasterEntities.Where(a => a.IsDeleted == false).
                    OrderBy(b => b.CountryName)
                    .Skip(skipSize).Take(pagesize)
                    .ToList();

            }
            return response;
        }


        public int GetCountryCount(string search = "")
        {
            int totalCount = 0;
            
            if (!string.IsNullOrEmpty(search))
            {
                totalCount = context.countryMasterEntities.Where(a => a.IsDeleted == false && a.CountryName.StartsWith(search)).Count();

            }
            else
            {
                totalCount = context.countryMasterEntities.Where(a => a.IsDeleted == false).Count();

            }
            return totalCount;
        }

        public List<StateMasterEntity> GetAllStates(int pageNumber = 1, int pagesize = 10, string search = "", int countryId = 0)
        {
            List<StateMasterEntity> response = new List<StateMasterEntity>();
            int skipSize = pageNumber == 1 ? 0 : (pageNumber - 1) * pagesize;
            if (!string.IsNullOrEmpty(search))
            {
                response = context.stateMasterEntities.Where(a => a.IsDeleted == false && 
                a.StateName.StartsWith(search) && a.CountryId == countryId).
               OrderBy(b => b.StateName)
               .Skip(skipSize).Take(pagesize)
               .ToList();

            }
            else
            {
                response = context.stateMasterEntities.Where(a => a.IsDeleted == false && a.CountryId == countryId).
                   OrderBy(b => b.StateName)
                   .Skip(skipSize).Take(pagesize)
                   .ToList();

            }
            return response;
        }


        public int GetStateCount(string search = "", int countryId = 0)
        {
            int totalCount = 0;

            if (!string.IsNullOrEmpty(search))
            {
                totalCount = context.stateMasterEntities.Where(a => a.IsDeleted == false && 
                a.StateName.StartsWith(search) && a.CountryId == countryId).Count();

            }
            else
            {
                totalCount = context.stateMasterEntities.Where(a => a.IsDeleted == false && a.CountryId == countryId).Count();

            }
            return totalCount;
        }

        public List<CityMasterEntity> GetAllCities(int pageNumber = 1, int pagesize = 10, string search = "", int stateId = 0)
        {
            List<CityMasterEntity> response = new List<CityMasterEntity>();
            int skipSize = pageNumber == 1 ? 0 : (pageNumber - 1) * pagesize;
            if (!string.IsNullOrEmpty(search))
            {
                response = context.cityMasterEntities.Where(a => a.IsDeleted == false &&
                a.CityName.StartsWith(search) && a.StateId == stateId).
               OrderBy(b => b.CityName)
               .Skip(skipSize).Take(pagesize)
               .ToList();

            }
            else
            {
                response = context.cityMasterEntities.Where(a => a.IsDeleted == false && a.StateId== stateId).
                   OrderBy(b => b.CityName)
                   .Skip(skipSize).Take(pagesize)
                   .ToList();

            }
            return response;
        }


        public int GetCityCount(string search = "", int stateId = 0)
        {
            int totalCount = 0;

            if (!string.IsNullOrEmpty(search))
            {
                totalCount = context.cityMasterEntities.Where(a => a.IsDeleted == false &&
                a.CityName.StartsWith(search) && a.StateId== stateId).Count();

            }
            else
            {
                totalCount = context.cityMasterEntities.Where(a => a.IsDeleted == false && a.StateId == stateId).Count();

            }
            return totalCount;
        }

        public CountryMasterEntity GetCountryById(int countryId)
        {
            return context.countryMasterEntities.Where(a => a.Id == countryId).FirstOrDefault();
        }
        public ProcessResponse SaveCountryMaster(CountryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.countryMasterEntities.Add(request);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Save country";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }

            return response;
        }
        public ProcessResponse UpdateCountryMaster(CountryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.countryMasterEntities.Where(a => a.Id== request.Id).FirstOrDefault();
                catObj.CountryName= request.CountryName;
                catObj.CountryCode = request.CountryCode;
                catObj.IsDeleted = request.IsDeleted;
                catObj.PhoneCode = request.PhoneCode;
                catObj.CurrenceString = request.CurrenceString;
                context.Entry(catObj).CurrentValues.SetValues(catObj);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Update Category";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }
            return response;
        }
        public bool CheckCountryName(string request, int counryId=0)
        {
            bool res = true;
            if (counryId == 0)
            {
                var check = context.countryMasterEntities
                    .Where(a => a.CountryName.Trim().ToLower() == request.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.countryMasterEntities
                    .Where(a => a.CountryName.Trim().ToLower() == request.Trim().ToLower() && a.Id != counryId)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }


        // bannerads
        public ProcessResponse SaveBannerAdd(BannerAdsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if(request.BannerId > 0)
                {

                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    request.IsDeleted = false;
                    context.bannerAdsEntities.Add(request);
                    context.SaveChanges();
                }
                
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                ex.Source = "Save country";
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to save : " + ex.Message.ToString();
            }

            return response;
        }

        public BannerAdsEntity GetBannerById(int id)
        {
            return context.bannerAdsEntities.Where(a => a.BannerId == id).FirstOrDefault();
        }
        public List<BannerAdsDisplayModel> GetAllBanners(string page)
        {
            List<BannerAdsDisplayModel> mylist = new List<BannerAdsDisplayModel>();
            mylist = context.bannerAdsEntities.Where(a => a.BannerPage == page && a.IsDeleted == false)
                .Select(b => new BannerAdsDisplayModel
                {
                    IsDeleted = b.IsDeleted,
                    BannerPage = b.BannerPage,
                    BannerId = b.BannerId,
                    BannerSection =  b.BannerSection,
                    BannerTextBig = b.BannerTextBig,
                    BannerTextShort = b.BannerTextShort,
                    BannerType = b.BannerType,
                    BannerUrl = b.BannerUrl,
                    BannerWebSite = b.BannerWebSite,
                    CurrentStatus = b.CurrentStatus,
                    Duration = b.Duration,
                    EndDate = b.EndDate,
                    PostedBy = b.PostedBy,
                    PostedOn = b.PostedOn,
                    StartDate = b.StartDate
                }).ToList();
            return mylist;
        }
        public List<BannerPageMaster> GetBannerPages()
        {
            return context.bannerPageMasters.Where(a => a.IsDeleted == false).ToList();
        }
        public List<BannerPageSection> GetBannerSections()
        {
            return context.bannerPageSections.Where(a => a.IsDeleted == false).ToList();
        }
    }
}
