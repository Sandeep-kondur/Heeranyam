using Ecommerce.Models.InterfacesBAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterMgmtController : ControllerBase
    {
        private readonly ILogger<UserMgmtController> _logger;
        private readonly INotificationService _nService;
        private readonly IUserMgmtService _uService;
        private readonly IMasterDataMgmtService _mService;
        private readonly IOtherMgmtService _oService;
        public MasterMgmtController(ILogger<UserMgmtController> logger,
            INotificationService nService,
            IMasterDataMgmtService mService,
            IOtherMgmtService oService,
            IUserMgmtService uService)
        {
            _logger = logger;
            _nService = nService;
            _uService = uService;
            _mService = mService;
            _oService = oService;
        }

        
        #region Categories
        [HttpPost]
        public IActionResult GetCategories(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllCategories(request));
                response.totalRecords = _oService.GetAllCategories_Count(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;
                

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetCategoryById(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetCategoryById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateCategory(CategoryMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_oService.UpdateCategory(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveCategory(CategoryMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.SaveCategory(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteCategory(GenericRequest request)
        {
            try
            {
                CategoryMasterEntity obj = new CategoryMasterEntity();
                obj = _oService.GetCategoryById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_oService.UpdateCategory(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region SubCategories
        [HttpPost]
        public IActionResult GetSubCategories(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllSubCategories(request));
                response.totalRecords = _oService.GetAllSubCategories_Count(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetSubCategoryById(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetSubCategoryById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateSubCategory(SubCategoryMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_oService.UpdateSubCategory(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveSubCategory(SubCategoryMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.SaveSubCategory(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteSubCategory(GenericRequest request)
        {
            try
            {
                SubCategoryMasterEntity obj = new SubCategoryMasterEntity();
                obj = _oService.GetSubCategoryById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_oService.UpdateSubCategory(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Detail Categories
        [HttpPost]
        public IActionResult GetDetailCategories(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllDetailCategories(request));
                response.totalRecords = _oService.GetAllDetailCategories_Count(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDetailCategoryById(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetDetailCategoryById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDetailCategory(DetailCategoryMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_oService.UpdateDetailCategory(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDetailCategory(DetailCategoryMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.SaveDetailCategory(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDetailCategory(GenericRequest request)
        {
            try
            {
                DetailCategoryMasterEntity obj = new DetailCategoryMasterEntity();
                obj = _oService.GetDetailCategoryById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_oService.UpdateDetailCategory(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion


        #region country,state,city
        [HttpPost]
        public IActionResult GetAllCountries(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllCountries(request.pageNumber, request.pageSize, request.search));
                response.totalRecords = _oService.GetCountryCount(request.search);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult GetAllCities(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllCities(request.pageNumber, request.pageSize, request.search,request.Id));
                response.totalRecords = _oService.GetCityCount(request.search, request.Id);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetAllStates(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllStates(request.pageNumber, request.pageSize, request.search, request.Id));
                response.totalRecords = _oService.GetStateCount(request.search, request.Id);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        #endregion

        #region Gold Master
        [HttpPost]
        public IActionResult GetGoldMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetAllGoldMasters(request));
                response.totalRecords = _mService.GetGoldMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetGoldMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetGoldMasterMbyId(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateGoldMaster(GoldMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateGoldMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveGoldMaster(GoldMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveGoldMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteGoldMaster(GenericRequest request)
        {
            try
            {
                GoldMasterEntity obj = new GoldMasterEntity();
                obj = _mService.GetGoldMasterMbyId(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateGoldMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

   
        #region Daimond Types Master
        [HttpPost]
        public IActionResult GetDaimondTypesMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondTypeMaster(request));
                response.totalRecords = _mService.GetDaimondTypeMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDaimondTypeMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondTypeById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDaimondTypeMaster(DaimondTypeMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondTypeMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDaimondTypeMaster(DaimondTypeMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveDaimondTypeMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDaimondTypeMaster(GenericRequest request)
        {
            try
            {
                DaimondTypeMasterEntity obj = new DaimondTypeMasterEntity();
                obj = _mService.GetDaimondTypeById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondTypeMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Daimond Colors Master
        [HttpPost]
        public IActionResult GetDaimondColorMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondColorMaster(request));
                response.totalRecords = _mService.GetDaimondColorMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDaimondColorMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondColorById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDaimondColorMaster(DaimondColorMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondColorMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDaimondColorMaster(DaimondColorMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveDaimondColorMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDaimondColorMaster(GenericRequest request)
        {
            try
            {
                DaimondColorMasterEntity obj = new DaimondColorMasterEntity();
                obj = _mService.GetDaimondColorById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondColorMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Daimond carat Master
        [HttpPost]
        public IActionResult GetDaimondCaratMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondCaratMaster(request));
                response.totalRecords = _mService.GetDaimondCaratMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDaimondCaratMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondCaratById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDaimondCaratMaster(DaimondCaratMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondCaratMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDaimondCaratMaster(DaimondCaratMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveDaimondCaratMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDaimondCaratMaster(GenericRequest request)
        {
            try
            {
                DaimondCaratMasterEntity obj = new DaimondCaratMasterEntity();
                obj = _mService.GetDaimondCaratById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondCaratMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Daimond Clarity Master
        [HttpPost]
        public IActionResult GetDaimondClarityMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondClarityMaster(request));
                response.totalRecords = _mService.GetDaimondClarityMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDaimondClarityMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondClarityById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDaimondClarityMaster(DaimondClarityMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondClarityMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDaimondClarityMaster(DaimondClarityMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveDaimondClarityMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDaimondClarityMaster(GenericRequest request)
        {
            try
            {
                DaimondClarityMasterEntity obj = new DaimondClarityMasterEntity();
                obj = _mService.GetDaimondClarityById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondClarityMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Daimond Cut Master
        [HttpPost]
        public IActionResult GetDaimondCutMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondCutMaster(request));
                response.totalRecords = _mService.GetDaimondCutMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDaimondCutMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondCutById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDaimondCutMaster(DaimondCutMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondCutMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDaimondCutMaster(DaimondCutMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveDaimondCutMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDaimondCutMaster(GenericRequest request)
        {
            try
            {
                DaimondCutMasterEntity obj = new DaimondCutMasterEntity();
                obj = _mService.GetDaimondCutById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondCutMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Daimond Settings Master
        [HttpPost]
        public IActionResult GetDaimondSettingMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondSettingsMaster(request));
                response.totalRecords = _mService.GetDaimondSettingsMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDaimondSettingMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetDaimondSettingsById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateDaimondSettingMaster(DaimondSettingMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondSettingsMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveDaimondSettingMaster(DaimondSettingMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveDaimondSettingsMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteDaimondSettingMaster(GenericRequest request)
        {
            try
            {
                DaimondSettingMasterEntity obj = new DaimondSettingMasterEntity();
                obj = _mService.GetDaimondSettingsById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateDaimondSettingsMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion


        #region Metal Types Master
        [HttpPost]
        public IActionResult GetMetalMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetMetalMaster(request));
                response.totalRecords = _mService.GetMetalMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetMetalMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetMetalById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateMetalMaster(MetalMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateMetalMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveMetalMaster(MetalMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveMetalMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteMetalMaster(GenericRequest request)
        {
            try
            {
                MetalMasterEntity obj = new MetalMasterEntity();
                obj = _mService.GetMetalById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateMetalMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Ruby Shapes Master
        [HttpPost]
        public IActionResult GetRubyShapeMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetRubyShapeMaster(request));
                response.totalRecords = _mService.GetRubyShapeMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetRubyShapeMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetRubyShapeById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateRubyShapeMaster(RubyShapeMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateRubyShapeMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveRubyShapeMaster(RubyShapeMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveRubyShapeMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteRubyShapeMaster(GenericRequest request)
        {
            try
            {
                RubyShapeMasterEntity obj = new RubyShapeMasterEntity();
                obj = _mService.GetRubyShapeById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateRubyShapeMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Solitire Shapes Master
        [HttpPost]
        public IActionResult GetSolitaireShapeMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetSolitaireShapeMaster(request));
                response.totalRecords = _mService.GetSolitaireShapeMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetSolitaireShapeMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetSolitaireShapeById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateSolitaireShapeMaster(SolitaireShapeMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateSolitaireShapeMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveSolitaireShapeMaster(SolitaireShapeMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveSolitaireShapeMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteSolitaireShapeMaster(GenericRequest request)
        {
            try
            {
                SolitaireShapeMasterEntity obj = new SolitaireShapeMasterEntity();
                obj = _mService.GetSolitaireShapeById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateSolitaireShapeMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Polish  Master
        [HttpPost]
        public IActionResult GetPolishMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetPolishMaster(request));
                response.totalRecords = _mService.GetPolishMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetPolishMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetPolishById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdatePolishMaster(PolishMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdatePolishMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SavePolishMaster(PolishMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SavePolishMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeletePolishMaster(GenericRequest request)
        {
            try
            {
                PolishMasterEntity obj = new PolishMasterEntity();
                obj = _mService.GetPolishById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdatePolishMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Symmetry  Master
        [HttpPost]
        public IActionResult GetSymmetryMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetSymmetryMaster(request));
                response.totalRecords = _mService.GetSymmetryMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetSymmetryMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetSymmetryById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateSymmetryMaster(SymmetryMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateSymmetryMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveSymmetryMaster(SymmetryMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveSymmetryMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteSymmetryMaster(GenericRequest request)
        {
            try
            {
                SymmetryMasterEntity obj = new SymmetryMasterEntity();
                obj = _mService.GetSymmetryById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateSymmetryMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Flourosence  Master
        [HttpPost]
        public IActionResult GetFluorescenceMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetFluorescenceMaster(request));
                response.totalRecords = _mService.GetFluorescenceMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetFluorescenceMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetFluorescenceById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateFluorescenceMaster(FluorescenceMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateFluorescenceMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveFluorescenceMaster(FluorescenceMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveFluorescenceMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteFluorescenceMaster(GenericRequest request)
        {
            try
            {
                FluorescenceMasterEntity obj = new FluorescenceMasterEntity();
                obj = _mService.GetFluorescenceById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateFluorescenceMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion

        #region Certificate  Master
        [HttpPost]
        public IActionResult GetCertificateMasters(PaginationRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetCertificateMaster(request));
                response.totalRecords = _mService.GetCertificateMasterCount(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetCertificateMasterbyId(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetCertificateById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateCertificateMaster(CertificateMasterEntity request)
        {
            try
            {
                request.IsDeleted = false;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateCertificateMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveCertificateMaster(CertificateMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.SaveCertificateMaster(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteCertificateMaster(GenericRequest request)
        {
            try
            {
                CertificateMasterEntity obj = new CertificateMasterEntity();
                obj = _mService.GetCertificateById(request.Id);
                obj.IsDeleted = true;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateCertificateMaster(obj));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion


      
        [HttpPost]
        public IActionResult GetAllMeasurements(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetAllMeasurements(request));

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult GetAllDiscounts(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetAllDiscounts(request));

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpPost]
        public IActionResult GetAllSizes(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetAllSizes(request));

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult GetSizeById(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_mService.GetSizeById(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateSize(SizeMasterDisplay request)
        {
            try
            {
                SizeMasterEntity sm = new SizeMasterEntity();
                sm.IsDeleted = false;
                sm.SizeMasterId = request.SizeMasterId;
                sm.SizeName = request.SizeName;
                sm.SubCategoryId = request.CategoryId;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateSizes(sm));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveSize(SizeMasterDisplay request)
        {
            try
            {
                SizeMasterEntity sm = new SizeMasterEntity();
                sm.IsDeleted = false;
                sm.SizeMasterId = request.SizeMasterId;
                sm.SizeName = request.SizeName;
                sm.SubCategoryId = request.CategoryId;
                var response = Transform.ConvertResultToApiResonse(_mService.SaveSizes(sm));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult DeleteSize(GenericRequest request)
        {
            try
            {
                SizeMasterDisplay obj = new SizeMasterDisplay();
                obj = _mService.GetSizeById(request.Id);
                SizeMasterEntity req = new SizeMasterEntity();
                req.IsDeleted = true;
                req.SizeMasterId = obj.SizeMasterId;
                req.SizeName = obj.SizeName;
                req.SubCategoryId = obj.CategoryId;
                var response = Transform.ConvertResultToApiResonse(_mService.UpdateSizes(req));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }




        [HttpPost]
        public IActionResult GetSubCategories_V1(int Id)
        {
            try
            {
                GenericRequest request = new GenericRequest();
                request.Id = Id;
                request.pageNumber = 1;
                request.pageSize = 1000;
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllSubCategories(request));
                response.totalRecords = _oService.GetAllSubCategories_Count(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetDetailCategories_V1(int Id)
        {
            try
            {
                GenericRequest request = new GenericRequest();
                request.Id = Id;
                request.pageNumber = 1;
                request.pageSize = 1000;
                var response = Transform.ConvertResultToApiResonse(_oService.GetAllDetailCategories(request));
                response.totalRecords = _oService.GetAllDetailCategories_Count(request);

                int currentStartPage = 1;
                if (request.pageNumber > 1)
                { currentStartPage = request.pageNumber; }
                response.fromRecord = ((request.pageNumber - 1) * request.pageSize) + 1;
                int? toRecords = response.totalRecords > request.pageSize ? currentStartPage * request.pageSize : response.totalRecords;
                if (response.totalRecords < toRecords)
                {
                    toRecords = response.totalRecords;
                }
                response.torecord = toRecords;


                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
