using Ecommerce.Models.BAL;
using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class MastersController : Controller
    {
        private readonly IMasterDataMgmtService _mService;
        private readonly IProductManagementService _pService;
        private readonly IOtherMgmtService _oService;
        private readonly IHostingEnvironment hostingEnvironment;
        public MastersController(IMasterDataMgmtService mService, IHostingEnvironment environment,
        IProductManagementService pService, IOtherMgmtService oService)
        {
            _mService = mService;
            _pService = pService;
            _oService = oService;
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
            }
            ViewBag.LoggedUser = loginCheckResponse;


            return View();
        }


        /// <summary>
        /// Gold Master
        /// </summary>
        /// <returns></returns>
        public IActionResult GoldMaster()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;
            List<GoldMasterEntity> myList = new List<GoldMasterEntity>();
            //  myList = _mService.GetAllGoldMasters();
            return View(myList);
        }


        public IActionResult GoldMasterData(int id = 0)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
            }
            ViewBag.LoggedUser = loginCheckResponse;
            GoldMasterEntity utm = new GoldMasterEntity();
            if (id > 0)
            {
                utm = _mService.GetGoldMasterMbyId(id);
            }
            else
            {
                utm = new GoldMasterEntity();
            }

            return View(utm);
        }

        [HttpPost]
        public IActionResult GoldMasterData(GoldMasterEntity request)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
            }
            ViewBag.LoggedUser = loginCheckResponse;

            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {
                    if (request.MasterId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _mService.SaveGoldMaster(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("GoldMaster");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _mService.UpdateGoldMaster(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("GoldMaster");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                }

            }
            return View(request);
        }
        [HttpPost]
        public IActionResult DeleteGoldMaster(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                GoldMasterEntity request = new GoldMasterEntity();
                request = _mService.GetGoldMasterMbyId(id);
                request.IsDeleted = true;
                response = _mService.UpdateGoldMaster(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }
        /// <summary>
        /// diamond carat
        /// </summary>
        /// <returns></returns>
        public IActionResult DaimondCarat()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;

            List<DaimondCaratMasterEntity> myList = new List<DaimondCaratMasterEntity>();
            //myList = _mService.GetDaimondCaratMaster();
            return View(myList);
        }
        public IActionResult DaimondCaratData(int id = 0)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
            }
            ViewBag.LoggedUser = loginCheckResponse;
            DaimondCaratMasterEntity utm = new DaimondCaratMasterEntity();
            if (id > 0)
            {
                utm = _mService.GetDaimondCaratById(id);
            }
            else
            {
                utm = new DaimondCaratMasterEntity();
            }

            return View(utm);
        }

        [HttpPost]
        public IActionResult DaimondCaratData(DaimondCaratMasterEntity request)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
            }
            ViewBag.LoggedUser = loginCheckResponse;

            if (ModelState.IsValid)
            {
                var checkUserType = _mService.CheckDaimondCaratNameCheck(request.CaratName, request.MasterId);
                if (checkUserType == false)
                {
                    ModelState.AddModelError("CaratName", "Carat Name not available");
                }
                if (ModelState.IsValid)
                {
                    if (request.MasterId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _mService.SaveDaimondCaratMaster(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("DaimondCarat");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _mService.UpdateDaimondCaratMaster(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("DaimondCarat");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                }

            }
            return View(request);
        }
        [HttpPost]
        public IActionResult DeleteDaimondCarat(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                DaimondCaratMasterEntity request = new DaimondCaratMasterEntity();
                request = _mService.GetDaimondCaratById(id);
                request.IsDeleted = true;
                response = _mService.UpdateDaimondCaratMaster(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }



        public IActionResult GoldRateMaster()
        {
            return View();
        }
        public IActionResult DaimondColors()
        {
            return View();
        }
        public IActionResult DaimondClarity()
        {
            return View();
        }

        public IActionResult DaimondCut()
        {
            return View();
        }
        public IActionResult AddressTypes()
        {
            return View();
        }
        public IActionResult TagsMaster()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult MetalType()
        {
            return View();
        }
        public IActionResult MetalRates()
        {
            return View();
        }
        public IActionResult RubyShapes()
        {
            return View();
        }
        public IActionResult SolitireShapes()
        {
            return View();
        }
        public IActionResult PolishMaster()
        {
            return View();
        }

        public IActionResult Symmetry()
        {
            return View();
        }
        public IActionResult Fluroscence()
        {
            return View();
        }
        public IActionResult CertifidateLabs()
        {
            return View();
        }



        public IActionResult AllProducts()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;
            List<ProductListDisplay> myProducts = new List<ProductListDisplay>();
            myProducts = _pService.GetMyProducts(loginCheckResponse.userId);


            return View(myProducts);
        }

        public IActionResult AllSubProducts(int pid = 0)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;
            List<ProductDetailsDisplay> myProducts = new List<ProductDetailsDisplay>();
            myProducts = _pService.GetSubProducts(pid);
            ViewBag.PID = pid;

            return View(myProducts);
        }
        public IActionResult AddProduct(int pid = 0)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;
            PostProduct_Ver1 myproduct = new PostProduct_Ver1();
            if (pid > 0)
            {
                var pm = _pService.GetProductMasterByid(pid);
                CloneObjects.CopyPropertiesTo(pm, myproduct);
                myproduct.mainImages = _pService.GetMainImages(pm.ProductId);
            }
            PaginationRequest pRequest = new PaginationRequest();
            pRequest.pageNumber = 1;
            pRequest.pageSize = 1000;
            GenericRequest gRequest = new GenericRequest();
            gRequest.pageNumber = 1;
            gRequest.pageSize = 1000;
            
            myproduct.catMaster = _oService.GetAllCategories(pRequest);
            gRequest.Id = pid > 0 ? (int) myproduct.CategoryId :  myproduct.catMaster[0].CategoryId;
            myproduct.subCatMaster = _oService.GetAllSubCategories(gRequest);
            gRequest.Id = pid > 0 ? (int) myproduct.SubCategoryId :   myproduct.subCatMaster[0].SubCategoryId;
            myproduct.detCatMaster = _oService.GetAllDetailCategories(gRequest);
            gRequest.Id = pid > 0 ? (int) myproduct.CategoryId :  myproduct.catMaster[0].CategoryId;
            myproduct.discountMaster = _mService.GetAllDiscounts(gRequest, "Posting");
            myproduct.currentGoldRate = _pService.GetGoldTodayRate();
            return View(myproduct);
        }

        [HttpPost]
        public IActionResult AddProduct(PostProduct_Ver1 request)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; 
                return RedirectToAction("Login", "Authenticate");
             
            }
            ViewBag.LoggedUser = loginCheckResponse;
            if (request.SubCategoryId == null)
            {
                ModelState.AddModelError("SubCategoryId", "Subcategory is required");
            }
            if (request.CategoryId == null )
            {
                ModelState.AddModelError("CategoryId", "Category is required");
            }
            if (request.DetailCategoryId == null)
            {
                ModelState.AddModelError("DetaiCategoryId", "Detail Category is required");
            }
            if (ModelState.IsValid)
            {
                ProcessResponse pr = new ProcessResponse();
                ProductMasterEntity pm = new ProductMasterEntity();
                if (request.ProductId > 0)
                {
                    pm = _pService.GetProductMasterByid(request.ProductId);
                    pm.CategoryId = request.CategoryId;
                    pm.DetailCategoryId = request.DetailCategoryId;
                    pm.DiscountApplicableId = request.DiscountApplicableId;
                    pm.IsAllGold = request.IsAllGold;
                    pm.IsCustomizable = request.IsCustomizable;
                    pm.IsHotDeal = request.IsHotDeal;
                    pm.IsSizeApplicable = request.IsSizeApplicable;
                    pm.MaxDelivaryDays = request.MaxDelivaryDays;
                    pm.PrefferedGender = request.PrefferedGender;
                    pm.ProductDescription = request.ProductDescription;
                    pm.ProductTitle = request.ProductTitle;
                    pm.SubCategoryId = request.SubCategoryId;
                    pm.Tags = request.Tags;
                    pr = _pService.SaveProductMaster(pm);
                         

                }
                else
                {
                    CloneObjects.CopyPropertiesTo(request, pm);
                    pm.IsDeleted = false;
                    pm.IsActive = true;
                    pm.PostedBy = loginCheckResponse.userId;
                    pm.PostedOn = DateTime.Now;
                    pm.NoofViews = 0;
                    pm.LastModifiedBy = loginCheckResponse.userId;
                    pm.LastModifiedOn = DateTime.Now;
                    pr = _pService.SaveProductMaster(pm);

                }
                
                if (pr.currentId > 0)
                {
                    if (request.ProductMainImages != null)
                    {
                        foreach (FormFile file in request.ProductMainImages)
                        {
                            var fileNameUploaded = Path.GetFileName(file.FileName);
                            if (fileNameUploaded != null)
                            {
                                var conentType = file.ContentType;
                                string filename = DateTime.UtcNow.ToString();
                                filename = Regex.Replace(filename, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                                filename = Regex.Replace(filename, "[A-Za-z ]", "");
                                filename = filename + RandomGenerator.RandomString(4, false);
                                string extension = Path.GetExtension(fileNameUploaded);
                                filename += extension;
                                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "ProductImages");
                                var filePath = Path.Combine(uploads, filename);
                                file.CopyTo(new FileStream(filePath, FileMode.Create));
                                ProductImagesEntity detimages = new ProductImagesEntity();
                                detimages.ImageType = conentType;
                                detimages.ImageUrl = filename;
                                detimages.IsDeleted = false;
                                detimages.ProductId = pr.currentId;
                                _pService.SaveProductMainImage(detimages);
                            }
                        }
                    }
                }
                if(request.ProductId > 0)
                {
                    return RedirectToAction("AllProducts");
                }
                else
                {
                    return RedirectToAction("AddProductDetail", new { pid = pr.currentId });
                }
                
            }


            PaginationRequest pRequest = new PaginationRequest();
            pRequest.pageNumber = 1;
            pRequest.pageSize = 1000;
            GenericRequest gRequest = new GenericRequest();
            gRequest.pageNumber = 1;
            gRequest.pageSize = 1000;

            request.catMaster = _oService.GetAllCategories(pRequest);
            gRequest.Id = (int)request.CategoryId;
            request.subCatMaster = _oService.GetAllSubCategories(gRequest);
            gRequest.Id = (int)request.SubCategoryId;
            request.detCatMaster = _oService.GetAllDetailCategories(gRequest);
            gRequest.Id = (int)request.CategoryId;
            request.discountMaster = _mService.GetAllDiscounts(gRequest);
            request.currentGoldRate = _pService.GetGoldTodayRate();

            return View(request);
        }

        public IActionResult AddProductDetail(int pid = 0, int did = 0)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;

            ProductMasterEntity pm = new ProductMasterEntity();
            pm = _pService.GetProductMasterByid(pid);
            PaginationRequest pRequest = new PaginationRequest();
            pRequest.pageNumber = 1;
            pRequest.pageSize = 1000;
            GenericRequest gRequest = new GenericRequest();
            gRequest.pageNumber = 1;
            gRequest.pageSize = 1000;
            ProductDetails_V1 myproduct = new ProductDetails_V1();
            if(did > 0)
            {
                ProductDetailsEntity pde = new ProductDetailsEntity();
                pde = _pService.GetProductDetailById(did);
                CloneObjects.CopyPropertiesTo(pde, myproduct);
                myproduct.detImages = _pService.GetDetialImages(did);

            }
            myproduct.currentGoldRate = _pService.GetGoldTodayRate();
            myproduct.measureMaster = _mService.GetAllMeasurements(gRequest);
            myproduct.MetalMaster = _mService.GetMetalMaster(pRequest,"P");
            gRequest.Id =  (int)pm.CategoryId;
            myproduct.Sizes = _mService.GetAllSizes_Web(gRequest);
            myproduct.dCaratMaster = _mService.GetDaimondCaratMaster(pRequest);
            myproduct.dClarityMaster = _mService.GetDaimondClarityMaster(pRequest);
            myproduct.dCutMaster = _mService.GetDaimondCutMaster(pRequest);
            myproduct.dSettingMaster = _mService.GetDaimondSettingsMaster(pRequest);
            myproduct.dShapeMaster = _mService.GetDaimondShapreMaster(pRequest);
            myproduct.dColorMaster = _mService.GetDaimondColorMaster(pRequest);
            myproduct.dTypeMaster = _mService.GetDaimondTypeMaster(pRequest);
            myproduct.sCertiMaster = _mService.GetCertificateMaster(pRequest);
            myproduct.sFluroMaster = _mService.GetFluorescenceMaster(pRequest);
            myproduct.sShapeMaster = _mService.GetSolitaireShapeMaster(pRequest);
            myproduct.sSymmetryMaster = _mService.GetSymmetryMaster(pRequest);
            myproduct.DList = _pService.GetDaimondPerList(did);
            myproduct.SList = _pService.GetSolPerList(did);
            myproduct.SRList = _pService.GetSRubyPerList(did);
            myproduct.PList = _pService.GetPerlPerList(did);
            
            myproduct.ProductId = pid;

            ViewBag.PM = pm;
            return View(myproduct);
        }

        [HttpPost]
        public IActionResult AddProductDetail(ProductDetails_V1 request)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }

            ModelState.Remove("daimondLineTotal");
            ModelState.Remove("daimondLineWeight");
            ModelState.Remove("perlSettingId");
            ModelState.Remove("srubySettingId");

            ModelState.Remove("solLineWeight1");
            ModelState.Remove("perlLineTotal");
            ModelState.Remove("perlLineTotal1");
            ModelState.Remove("solLineWeight1");
            ModelState.Remove("solLineWeight");
            ModelState.Remove("solLineTotal1");
            ModelState.Remove("solLineTotal");

            ModelState.Remove("daimondLineTotal1");
            ModelState.Remove("daimondLineWeight1");
            ModelState.Remove("srubyLineTotal1");

            ModelState.Remove("solFluorescenceId");
            
            if (ModelState.IsValid)
            {
                ProductDetailsEntity pd = new ProductDetailsEntity();
                if(request.ProductDetailId > 0)
                {

                    pd = _pService.GetProductDetailById(request.ProductDetailId);
                    pd.ActualPrice = request.ActualPrice;
                    pd.Height = request.Height;
                    pd.HeightMeasurementId = request.HeightMeasurementId;
                    pd.MakingCharges = request.MakingCharges;
                    pd.MetailWeightMesuremetnId = request.MetailWeightMesuremetnId;
                    pd.MetalMasterId = request.MetalMasterId;
                    pd.MetalWeight = request.MetalWeight;
                    pd.ProductCode = request.ProductCode;
                    pd.ProductId = request.ProductId;
                    pd.ProductWeight = request.ProductWeight;
                    pd.ProductWeightMeasurement = request.ProductWeightMeasurement;
                    pd.SellingPrice = request.SellingPrice;
                    pd.SizeMasterId = request.SizeMasterId;
                    pd.SubTitleText = request.SubTitleText;
                    pd.WeightMeasurementId = request.WeightMeasurementId;
                    pd.Width = request.Width;
                }
                else
                {
                    CloneObjects.CopyPropertiesTo(request, pd);
                    pd.IsActive = true;
                    pd.IsDeleted = false;
                    
                }
                var res = _pService.SaveProductDetail(pd);
                if (res.currentId > 0)
                {
                    if (request.ProductDetailImages != null)
                    {
                        foreach (FormFile file in request.ProductDetailImages)
                        {
                            var fileNameUploaded = Path.GetFileName(file.FileName);
                            if (fileNameUploaded != null)
                            {
                                var conentType = file.ContentType;
                                string filename = DateTime.UtcNow.ToString();
                                filename = Regex.Replace(filename, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                                filename = Regex.Replace(filename, "[A-Za-z ]", "");
                                filename = filename + RandomGenerator.RandomString(4, false);
                                string extension = Path.GetExtension(fileNameUploaded);
                                filename += extension;
                                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "ProductImages");
                                var filePath = Path.Combine(uploads, filename);
                                file.CopyTo(new FileStream(filePath, FileMode.Create));
                                ProductDetailImagesEntity detimages = new ProductDetailImagesEntity();
                                detimages.ImageType = conentType;
                                detimages.ImageUrl = filename;
                                detimages.IsDeleted = false;
                                detimages.ProductDetailId = res.currentId;
                                _pService.SaveDetailImages(detimages);
                            }
                        }
                    }

                    //add diamonds
                    if (request.daimondClarityId != null)
                    {
                        if (request.daimondClarityId.Count() > 0)
                        {
                            DaimondsPerProductEntity dpp = new DaimondsPerProductEntity();
                            dpp.IsDeleted = false;
                            dpp.ProductDetailId = res.currentId;
                            dpp.TotalDaimonds = request.daimondLineTotal.Sum();
                            dpp.TotalWeight = request.daimondLineWeight.Sum();
                            var dr = _pService.SaveDaimondsMain(dpp);

                            for (int i = 0; i < request.daimondClarityId.Count(); i++)
                            {
                                DaimondsPerPrdDetailsEntity dP = new DaimondsPerPrdDetailsEntity();
                                dP.ClarityId = request.daimondClarityId[i];
                                dP.ColorId = request.daimondColorId[i];
                                dP.DaimondTypeId = request.daimondTypeId[i];
                                dP.DPPId = dr.currentId;
                                dP.NoofDaimonds = request.daimondLineTotal[i];
                                dP.TotalWaight = request.daimondLineWeight[i];
                                dP.ShapeId = request.daimondShapeId[i];
                                dP.SettingTypeId = request.daimondSettingId[i];
                                dP.IsDeleted = false;
                                var fD = _pService.SaveDaimondsDetails(dP);
                            }
                        }

                    }

                    //add solitaire
                    if (request.solClarityId != null)
                    {
                        if (request.solClarityId.Count() > 0)
                        {
                            SolitairePerProductEntity dpp = new SolitairePerProductEntity();
                            dpp.IsDeleted = false;
                            dpp.ProductDetailId = res.currentId;
                            dpp.TotalSolitaires = request.solLineTotal.Sum();
                            dpp.TotalWeight = request.solLineWeight.Sum();
                            var dr = _pService.SaveSolitaireMain(dpp);

                            for (int i = 0; i < request.solClarityId.Count(); i++)
                            {
                                SolitairePerPrdDetailsEntity dP = new SolitairePerPrdDetailsEntity();
                                dP.ClarityId = request.solClarityId[i];
                                dP.ColorId = request.solColorId[i];
                                dP.TotalWaight = request.solLineWeight[i];
                                dP.ShapeId = request.solShapeId[i];
                                dP.CertificationId = request.solCertificateId[i];
                                dP.FluorescenceId = request.solFluorescenceId[i];
                                dP.NoofSolitaire = request.solLineTotal[i];
                                dP.Symmetry = request.solSymmetryId[i];
                                dP.IsDeleted = false;
                                dP.SPPId = dr.currentId;
                                var fD = _pService.SaveSolitaireDetails(dP);
                            }
                        }

                    }

                    //add Perol
                    if (request.perlSettingId != null)
                    {
                        if (request.perlSettingId.Count() > 0)
                        {
                            PerlPerProductEntity dpp = new PerlPerProductEntity();
                            dpp.IsDeleted = false;
                            dpp.ProductDetailId = res.currentId;
                            dpp.TotalStones = request.perlLineTotal.Sum();
                            dpp.TotalWeight = 0;
                            var dr = _pService.SavePerlMain(dpp);

                            for (int i = 0; i < request.perlSettingId.Count(); i++)
                            {
                                PerlPerPrdDetailsEntity dP = new PerlPerPrdDetailsEntity();
                                dP.NoofStones = request.perlLineTotal[i];
                                dP.PPPId = dr.currentId;
                                dP.SettingId = request.perlSettingId[i];
                                dP.ShapeId = request.perlShapeId[i];
                                dP.Size = request.perlSize[i];
                                dP.IsDeleted = false;
                                var fD = _pService.SavePerlDeail(dP);
                            }
                        }

                    }


                    //add srub
                    if (request.srubySettingId != null)
                    {
                        if (request.srubySettingId.Count() > 0)
                        {
                            SRubyPerProductEntity dpp = new SRubyPerProductEntity();
                            dpp.IsDeleted = false;
                            dpp.ProductDetailId = res.currentId;
                            dpp.TotalStones = request.perlLineTotal.Sum();
                            dpp.TotalWeight = 0;
                            var dr = _pService.SaveSRubyMain(dpp);

                            for (int i = 0; i < request.srubySettingId.Count(); i++)
                            {
                                SRubyPerPrdDetailsEntity dP = new SRubyPerPrdDetailsEntity();
                                dP.NoofStones = request.srubylLineTotal[i];
                                dP.SRPPId = dr.currentId;
                                dP.SettingId = request.srubySettingId[i];
                                dP.ShapeId = request.srubyShapeId[i];
                                dP.Size = request.srubySize[i];
                                dP.IsDeleted = false;
                                var fD = _pService.SaveSRubyDetails(dP);
                            }
                        }

                    }

                    //calculate price 
                    PriceBreakUpModel pb = new PriceBreakUpModel();
                    pb = _pService.CalculatePrice(request.ProductId, res.currentId);
                    ProductDetailsEntity pdEntity = _pService.GetProductDetailById(res.currentId);
                    pdEntity.ActualPrice = pb.oldAmount;
                    pdEntity.SellingPrice = pb.totalAmount;
                    _pService.UpdateProductPrice(pdEntity);
                }

                return RedirectToAction("AllSubProducts", new { pid=request.ProductId});
            }
            ViewBag.LoggedUser = loginCheckResponse;
            ProductMasterEntity pm = new ProductMasterEntity();
            pm = _pService.GetProductMasterByid(request.ProductId);
            PaginationRequest pRequest = new PaginationRequest();
            pRequest.pageNumber = 1;
            pRequest.pageSize = 1000;
            GenericRequest gRequest = new GenericRequest();
            gRequest.pageNumber = 1;
            gRequest.pageSize = 1000;

            request.currentGoldRate = _pService.GetGoldTodayRate();
            request.measureMaster = _mService.GetAllMeasurements(gRequest);
            request.MetalMaster = _mService.GetMetalMaster(pRequest, "P");
            gRequest.Id = (int)pm.CategoryId;
            request.Sizes = _mService.GetAllSizes_Web(gRequest);
            request.dCaratMaster = _mService.GetDaimondCaratMaster(pRequest);
            request.dClarityMaster = _mService.GetDaimondClarityMaster(pRequest);
            request.dCutMaster = _mService.GetDaimondCutMaster(pRequest);
            request.dSettingMaster = _mService.GetDaimondSettingsMaster(pRequest);
            request.dColorMaster = _mService.GetDaimondColorMaster(pRequest);
            request.dTypeMaster = _mService.GetDaimondTypeMaster(pRequest);
            request.dShapeMaster = _mService.GetDaimondShapreMaster(pRequest);
            request.sCertiMaster = _mService.GetCertificateMaster(pRequest);
            request.sFluroMaster = _mService.GetFluorescenceMaster(pRequest);
            request.sShapeMaster = _mService.GetSolitaireShapeMaster(pRequest);
            request.sSymmetryMaster = _mService.GetSymmetryMaster(pRequest);
            request.ProductId = request.ProductId;


            ViewBag.PM = pm;

            return View(request);
        }


        [HttpPost]
        public IActionResult DeleteProduct(int id = 0)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                ProductMasterEntity request = new ProductMasterEntity();
                request = _pService.GetProductMasterByid(id);
                request.IsDeleted = true;
                response = _pService.SaveProductMaster(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }
        [HttpPost]
        public IActionResult DeleteSubProduct(int id = 0)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                ProductDetailsEntity request = new ProductDetailsEntity();
                request = _pService.GetProductDetailById(id);
                request.IsDeleted = true;
                response = _pService.SaveProductDetail(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }


        public IActionResult TodayGoldRate()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            ViewBag.LoggedUser = loginCheckResponse;
            GoldRateMasterEntity gold = new GoldRateMasterEntity();
            gold = _pService.GetGoldRate();
            return View(gold);
        }
        [HttpPost]
        public IActionResult TodayGoldRate(GoldRateMasterEntity request)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard" });
            }
            if (ModelState.IsValid)
            {
                request.IsDeleted = false;
                request.DateOfLastUpdate = DateTime.Now;
                request.UnitofMeasure = "GM";
                var re = _pService.UpdateGoldRate(request);
            }
            ViewBag.LoggedUser = loginCheckResponse;
            return View(request);
        }

        [HttpPost]
        public IActionResult GetCities(int cid)
        {
            List<CityMasterEntity> myList = _oService.GetAllCities(1, 10000, "", cid);
            return Json(new { result = myList });
        }


        [HttpPost]
        public IActionResult DeleteProductMainImage(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                _pService.DeleteMainImage(id);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }

        [HttpPost]
        public IActionResult DeleteProductDetailImage(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                _pService.DeleteDetailImage(id);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }


        [HttpPost]
        public IActionResult DeletePerlLineItem(int id)
        {
            _pService.DeletePerlPerPrd(id);
            return Json(new { result = "Ok" });
        }
        [HttpPost]
        public IActionResult DeleteDaimondLineItem(int id)
        {
            _pService.DeleteDaimondPerPrd(id);
            return Json(new { result = "Ok" });
        }
        [HttpPost]
        public IActionResult DeleteSolLineItem(int id)
        {
            _pService.DeleteSolPerPrd(id);
            return Json(new { result = "Ok" });
        }
        [HttpPost]
        public IActionResult DeleteSubyLineItem(int id)
        {
            _pService.DeleteSRubyPerPrd(id);
            return Json(new { result = "Ok" });
        }
    }
}
