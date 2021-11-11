using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.InterfacesBAL;
using Microsoft.Extensions.Logging;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Ecommerce.Models.Entity;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace Ecommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductManagementController : ControllerBase
    {
        private readonly ILogger<UserMgmtController> _logger;
        private readonly INotificationService _nService;
        private readonly IUserMgmtService _uService;
        private readonly IMasterDataMgmtService _mService;
        private readonly IOtherMgmtService _oService;
        private readonly IProductManagementService _pService;
        private readonly IHostingEnvironment hostingEnvironment;
        public ProductManagementController (ILogger<UserMgmtController> logger,
            INotificationService nService,
            IMasterDataMgmtService mService,
            IOtherMgmtService oService,
            IUserMgmtService uService,
            IProductManagementService pService, IHostingEnvironment environement)
        {
            _logger = logger;
            _nService = nService;
            _uService = uService;
            _mService = mService;
            _oService = oService;
            _pService = pService;
            hostingEnvironment = environement;
        }

        [HttpPost]
        public IActionResult PostProduct(PostProductModel request)
        {
            ProcessResponse pResponse = new ProcessResponse();
            try
            {
                
                if (request != null)
                {
                    ProductMasterEntity pMaster = new ProductMasterEntity();
                    CloneObjects.CopyPropertiesTo(request, pMaster);
                    pMaster.IsDeleted = false;
                    pMaster.IsActive = true;
                    pMaster.NoofViews = 0;
                    pMaster.PostedOn = DateTime.Now;
                    pMaster.LastModifiedBy = pMaster.PostedBy;
                    pMaster.LastModifiedOn = DateTime.Now;
                    pResponse = _pService.SaveProductMaster(pMaster);
                    if(pResponse.statusCode == 1)
                    {
                        if(request.ProductDetails.Count > 0)
                        {
                            foreach(var d in request.ProductDetails)
                            {
                                ProductDetailsEntity pd = new ProductDetailsEntity();
                                CloneObjects.CopyPropertiesTo(d, pd);
                                pd.IsDeleted = false;
                                pd.IsActive = true;
                                pd.ProductId = pResponse.currentId;
                                var dResponse = _pService.SaveProductDetail(pd);
                                if(dResponse.statusCode == 1)
                                {
                                    decimal daimondRate = 0;
                                    if (d.DaimondsMain != null)
                                    {
                                        DaimondsPerProductEntity daimondMain = new DaimondsPerProductEntity();
                                        CloneObjects.CopyPropertiesTo(d.DaimondsMain, daimondMain);
                                        daimondMain.ProductDetailId = dResponse.currentId;
                                        daimondMain.IsDeleted = false;
                                        var dMResponse = _pService.SaveDaimondsMain(daimondMain);
                                        if(d.DaimondsDetail.Count > 0)
                                        {
                                            foreach (var dd in d.DaimondsDetail)
                                            {
                                                DaimondsPerPrdDetailsEntity dPP = new DaimondsPerPrdDetailsEntity();
                                                CloneObjects.CopyPropertiesTo(dd, dPP);
                                                dPP.DPPId = dMResponse.currentId;
                                                dPP.IsDeleted = false;
                                                _pService.SaveDaimondsDetails(dPP);
                                                decimal dmPrice = (decimal)_pService.GetDaimondRate((int) dPP.DaimondTypeId);
                                                daimondRate  += (decimal) dd.TotalWaight * dmPrice;
                                            }
                                        }
                                    }
                                    if(d.PerlMain != null)
                                    {
                                        PerlPerProductEntity perlMain = new PerlPerProductEntity();
                                        CloneObjects.CopyPropertiesTo(d.PerlMain, perlMain);
                                        perlMain.ProductDetailId = dResponse.currentId;
                                        perlMain.IsDeleted = false;
                                        var pmResponse = _pService.SavePerlMain(perlMain);
                                        if(d.PerlDetails.Count > 0)
                                        {
                                            foreach(var perlDetails in d.PerlDetails)
                                            {
                                                PerlPerPrdDetailsEntity pDetails = new PerlPerPrdDetailsEntity();
                                                CloneObjects.CopyPropertiesTo(perlDetails, pDetails);
                                                pDetails.IsDeleted = false;
                                                pDetails.PPPId = pmResponse.currentId;
                                                _pService.SavePerlDeail(pDetails);
                                            }
                                        }
                                    }
                                    if (d.SolitaireMain != null)
                                    {
                                        SolitairePerProductEntity solMain = new SolitairePerProductEntity();
                                        CloneObjects.CopyPropertiesTo(d.SolitaireMain,solMain );
                                        solMain.ProductDetailId = dResponse.currentId;
                                        solMain.IsDeleted = false;
                                        var pmResponse = _pService.SaveSolitaireMain(solMain);
                                        if (d.SolitaireDetails.Count > 0)
                                        {
                                            foreach (var solDetails in d.SolitaireDetails)
                                            {
                                                SolitairePerPrdDetailsEntity pDetails = new SolitairePerPrdDetailsEntity();
                                                CloneObjects.CopyPropertiesTo(solDetails, pDetails);
                                                pDetails.IsDeleted = false;
                                                pDetails.SPPId = pmResponse.currentId;
                                                _pService.SaveSolitaireDetails(pDetails);
                                            }
                                        }
                                    }
                                    if (d.SRubyMain != null)
                                    {
                                        SRubyPerProductEntity solMain = new SRubyPerProductEntity();
                                        CloneObjects.CopyPropertiesTo(d.SRubyMain, solMain);
                                        solMain.ProductDetailId = dResponse.currentId;
                                        solMain.IsDeleted = false;
                                        var pmResponse = _pService.SaveSRubyMain(solMain);
                                        if (d.SRubyDetails.Count > 0)
                                        {
                                            foreach (var solDetails in d.SRubyDetails)
                                            {
                                                SRubyPerPrdDetailsEntity rubyDetails = new SRubyPerPrdDetailsEntity();
                                                CloneObjects.CopyPropertiesTo(solDetails, rubyDetails);
                                                rubyDetails.IsDeleted = false;
                                                rubyDetails.SRPPId = pmResponse.currentId;
                                                _pService.SaveSRubyDetails(rubyDetails);
                                            }
                                        }
                                    }

                                    // saving images
                                    if (d.ProductDetailImages != null)
                                    {
                                        foreach(FormFile file in d.ProductDetailImages)
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
                                                detimages.ImageUrl = uploads + filename;
                                                detimages.IsDeleted = false;
                                                detimages.ProductDetailId = dResponse.currentId;
                                                _pService.SaveDetailImages(detimages);
                                            }
                                        }
                                       
                                       
                                    }

                                    //calculate price 
                                   
                                    decimal goldWeight = (decimal)d.ProductWeight;
                                    decimal goldOriginalRate = _pService.GetGoldTodayRate();
                                    decimal goldKaratPercentatge = _pService.GetMetalTypeRate((int)d.MetalMasterId);
                                    decimal goldRate = goldWeight * ((goldOriginalRate * goldKaratPercentatge) / 100);


                                    PriceBreakUpModel pm = new PriceBreakUpModel();
                                    pm.DaimondRate = daimondRate;

                                    pm.GoldRate = goldRate;
                                    pm.GST = (decimal) _pService.GetGSTRate() * goldRate / 100;
                                    pm.MakingCharges = goldRate * 10 / 100;
                                    pm.discount = (decimal) _pService.GetDisocuntRate((int)request.DiscountApplicableId) * pm.MakingCharges / 100;
                                    pm.totalAmount = (daimondRate + goldRate + pm.MakingCharges + pm.GST) - pm.discount;
                                    pm.oldAmount = daimondRate + goldRate + pm.GST + pm.MakingCharges;

                                    ProductDetailsEntity pdEntity = _pService.GetProductDetailById(dResponse.currentId);
                                    pdEntity.ActualPrice = pm.totalAmount;
                                    pdEntity.SellingPrice = pm.oldAmount;
                                    _pService.UpdateProductPrice(pdEntity);

                                }

                            }
                        }

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
                                    detimages.ImageUrl = uploads + filename;
                                    detimages.IsDeleted = false;
                                    detimages.ProductId = pResponse.currentId;
                                    _pService.SaveProductMainImage(detimages);
                                }
                            }


                        }
                    }

                    return Ok(pResponse);
                }
                else
                {
                    ProcessResponse response = new ProcessResponse();
                    response.statusCode = 0;
                    response.statusMessage = "Send project object";
                }

                return Ok(pResponse);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult GetProductDetails(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_pService.GetProductDetails(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet]
        public IActionResult APIGetProductDetails(int request)
        {
            try
            {
                var productDetails = Transform.ConvertResultToApiResonse(_pService.GetProductDetails(request));
                return StatusCode(200, new { ProductDetails= productDetails, Message="Success" });
            }
            catch (Exception ex)
            {
                return StatusCode(200, new { status=0, message="Failure"});
            }
        }
        [HttpPost]
        public IActionResult APIGetProductsByCatId([FromForm] ProductDetailsRequest request ) 
        {
            try
            {
                string url = HttpContext.Request.Scheme + ":\\" + HttpContext.Request.Host.Value + @"\ProductImages\";
                  var response = _pService.APIGetProductsByCatId(request,url);
                 

                return StatusCode(200, new { status =1, message="Success", productDetails=response});
            }
            catch (Exception ex)
            {
                return StatusCode(200, new { status = 1, message = "Failure"});
            }
        }

        [HttpPost]
        public IActionResult GetMyProducts(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_pService.GetMyProducts(request.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }   

        [HttpPost]
        public IActionResult GetGoldRate(GenericRequest request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_pService.GetGoldRate());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public IActionResult UpdateGoldRate(GoldRateMasterEntity request)
        {
            try
            {
                var response = Transform.ConvertResultToApiResonse(_pService.UpdateGoldRate(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        public PriceBreakUpModel CalculatePrice(int prid)
        {
             

            //calculate price 
            PostProductModel_Web product = _pService.GetProductDetails_Web(prid);
            PriceBreakUpModel pm = new PriceBreakUpModel();
            if (product.ProductDetails.Count > 0)
            {
                decimal goldWeight = (decimal)product.ProductDetails[0].ProductWeight;
                decimal goldOriginalRate = (decimal)product.GoldRate.Rate;
                decimal goldKaratPercentatge = (decimal)product.MetalMaster.Where(a => a.MasterId == product.ProductDetails[0].MetalMasterId).Select(b => b.PriceCalPercentage).FirstOrDefault();
                decimal goldRate = goldWeight * ((goldOriginalRate * goldKaratPercentatge) / 100);

                decimal daimondRate = 0;
                if (product.ProductDetails[0].DaimondsMain != null)
                {
                    decimal individualPrice = 0;
                    foreach (var v in product.ProductDetails[0].DaimondsDetail)
                    {
                        decimal dmPrice = (decimal)product.DiamondRate.Where(a => a.MasterId == v.DaimondTypeId).Select(b => b.PriceTag).FirstOrDefault();
                        individualPrice += (decimal)v.TotalWaight * dmPrice;
                        daimondRate += individualPrice;
                    }
                }

                pm.DaimondRate = daimondRate;

                pm.GoldRate = goldRate;
                pm.GST = (decimal)product.GST[0].GSTTaxValue * goldRate / 100;
                pm.MakingCharges =(decimal) product.ProductDetails[0].MakingCharges;
                pm.discount = (decimal)product.DiscountAmount * pm.MakingCharges / 100;
                pm.totalAmount = (daimondRate + goldRate + pm.MakingCharges + pm.GST) - pm.discount;
                pm.oldAmount = daimondRate + goldRate + pm.GST + pm.MakingCharges;
                product.priceBreakup = pm;

            }
            
            return pm;

        }

    }
}
