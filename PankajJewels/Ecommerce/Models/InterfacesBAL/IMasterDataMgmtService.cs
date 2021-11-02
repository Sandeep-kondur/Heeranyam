using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
   public interface IMasterDataMgmtService
    {
        List<SizeMasterEntity> GetAllSizes_Web(GenericRequest request);
        List<SizeMasterForDeailPage> GetSizesForDetailPage(int prodcutid);
        List<DaimondShapeMasterEntity> GetDaimondShapreMaster(PaginationRequest request);
        List<CountryMasterEntity> GetAllCountries();

        CountryMasterEntity GetCountryById(int countryId);


        #region Usertype Masters

        List<UserTypeMasterEnity> GetAllUserTypes();
        bool CheckUserType(string rquest, int typeId = 0);
        ProcessResponse AddUserType(UserTypeMasterEnity request);

        UserTypeMasterEnity GetUserTypeById(int typeId);
        ProcessResponse UpdateUserType(UserTypeMasterEnity request);

        #endregion

        #region Gold Master
        /// <summary>
        /// Gold Master management
        /// </summary>
        /// <returns></returns>
        List<GoldMasterEntity> GetAllGoldMasters(PaginationRequest request);
        int GetGoldMasterCount(PaginationRequest request);
        GoldMasterEntity GetGoldMasterMbyId(int masterId);
        ProcessResponse SaveGoldMaster(GoldMasterEntity request);
        ProcessResponse UpdateGoldMaster(GoldMasterEntity request);
        bool CheckGoldMasterNameAvailable(string rquest, int masterid = 0);


        #endregion

        #region Daimond Carat Master  Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<DaimondCaratMasterEntity> GetDaimondCaratMaster(PaginationRequest request);
        int GetDaimondCaratMasterCount(PaginationRequest request);
        DaimondCaratMasterEntity GetDaimondCaratById(int masterId);
        ProcessResponse SaveDaimondCaratMaster(DaimondCaratMasterEntity request);
        ProcessResponse UpdateDaimondCaratMaster(DaimondCaratMasterEntity request);
        bool CheckDaimondCaratNameCheck(string rquest, int masterid = 0);
        #endregion

        #region Daimond Type Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<DaimondTypeMasterEntity> GetDaimondTypeMaster(PaginationRequest request);
        int GetDaimondTypeMasterCount(PaginationRequest request);
        DaimondTypeMasterEntity GetDaimondTypeById(int masterId);
        ProcessResponse SaveDaimondTypeMaster(DaimondTypeMasterEntity request);
        ProcessResponse UpdateDaimondTypeMaster(DaimondTypeMasterEntity request);
        bool CheckDaimondTypeName(string rquest, int masterid = 0);
        #endregion

        #region Daimond color Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<DaimondColorMasterEntity> GetDaimondColorMaster(PaginationRequest request);
        int GetDaimondColorMasterCount(PaginationRequest request);
        DaimondColorMasterEntity GetDaimondColorById(int masterId);
        ProcessResponse SaveDaimondColorMaster(DaimondColorMasterEntity request);
        ProcessResponse UpdateDaimondColorMaster(DaimondColorMasterEntity request);
        
        bool CheckDaimondColorName(string rquest, int masterid = 0);
        #endregion

        #region Daimond Cut Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<DaimondCutMasterEntity> GetDaimondCutMaster(PaginationRequest request);
        int GetDaimondCutMasterCount(PaginationRequest request);
        DaimondCutMasterEntity GetDaimondCutById(int masterId);
        ProcessResponse SaveDaimondCutMaster(DaimondCutMasterEntity request);
        ProcessResponse UpdateDaimondCutMaster(DaimondCutMasterEntity request);
        bool CheckDaimondCutName(string rquest, int masterid = 0);
        #endregion

        #region Daimond Settings Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<DaimondSettingMasterEntity> GetDaimondSettingsMaster(PaginationRequest request);
        int GetDaimondSettingsMasterCount(PaginationRequest request);
        DaimondSettingMasterEntity GetDaimondSettingsById(int masterId);
        ProcessResponse SaveDaimondSettingsMaster(DaimondSettingMasterEntity request);
        ProcessResponse UpdateDaimondSettingsMaster(DaimondSettingMasterEntity request);
        bool CheckDaimondSettingsName(string rquest, int masterid = 0);
        #endregion

        #region Metal type Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<MetalMasterEntity> GetMetalMaster(PaginationRequest request, string src="Home");
        int GetMetalMasterCount(PaginationRequest request);
        MetalMasterEntity GetMetalById(int masterId);
        ProcessResponse SaveMetalMaster(MetalMasterEntity request);
        ProcessResponse UpdateMetalMaster(MetalMasterEntity request);
        bool CheckMetalName(string rquest, int masterid = 0);
        #endregion

        #region Ruby shapes Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<RubyShapeMasterEntity> GetRubyShapeMaster(PaginationRequest request);
        int GetRubyShapeMasterCount(PaginationRequest request);
        RubyShapeMasterEntity GetRubyShapeById(int masterId);
        ProcessResponse SaveRubyShapeMaster(RubyShapeMasterEntity request);
        ProcessResponse UpdateRubyShapeMaster(RubyShapeMasterEntity request);
        bool CheckRubyShapeName(string rquest, int masterid = 0);
        #endregion

        #region Soliaire Shapes Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<SolitaireShapeMasterEntity> GetSolitaireShapeMaster(PaginationRequest request);
        int GetSolitaireShapeMasterCount(PaginationRequest request);
        SolitaireShapeMasterEntity GetSolitaireShapeById(int masterId);
        ProcessResponse SaveSolitaireShapeMaster(SolitaireShapeMasterEntity request);
        ProcessResponse UpdateSolitaireShapeMaster(SolitaireShapeMasterEntity request);
        bool CheckSolitaireShapeName(string rquest, int masterid = 0);
        #endregion

        #region Polish  Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<PolishMasterEntity> GetPolishMaster(PaginationRequest request);
        int GetPolishMasterCount(PaginationRequest request);
        PolishMasterEntity GetPolishById(int masterId);
        ProcessResponse SavePolishMaster(PolishMasterEntity request);
        ProcessResponse UpdatePolishMaster(PolishMasterEntity request);
        bool CheckPolishName(string rquest, int masterid = 0);
        #endregion

        #region Symmetry Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<SymmetryMasterEntity> GetSymmetryMaster(PaginationRequest request);
        int GetSymmetryMasterCount(PaginationRequest request);
        SymmetryMasterEntity GetSymmetryById(int masterId);
        ProcessResponse SaveSymmetryMaster(SymmetryMasterEntity request);
        ProcessResponse UpdateSymmetryMaster(SymmetryMasterEntity request);
        bool CheckSymmetryName(string rquest, int masterid = 0);
        #endregion

        #region Fluourosence  Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<FluorescenceMasterEntity> GetFluorescenceMaster(PaginationRequest request);
        int GetFluorescenceMasterCount(PaginationRequest request);
        FluorescenceMasterEntity GetFluorescenceById(int masterId);
        ProcessResponse SaveFluorescenceMaster(FluorescenceMasterEntity request);
        ProcessResponse UpdateFluorescenceMaster(FluorescenceMasterEntity request);
        bool CheckFluorescenceName(string rquest, int masterid = 0);
        #endregion

        #region Certificate Master
        /// <summary>
        /// Gold Master management
        /// </summary>Carat Master
        /// <returns></returns>
        /// 
        List<CertificateMasterEntity> GetCertificateMaster(PaginationRequest request);
        int GetCertificateMasterCount(PaginationRequest request);
        CertificateMasterEntity GetCertificateById(int masterId);
        ProcessResponse SaveCertificateMaster(CertificateMasterEntity request);
        ProcessResponse UpdateCertificateMaster(CertificateMasterEntity request);
        bool CheckCertificateName(string rquest, int masterid = 0);
        #endregion

        List<DaimondClarityMasterEntity> GetDaimondClarityMaster(PaginationRequest request);
        int GetDaimondClarityMasterCount(PaginationRequest request);
        DaimondClarityMasterEntity GetDaimondClarityById(int masterId);
        ProcessResponse SaveDaimondClarityMaster(DaimondClarityMasterEntity request);
        ProcessResponse UpdateDaimondClarityMaster(DaimondClarityMasterEntity request);
        bool CheckDaimondClarityName(string rquest, int masterid = 0);

        List<SizeMasterDisplay> GetAllSizes(GenericRequest request);

        int GetSizesCount(GenericRequest request);
        SizeMasterDisplay GetSizeById(int masterId);
        ProcessResponse SaveSizes(SizeMasterEntity request);
        ProcessResponse UpdateSizes(SizeMasterEntity request);


        DiscountMasterEntity GetDiscountById(int id);

        ProcessResponse UpdateDiscount(DiscountMasterEntity request);
        List<DiscountMasterEntity> GetAllDiscounts(GenericRequest request, string source = "Home");
        List<MeasurementMasterEntity> GetAllMeasurements(GenericRequest request);

    }
}
