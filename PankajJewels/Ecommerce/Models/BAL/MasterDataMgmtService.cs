using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.BAL
{
    public class MasterDataMgmtService : IMasterDataMgmtService
    {
        private readonly MyDbContext context;
        private readonly ILogApplicationErrorService _logService;
        public MasterDataMgmtService(MyDbContext _context, ILogApplicationErrorService lService)
        {
            context = _context;
            _logService = lService;
        }


        public List<CountryMasterEntity> GetAllCountries()
        {
            List<CountryMasterEntity> response = new List<CountryMasterEntity>();
            try
            {
                response = context.countryMasterEntities.Where(a => a.IsDeleted == false)
                    .OrderBy(a => a.CountryName)
                    .ToList();

            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public CountryMasterEntity GetCountryById(int countryId)
        {
            CountryMasterEntity response = new CountryMasterEntity();
            try
            {
                response = context.countryMasterEntities.Where(a => a.IsDeleted == false).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            return response;
        }


        #region Usertype Masters

        public List<UserTypeMasterEnity> GetAllUserTypes()
        {
            List<UserTypeMasterEnity> response = new List<UserTypeMasterEnity>();
            try
            {
                response = context.userTypeMasters.Where(a => a.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public bool CheckUserType(string rquest,int typeId=0)
        {
            bool res = true;
            if (typeId == 0)
            {
                var check = context.userTypeMasters
                    .Where(a => a.TypeName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.userTypeMasters
                    .Where(a => a.TypeName.Trim().ToLower() == rquest.Trim().ToLower() && a.TypeId != typeId)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        public ProcessResponse AddUserType(UserTypeMasterEnity request)
        {
            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to save";
            try
            {
                request.IsDeleted = false;
                context.userTypeMasters.Add(request);
                context.SaveChanges();
                response.statusMessage = "success";
                response.statusCode = 1;
                response.currentId = request.TypeId;
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }

        public UserTypeMasterEnity GetUserTypeById(int typeId)
        {
            UserTypeMasterEnity response = new UserTypeMasterEnity();
            try
            {
                response = context.userTypeMasters.Where(a => a.IsDeleted == false && a.TypeId == typeId).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public ProcessResponse UpdateUserType(UserTypeMasterEnity request)
        {
            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to update";
            try
            {
                UserTypeMasterEnity tempObj = new UserTypeMasterEnity();
                tempObj = context.userTypeMasters.Where(a => a.TypeId == request.TypeId).FirstOrDefault();
                context.Entry(tempObj).CurrentValues.SetValues(request);
                context.SaveChanges();
                response.statusMessage = "success";
                response.statusCode = 1;
                response.currentId = request.TypeId;
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }

        #endregion

        #region Gold Master
        /// <summary>
        /// Gold Master management
        /// </summary>
        /// <returns></returns>
        public List<GoldMasterEntity> GetAllGoldMasters(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<GoldMasterEntity> result = new List<GoldMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.goldMasterEntities
                        .Where(a => a.IsDeleted == false && 
                        a.GoldColor.StartsWith(request.search)).OrderBy(b => b.GoldColor)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.goldMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.GoldColor)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetGoldMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.goldMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.GoldColor.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.goldMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public GoldMasterEntity GetGoldMasterMbyId(int masterId)
        {
            return context.goldMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveGoldMaster(GoldMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.goldMasterEntities.Add(request);
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
        public ProcessResponse UpdateGoldMaster(GoldMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.goldMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.GoldColor = request.GoldColor;
                catObj.GoldKarat = request.GoldKarat;
                catObj.IsDeleted = request.IsDeleted;
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
        public bool CheckGoldMasterNameAvailable(string rquest, int masterid=0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.goldMasterEntities
                    .Where(a => a.GoldColor.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.goldMasterEntities
                    .Where(a => a.GoldColor.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }


        #endregion

        #region Daimond Carat Master  Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<DaimondCaratMasterEntity> GetDaimondCaratMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondCaratMasterEntity> result = new List<DaimondCaratMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.daimondCaratMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.CaratName.StartsWith(request.search)).OrderBy(b => b.CaratName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.daimondCaratMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.CaratName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetDaimondCaratMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.daimondCaratMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.CaratName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.daimondCaratMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public DaimondCaratMasterEntity GetDaimondCaratById(int masterId)
        {
            return context.daimondCaratMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveDaimondCaratMaster(DaimondCaratMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.daimondCaratMasterEntities.Add(request);
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
        public ProcessResponse UpdateDaimondCaratMaster(DaimondCaratMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.daimondCaratMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.CaratName = request.CaratName;
                catObj.IsDeleted = request.IsDeleted;
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
        public bool CheckDaimondCaratNameCheck(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.daimondCaratMasterEntities
                    .Where(a => a.CaratName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.daimondCaratMasterEntities
                    .Where(a => a.CaratName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Daimond Type Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<DaimondTypeMasterEntity> GetDaimondTypeMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondTypeMasterEntity> result = new List<DaimondTypeMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.daimondTypeMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.TypeName.StartsWith(request.search)).OrderBy(b => b.TypeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.daimondTypeMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.TypeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetDaimondTypeMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.daimondTypeMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.TypeName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.daimondTypeMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public DaimondTypeMasterEntity GetDaimondTypeById(int masterId)
        {
            return context.daimondTypeMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveDaimondTypeMaster(DaimondTypeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.daimondTypeMasterEntities.Add(request);
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
        public ProcessResponse UpdateDaimondTypeMaster(DaimondTypeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.daimondTypeMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.PriceTag = request.PriceTag;
                catObj.TypeDescription = request.TypeDescription;
                catObj.TypeName = request.TypeName;
                catObj.IsDeleted = request.IsDeleted;
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
        public bool CheckDaimondTypeName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.daimondTypeMasterEntities
                    .Where(a => a.TypeName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.daimondCaratMasterEntities
                    .Where(a => a.CaratName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Daimond color Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<DaimondColorMasterEntity> GetDaimondColorMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondColorMasterEntity> result = new List<DaimondColorMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.daimondColorMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ColorName.StartsWith(request.search)).OrderBy(b => b.ColorName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.daimondColorMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.ColorName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetDaimondColorMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.daimondColorMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ColorName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.daimondColorMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public DaimondColorMasterEntity GetDaimondColorById(int masterId)
        {
            return context.daimondColorMasterEntities.Where(a => a.ColorId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveDaimondColorMaster(DaimondColorMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.daimondColorMasterEntities.Add(request);
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
        public ProcessResponse UpdateDaimondColorMaster(DaimondColorMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.daimondColorMasterEntities.Where(a => a.ColorId == request.ColorId).FirstOrDefault();
                catObj.ColorCode = request.ColorCode;
                catObj.ColorName = request.ColorName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckDaimondColorName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.daimondColorMasterEntities
                    .Where(a => a.ColorName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.daimondColorMasterEntities
                    .Where(a => a.ColorName.Trim().ToLower() == rquest.Trim().ToLower() && a.ColorId== masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Daimond Clarity Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<DaimondClarityMasterEntity> GetDaimondClarityMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondClarityMasterEntity> result = new List<DaimondClarityMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.daimondClarityMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ClarityName.StartsWith(request.search)).OrderBy(b => b.ClarityName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.daimondClarityMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.ClarityName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetDaimondClarityMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.daimondClarityMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ClarityName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.daimondClarityMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public DaimondClarityMasterEntity GetDaimondClarityById(int masterId)
        {
            return context.daimondClarityMasterEntities.Where(a => a.ClarityId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveDaimondClarityMaster(DaimondClarityMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.daimondClarityMasterEntities.Add(request);
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
        public ProcessResponse UpdateDaimondClarityMaster(DaimondClarityMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.daimondClarityMasterEntities.Where(a => a.ClarityId == request.ClarityId).FirstOrDefault();
                catObj.ClarityCode = request.ClarityCode;
                catObj.ClarityName = request.ClarityName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckDaimondClarityName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.daimondClarityMasterEntities
                    .Where(a => a.ClarityName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.daimondClarityMasterEntities
                    .Where(a => a.ClarityName.Trim().ToLower() == rquest.Trim().ToLower() && a.ClarityId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Daimond Cut Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<DaimondCutMasterEntity> GetDaimondCutMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondCutMasterEntity> result = new List<DaimondCutMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.daimondCutMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.CutName.StartsWith(request.search)).OrderBy(b => b.CutName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.daimondCutMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.CutName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetDaimondCutMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.daimondCutMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.CutName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.daimondCutMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public DaimondCutMasterEntity GetDaimondCutById(int masterId)
        {
            return context.daimondCutMasterEntities.Where(a => a.ClarityId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveDaimondCutMaster(DaimondCutMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.daimondCutMasterEntities.Add(request);
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
        public ProcessResponse UpdateDaimondCutMaster(DaimondCutMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.daimondCutMasterEntities.Where(a => a.ClarityId == request.ClarityId).FirstOrDefault();
                catObj.CutCode = request.CutCode;
                catObj.CutName = request.CutName;

                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckDaimondCutName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.daimondCutMasterEntities
                    .Where(a => a.CutName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.daimondCutMasterEntities
                    .Where(a => a.CutName.Trim().ToLower() == rquest.Trim().ToLower() && a.ClarityId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Daimond Settings Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<DaimondSettingMasterEntity> GetDaimondSettingsMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondSettingMasterEntity> result = new List<DaimondSettingMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.daimondSettingMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.SettingName.StartsWith(request.search)).OrderBy(b => b.SettingName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.daimondSettingMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.SettingName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetDaimondSettingsMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.daimondSettingMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.SettingName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.daimondSettingMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public DaimondSettingMasterEntity GetDaimondSettingsById(int masterId)
        {
            return context.daimondSettingMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveDaimondSettingsMaster(DaimondSettingMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.daimondSettingMasterEntities.Add(request);
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
        public ProcessResponse UpdateDaimondSettingsMaster(DaimondSettingMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.daimondSettingMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.SettingName = request.SettingName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckDaimondSettingsName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.daimondSettingMasterEntities
                    .Where(a => a.SettingName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.daimondSettingMasterEntities
                    .Where(a => a.SettingName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Metal type Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<MetalMasterEntity> GetMetalMaster(PaginationRequest request, string src="Home")
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<MetalMasterEntity> result = new List<MetalMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.metalMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.MetalCode.StartsWith(request.search)).OrderBy(b => b.MetalCode)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    if (src != "Home")
                    {
                        result = context.metalMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .Select(b => new MetalMasterEntity
                        {
                            MasterId = b.MasterId,
                            MetalCode = b.MetalCode + " " + b.GoldKarat
                        })
                        .OrderBy(b => b.MetalCode)
                          .ToList();
                    }
                    else
                    {
                        result = context.metalMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.MetalCode)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                    }
                    
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetMetalMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.metalMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.MetalCode.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.metalMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public MetalMasterEntity GetMetalById(int masterId)
        {
            return context.metalMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveMetalMaster(MetalMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.metalMasterEntities.Add(request);
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
        public ProcessResponse UpdateMetalMaster(MetalMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.metalMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.MetalCode = request.MetalCode;
                catObj.IsDeleted = request.IsDeleted;
                catObj.PriceCalPercentage = request.PriceCalPercentage;
                catObj.GoldKarat = request.GoldKarat;

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
        public bool CheckMetalName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.metalMasterEntities
                    .Where(a => a.MetalCode.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.metalMasterEntities
                    .Where(a => a.MetalCode.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Ruby shapes Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<RubyShapeMasterEntity> GetRubyShapeMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<RubyShapeMasterEntity> result = new List<RubyShapeMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.rubyShapeMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ShapeName.StartsWith(request.search)).OrderBy(b => b.ShapeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.rubyShapeMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.ShapeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetRubyShapeMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.rubyShapeMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ShapeName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.rubyShapeMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public RubyShapeMasterEntity GetRubyShapeById(int masterId)
        {
            return context.rubyShapeMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveRubyShapeMaster(RubyShapeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.rubyShapeMasterEntities.Add(request);
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
        public ProcessResponse UpdateRubyShapeMaster(RubyShapeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.rubyShapeMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.ShapeName = request.ShapeName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckRubyShapeName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.rubyShapeMasterEntities
                    .Where(a => a.ShapeName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.rubyShapeMasterEntities
                    .Where(a => a.ShapeName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Soliaire Shapes Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<SolitaireShapeMasterEntity> GetSolitaireShapeMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<SolitaireShapeMasterEntity> result = new List<SolitaireShapeMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.solitaireShapeMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ShapeName.StartsWith(request.search)).OrderBy(b => b.ShapeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.solitaireShapeMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.ShapeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetSolitaireShapeMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.solitaireShapeMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.ShapeName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.solitaireShapeMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public SolitaireShapeMasterEntity GetSolitaireShapeById(int masterId)
        {
            return context.solitaireShapeMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveSolitaireShapeMaster(SolitaireShapeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.solitaireShapeMasterEntities.Add(request);
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
        public ProcessResponse UpdateSolitaireShapeMaster(SolitaireShapeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.solitaireShapeMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.ShapeName = request.ShapeName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckSolitaireShapeName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.solitaireShapeMasterEntities
                    .Where(a => a.ShapeName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.solitaireShapeMasterEntities
                    .Where(a => a.ShapeName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Polish  Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<PolishMasterEntity> GetPolishMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<PolishMasterEntity> result = new List<PolishMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.polishMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.PolishName.StartsWith(request.search)).OrderBy(b => b.PolishName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.polishMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.PolishName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetPolishMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.polishMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.PolishName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.polishMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public PolishMasterEntity GetPolishById(int masterId)
        {
            return context.polishMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SavePolishMaster(PolishMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.polishMasterEntities.Add(request);
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
        public ProcessResponse UpdatePolishMaster(PolishMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.polishMasterEntities.Where(a => a.MasterId== request.MasterId).FirstOrDefault();
                catObj.PolishName= request.PolishName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckPolishName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.polishMasterEntities
                    .Where(a => a.PolishName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.polishMasterEntities
                    .Where(a => a.PolishName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Symmetry Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<SymmetryMasterEntity> GetSymmetryMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<SymmetryMasterEntity> result = new List<SymmetryMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.symmetryMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.SymmetryName.StartsWith(request.search)).OrderBy(b => b.SymmetryName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.symmetryMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.SymmetryName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetSymmetryMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.symmetryMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.SymmetryName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.symmetryMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public SymmetryMasterEntity GetSymmetryById(int masterId)
        {
            return context.symmetryMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveSymmetryMaster(SymmetryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.symmetryMasterEntities.Add(request);
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
        public ProcessResponse UpdateSymmetryMaster(SymmetryMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.symmetryMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.SymmetryName= request.SymmetryName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckSymmetryName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.symmetryMasterEntities
                    .Where(a => a.SymmetryName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.symmetryMasterEntities
                    .Where(a => a.SymmetryName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Fluourosence  Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<FluorescenceMasterEntity> GetFluorescenceMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<FluorescenceMasterEntity> result = new List<FluorescenceMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.fluorescenceMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.FluorescenceName.StartsWith(request.search)).OrderBy(b => b.FluorescenceName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.fluorescenceMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.FluorescenceName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetFluorescenceMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.fluorescenceMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.FluorescenceName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.fluorescenceMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public FluorescenceMasterEntity GetFluorescenceById(int masterId)
        {
            return context.fluorescenceMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveFluorescenceMaster(FluorescenceMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.fluorescenceMasterEntities.Add(request);
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
        public ProcessResponse UpdateFluorescenceMaster(FluorescenceMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.fluorescenceMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.FluorescenceName = request.FluorescenceName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckFluorescenceName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.fluorescenceMasterEntities
                    .Where(a => a.FluorescenceName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.fluorescenceMasterEntities
                    .Where(a => a.FluorescenceName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        #region Certificate Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        public List<CertificateMasterEntity> GetCertificateMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<CertificateMasterEntity> result = new List<CertificateMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    result = context.certificateMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.CertifycateName.StartsWith(request.search)).OrderBy(b => b.CertifycateName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }
                else
                {
                    result = context.certificateMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.CertifycateName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int GetCertificateMasterCount(PaginationRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.certificateMasterEntities
                        .Where(a => a.IsDeleted == false &&
                        a.CertifycateName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.certificateMasterEntities
                        .Where(a => a.IsDeleted == false).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public CertificateMasterEntity GetCertificateById(int masterId)
        {
            return context.certificateMasterEntities.Where(a => a.MasterId == masterId).FirstOrDefault();
        }
        public ProcessResponse SaveCertificateMaster(CertificateMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.certificateMasterEntities.Add(request);
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
        public ProcessResponse UpdateCertificateMaster(CertificateMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.certificateMasterEntities.Where(a => a.MasterId == request.MasterId).FirstOrDefault();
                catObj.CertifycateName = request.CertifycateName;
                catObj.IsDeleted = request.IsDeleted;

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
        public bool CheckCertificateName(string rquest, int masterid = 0)
        {
            bool res = true;
            if (masterid == 0)
            {
                var check = context.certificateMasterEntities
                    .Where(a => a.CertifycateName.Trim().ToLower() == rquest.Trim().ToLower())
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            else
            {
                var check = context.certificateMasterEntities
                    .Where(a => a.CertifycateName.Trim().ToLower() == rquest.Trim().ToLower() && a.MasterId == masterid)
                    .FirstOrDefault();
                if (check != null)
                {
                    res = false;
                }
            }
            return res;
        }
        #endregion

        public List<SizeMasterForDeailPage> GetSizesForDetailPage(int prodcutid)
        {
            List<SizeMasterForDeailPage> myList = new List<SizeMasterForDeailPage>();
            myList = (from pr in context.productMasterEntities
                      join pd in context.productDetailsEntities on pr.ProductId equals pd.ProductId
                      join s in context.sizeMasterEntities on pd.SizeMasterId equals s.SizeMasterId
                      where pd.IsDeleted == false && pr.ProductId == prodcutid
                      select new SizeMasterForDeailPage
                      {
                          IsDeleted = s.IsDeleted,
                          ProductDetailId = pd.ProductDetailId,
                          SizeMasterId = s.SizeMasterId,
                          SizeName = s.SizeName,
                          SubCategoryId = pr.CategoryId
                      }).ToList();
            return myList;
        }
        public List<SizeMasterDisplay> GetAllSizes(GenericRequest request)
        {   
            List<SizeMasterDisplay> result = new List<SizeMasterDisplay>();
            try
            {
                result = (from s in context.sizeMasterEntities
                          join c in context.categoryMasterEntities on s.SubCategoryId equals c.CategoryId
                          where s.IsDeleted == false && s.SubCategoryId == request.Id
                          select new SizeMasterDisplay
                          {
                              CategoryId = s.SubCategoryId,
                              SizeMasterId = s.SizeMasterId,
                              CategoryName = c.CategoryName,
                              IsDeleted = s.IsDeleted,
                              SizeName = s.SizeName
                          }).OrderBy(b => b.SizeName).ToList();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<SizeMasterEntity> GetAllSizes_Web(GenericRequest request)
        {
            List<SizeMasterEntity> result = new List<SizeMasterEntity>();
            try
            {
                result = context.sizeMasterEntities.Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int GetSizesCount(GenericRequest request)
        {

            int totalRecords = 0;
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    totalRecords = context.sizeMasterEntities   
                        .Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id &&
                        a.SizeName.StartsWith(request.search)).Count();
                }
                else
                {
                    totalRecords = context.sizeMasterEntities
                        .Where(a => a.IsDeleted == false && a.SubCategoryId == request.Id).Count();
                }


            }
            catch (Exception ex)
            {

            }
            return totalRecords;
        }
        public SizeMasterDisplay GetSizeById(int masterId)
        {
            SizeMasterDisplay result = new SizeMasterDisplay();
            result = (from s in context.sizeMasterEntities
                      join c in context.categoryMasterEntities on s.SubCategoryId equals c.CategoryId
                      where s.IsDeleted == false && s.SubCategoryId == masterId
                      select new SizeMasterDisplay
                      {
                          CategoryId = s.SubCategoryId,
                          SizeMasterId = s.SizeMasterId,
                          CategoryName = c.CategoryName,
                          IsDeleted = s.IsDeleted,
                          SizeName = s.SizeName
                      }).FirstOrDefault();
            return result;
        }
        public ProcessResponse SaveSizes(SizeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                request.IsDeleted = false;
                context.sizeMasterEntities.Add(request);
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
        public ProcessResponse UpdateSizes(SizeMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var catObj = context.sizeMasterEntities.Where(a => a.SizeMasterId == request.SizeMasterId).FirstOrDefault();
                catObj.SizeName= request.SizeName;
                catObj.SubCategoryId = request.SubCategoryId;
                catObj.IsDeleted = request.IsDeleted;

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
         


        public List<DiscountMasterEntity> GetAllDiscounts(GenericRequest request, string source="Home")
        {


            List<DiscountMasterEntity> result = new List<DiscountMasterEntity>();
            try
            {
                if(source == "Home")
                {
                    result = context.discountMasterEntities
                    .Where(a => a.IsDeleted == false).ToList();
                }
                else
                {
                    result = context.discountMasterEntities
                    .Where(a => a.IsDeleted == false && a.IsApplicable == true).ToList();
                }
                

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public DiscountMasterEntity GetDiscountById(int id)
        {

            DiscountMasterEntity result = new DiscountMasterEntity();
            try
            {
                result = context.discountMasterEntities
                    .Where(a => a.IsDeleted == false && a.DMasterId == id
                    ).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ProcessResponse UpdateDiscount(DiscountMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to save";
            try
            {
                if(request.DMasterId > 0)
                {
                    DiscountMasterEntity dm = new DiscountMasterEntity();
                    dm = context.discountMasterEntities.Where(a => a.DMasterId == request.DMasterId).FirstOrDefault();
                    dm.DicountTitile = request.DicountTitile;
                    dm.DiscountAmount = request.DiscountAmount;
                    dm.DiscountType = request.DiscountType;
                    dm.IsApplicable = request.IsApplicable;
                    dm.IsDeleted = request.IsDeleted;
                    context.Entry(dm).CurrentValues.SetValues(dm);
                    context.SaveChanges();
                }
                else
                {
                    request.IsDeleted = false;
                    context.discountMasterEntities.Add(request);
                    context.SaveChanges();
                    response.statusMessage = "success";
                }
                
                response.statusCode = 1;
                response.currentId = request.DMasterId;
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }

        public List<MeasurementMasterEntity> GetAllMeasurements(GenericRequest request)
        {


            List<MeasurementMasterEntity> result = new List<MeasurementMasterEntity>();
            try
            {
                result = context.measurementMasterEntities
                    .Where(a => a.IsDeleted == false).ToList();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<DaimondShapeMasterEntity> GetDaimondShapreMaster(PaginationRequest request)
        {

            int skipSize = request.pageNumber == 1 ? 0 : (request.pageNumber - 1) * request.pageSize;
            List<DaimondShapeMasterEntity> result = new List<DaimondShapeMasterEntity>();
            try
            {
                if (!string.IsNullOrEmpty(request.search))
                {
                    //result = context.daimondShapeMasterEntities
                    //    .Where(a => a.IsDeleted == false &&
                    //    a.ShapeName.StartsWith(request.search)).OrderBy(b => b.ShapeName)
                    //     .Skip(skipSize).Take(request.pageSize)
                    //      .ToList();
                }
                else
                {
                    result = context.daimondShapeMasterEntities
                        .Where(a => a.IsDeleted == false)
                        .OrderBy(b => b.ShapeName)
                         .Skip(skipSize).Take(request.pageSize)
                          .ToList();
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
