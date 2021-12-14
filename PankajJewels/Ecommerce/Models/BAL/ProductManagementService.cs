using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Ecommerce.Models.Utilities;

namespace Ecommerce.Models.BAL
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly MyDbContext context;
        private readonly ILogApplicationErrorService _logService;
        public ProductManagementService(MyDbContext _context, ILogApplicationErrorService lService)
        {
            context = _context;
            _logService = lService;
        }
        public ProcessResponse SaveProductMaster(ProductMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if(request.ProductId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.productMasterEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.ProductId;
                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch(Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveProductDetail(ProductDetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.ProductDetailId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.productDetailsEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.ProductDetailId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveDaimondsMain(DaimondsPerProductEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.DPPId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.daimondsPerProductEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.DPPId;
                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveDaimondsDetails(DaimondsPerPrdDetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.DPPDId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.daimondsPerPrdDetailsEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.DPPDId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SavePerlMain(PerlPerProductEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.PPPId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.perlPerProductEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.PPPId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SavePerlDeail(PerlPerPrdDetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.PPPDId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.perlPerPrdDetailsEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.PPPDId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveSolitaireMain(SolitairePerProductEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.SPPId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.solitairePerProductEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.SPPId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveSolitaireDetails(SolitairePerPrdDetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.SPPDId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.solitairePerPrdDetailsEntities.Add(request);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveSRubyMain(SRubyPerProductEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.SRPPId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.sRubyPerProductEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.SRPPId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveSRubyDetails(SRubyPerPrdDetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.SRPPDId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.sRubyPerPrdDetailsEntities.Add(request);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveProductMainImage(ProductImagesEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.PrImageId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.productImagesEntities.Add(request);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public ProcessResponse SaveDetailImages(ProductDetailImagesEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.PrDetailImageId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.productDetailImagesEntities.Add(request);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }
        public PostProductModel GetProductDetails(int productId)
        {
            PostProductModel response = new PostProductModel();
            try
            {
                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            join disc in context.discountMasterEntities on prd.DiscountApplicableId equals disc.DMasterId
                            where prd.ProductId == productId
                            select new PostProductModel
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMaster_IdName = disc.DicountTitile,
                                DiscountAmount = disc.DiscountAmount,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductDetails = null,
                                ProductMainImages = null,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a=>a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b=>b.ImageUrl).FirstOrDefault()
                                
                            }).FirstOrDefault();
                if(response != null)
                {
                    List<ProductDetailsModel> details = new List<ProductDetailsModel>();
                    details = (from pd in context.productDetailsEntities
                               join hMe in context.measurementMasterEntities on pd.HeightMeasurementId equals hMe.MeasurementId
                               join mwMe in context.measurementMasterEntities on pd.HeightMeasurementId equals mwMe.MeasurementId
                               join pwMe in context.measurementMasterEntities on pd.HeightMeasurementId equals pwMe.MeasurementId
                               join wMe in context.measurementMasterEntities on pd.HeightMeasurementId equals wMe.MeasurementId
                               join metm in context.metalMasterEntities on pd.MetalMasterId equals metm.MasterId
                               join siz in context.sizeMasterEntities on pd.SizeMasterId equals siz.SizeMasterId
                               where pd.ProductId == response.ProductId && pd.IsDeleted == false
                               select new ProductDetailsModel
                               {
                                   ActualPrice = pd.ActualPrice,
                                   IsDeleted = pd.IsDeleted,
                                   ProductId = pd.ProductId,
                                   DaimondsDetail = null,
                                   DaimondsMain = context.daimondsPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   Height = pd.Height,
                                   ProductDetailId = pd.ProductDetailId,
                                   HeightMeasurementId = pd.HeightMeasurementId,
                                   HeightMeasurementId_name = hMe.MeasurementName,
                                   IsActive = pd.IsActive,
                                   MetailWeightMesuremetnId = pd.MetailWeightMesuremetnId,
                                   MetailWeightMesuremetnId_Name = mwMe.MeasurementName,
                                   MetalMasterId = pd.MetalMasterId,
                                   MetalMasterId_Name = metm.MetalCode,
                                   MetalWeight = pd.MetalWeight,
                                   PerlDetails = null,
                                   PerlMain = context.perlPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   ProductCode = pd.ProductCode,
                                   ProductDetailImages_List = context.productDetailImagesEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).Select(b => b.ImageUrl).FirstOrDefault(),
                                   ProductWeight = pd.ProductWeight,
                                   ProductWeightMeasurement = pd.ProductWeightMeasurement,
                                   ProductWeightMeasurement_Name = pwMe.MeasurementName,
                                   SellingPrice = pd.SellingPrice,
                                   ProductDetailImages = null,
                                   SizeMasterId = pd.SizeMasterId,
                                   SizeMasterId_name = siz.SizeName,
                                   SolitaireDetails = null,
                                   SolitaireMain = context.solitairePerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   SRubyDetails = null,
                                   SRubyMain = context.sRubyPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   SubTitleText = pd.SubTitleText,
                                   WeightMeasurementId = pd.WeightMeasurementId,
                                   WeightMeasurementId_Name = wMe.MeasurementName,
                                   Width = pd.Width,
                                   MakingCharges = pd.MakingCharges
                               }).ToList();
                    if(details.Count > 0)
                    {
                        for(int i=0;i < details.Count; i ++)
                        {
                            if(details[i].DaimondsMain != null)
                            {
                                int cId = details[i].DaimondsMain.DPPId;
                                details[i].DaimondsDetail = context.daimondsPerPrdDetailsEntities.Where(a => a.DPPId == cId).ToList();
                            }
                            else
                            {
                                details[i].DaimondsDetail = new List<DaimondsPerPrdDetailsEntity>();
                            }
                            if (details[i].SolitaireMain != null)
                            {
                                int cId = details[i].SolitaireMain.SPPId;
                                details[i].SolitaireDetails = context.solitairePerPrdDetailsEntities.Where(a => a.SPPId== cId).ToList();
                            }
                            else
                            {
                                details[i].SolitaireDetails = new List<SolitairePerPrdDetailsEntity>();
                            }
                            if (details[i].PerlMain != null)
                            {
                                int cId = details[i].PerlMain.PPPId;
                                details[i].PerlDetails = context.perlPerPrdDetailsEntities.Where(a => a.PPPId== cId).ToList();
                            }
                            else
                            {
                                details[i].PerlDetails = new List<PerlPerPrdDetailsEntity>();
                            }
                            if (details[i].SRubyMain!= null)
                            {
                                int cId = details[i].SRubyMain.SRPPId;
                                details[i].SRubyDetails = context.sRubyPerPrdDetailsEntities.Where(a => a.SRPPId== cId).ToList();
                            }
                            else
                            {
                                details[i].SRubyDetails = new List<SRubyPerPrdDetailsEntity>();
                            }
                        }
                    }
                    response.ProductDetails = details;

                }
            }
            catch(Exception ex)
            {
                _logService.LogError(ex);
            }

            return response;
        }

        public APIPostProductModel APIGetProductDetails(int productId,int userid)
        {
            APIPostProductModel response = new APIPostProductModel();
            try
            {
                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            join disc in context.discountMasterEntities on prd.DiscountApplicableId equals disc.DMasterId
                            where prd.ProductId == productId
                            select new APIPostProductModel
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMaster_IdName = disc.DicountTitile,
                                DiscountAmount = disc.DiscountAmount,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductDetails = null,
                                ProductMainImages = null,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).ToList(),
                                Stock=prd.Stock

                            }).FirstOrDefault();
                if (response != null)
                {
                    List<APIProductDetailsModel> details = new List<APIProductDetailsModel>();
                    details = (from pd in context.productDetailsEntities
                               join hMe in context.measurementMasterEntities on pd.HeightMeasurementId equals hMe.MeasurementId
                               join mwMe in context.measurementMasterEntities on pd.HeightMeasurementId equals mwMe.MeasurementId
                               join pwMe in context.measurementMasterEntities on pd.WeightMeasurementId equals pwMe.MeasurementId
                               join wMe in context.measurementMasterEntities on pd.HeightMeasurementId equals wMe.MeasurementId
                               join metm in context.metalMasterEntities on pd.MetalMasterId equals metm.MasterId
                               join siz in context.sizeMasterEntities on pd.SizeMasterId equals siz.SizeMasterId
                               where pd.ProductId == response.ProductId && pd.IsDeleted == false
                               select new APIProductDetailsModel
                               {
                                   ActualPrice = pd.ActualPrice,
                                   IsDeleted = pd.IsDeleted,
                                   ProductId = pd.ProductId,
                                   DaimondsDetail = null,
                                   DaimondsMain = context.daimondsPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   Height = pd.Height.GetValueOrDefault(),
                                   ProductDetailId = pd.ProductDetailId,
                                   HeightMeasurementId = pd.HeightMeasurementId,
                                   HeightMeasurementId_name = hMe.MeasurementName,
                                   IsActive = pd.IsActive,
                                   MetailWeightMesuremetnId = pd.MetailWeightMesuremetnId,
                                   MetailWeightMesuremetnId_Name = mwMe.MeasurementName,
                                   MetalMasterId = pd.MetalMasterId,
                                   MetalMasterId_Name = metm.MetalCode,
                                   MetalWeight = pd.MetalWeight,
                                   PerlDetails = null,
                                   PerlMain = context.perlPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   ProductCode = pd.ProductCode,
                                   ProductDetailImages_List = context.productDetailImagesEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).Select(b => b.ImageUrl).ToList(),
                                   ProductWeight = pd.ProductWeight,
                                   ProductWeightMeasurement = pd.ProductWeightMeasurement,
                                   ProductWeightMeasurement_Name = pwMe.MeasurementName,
                                   SellingPrice = pd.SellingPrice,
                                   ProductDetailImages = null,
                                   SizeMasterEntity = context.sizeMasterEntities.Where(x=>x.SubCategoryId== response.SubCategoryId).ToList(),
                                   SolitaireDetails = null,
                                   SolitaireMain = context.solitairePerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   SRubyDetails = null,
                                   SRubyMain = context.sRubyPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   SubTitleText = pd.SubTitleText,
                                   WeightMeasurementId = pd.WeightMeasurementId,
                                   WeightMeasurementId_Name = wMe.MeasurementName,
                                   Width = pd.Width.GetValueOrDefault(),
                                   MakingCharges = pd.MakingCharges
                               }).ToList();
                    if (details.Count > 0)
                    {
                        for (int i = 0; i < details.Count; i++)
                        {
                            if (details[i].DaimondsMain != null)
                            {
                                int cId = details[i].DaimondsMain.DPPId;
                                
                               // details[i].DaimondsDetail = context.daimondsPerPrdDetailsEntities.Where(a => a.DPPId == cId).ToList();

                                details[i].DaimondsDetail = (from b in context.daimondsPerPrdDetailsEntities
                                                             join c in context.daimondClarityMasterEntities on b.ClarityId equals c.ClarityId
                                                             join col in context.daimondColorMasterEntities on b.ColorId equals col.ColorId
                                                             join set in context.daimondSettingMasterEntities on b.SettingTypeId equals set.MasterId
                                                             join sh in context.daimondShapeMasterEntities on b.ShapeId equals sh.MasterId
                                                             join dt in context.daimondTypeMasterEntities on b.DaimondTypeId equals dt.MasterId
                                                             where b.IsDeleted == false && b.DPPId == cId
                                                             select new DaimondsPerPrdDetailsEntity_Web
                                                             {
                                                                 ClarityId = b.ClarityId,
                                                                 ClarityId_Name = c.ClarityName,
                                                                 ColorId = b.ColorId,
                                                                 ColorId_Name = col.ColorName,
                                                                 DaimondTypeId = b.DaimondTypeId,
                                                                 DPPDId = b.DPPDId,
                                                                 DPPId = b.DPPId,
                                                                 IsDeleted = b.IsDeleted,
                                                                 NoofDaimonds = b.NoofDaimonds,
                                                                 SettingTypeId = b.SettingTypeId,
                                                                 SettingTypeId_Name = set.SettingName,
                                                                 ShapeId = b.ShapeId,
                                                                 ShapeId_Name = sh.ShapeName,
                                                                 TotalWaight = b.TotalWaight,
                                                                 DaimondTypeId_Name = dt.TypeName
                                                             }).ToList();
                            }
                            else
                            {
                                details[i].DaimondsDetail = new List<DaimondsPerPrdDetailsEntity_Web>();
                            }
                            if (details[i].SolitaireMain != null)
                            {
                                int cId = details[i].SolitaireMain.SPPId;
                              //  details[i].SolitaireDetails = context.solitairePerPrdDetailsEntities.Where(a => a.SPPId == cId).ToList();
                                details[i].SolitaireDetails = (from s in context.solitairePerPrdDetailsEntities
                                                               join c in context.certificateMasterEntities on s.CertificationId equals c.MasterId
                                                               join sh in context.daimondShapeMasterEntities on s.ShapeId equals sh.MasterId
                                                               join f in context.fluorescenceMasterEntities on s.FluorescenceId equals f.MasterId
                                                               join sy in context.symmetryMasterEntities on s.Symmetry equals sy.MasterId
                                                               join cl in context.daimondClarityMasterEntities on s.ClarityId equals cl.ClarityId
                                                               join col in context.daimondColorMasterEntities on s.ColorId equals col.ColorId
                                                               where s.IsDeleted == false && s.SPPId == cId
                                                               select new SolitairePerPrdDetailsEntity_Web
                                                               {
                                                                   IsDeleted = s.IsDeleted,
                                                                   CertificationId = s.CertificationId,
                                                                   CertificationId_Name = c.CertifycateName,
                                                                   ClarityId = s.ClarityId,
                                                                   ClarityId_Nme = cl.ClarityName,
                                                                   ColorId = s.ColorId,
                                                                   ColorId_Name = col.ColorName,
                                                                   FluorescenceId = s.FluorescenceId,
                                                                   FluorescenceId_Name = f.FluorescenceName,
                                                                   NoofSolitaire = s.NoofSolitaire,
                                                                   ShapeId = s.ShapeId,
                                                                   ShapeId_Name = sh.ShapeName,
                                                                   SPPDId = s.SPPDId,
                                                                   SPPId = s.SPPId,
                                                                   Symmetry = s.Symmetry,
                                                                   Symmetry_Name = sy.SymmetryName,
                                                                   TotalWaight = s.TotalWaight

                                                               }).ToList();
                            }
                            else
                            {
                                details[i].SolitaireDetails = new List<SolitairePerPrdDetailsEntity_Web>();
                            }
                            if (details[i].PerlMain != null)
                            {
                                int cId = details[i].PerlMain.PPPId;
                               // details[i].PerlDetails = context.perlPerPrdDetailsEntities.Where(a => a.PPPId == cId).ToList();
                                details[i].PerlDetails = (from p in context.perlPerPrdDetailsEntities
                                                          join s in context.daimondSettingMasterEntities on p.SettingId equals s.MasterId
                                                          join sh in context.daimondShapeMasterEntities on p.ShapeId equals sh.MasterId
                                                          where p.IsDeleted == false && p.PPPId == cId
                                                          select new PerlPerPrdDetailsEntity_Web
                                                          {
                                                              PPPId = p.PPPId,
                                                              IsDeleted = p.IsDeleted,
                                                              NoofStones = p.NoofStones,
                                                              PPPDId = p.PPPDId,
                                                              SettingId = p.SettingId,
                                                              SettingId_Name = s.SettingName,
                                                              ShapeId = p.ShapeId,
                                                              ShapeId_Name = sh.ShapeName,
                                                              Size = p.Size
                                                          }).ToList();

                            }
                            else
                            {
                                details[i].PerlDetails = new List<PerlPerPrdDetailsEntity_Web>();
                            }
                            if (details[i].SRubyMain != null)
                            {
                                int cId = details[i].SRubyMain.SRPPId;
                              //  details[i].SRubyDetails = context.sRubyPerPrdDetailsEntities.Where(a => a.SRPPId == cId).ToList();

                                details[i].SRubyDetails = (from s in context.sRubyPerPrdDetailsEntities
                                                           join set in context.daimondSettingMasterEntities on s.SettingId equals set.MasterId
                                                           join sh in context.daimondShapeMasterEntities on s.ShapeId equals sh.MasterId
                                                           where s.IsDeleted == false && s.SRPPId == cId
                                                           select new SRubyPerPrdDetailsEntity_Web
                                                           {
                                                               SRPPId = s.SRPPId,
                                                               IsDeleted = s.IsDeleted,
                                                               NoofStones = s.NoofStones,
                                                               SettingId = s.SettingId,
                                                               SettingId_Name = set.SettingName,
                                                               ShapeId = s.ShapeId,
                                                               ShapeId_Name = sh.ShapeName,
                                                               Size = s.Size,
                                                               SRPPDId = s.SRPPDId
                                                           }).ToList();
                            }
                            else
                            {
                                details[i].SRubyDetails = new List<SRubyPerPrdDetailsEntity_Web>();
                            }
                        }
                    }
                    if (response.ProductDetails != null)
                    {
                         
                    }
                    response.ProductDetails = details;

                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }

            return response;
        }

        public int isInWishList(int productid , int userid) {
            try
            {
                var wl = context.wishListEntities.Where(x => x.ProductId == productid && x.UserId == userid && x.IsDeleted==false).FirstOrDefault();
                if (wl!=null)
                {
                    return 1;
                }
            }
            catch (Exception)
            {

                return 0;
            }
            return 0;
        }

        public List<UserReviewMaster> GetProductReviews(int productId, int userid) 
        {

            var response = context.UserReviewMasters.Where(x => x.UserId == userid && x.ProductId == productId).ToList();
            return response;
        }
        public PostProductModel_Web GetProductDetails_Web(int productId, int pdid=0)
        {
            PostProductModel_Web response = new PostProductModel_Web();
            try
            {
                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            join disc in context.discountMasterEntities on prd.DiscountApplicableId equals disc.DMasterId
                            where prd.ProductId == productId
                            select new PostProductModel_Web
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMaster_IdName = disc.DicountTitile,
                                DiscountAmount = disc.DiscountAmount,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductDetails = null,
                                ProductMainImages = null,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                Tags = prd.Tags,
                                PrefferedGender = prd.PrefferedGender,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                DiamondRate = context.daimondTypeMasterEntities.Where(a => a.IsDeleted == false).ToList(),
                                GoldRate = context.goldRateMasterEntities.Where(a => a.IsDeleted == false).FirstOrDefault(),
                                MetalMaster = context.metalMasterEntities.Where(a => a.IsDeleted == false).ToList(),
                                discountMaster = context.discountMasterEntities.Where(a => a.IsDeleted == false).ToList(),
                                GST = context.gSTMasterEntities.Where(a => a.IsDeleted == false).ToList()
                            }).FirstOrDefault();
                if (response != null)
                {
                    List<ProductDetailsModel_Web> details = new List<ProductDetailsModel_Web>();
                    details = (from pd in context.productDetailsEntities
                               join hMe in context.measurementMasterEntities on pd.HeightMeasurementId equals hMe.MeasurementId
                               join mwMe in context.measurementMasterEntities on pd.HeightMeasurementId equals mwMe.MeasurementId
                               join pwMe in context.measurementMasterEntities on pd.HeightMeasurementId equals pwMe.MeasurementId
                               join wMe in context.measurementMasterEntities on pd.HeightMeasurementId equals wMe.MeasurementId
                               join metm in context.metalMasterEntities on pd.MetalMasterId equals metm.MasterId
                               
                               join siz in context.sizeMasterEntities on pd.SizeMasterId equals siz.SizeMasterId
                               where pd.ProductId == response.ProductId && pd.IsDeleted == false
                               select new ProductDetailsModel_Web
                               {
                                   ActualPrice = pd.ActualPrice,
                                   IsDeleted = pd.IsDeleted,
                                   ProductId = pd.ProductId,
                                   DaimondsDetail = null,
                                   DaimondsMain = context.daimondsPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   Height = pd.Height,
                                   ProductDetailId = pd.ProductDetailId,
                                   HeightMeasurementId = pd.HeightMeasurementId,
                                   HeightMeasurementId_name = hMe.MeasurementName,
                                   IsActive = pd.IsActive,
                                   MetailWeightMesuremetnId = pd.MetailWeightMesuremetnId,
                                   MetailWeightMesuremetnId_Name = mwMe.MeasurementName,
                                   MetalMasterId = pd.MetalMasterId,
                                   MetalMasterId_Name = metm.MetalCode,
                                   MetalWeight = pd.MetalWeight,
                                   PerlDetails = null,
                                   PerlMain = context.perlPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   ProductCode = pd.ProductCode,
                                   ProductDetailImages_List = context.productDetailImagesEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).Select(b => b.ImageUrl).ToList(),
                                   ProductWeight = pd.ProductWeight,
                                   ProductWeightMeasurement = pd.ProductWeightMeasurement,
                                   ProductWeightMeasurement_Name = pwMe.MeasurementName,
                                   SellingPrice = pd.SellingPrice,
                                   ProductDetailImages = null,
                                   SizeMasterId = pd.SizeMasterId,
                                   SizeMasterId_name = siz.SizeName,
                                   SolitaireDetails = null,
                                   SolitaireMain = context.solitairePerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   SRubyDetails = null,
                                   SRubyMain = context.sRubyPerProductEntities.Where(a => a.ProductDetailId == pd.ProductDetailId).FirstOrDefault(),
                                   SubTitleText = pd.SubTitleText,
                                   WeightMeasurementId = pd.WeightMeasurementId,
                                   WeightMeasurementId_Name = wMe.MeasurementName,
                                   Width = pd.Width,
                                   MakingCharges = pd.MakingCharges
                               }).ToList();
                    if (details.Count > 0)
                    {
                        for (int i = 0; i < details.Count; i++)
                        {
                            if (details[i].DaimondsMain != null)
                            {
                                int cId = details[i].DaimondsMain.DPPId;
                                details[i].DaimondsDetail = (from b in context.daimondsPerPrdDetailsEntities
                                                             join c in context.daimondClarityMasterEntities on b.ClarityId equals c.ClarityId
                                                             join col in context.daimondColorMasterEntities on b.ColorId equals col.ColorId
                                                             join set in context.daimondSettingMasterEntities on b.SettingTypeId equals set.MasterId
                                                             join sh in context.daimondShapeMasterEntities on b.ShapeId equals sh.MasterId
                                                             join dt in context.daimondTypeMasterEntities on b.DaimondTypeId equals dt.MasterId
                                                             where b.IsDeleted == false && b.DPPId == cId
                                                             select new DaimondsPerPrdDetailsEntity_Web
                                    {
                                        ClarityId = b.ClarityId,
                                        ClarityId_Name = c.ClarityName,
                                        ColorId = b.ColorId,
                                        ColorId_Name = col.ColorName,
                                        DaimondTypeId = b.DaimondTypeId,
                                        DPPDId = b.DPPDId,
                                        DPPId = b.DPPId,
                                        IsDeleted = b.IsDeleted,
                                        NoofDaimonds = b.NoofDaimonds,
                                        SettingTypeId = b.SettingTypeId,
                                        SettingTypeId_Name = set.SettingName    ,
                                        ShapeId = b.ShapeId,
                                        ShapeId_Name = sh.ShapeName,
                                        TotalWaight = b.TotalWaight,
                                         DaimondTypeId_Name= dt.TypeName
                                    }).ToList();
                            }
                            if (details[i].SolitaireMain != null)
                            {
                                int cId = details[i].SolitaireMain.SPPId;
                                details[i].SolitaireDetails = (from s in context.solitairePerPrdDetailsEntities
                                                               join c in context.certificateMasterEntities on s.CertificationId equals c.MasterId
                                                               join sh in context.daimondShapeMasterEntities on s.ShapeId equals sh.MasterId
                                                               join f in context.fluorescenceMasterEntities on s.FluorescenceId equals f.MasterId
                                                               join sy in context.symmetryMasterEntities on s.Symmetry equals sy.MasterId
                                                               join cl in context.daimondClarityMasterEntities on s.ClarityId equals cl.ClarityId
                                                               join col in context.daimondColorMasterEntities on s.ColorId equals col.ColorId
                                                               where s.IsDeleted == false && s.SPPId == cId
                                                               select new SolitairePerPrdDetailsEntity_Web
                                                               {
                                                                   IsDeleted = s.IsDeleted,
                                                                   CertificationId = s.CertificationId,
                                                                   CertificationId_Name = c.CertifycateName,
                                                                   ClarityId = s.ClarityId,
                                                                   ClarityId_Nme = cl.ClarityName,
                                                                   ColorId = s.ColorId,
                                                                   ColorId_Name = col.ColorName,
                                                                   FluorescenceId = s.FluorescenceId,
                                                                   FluorescenceId_Name = f.FluorescenceName,
                                                                   NoofSolitaire = s.NoofSolitaire,
                                                                   ShapeId = s.ShapeId,
                                                                   ShapeId_Name = sh.ShapeName,
                                                                   SPPDId = s.SPPDId,
                                                                   SPPId = s.SPPId,
                                                                   Symmetry = s.Symmetry,
                                                                   Symmetry_Name = sy.SymmetryName,
                                                                   TotalWaight = s.TotalWaight

                                                               }).ToList();
                            }
                            if (details[i].PerlMain != null)
                            {
                                int cId = details[i].PerlMain.PPPId;
                                details[i].PerlDetails = (from p in context.perlPerPrdDetailsEntities
                                                          join s in context.daimondSettingMasterEntities on p.SettingId equals s.MasterId
                                                          join sh in context.daimondShapeMasterEntities on p.ShapeId equals sh.MasterId
                                                          where p.IsDeleted == false && p.PPPId == cId
                                                          select new PerlPerPrdDetailsEntity_Web
                                                          {
                                                              PPPId = p.PPPId,
                                                              IsDeleted = p.IsDeleted,
                                                              NoofStones = p.NoofStones,
                                                              PPPDId = p.PPPDId,
                                                              SettingId = p.SettingId,
                                                              SettingId_Name = s.SettingName,
                                                              ShapeId = p.ShapeId,
                                                              ShapeId_Name = sh.ShapeName,
                                                              Size = p.Size
                                                          }).ToList();
                            }
                            if (details[i].SRubyMain != null)
                            {
                                int cId = details[i].SRubyMain.SRPPId;
                                details[i].SRubyDetails = (from s in context.sRubyPerPrdDetailsEntities
                                                           join set in context.daimondSettingMasterEntities on s.SettingId equals set.MasterId
                                                           join sh in context.daimondShapeMasterEntities on s.ShapeId equals sh.MasterId
                                                           where s.IsDeleted == false && s.SRPPId == cId
                                                           select new SRubyPerPrdDetailsEntity_Web
                                                           {
                                                               SRPPId = s.SRPPId,
                                                               IsDeleted = s.IsDeleted,
                                                               NoofStones = s.NoofStones,
                                                               SettingId = s.SettingId,
                                                               SettingId_Name = set.SettingName,
                                                               ShapeId = s.ShapeId,
                                                               ShapeId_Name = sh.ShapeName,
                                                               Size = s.Size,
                                                               SRPPDId = s.SRPPDId
                                                           }).ToList();
                            }
                        }
                    }
                    response.ProductDetails = details;

                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }

            return response;
        }
        public List<ProductListDisplay> GetMyProducts(int postedBy)
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {
                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false  
                            select new ProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault()
                            }).ToList();
            }
            catch(Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }

        public List<ProductDetailsDisplay> GetSubProducts(int pid)
        {
            List<ProductDetailsDisplay> response = new List<ProductDetailsDisplay>();
            try
            {
                response = (from prd in context.productDetailsEntities
                            join s in context.sizeMasterEntities on prd.SizeMasterId equals s.SizeMasterId
                            where prd.IsDeleted == false && prd.ProductId == pid
                            select new ProductDetailsDisplay
                            {

                                ProductImages_List = context.productDetailImagesEntities.Where(a => a.IsDeleted == false && a.ProductDetailId == prd.ProductDetailId).Select(b => b.ImageUrl).ToList(),
                                ProductDetailId = prd.ProductDetailId,
                                ProductId = prd.ProductId,
                                SizeMasterId = prd.SizeMasterId,
                                ActualPrice = prd.ActualPrice,
                                Height = prd.Height,
                                HeightMeasurementId = prd.HeightMeasurementId,
                                IsActive = prd.IsActive, IsDeleted = prd.IsDeleted,
                                MetailWeightMesuremetnId = prd.MetailWeightMesuremetnId,
                                MetalMasterId = prd.MetalMasterId,
                                MetalWeight = prd.MetalWeight,
                                ProductCode = prd.ProductCode,
                                ProductWeight = prd.ProductWeight,
                                ProductWeightMeasurement = prd.ProductWeightMeasurement,
                                SellingPrice = prd.SellingPrice,
                                SizeMasterId_Name = s.SizeName,
                                SubTitleText = prd.SubTitleText, WeightMeasurementId=prd.WeightMeasurementId,
                                 Width= prd.Width 
                            })
                            .ToList();
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public GoldRateMasterEntity GetGoldRate()
        {
            GoldRateMasterEntity response = new GoldRateMasterEntity();
            response = context.goldRateMasterEntities.FirstOrDefault();
            return response;
        }
        public ProcessResponse UpdateGoldRate(GoldRateMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                GoldRateMasterEntity r = new GoldRateMasterEntity();
                if(request.MasterId > 0)
                {
                    r = context.goldRateMasterEntities.Where(a=>a.MasterId == request.MasterId).FirstOrDefault();
                    r.Rate = request.Rate;
                    r.DateOfLastUpdate = DateTime.Now;
                    r.IsDeleted = false;
                    context.Entry(r).CurrentValues.SetValues(r);
                    context.SaveChanges();
                }
                else
                {
                    r.DateOfLastUpdate = DateTime.Now;
                    r.IsDeleted = false;
                    context.goldRateMasterEntities.Add(r);
                    context.SaveChanges();
                }
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch(Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }
        public List<ProductListDisplay> SearchProducts(int catId, int scatId, int detCatId, string search="", int pageNumber = 1, int pageSize = 10)
        {
            int skipSize = pageNumber == 1 ? 0 : (pageNumber - 1) * pageSize;
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {
                if(catId > 0)
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.CategoryId == catId
                                select new ProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn)
                                 .Skip(skipSize).Take(pageSize).
                                ToList();
                }
                if(scatId > 0)
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.SubCategoryId == scatId
                                select new ProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault()
                                }).OrderByDescending(b=>b.PostedOn)
                                .Skip(skipSize).Take(pageSize).
                                ToList();
                }
                if (detCatId > 0)
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.DetailCategoryId == detCatId
                                select new ProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn)
                                .Skip(skipSize).Take(pageSize).
                                ToList();
                }

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }

        public List<APIProductListDisplay> APIGetLatestProducts(string src = "0")
        {
            List<APIProductListDisplay> response = new List<APIProductListDisplay>();
            try
            {
                if (src == "0")
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false
                                select new APIProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();
                }
                else if (src == "AG")
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.IsAllGold == "Yes"
                                select new APIProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();
                }
                else if (src == "HT")
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.IsHotDeal == "Yes"
                                select new APIProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();
                }




            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public List<ProductListDisplay> GetLatestProducts(string src="0")
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {
                if(src=="0")
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false
                                select new ProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();
                }
                else if(src=="AG")
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.IsAllGold == "Yes"
                                select new ProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();
                }
                else if (src == "HT")
                {
                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.IsHotDeal == "Yes"
                                select new ProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();
                }




            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }


        public List<APIProductListDisplay> APISearchGetProductsByCatId(int userid, string url,int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "")
        {
            List<APIProductListDisplay> response = new List<APIProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false && prd.CategoryId == cid
                            select new APIProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = url+context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                IsInWishList = userid != 0 ? context.wishListEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false && a.UserId == userid).FirstOrDefault() != null ? 1 : 0 : 0,
                                Stock = prd.Stock
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public List<ProductListDisplay> GetProductsByCatId(int cid=0, int pageNumber = 1, int pageSize = 10, string search="")
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false && prd.CategoryId == cid
                            select new ProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }

        public List<APIProductListDisplay> APIGetProductsBySearch(int userid, string url,int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "")
        {
            List<APIProductListDisplay> response = new List<APIProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false && prd.ProductTitle.Contains(search)
                            select new APIProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                IsInWishList = userid != 0 ? context.wishListEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false && a.UserId == userid).FirstOrDefault() != null ? 1 : 0 : 0,
                                Stock = prd.Stock
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }

        public List<ProductListDisplay> GetProductsBySearch(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "")
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false && prd.ProductTitle.Contains(search)
                            select new ProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault()    ,
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }

        public List<ProductListDisplay> GetProductsByFilter(string query)
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {
                System.FormattableString m = $"EXEC {query}";
                response = context.Set<ProductListDisplay>().FromSqlRaw(query).ToList();

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public int GetProductsByFilter_count(string query)
        {
            int total = 0;
            try
            {
                SingleQueryCountModel resp = new SingleQueryCountModel();
                System.FormattableString m = $"EXEC {query}";
                resp = context.Set<SingleQueryCountModel>().FromSqlInterpolated(m).FirstOrDefault();
                total = resp.cnt;

            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return total;
        }
        //public ICollection<T> ExecuteQueryWParams(string sqlQuery, object[] parameters)
        //{

        //    ICollection<T> result = _context.Set<T>().FromSqlRaw(sqlQuery, parameters).ToList();
        //    return result;
        //}
        public int GetProductsBySearch_count(int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "")
        {
            int count = 0;
            try
            {

                count = (from prd in context.productMasterEntities
                         join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                         join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                         join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                         where prd.IsDeleted == false && prd.ProductTitle.Contains(serach)
                         select new
                         {
                             CategoryId = prd.CategoryId,

                         }).Count();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return count;
        }

        public List<ProductListDisplay> GetProductsByDetId(int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "")
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false && prd.DetailCategoryId == did
                            select new ProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public List<APIProductListDisplay> APIGetProductsByDetId(int userid, string url,int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "")
        {
            List<APIProductListDisplay> response = new List<APIProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false && prd.DetailCategoryId == did
                            select new APIProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                IsInWishList = userid != 0 ? context.wishListEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false && a.UserId == userid).FirstOrDefault() != null ? 1 : 0 : 0,
                                Stock = prd.Stock
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }

         

        public int GetProductsByDetId_Count(int did = 0, int pageNumber = 1, int pageSize = 10, string serach = "")
        {
            int count = 0;
            try
            {

                count = (from prd in context.productMasterEntities
                         join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                         join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                         join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                         where prd.IsDeleted == false && prd.DetailCategoryId == did
                         select new
                         {
                             CategoryId = prd.CategoryId,

                         }).Count();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return count;
        }
        public int GetProductsByCatId_Count(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "")
        {
            int count = 0;
            try
            {

                count = (from prd in context.productMasterEntities
                         join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                         join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                         join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                         where prd.IsDeleted == false && prd.CategoryId == cid
                         select new
                         {
                             CategoryId = prd.CategoryId,

                         }).Count();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return count;
        }

        public decimal GetGoldTodayRate()
        {
            return (decimal)context.goldRateMasterEntities.Select(a => a.Rate).FirstOrDefault();
        }
        public decimal GetGSTRate()
        {
            return (decimal)context.gSTMasterEntities.Select(a => a.GSTTaxValue).FirstOrDefault();
        }
        public decimal GetMetalTypeRate(int metalId)
        {
            return (decimal) context.metalMasterEntities.Where(a => a.MasterId == metalId).Select(b => b.PriceCalPercentage).FirstOrDefault();
        }
        public  decimal GetDaimondRate(int typeid)
        {
            return (decimal)context.daimondTypeMasterEntities.Where(a => a.MasterId == typeid).Select(b => b.PriceTag).FirstOrDefault();
        }
        public List<ProductImagesEntity> GetMainImages(int id)
        {
            return context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == id).ToList();
        }
        public void DeleteMainImage(int imageid)
        {
            var mi = context.productImagesEntities.Where(a => a.PrImageId == imageid).FirstOrDefault();
            mi.IsDeleted = true;
            context.Entry(mi).CurrentValues.SetValues(mi);
            context.SaveChanges();
        }
        public List<ProductDetailImagesEntity> GetDetialImages(int id)
        {
            return context.productDetailImagesEntities.Where(a => a.IsDeleted == false && a.ProductDetailId== id).ToList();
        }
        public void DeleteDetailImage(int imageid)
        {
            var mi = context.productDetailImagesEntities.Where(a => a.PrDetailImageId == imageid).FirstOrDefault();
            mi.IsDeleted = true;
            context.Entry(mi).CurrentValues.SetValues(mi);
            context.SaveChanges();
        }

        public void UpdateProductPrice(ProductDetailsEntity request)
        {
            context.Entry(request).CurrentValues.SetValues(request);
            context.SaveChanges();
        }
        public ProductDetailsEntity GetProductDetailById(int id)
        {
            return context.productDetailsEntities.Where(a => a.ProductDetailId == id).FirstOrDefault();
        }
        public ProductMasterEntity GetProductMasterByid(int id)
        {
            return context.productMasterEntities.Where(a => a.ProductId== id).FirstOrDefault();
        }
        public decimal GetDisocuntRate(int id)
        {
            return (decimal) context.discountMasterEntities.Where(a => a.DMasterId == id).Select(b=>b.DiscountAmount).FirstOrDefault();
        }

        public PriceBreakUpModel CalculatePrice(int prid, int pdid=0)
        {


            //calculate price 
            PostProductModel_Web product = GetProductDetails_Web(prid);
            PriceBreakUpModel pm = new PriceBreakUpModel();
            if (product.ProductDetails.Count > 0)
            {
                if(pdid > 0)
                {
                   product.ProductDetails= product.ProductDetails.Where(a => a.ProductDetailId == pdid).ToList();
                }
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
                pm.MakingCharges = (decimal)product.ProductDetails[0].MakingCharges;
                pm.discount = (decimal)product.DiscountAmount * pm.MakingCharges / 100;
                pm.totalAmount = (daimondRate + goldRate + pm.MakingCharges + pm.GST) - pm.discount;
                pm.oldAmount = daimondRate + goldRate + pm.GST + pm.MakingCharges;
                product.priceBreakup = pm;

            }

            return pm;

        }

        public List<POFollowUpEntity> GetPOFollowups(int poid)
        {
           return context.pOFollowUpEntities.Where(a => a.IsDeleted == false && a.POId == poid).OrderBy(b=>b.FollowUpOn).
                ToList();
        }
        public ProcessResponse SaveFollowUp(POFollowUpEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.FollowUpId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.pOFollowUpEntities.Add(request);
                    context.SaveChanges();
                }
                response.currentId = request.FollowUpId;
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                response.statusCode = 0;
                response.statusMessage = "Failed to Update ";
            }
            return response;
        }

        public POFollowUpEntity GetPOFollowUpById(int id)
        {
            return context.pOFollowUpEntities.Where(a => a.FollowUpId == id).FirstOrDefault();
        }

        public List<SolPerPrdDisplayModel> GetSolPerList(int detailid)
        {
            List<SolPerPrdDisplayModel> myList = new List<SolPerPrdDisplayModel>();
            SqlParameter[] sParams =
           {
                new SqlParameter("detailId",detailid)
            };
            string sp = StoredProcedures.GetSolitairePerPrd + " @detailId";
            myList = context.Set<SolPerPrdDisplayModel>().FromSqlRaw(sp, sParams).ToList();
            return myList;
        }
        public List<PerlPerPrdDisplayModel> GetPerlPerList(int detailid)
        {
            List<PerlPerPrdDisplayModel> myList = new List<PerlPerPrdDisplayModel>();
            SqlParameter[] sParams =
           {
                new SqlParameter("detailId",detailid)
            };
            string sp = StoredProcedures.GetPerlPerProduct + " @detailId";
            myList = context.Set<PerlPerPrdDisplayModel>().FromSqlRaw(sp, sParams).ToList();
            return myList;
        }
        public List<DaimondsPerPrdDisplayModel> GetDaimondPerList(int detailid)
        {
            List<DaimondsPerPrdDisplayModel> myList = new List<DaimondsPerPrdDisplayModel>();
            SqlParameter[] sParams =
           {
                new SqlParameter("detailId",detailid)
            };
            string sp = StoredProcedures.GEtDaimondDetailsPerProduct + " @detailId";
            myList = context.Set<DaimondsPerPrdDisplayModel>().FromSqlRaw(sp, sParams).ToList();
            return myList;
        }
        public List<SRubyPerPrdDisplayModel> GetSRubyPerList(int detailid)
        {
            List<SRubyPerPrdDisplayModel> myList = new List<SRubyPerPrdDisplayModel>();
            SqlParameter[] sParams =
           {
                new SqlParameter("detailId",detailid)
            };
            string sp = StoredProcedures.GetSRubyDetailsPerProduct + " @detailId";
            myList = context.Set<SRubyPerPrdDisplayModel>().FromSqlRaw(sp, sParams).ToList();
            return myList;
        }

        public void DeleteDaimondPerPrd(int id)
        {
            DaimondsPerPrdDetailsEntity d = new DaimondsPerPrdDetailsEntity();
            d = context.daimondsPerPrdDetailsEntities.Where(a => a.DPPDId == id).FirstOrDefault();
            d.IsDeleted = true;
            context.Entry(d).CurrentValues.SetValues(d);
            context.SaveChanges();
        }
        public void DeleteSRubyPerPrd(int id)
        {
            SRubyPerPrdDetailsEntity d = new SRubyPerPrdDetailsEntity();
            d = context.sRubyPerPrdDetailsEntities.Where(a => a.SRPPDId == id).FirstOrDefault();
            d.IsDeleted = true;
            context.Entry(d).CurrentValues.SetValues(d);
            context.SaveChanges();
        }
        public void DeletePerlPerPrd(int id)
        {
            PerlPerPrdDetailsEntity d = new PerlPerPrdDetailsEntity();
            d = context.perlPerPrdDetailsEntities.Where(a => a.PPPDId == id).FirstOrDefault();
            d.IsDeleted = true;
            context.Entry(d).CurrentValues.SetValues(d);
            context.SaveChanges();
        }
        public void DeleteSolPerPrd(int id)
        {
            SolitairePerPrdDetailsEntity d = new SolitairePerPrdDetailsEntity();
            d = context.solitairePerPrdDetailsEntities.Where(a => a.SPPDId== id).FirstOrDefault();
            d.IsDeleted = true;
            context.Entry(d).CurrentValues.SetValues(d);
            context.SaveChanges();
        }


        #region API Products


        public List<APIProductListDisplay> APIGetProductsBySearchforUser( int userid,int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "")
        {
            List<APIProductListDisplay> response = new List<APIProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false &&
                            (prd.ProductTitle.Contains(search) || subcat.SubCategoryName.Contains(search) || cat.CategoryName.Contains(search))
                            select new APIProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                IsInWishList = userid != 0 ? context.wishListEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false && a.UserId == userid).FirstOrDefault() != null ? 1 : 0 : 0
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public List<ProductListDisplay> APIGetProductsBySearch(int cid = 0, int pageNumber = 1, int pageSize = 10, string search = "")
        {
            List<ProductListDisplay> response = new List<ProductListDisplay>();
            try
            {

                response = (from prd in context.productMasterEntities
                            join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                            join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                            join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                            where prd.IsDeleted == false &&
                            ( prd.ProductTitle.Contains(search) || subcat.SubCategoryName.Contains(search) || cat.CategoryName.Contains(search))
                            select new ProductListDisplay
                            {
                                CategoryId = prd.CategoryId,
                                CategoryId_name = cat.CategoryName,
                                DetailCategoryId = prd.DetailCategoryId,
                                ProductId = prd.ProductId,
                                DetailCategoryId_name = detcat.DetailCategoryName,
                                DiscountApplicableId = prd.DiscountApplicableId,
                                DiscountMasterId = prd.DiscountApplicableId,
                                IsCustomizable = prd.IsCustomizable,
                                IsSizeApplicable = prd.IsSizeApplicable,
                                MaxDelivaryDays = prd.MaxDelivaryDays,
                                PostedBy = prd.PostedBy,
                                PostedOn = prd.PostedOn,
                                ProductDescription = prd.ProductDescription,
                                ProductTitle = prd.ProductTitle,
                                SubCategoryId = prd.SubCategoryId,
                                SubCategoryId_name = subcat.SubCategoryName,
                                ProductMainImages_List = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault()
                            }).OrderByDescending(b => b.PostedOn).Take(10).
                            ToList();


            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
            }
            return response;
        }
        public List<APIProductListDisplay> APIGetProductsByCatId(ProductDetailsRequest request,string url,int userId)
        {
            int id = 0;
            List<APIProductListDisplay> response = new List<APIProductListDisplay>();

            if (request.SubCatID!=0  && request.CatID>0)
            {
                id = request.SubCatID;
                try
                {

                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.SubCategoryId == request.SubCatID && prd.CategoryId==request.CatID
                                select new APIProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List =url+ context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                    IsInWishList=userId !=0?context.wishListEntities.Where(a=>a.ProductId==prd.ProductId &&a.IsDeleted==false&&a.UserId==userId).FirstOrDefault()!=null?1:0:0,
                                    Stock = prd.Stock
                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();


                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                }
            }

            else if(request.CatID==0 && request.SubCatID>0)
            {
                id = request.SubCatID;
                try
                {

                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.SubCategoryId == id
                                select new APIProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = url + context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                    IsInWishList = userId != 0 ? context.wishListEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false && a.UserId == userId).FirstOrDefault() != null ? 1 : 0 : 0,
                                    Stock = prd.Stock

                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();


                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                }
            }
            else
            {
                id = request.CatID;
                try
                {

                    response = (from prd in context.productMasterEntities
                                join cat in context.categoryMasterEntities on prd.CategoryId equals cat.CategoryId
                                join subcat in context.subCategoryMasters on prd.SubCategoryId equals subcat.SubCategoryId
                                join detcat in context.detailCategoryMasters on prd.DetailCategoryId equals detcat.DetailCategoryId
                                where prd.IsDeleted == false && prd.CategoryId == id
                                select new APIProductListDisplay
                                {
                                    CategoryId = prd.CategoryId,
                                    CategoryId_name = cat.CategoryName,
                                    DetailCategoryId = prd.DetailCategoryId,
                                    ProductId = prd.ProductId,
                                    DetailCategoryId_name = detcat.DetailCategoryName,
                                    DiscountApplicableId = prd.DiscountApplicableId,
                                    DiscountMasterId = prd.DiscountApplicableId,
                                    IsCustomizable = prd.IsCustomizable,
                                    IsSizeApplicable = prd.IsSizeApplicable,
                                    MaxDelivaryDays = prd.MaxDelivaryDays,
                                    PostedBy = prd.PostedBy,
                                    PostedOn = prd.PostedOn,
                                    ProductDescription = prd.ProductDescription,
                                    ProductTitle = prd.ProductTitle,
                                    SubCategoryId = prd.SubCategoryId,
                                    SubCategoryId_name = subcat.SubCategoryName,
                                    ProductMainImages_List = url+context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == prd.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                                    ActualPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.ActualPrice).FirstOrDefault(),
                                    SellingPrice = context.productDetailsEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false).Select(b => b.SellingPrice).FirstOrDefault(),
                                    IsInWishList = userId != 0 ? context.wishListEntities.Where(a => a.ProductId == prd.ProductId && a.IsDeleted == false && a.UserId == userId).FirstOrDefault() != null ? 1 : 0 : 0,
                                    Stock=prd.Stock

                                }).OrderByDescending(b => b.PostedOn).Take(10).
                                ToList();


                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                }
            }

            
            return response;
        }
        #endregion
    }
}
