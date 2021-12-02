using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class OthersMastersController : Controller
    {

        public readonly IOtherMgmtService _oService;
        public readonly IProductManagementService _pservice;
        private readonly IHostingEnvironment hostingEnvironment; public readonly IMasterDataMgmtService _mService;
        public OthersMastersController(
            IOtherMgmtService oService, IMasterDataMgmtService mService, IProductManagementService pService,
            IHostingEnvironment environment
            ) 
        {
            _oService = oService;
            _mService = mService;
            _pservice = pService;
            hostingEnvironment = environment;
        }
        /// <summary>
        /// category master data management
        /// </summary>
        /// <returns></returns>
        public IActionResult Categories()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
                ViewBag.LoggedUser = loginCheckResponse;
                return RedirectToAction("Login", "Authenticate", new { url = "Master/Dashboard"});
            }
            ViewBag.LoggedUser = loginCheckResponse;
            List<CategoryMasterEntity> myList = new List<CategoryMasterEntity>();
            PaginationRequest request = new PaginationRequest();
            myList = _oService.GetAllCategories(request);
            return View(myList);
        }


        public IActionResult CategoryData(int id = 0)
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
            CategoryMasterEntity utm = new CategoryMasterEntity();
            if (id > 0)
            {
                utm = _oService.GetCategoryById(id);
            }
            else
            {
                utm = new CategoryMasterEntity();
            }

            return View(utm);
        }

        [HttpPost]
        public IActionResult CategoryData(CategoryMasterEntity request)
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
                var checkUserType = _oService.CheckCategoryType(request.CategoryName, request.CategoryId);
                if (checkUserType == false)
                {
                    ModelState.AddModelError("CategoryName", "CategoryName not available");
                }
                if (ModelState.IsValid)
                {
                    if (request.CategoryId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _oService.SaveCategory(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Categories");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _oService.UpdateCategory(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Categories");
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
        public IActionResult DeleteCategoryMaster(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                CategoryMasterEntity request = new CategoryMasterEntity();
                request = _oService.GetCategoryById(id);
                request.IsDeleted = true;
                response = _oService.UpdateCategory(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }

        /// <summary>
        /// sub category masters
        /// </summary>
        /// <returns></returns>
        public IActionResult Subcategories(int catid=0)
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
            List<CategoryMasterEntity> catList = new List<CategoryMasterEntity>();
            PaginationRequest request = new PaginationRequest();
            catList = _oService.GetAllCategories(request);
            ViewBag.catid = catList;
            if (catid == 0 && catList.Count > 0)
            {
                catid = catList[0].CategoryId;
            }
            ViewBag.currentcatid = catid;
            List<SubCategoryMasterEntity> myList = new List<SubCategoryMasterEntity>();
            GenericRequest r = new GenericRequest();
            r.Id = catid;
            myList = _oService.GetAllSubCategories(r);
            return View(myList);
        }
        public IActionResult SubCategoryData(int id = 0)
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
            List<CategoryMasterEntity> catList = new List<CategoryMasterEntity>();
            PaginationRequest request = new PaginationRequest();
            catList = _oService.GetAllCategories(request);
            ViewBag.catid = catList;
            
            SubCategoryMasterEntity utm = new SubCategoryMasterEntity();
            if (id > 0)
            {
                utm = _oService.GetSubCategoryById(id);
                ViewBag.currentcatid = utm.CategoryId;
            }
            else
            {
                utm = new SubCategoryMasterEntity();
                ViewBag.currentcatid = 0;
            }

            return View(utm);
        }

        [HttpPost]
        public IActionResult SubCategoryData(SubCategoryMasterEntity request)
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
            List<CategoryMasterEntity> catList = new List<CategoryMasterEntity>();
            PaginationRequest pr = new PaginationRequest();
            catList = _oService.GetAllCategories(pr);
            ViewBag.catid = catList;
            ViewBag.currentcategoryid = request.CategoryId;
            if (ModelState.IsValid)
            {
                var checkUserType = _oService.CheckSubCategoryType(request.SubCategoryName, (int)request.CategoryId, request.SubCategoryId);
                if (checkUserType == false)
                {
                    ModelState.AddModelError("SubCategoryName", "CategoryName not available");
                }
                if (ModelState.IsValid)
                {
                    if (request.SubCategoryId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _oService.SaveSubCategory(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Subcategories", new { catid = request.CategoryId });
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _oService.UpdateSubCategory(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Subcategories");
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
        public IActionResult DeleteSubCategoryMaster(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                SubCategoryMasterEntity request = new SubCategoryMasterEntity();
                request = _oService.GetSubCategoryById(id);
                request.IsDeleted = true;
                response = _oService.UpdateSubCategory(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }

        [HttpPost]
        public IActionResult GetAllSubCatsDrop(int catid = 0)
        {
            List<SubCategoryMasterEntity> masterEntities = new List<SubCategoryMasterEntity>();
            GenericRequest r = new GenericRequest();
            r.Id = catid;
            masterEntities = _oService.GetAllSubCategories(r);


            return Json(new { result = masterEntities });
        }
        /// <summary>
        /// detail category masters
        /// </summary>
        /// <returns></returns>
        ///
        public IActionResult DetailCategories(int subcatid=0, int catid=0)
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
            List<CategoryMasterEntity> catList = new List<CategoryMasterEntity>();
            List<SubCategoryMasterEntity> subCatList = new List<SubCategoryMasterEntity>();
            PaginationRequest pr = new PaginationRequest();
            catList = _oService.GetAllCategories(pr);
            int currentCatId = catid > 0 ? catid : (catList.Count > 0 ? catList[0].CategoryId : 0);
            GenericRequest r = new GenericRequest();
            r.Id = currentCatId;
            subCatList = _oService.GetAllSubCategories(r);
            int currentSubCatId = subcatid > 0 ? subcatid : (subCatList.Count > 0 ? subCatList[0].SubCategoryId : 0);
            ViewBag.cats = catList;
            ViewBag.currentCatId = currentCatId;
            ViewBag.subcats = subCatList;
            ViewBag.currentSubCatId = currentSubCatId;
            List<DetailCategoryMasterEntity> myList = new List<DetailCategoryMasterEntity>();
            myList = _oService.GetAllDetailCategories(r);
            return View(myList);
        }

        public IActionResult DetailCategoryData(int id = 0)
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

            List<CategoryMasterEntity> catList = new List<CategoryMasterEntity>();
            List<SubCategoryMasterEntity> subCatList = new List<SubCategoryMasterEntity>();
            PaginationRequest pr = new PaginationRequest();
            catList = _oService.GetAllCategories(pr);

            int currentCatId = (catList.Count > 0 ? catList[0].CategoryId : 0);
            DetailCategoryMasterEntity utm = new DetailCategoryMasterEntity();
            if (id > 0)
            {
                utm = _oService.GetDetailCategoryById(id);
                ViewBag.currentCatId = utm.CategoryId;
                ViewBag.currentSubCatId = utm.SubCategoryId;
                currentCatId = (int) utm.CategoryId;
                GenericRequest r = new GenericRequest();
                r.Id = currentCatId;
                subCatList = _oService.GetAllSubCategories(r);
                int currentSubCatId = (int) utm.SubCategoryId ;
                ViewBag.cats = catList;
                ViewBag.currentCatId = currentCatId;
                ViewBag.subcats = subCatList;
                ViewBag.currentSubCatId = currentSubCatId;
            }
            else
            {
                utm = new DetailCategoryMasterEntity();
                ViewBag.currentCatId = 0;
                GenericRequest r = new GenericRequest();
                r.Id = catList.Count > 0 ? catList[0].CategoryId : 0;
                subCatList = _oService.GetAllSubCategories(r);
                ViewBag.currentSubCatId = 0;
                ViewBag.cats = catList;
                ViewBag.currentCatId = currentCatId;
                ViewBag.subcats = subCatList;
            }
           
            return View(utm);
        }

        [HttpPost]
        public IActionResult DetailCategoryData(DetailCategoryMasterEntity request)
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
            List<CategoryMasterEntity> catList = new List<CategoryMasterEntity>();
            List<SubCategoryMasterEntity> subCatList = new List<SubCategoryMasterEntity>();
            PaginationRequest pr = new PaginationRequest();
            catList = _oService.GetAllCategories(pr);
            int currentCatId =request.CategoryId == null ? 0 :  (int) request.CategoryId;
            GenericRequest r = new GenericRequest();
            r.Id = currentCatId;
            subCatList =  _oService.GetAllSubCategories(r);
            int currentSubCatId = request.SubCategoryId == null ? 0 :  (int) request.SubCategoryId;
            ViewBag.cats = catList;
            ViewBag.currentCatId = currentCatId;
            ViewBag.subcats = subCatList;
            ViewBag.currentSubCatId = currentSubCatId;


            if (ModelState.IsValid)
            {
                var checkUserType = _oService.CheckDetailCategoryType(request.DetailCategoryName, 
                    (int)request.SubCategoryId, (int) request.DetailCategoryId);
                if (checkUserType == false)
                {
                    ModelState.AddModelError("DetailCategoryName", "CategoryName not available");
                }
                if (ModelState.IsValid)
                {
                    if (request.DetailCategoryId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _oService.SaveDetailCategory(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("DetailCategories", new { subcatid = request.SubCategoryId, catid = request.CategoryId });
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _oService.UpdateDetailCategory(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("DetailCategories");
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
        public IActionResult DeleteDetailCategoryMaster(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                DetailCategoryMasterEntity request = new DetailCategoryMasterEntity();
                request = _oService.GetDetailCategoryById(id);
                request.IsDeleted = true;
                response = _oService.UpdateDetailCategory(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }



        /// <summary>
        /// banner  adds
        /// </summary>
        /// <returns></returns>
        public IActionResult BannerAds(string page="")
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
            BannerAdsDisplayModelBase obj = new BannerAdsDisplayModelBase();
            string url = HttpContext.Request.Scheme + @"://" + HttpContext.Request.Host.Value;
            obj.myAds = _oService.GetAllBanners(page);

            foreach (var item in obj.myAds)
            {
                if (!string.IsNullOrEmpty(item.BannerWebSite))
                {
                    item.BannerWebSite = url + item.BannerWebSite + item.BannerUrl;
                }
            }
            obj.pageDrop = _oService.GetBannerPages();
            obj.sectionDrop = _oService.GetBannerSections();
            ViewBag.Page = page;
            return View(obj);
        }

       
        public IActionResult BannerAdData(int bid=0)
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
            

            BannerAdsDisplayModel myAds = new BannerAdsDisplayModel();
            if(bid > 0)
            {
                BannerAdsEntity bd = new BannerAdsEntity();
                bd= _oService.GetBannerById(bid);
                CloneObjects.CopyPropertiesTo(bd, myAds);
            }
            ViewBag.pageDrop = _oService.GetBannerPages();
            ViewBag.sectionDrop = _oService.GetBannerSections();
            
            return View(myAds);

        }
        [HttpPost]
        public IActionResult BannerAdData(BannerAdsDisplayModel request)
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
            string upFile = string.Empty;
            string upType = string.Empty;
            if(ModelState.IsValid)
            {
                bool isImageUploaded = false;

                if (request.ImageUploaded != null)
                {
                    var file = request.ImageUploaded;
                        var fileNameUploaded = Path.GetFileName(file.FileName);
                        if (fileNameUploaded != null)
                        {
                            var conentType = file.ContentType;
                        upType = file.ContentType;
                            string filename = DateTime.UtcNow.ToString();
                            filename = Regex.Replace(filename, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                            filename = Regex.Replace(filename, "[A-Za-z ]", "");
                            filename = filename + RandomGenerator.RandomString(4, false);
                            string extension = Path.GetExtension(fileNameUploaded);
                            filename += extension;
                            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "ProductImages");
                            var filePath = Path.Combine(uploads, filename);
                            file.CopyTo(new FileStream(filePath, FileMode.Create));
                            isImageUploaded = true;
                        upFile = filename;
                        }
                    
                }

                BannerAdsEntity be = new BannerAdsEntity();
                if (request.BannerId > 0)
                {
                    
                    be = _oService.GetBannerById(request.BannerId);
                    be.BannerPage = request.BannerPage;
                    be.BannerSection = request.BannerSection;
                    be.BannerTextBig = request.BannerTextBig;
                    be.BannerTextShort = request.BannerTextShort;
                    be.BannerWebSite = request.BannerWebSite;
                    be.CurrentStatus = be.CurrentStatus;
                    be.Duration = be.Duration;
                    be.EndDate = request.EndDate;
                    be.PostedBy = be.PostedBy;
                    be.PostedOn = be.PostedOn;
                    be.StartDate = request.StartDate;
                    be.BannerUrl = isImageUploaded ? upFile : be.BannerUrl;
                    be.BannerType = isImageUploaded ? upType : be.BannerType;
                }
                else
                {
                    CloneObjects.CopyPropertiesTo(request, be);
                    be.IsDeleted = false;
                    be.PostedOn = DateTime.Now;
                    be.BannerUrl = upFile;
                    be.BannerType = upType;
                    be.PostedBy = loginCheckResponse.userId;
                    
                }
                var v = _oService.SaveBannerAdd(be);

                return RedirectToAction("BannerAds", new { page = request.BannerPage });

            }
            ViewBag.pageDrop = _oService.GetBannerPages();
            ViewBag.sectionDrop = _oService.GetBannerSections();

            return View(request);

        }

        /// <summary>
        /// country management
        /// </summary>
        /// <returns></returns>
        public IActionResult Countries(int pageNumber = 1,
            int pageSize = 10, string search = "")
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
            List<CountryMasterEntity> myList = new List<CountryMasterEntity>();
            myList = _oService.GetAllCountries(pageNumber, pageSize,search);
            int totalCount = _oService.GetCountryCount(search);
            ViewBag.TotalCount = totalCount;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.search = search;

            return View(myList);
        }






        public IActionResult States()
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
            return View();
        }
        public IActionResult Cities()
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
            return View();
        }


        /// <summary>
        /// discounts master data management
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult Discounts()
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
            List<DiscountMasterEntity> myList = new List<DiscountMasterEntity>();
            GenericRequest request = new GenericRequest();
            myList = _mService.GetAllDiscounts(request);
            return View(myList);
        }


        public IActionResult DiscountsData(int id = 0)
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
            DiscountMasterEntity utm = new DiscountMasterEntity();
            if (id > 0)
            {
                utm = _mService.GetDiscountById(id);
            }
            else
            {
                utm = new DiscountMasterEntity();
            }

            return View(utm);
        }

        [HttpPost]
        public IActionResult DiscountsData(DiscountMasterEntity request)
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
                
                    if (request.DMasterId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _mService.UpdateDiscount(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Discounts");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _mService.UpdateDiscount(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Discounts");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                

            }
            return View(request);
        }
        
        [HttpPost]
        public IActionResult DeleteDiscount(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                DiscountMasterEntity request = new DiscountMasterEntity();
                request = _mService.GetDiscountById(id);
                request.IsDeleted = true;
                response = _mService.UpdateDiscount(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }


        [HttpPost]
        public IActionResult DeleteBannerAd(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                BannerAdsEntity request = new BannerAdsEntity();
                request = _oService.GetBannerById(id);
                request.IsDeleted = true;
                response = _oService.SaveBannerAdd(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }

        [HttpPost]
        public IActionResult EnableDisbleDiscount(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                DiscountMasterEntity request = new DiscountMasterEntity();
                request = _mService.GetDiscountById(id);
                if(request.IsApplicable == true)
                {
                    request.IsApplicable = false;
                }
                else
                {
                    request.IsApplicable = true;
                }

                response = _mService.UpdateDiscount(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to update";
            }

            return Json(new { result = response });
        }


        /// <summary>
        /// banner  adds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult APIGetBannerAds(string page = "")
        {
            BannerAdsDisplayModelBase obj = new BannerAdsDisplayModelBase();
             obj.myAds = _oService.GetAllBanners(page);
            List<BannerAdsDisplayModel> bannerAds = new List<BannerAdsDisplayModel>();
            string url = HttpContext.Request.Scheme + @"://" + HttpContext.Request.Host.Value;
            foreach (var item in obj.myAds)
            {
                if (!string.IsNullOrEmpty(item.BannerWebSite))
                {
                    item.BannerWebSite = url + item.BannerWebSite + item.BannerUrl;
                }
            }

            var featured = _pservice.APIGetLatestProducts();
            var hotDeals = _pservice.APIGetLatestProducts("HT");

            return Json(new { status = 1, Message= "Success", BannerADs=obj.myAds ,featured=featured!=null?featured:new List<APIProductListDisplay>(), htodeals=hotDeals!=null ? hotDeals: new List<APIProductListDisplay>()}) ;
        }

        [HttpGet]

        public IActionResult APIGetMenuProducts(string menuId) {

            BannerAdsDisplayModelBase obj = new BannerAdsDisplayModelBase();
            obj.myAds = _oService.GetAllBanners(menuId);
            string url = HttpContext.Request.Scheme + @"://" + HttpContext.Request.Host.Value;
            foreach (var item in obj.myAds)
            {
                if (!string.IsNullOrEmpty(item.BannerWebSite))
                {
                    item.BannerWebSite = url + item.BannerWebSite + item.BannerUrl;
                }
            }
            List<BannerAdsDisplayModel> bannerAds = new List<BannerAdsDisplayModel>();

            return Json(new { status = 1, Message = "Success", BannerADs = obj.myAds });

        }

    }
}
