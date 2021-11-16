using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Ecommerce.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using Ecommerce.Models.InterfacesBAL;

namespace Ecommerce.Models.BAL
{
    public class UserMgmtService : IUserMgmtService
    {
        private readonly MyDbContext context;
        private readonly INotificationService _nService;
        private readonly IConfiguration _config;
     
        public UserMgmtService(MyDbContext context , INotificationService nService, IConfiguration config)
        {
            this.context = context;
            _nService = nService;
            _config = config;
        }
        public bool EmailAvailablityCheck(string emailId)
        {
            bool result = true;

            var findResult = context.userMasters.Where(a => a.EmailId == emailId).FirstOrDefault();
            if (findResult != null)
            {
                result = false;
            }
            return result;
        }
        public bool MobileAvailablityCheck(string mobileNumber)
        {
            bool result = true;
            var findResult = context.userMasters.Where(a => a.MobileNumber == mobileNumber).FirstOrDefault();
            if (findResult != null)
            {
                result = false;
            }
            return result;
        }
        public IQueryable<UserTypeMasterEnity> GetUserTypes()
        {
            IQueryable<UserTypeMasterEnity> result = null;
            try
            {

                result = context.userTypeMasters;
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //public ICollection<UserTypeResultModel> GetUserTypesWithSP(string procedure)
        //{
        //    ICollection<UserTypeResultModel> result = null;
        //    try
        //    {
        //        GenericRepository<UserTypeResultModel> uRepo = new GenericRepository<UserTypeResultModel>();
        //        result = uRepo.ExecuteQueryWOParams(procedure);
        //        return Transform.ConvertResultToApiResonse(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Transform.GetErrorResponse<ICollection<UserTypeResultModel>>(
        //            result,
        //            errors: new List<string>() { ErrorMessages.DbOperationFailed, ex.Message }
        //            );
        //    }
        //}

        public UserTypeMasterEnity GetUserTypeById(int id)
        {
            UserTypeMasterEnity result = new UserTypeMasterEnity();
            try
            {
                result = context.userTypeMasters.Where(a => a.TypeId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ProcessResponse RegisterUser(UserMasterEntity userMaster)
        {
            ProcessResponse result = new ProcessResponse();
            try
            {
                userMaster.PWord = PasswordEncryption.Encrypt(userMaster.PWord);

                context.userMasters.Add(userMaster);
                context.SaveChanges();

                result.currentId = userMaster.UserId;
                result.statusCode = 1;
                result.statusMessage = "Registration is Success";
                result.emailId = userMaster.EmailId;
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public ProcessResponse UpdateUser(UserMasterEntity request)
        {

            ProcessResponse response = new ProcessResponse();
            try
            {
                UserMasterEntity cm = context.userMasters.Where(a => a.UserId == request.UserId).FirstOrDefault();
                if (cm != null)
                {
                    request.IsDeleted = cm.IsDeleted;
                    request.CurrentStatus = cm.CurrentStatus;
                    CloneObjects.CopyPropertiesTo(request, cm);
                    context.Entry(cm).CurrentValues.SetValues(cm);
                    context.SaveChanges();
                }

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }


            return response;
        }

        public UserMasterEntity GetUserById(int userId)
        {
            UserMasterEntity result = new UserMasterEntity();
            try
            {
                result = context.userMasters.Where(a => a.UserId == userId).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public void UpdatePassword(UserMasterEntity request)
        {
            UserMasterEntity um = context.userMasters.Where(a => a.UserId == request.UserId).FirstOrDefault();
            if (um != null)
            {
                um.PWord = request.PWord;
                context.Entry(um).CurrentValues.SetValues(um);
                context.SaveChanges();
            }
        }

        public void UpdateUserMaster(APIUser request)
        {
            var uma =context.userMasters.Where(a => a.UserId == request.UserId).FirstOrDefault();
            if (uma != null)
            {
                if (!String.IsNullOrEmpty(request.MobileNumber)
                     && request.MobileNumber.ToUpper() != uma.MobileNumber.ToUpper())
                {
                    uma.MobileNumber = request.MobileNumber;
                }
                if (!String.IsNullOrEmpty(request.ProfilePicUrl))
                {
                    uma.ProfileImage = request.ProfilePicUrl;
                }
                //if (!String.IsNullOrEmpty(request.APIUserMasterModel.DeviceId) 
                //    && request.APIUserMasterModel.DeviceId.ToUpper()!=uma.DeviceId.ToUpper())
                //{
                //    uma.DeviceId = request.APIUserMasterModel.DeviceId;
                //}

                //if (!String.IsNullOrEmpty(request.Address)
                //    && request.Address.ToUpper() != uma.Address.ToUpper())
                //{
                //    uma.Address = request.Address;
                //}
                if (request.AddressTypeId != 0)
                {
                    var addressMaster = context.addressEntities.Where(x => x.UserId == request.UserId && x.AddressTypeId == request.AddressTypeId).FirstOrDefault();
                    if (addressMaster != null)
                    {
                       if(request.Address1!=null) addressMaster.Address1 = request.Address1;
                        if (request.Address2 != null) addressMaster.Address2 = request.Address2;
                        if (request.LandMark != null) addressMaster.LandMark = request.LandMark;
                        if (request.ZipCode != null) addressMaster.ZipCode = request.ZipCode;

                        context.SaveChanges();
                    }
                }
              
                // um.PWord = request.PWord;
                context.Entry(uma).CurrentValues.SetValues(uma);
                context.SaveChanges();
            }
        }

        public APIUser GetUserByEmail(string email)
        {
            UserMasterEntity result = new UserMasterEntity();

            APIUser apiUser = new APIUser();
             
            try
            {
                result = context.userMasters.Where(a => a.EmailId == email || a.MobileNumber == email && a.IsDeleted == false).FirstOrDefault();
                apiUser = new APIUser()
                { UserId= result.UserId,UserName=result.UserName,EmailId=result.EmailId,
                    MobileNumber= result.MobileNumber,ProfilePicUrl=result.ProfileImage};
                var resultAddress = context.addressEntities.Where(x => x.UserId == result.UserId).FirstOrDefault();

                if (resultAddress != null && resultAddress.AddressTypeId!=4)
                {
                    apiUser.AddressTypeId = resultAddress.AddressTypeId;
                    apiUser.Address1 = resultAddress.Address1;
                    apiUser.Address2 = resultAddress.Address2;
                    apiUser.LandMark = resultAddress.LandMark;
                    apiUser.ZipCode = resultAddress.ZipCode;
                }
                else
                {
                    apiUser.AddressTypeId = resultAddress.AddressTypeId;
                    apiUser.Address1 = string.Empty;
                    apiUser.Address2 = string.Empty;
                    apiUser.LandMark = string.Empty;
                    apiUser.ZipCode = string.Empty;
                }
            
                
            }
            catch (Exception ex)
            {

            }
            return apiUser;
        }

        public LoginResponse IsValidUser(string emailId) 
        {
            LoginResponse response = new LoginResponse();

            try
            {
                var obj = (from um in context.userMasters
                           join ut in context.userTypeMasters on um.UserTypeId equals ut.TypeId into utTemp
                           from utype in utTemp.DefaultIfEmpty()
                           where um.EmailId == emailId &&
                           um.IsDeleted == false
                           select new
                           {
                               um.EmailId,
                               um.UserId,
                               um.UserName,
                               utype.TypeName,
                               um.PWord,
                               um.IsEmailVerified,
                               um.CurrentStatus,
                               um.ProfileImage
                           }).FirstOrDefault();

                if (obj != null)
                {

                    response.statusCode = 1;
                    response.statusMessage = "Valid User";
                    response.userId = obj.UserId;
                    response.userName = obj.UserName;
                    response.userTypeName = obj.TypeName;
                    response.emailId = obj.EmailId;
                    response.userImageURL = obj.ProfileImage != null ? obj.ProfileImage : "";
                    
                    //return response;
                }

                return  (response);

            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Invalid User";
                return  (response);
            }

        }

        public List<Category> APIGetMenuCat(string urlhost) 
        {
            List<Category> categories = new List<Category>();
            var response = (from cat in context.categoryMasterEntities
                            select new Category {
                                Name =cat.CategoryName,
                                ParentMenuId = 0,
                                Id = cat.CategoryId,
                                Permitted = true,
                                Image = urlhost + @"/icons/"+cat.CategoryCode+".png",
                            }).ToList();
            return response;
        }

        public List<SubCategory> APIGetMenuSubCat(string urlhost)
        {
            List<SubCategory> categories = new List<SubCategory>();
            var response = (from cat in context.subCategoryMasters
                            select new SubCategory
                            {
                                Name = cat.SubCategoryName,
                                ParentMenuId = cat.CategoryId  ?? default(int),
                                Id = cat.SubCategoryId,
                                Permitted = true,
                                Image = urlhost + @"/icons/" + cat.SubCategoryName + ".png",
                            }).ToList();
            return response;
        }


        public ApiResponse< LoginResponse> LoginCheck(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                var obj = (from um in context.userMasters
                           join ut in context.userTypeMasters on um.UserTypeId equals ut.TypeId into utTemp
                           from utype in utTemp.DefaultIfEmpty()
                           where um.EmailId == request.emailid || um.MobileNumber == request.mobileNumber && 
                           um.IsDeleted == false
                           select new
                           {
                               um.EmailId,
                               um.UserId,
                               um.UserName,
                               utype.TypeName,
                               um.PWord,
                               um.IsEmailVerified,
                               um.CurrentStatus,
                               um.ProfileImage                           }).FirstOrDefault();

                if (obj == null)
                {
                    response.statusCode = 0;
                    response.statusMessage = "Emailid / Mobile number not registered";
                }
                else
                {
                    string pw = PasswordEncryption.Encrypt(request.pword);
                    if (!obj.PWord.Equals(pw))
                    {
                        response.statusCode = 0;
                        response.statusMessage = "Passowrd mismatch";
                    }
                    else if (obj.IsEmailVerified == false)
                    {
                        response.statusCode = 0;
                        response.statusMessage = "Account not verified";
                    }
                    else
                    {
                        LoginTrack lt = new LoginTrack();
                        lt.IsDeleted = false;
                        lt.LoginTime = DateTime.Now;
                        lt.UserId = obj.UserId;
                        lt.UserName = obj.UserName;
                        context.loginTracks.Add(lt);
                        context.SaveChanges();
                        response.statusCode = 1;
                        response.statusMessage = "Login success";
                        response.userId = obj.UserId;
                        response.userName = obj.UserName;
                        response.userTypeName = obj.TypeName;
                        response.emailId = obj.EmailId;
                        response.userImageURL = obj.ProfileImage!=null ?obj.ProfileImage:"";
                    }
                }
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to login";
                return Transform.ConvertResultToApiResonse(response);
            }
        }

        public OtpTransactionsEntity GetOTPInformation(int userId)
        {
            OtpTransactionsEntity response = new OtpTransactionsEntity();
            try
            {
                response = context.OtpTransactions.Where(a => a.IsDeleted == false
                && a.TRId == userId
                && a.CurrentStatus == "Draft").FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return response;

        }
        public ProcessResponse SaveOtpInformation(OtpTransactionsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                context.OtpTransactions.Add(request);
                context.SaveChanges();
                response.currentId = request.TRId;
                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public ProcessResponse UpdateOtpInformation(OtpTransactionsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                OtpTransactionsEntity otp = new OtpTransactionsEntity();
                otp = context.OtpTransactions.Where(a => a.TRId == request.TRId).FirstOrDefault();
                context.Entry(otp).CurrentValues.SetValues(request);
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }


        public List<UserMasterDisplay> GetAllUsers(string type)
        {
            List<UserMasterDisplay> response = new List<UserMasterDisplay>();
            if (type == "All")
            {
                response = (from u in context.userMasters
                            join ut in context.userTypeMasters on u.UserTypeId equals ut.TypeId
                            where u.IsDeleted == false
                            select new UserMasterDisplay
                            {
                                UserName = u.UserName,
                                ActivatedOn = u.ActivatedOn,

                                CancelledOrders = 0,

                                CnfPWord = "",

                                CurrentStatus = u.CurrentStatus,
                                EmailId = u.EmailId,

                                IsDeleted = u.IsDeleted,
                                IsEmailVerified = u.IsEmailVerified,
                                MobileNumber = u.MobileNumber,
                                PWord = u.PWord,
                                RegisteredOn = u.RegisteredOn,

                                TotalOrders = 0,
                                UserId = u.UserId,
                                UserTypeId = u.UserTypeId,
                                UserTypeName = ut.TypeName
                            }).OrderBy(b => b.UserName).ToList();
            }
            else
            {
                response = (from u in context.userMasters
                            join ut in context.userTypeMasters on u.UserTypeId equals ut.TypeId
                            where u.IsDeleted == false && ut.TypeName == type
                            select new UserMasterDisplay
                            {
                                UserName = u.UserName,
                                ActivatedOn = u.ActivatedOn,
                                
                                CancelledOrders = 0,
                              
                                CnfPWord = "",
                            
                                CurrentStatus = u.CurrentStatus,
                                EmailId = u.EmailId,
                               
                                IsDeleted = u.IsDeleted,
                                IsEmailVerified = u.IsEmailVerified,
                                MobileNumber = u.MobileNumber,
                                PWord = u.PWord,
                                RegisteredOn = u.RegisteredOn,
                              
                                TotalOrders = 0,
                                UserId = u.UserId,
                                UserTypeId = u.UserTypeId,
                                UserTypeName = ut.TypeName

                            }).OrderBy(b => b.UserName).ToList();
            }


            return response;
        }

        public ProcessResponse SendRegistrationEmail(string moduleName, string toEamil, string userName,
            int userId)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                EmailTemplateEntity emailTemplate = new EmailTemplateEntity();
                emailTemplate = _nService.GetEmailTemplateByModule(moduleName);
                if (emailTemplate != null)
                {

                    string HostURL = _config.GetValue<string>("OtherConfig:WebHostURL");
                    UserVerificationEntity userVerification = new UserVerificationEntity();
                    string keyRegistration = string.Empty;
                    keyRegistration = DateTime.UtcNow.ToString();
                    keyRegistration = Regex.Replace(keyRegistration, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                    keyRegistration += userId.ToString();

                    userVerification.ActivationKey = keyRegistration;
                    userVerification.ActivationURL = HostURL + "/Authenticate/Activate?key=" + keyRegistration;
                    userVerification.DOR = DateTime.UtcNow;
                    userVerification.Status = "Draft";
                    userVerification.UserID = userId;
                    SaveUserVerification(userVerification);
                    string emailCC = _config.GetValue<string>("OtherConfig:EmailCC");
                    string emailText = emailTemplate.EmailTemplate;
                    emailText = emailText.Replace("##USERNAME##", userName);
                    emailText = emailText.Replace("##URL##", userVerification.ActivationURL);
                    bool res = _nService.PushEmail(emailText, toEamil, emailTemplate.Subject, emailCC);
                    ps.statusMessage = "email sent";
                    ps.statusCode = 1;


                }
            }
            catch (Exception ex)
            {

                ps.statusMessage = ex.Message;
                ps.statusCode = 0;
            }

            return ps;

        }
        public ProcessResponse SaveUserVerification(UserVerificationEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                context.userVerificationEntities.Add(request);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;

        }


        public ProcessResponse InitiateResetPassword(string emailId)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                
                var um = context.userMasters.Where(a => a.EmailId == emailId && a.IsDeleted == false && a.CurrentStatus == "Active").FirstOrDefault();
                if (um != null)
                {
                    string key = RandomGenerator.RandomString(8,false);
                    key = key + um.UserId.ToString();


                    ResetPasswordEntity rp = new ResetPasswordEntity();
                    rp.CurrentStatus = "Draft";
                    rp.IsDeleted = false;
                    rp.RaisedOn = DateTime.UtcNow;
                    rp.ResetKey = key;
                    rp.UserId = um.UserId;

                    context.resetPasswordEntities.Add(rp);
                    context.SaveChanges();
                    ps.statusMessage = key;
                    ps.statusCode = 1;
                    ps.currentId = um.UserId;
                }
                else
                {
                    ps.statusCode = 0;
                    ps.statusMessage = "Email ID not registered or your account is de-activated.";
                    ps.currentId = 0;
                }
            }
            catch (Exception ex)
            {
                ps.statusCode = 0;
                ps.statusMessage = "failed";
            }
            return ps;

        }
        public ProcessResponse CompletePasswordRequest(string key)
        {
            ProcessResponse ps = new ProcessResponse();
            ResetPasswordEntity rs = new ResetPasswordEntity();
            
            rs = context.resetPasswordEntities.Where(a => a.ResetKey.Equals(key) && a.CurrentStatus.Equals("Draft")).FirstOrDefault();
            if (rs != null)
            {
                rs.ResetOn = DateTime.UtcNow;
                rs.CurrentStatus = "Used";
                context.Entry(rs).CurrentValues.SetValues(rs);
                context.SaveChanges();
                ps.statusCode = 1;
                ps.statusMessage = "Success";
                ps.currentId = Convert.ToInt32(rs.UserId);
            }
            else
            {
                ps.statusCode = 0;
                ps.statusMessage = "Failed";
            }


            return ps;

        }

        public ProcessResponse UpdatePassword(LoginCheckRequest request)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {

                UserMasterEntity um = new UserMasterEntity();
                
                um = context.userMasters.Where (a => a.UserId == request.UserId).FirstOrDefault();

                um.PWord = PasswordEncryption.Encrypt(request.password);
                context.Entry(um).CurrentValues.SetValues(um);
                ps.statusCode = 1;
                ps.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                //    LogException.Record(ex);
                ps.statusMessage = "Unable to update";
                ps.statusCode = 0;
            }
            return ps;
        }


        public int GetUserCartCount(int userId)
        {
            int totalItems = 0;
            var cart = context.cartMasterEntities.Where(a => a.CartUserId == userId && a.IsDeleted == false && a.CurrentStatus == "Open").FirstOrDefault();
            if (cart == null)
            {
                totalItems = 0;
            }
            else
            {
                int currentId = cart.CartId;
                int itemCount = context.cartDetailsEntities.Where(a => a.CartId == currentId && a.IsDeleted == false && a.CurrentStatus == "Open").Count();//.Sum(i => i.NumberOfItems.GetValueOrDefault());//
                totalItems = itemCount;
            }

            return totalItems;
        }

        public ProcessResponse AddToCart(CartDetailsModel requst, int userId) 
        {

            ProcessResponse response = new ProcessResponse();

            CartDetailsEntity cartDetails = (from cmaster in context.cartMasterEntities
                                             join cmd in context.cartDetailsEntities on cmaster.CartId equals cmd.CartId
                                             where cmaster.CartUserId == userId && cmaster.CurrentStatus == "Open" && cmaster.IsDeleted == false && cmd.ProductId == requst.ProductId && cmd.IsDeleted== false 
                                             select cmd).FirstOrDefault();
            CartMasterEntity cmcheck = context.cartMasterEntities.Where(a => a.CartUserId == userId && a.CurrentStatus == "Open" && a.IsDeleted == false).FirstOrDefault();
            if (cmcheck != null   ) 
            {
                if (cartDetails != null && cartDetails.CurrentStatus.ToUpper()!="DELETED")
                {
                    decimal? totalpriceforoneitem = cartDetails.TotalPrice.GetValueOrDefault()/ cartDetails.NumberOfItems;
                    decimal? oldpriceforoneitem = cartDetails.OldPrice.GetValueOrDefault() / cartDetails.NumberOfItems;

                    cartDetails.NumberOfItems = requst.NumberOfItems+cartDetails.NumberOfItems;
                    cartDetails.TotalPrice = cartDetails.NumberOfItems * totalpriceforoneitem;
                    cartDetails.OldPrice = cartDetails.NumberOfItems * oldpriceforoneitem;
                    context.SaveChanges();

                    response.statusCode = 1;
                    response.statusMessage = "Success";
                }
                else
                {
                    int currentId = cmcheck.CartId;
                    requst.CartId = currentId;
                    requst.IsDeleted = false;
                    CartDetailsEntity cd = new CartDetailsEntity();

                    CloneObjects.CopyPropertiesTo(requst, cd);
                    context.cartDetailsEntities.Add(cd);
                    context.SaveChanges();
                    response.statusCode = 1;
                    response.statusMessage = "Success";
                }
               
            }
            else
            {
                CartMasterEntity cm = new CartMasterEntity();
                cm.CartId = 0;
                cm.CartUserId = userId;
                cm.CreatedOn = DateTime.Now;
                cm.CurrentStatus = "Open";
                cm.IsDeleted = false;
                context.cartMasterEntities.Add(cm);
                context.SaveChanges();

                int currentId = cm.CartId;
                requst.CartId = currentId;
                requst.IsDeleted = false;
                CartDetailsEntity cd = new CartDetailsEntity();

                CloneObjects.CopyPropertiesTo(requst, cd);
                context.cartDetailsEntities.Add(cd);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            return response;
        }
        public ProcessResponse AddToCart1(CartDetailsModel requst, int userId)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                CartMasterEntity cm = context.cartMasterEntities.Where(a => a.CartUserId == userId && a.CurrentStatus == "Open" && a.IsDeleted == false).FirstOrDefault();
                if (cm == null)
                {
                    cm = new CartMasterEntity();
                    cm.CartId = 0;
                    cm.CartUserId = userId;
                    cm.CreatedOn = DateTime.Now;
                    cm.CurrentStatus = "Open";
                    cm.IsDeleted = false;
                    context.cartMasterEntities.Add(cm);
                    context.SaveChanges();
                }
                int currentId = cm.CartId;
                requst.CartId = currentId;
                requst.IsDeleted = false;
                CartDetailsEntity cd = new CartDetailsEntity();

                CloneObjects.CopyPropertiesTo(requst, cd);
                context.cartDetailsEntities.Add(cd);
                context.SaveChanges();
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

        public CartDetailsEntity IsProdcutInCart(int userid, int productid) 
        {

            CartDetailsEntity cartDetails = (from cmaster in context.cartMasterEntities
                                             join cmd in context.cartDetailsEntities on cmaster.CartId equals cmd.CartId
                                             where cmaster.CartUserId == userid && cmaster.CurrentStatus == "Open" && cmaster.IsDeleted == false //&& cmd.ProductId == productid
                                             select cmd).FirstOrDefault();


            return cartDetails;
        }
        public CartMasterEntity GetCartById(int id)
        {
            return context.cartMasterEntities.Where(a => a.CartId == id).FirstOrDefault();
        }
        public CartDetailsEntity GetCartDetailById(int id)
        {
            return context.cartDetailsEntities.Where(a => a.CartDetailId == id).FirstOrDefault();
        }

        public ProcessResponse APIDecrementFromCart(int userid, int productid)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                CartDetailsEntity cd =
                    (from cm in context.cartMasterEntities
                     join cd1 in context.cartDetailsEntities on cm.CartId equals cd1.CartId
                     where cd1.ProductId == productid  && cd1.IsDeleted==false
                     select cd1).FirstOrDefault();
                if (cd != null)
                {
                    // cd.IsDeleted = true;
                    // cd.CurrentStatus = "Deleted";
                    if (cd.NumberOfItems>1)
                    {
                        cd.TotalPrice = cd.TotalPrice / cd.NumberOfItems;
                        cd.NumberOfItems = cd.NumberOfItems - 1;
                        cd.TotalPrice = cd.TotalPrice * cd.NumberOfItems;
                    }
                    else 
                    {
                        cd.NumberOfItems = 0;
                        cd.IsDeleted = true;
                        cd.CurrentStatus = "Deleted";
                       
                    }
                    context.Entry(cd).CurrentValues.SetValues(cd);
                    context.SaveChanges();
                    isCartEmptyandUpdate(userid, productid);
                }

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }

        private void isCartEmptyandUpdate(int userid, int productid) 
        {
         var   cart =
                    (from cm in context.cartMasterEntities
                     join cd1 in context.cartDetailsEntities on cm.CartId equals cd1.CartId
                     where  cd1.IsDeleted == false && cm.CartUserId==userid
                     select cd1).FirstOrDefault();
            if (cart==null)
            {
                var cm = context.cartMasterEntities.Where(x => x.CartUserId == userid && x.IsDeleted==false).FirstOrDefault();
                if (cm!=null)
                {
                    cm.IsDeleted = true;
                    context.SaveChanges();
                }
            }
        }
        public ProcessResponse APIDeleteFromCart(int userid,int productid)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                CartDetailsEntity cd =
                    (from cm in context.cartMasterEntities
                    join cd1 in  context.cartDetailsEntities on cm.CartId equals cd1.CartId 
                    where cd1.ProductId==productid && cd1.IsDeleted == false
                     select cd1).FirstOrDefault();
                if (cd != null)
                {
                    cd.IsDeleted = true;
                    cd.CurrentStatus = "Deleted";
                    context.Entry(cd).CurrentValues.SetValues(cd);
                    context.SaveChanges();
                }

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }
        
        public ProcessResponse DeleteFromCart(int detId)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                CartDetailsEntity cm = context.cartDetailsEntities.Where(a => a.CartDetailId == detId).FirstOrDefault();
                if (cm != null)
                {
                    cm.IsDeleted = true;
                    cm.CurrentStatus = "Deleted";
                    context.Entry(cm).CurrentValues.SetValues(cm);
                    context.SaveChanges();
                }
                
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }


            return response;
        }

        public ProcessResponse UpdateCart(CartDetailsModel request)
        {

            ProcessResponse response = new ProcessResponse();
            try
            {
                CartDetailsEntity cm = context.cartDetailsEntities.Where(a => a.CartDetailId == request.CartDetailId).FirstOrDefault();
                if (cm != null)
                {
                    request.IsDeleted = cm.IsDeleted;
                    request.CurrentStatus = cm.CurrentStatus;
                    CloneObjects.CopyPropertiesTo(request, cm);
                    context.Entry(cm).CurrentValues.SetValues(cm);
                    context.SaveChanges();
                }

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }


            return response;
        }

        public ProcessResponse UpdateCartMaster(CartMasterEntity request)
        {

            ProcessResponse response = new ProcessResponse();
            try
            {
                CartMasterEntity cm = context.cartMasterEntities.Where(a => a.CartId == request.CartId).FirstOrDefault();
                if (cm != null)
                {
                  
                    CloneObjects.CopyPropertiesTo(request, cm);
                    context.Entry(cm).CurrentValues.SetValues(cm);
                    context.SaveChanges();
                }

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }


            return response;
        }

        public ProcessResponse UpdateCartDetails(CartDetailsEntity request)
        {

            ProcessResponse response = new ProcessResponse();
            try
            {
                CartDetailsEntity cm = context.cartDetailsEntities.Where(a => a.CartDetailId == request.CartDetailId).FirstOrDefault();
                if (cm != null)
                { 
                    CloneObjects.CopyPropertiesTo(request, cm);
                    context.Entry(cm).CurrentValues.SetValues(cm);
                    context.SaveChanges();
                }

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }


            return response;
        }

        public UserCartModel GetMyCart(int userId)
        {
            UserCartModel res = new UserCartModel();
            try
            {
                res = (from c in context.cartMasterEntities
                       join u in context.userMasters on c.CartUserId equals u.UserId
                       where c.CartUserId == userId && c.CurrentStatus == "Open" && c.IsDeleted == false
                       select new UserCartModel
                       {
                           IsDeleted = c.IsDeleted,
                           CartDetails = null,
                           CartId = c.CartId,
                           CartUserId = c.CartUserId,
                           CreatedOn = c.CreatedOn,
                           CurrentStatus = c.CurrentStatus,
                           CustomerAddress = "dummy address",
                           CustomerEmail = u.EmailId,
                           CustomerMobile = u.MobileNumber,
                           CustomerName = u.UserName

                       }).FirstOrDefault();
                if(res!=null)
                {
                    decimal bankchareges = 2.36m;
                    decimal banktax = 0.36m;
                    int currentId = res.CartId;
                    List<CartDetailsModel> details = new List<CartDetailsModel>();
                    details = (from d in context.cartDetailsEntities
                               join pr in context.productMasterEntities on d.ProductId equals pr.ProductId
                               where d.IsDeleted == false && d.CartId == currentId && d.CurrentStatus == "Open"
                               select new CartDetailsModel
                               {
                                   CurrentStatus = d.CurrentStatus,
                                   CartId = d.CartId,
                                   IsDeleted = d.IsDeleted,
                                   CartDetailId = d.CartDetailId,
                                   DaimondPrice = d.DaimondPrice,
                                   Discount = d.Discount,
                                   GST = d.GST,
                                   MakingCharges = d.MakingCharges,
                                   NumberOfItems = d.NumberOfItems,
                                   OldPrice = d.OldPrice,
                                   ProductDetailId = d.ProductDetailId,
                                   ProductId = d.ProductId,
                                   ProductTitle = pr.ProductTitle,
                                   TotalPrice = d.TotalPrice,
                                   ProductImage = context.productImagesEntities
                                   .Where(a => a.IsDeleted == false && a.ProductId == d.ProductId)
                                   .Select(b => b.ImageUrl).FirstOrDefault(),
                                   GoldPrice = d.GoldPrice,
                                   GoldWeight = d.GoldWeight,
                                   SizeId = d.SizeId,
                                   SizeName = d.SizeName,
                                   AddedOn = d.AddedOn,
                                   GoldRate = d.GoldRate, MetalMasterId_Name = d.MetalMasterId_Name,
                                   MetalMasterId = d.MetalMasterId,
                                   BankChareges = ((decimal)d.TotalPrice * bankchareges) / 100,
                                   BankTax = ((decimal)d.TotalPrice * banktax) / 100

                               })
                       .ToList();
                    res.CartDetails = details;
                }
            
            }
            catch (Exception ex)
            {
                 
            }
            return res!= null?res:   new UserCartModel();

        }

        public ProcessResponse SavePOMaster(POMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if(request.POId > 0)
                {
                    POMasterEntity po = new POMasterEntity();
                    po = context.pOMasterEntities.Where(a => a.POId == request.POId).FirstOrDefault();
                    context.Entry(po).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.pOMasterEntities.Add(request);
                    context.SaveChanges();
                    response.currentId = request.POId;
                }
               
                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch (Exception ex)
            {

            }
            return response; 
        }

        public ProcessResponse SaveRazorPaymentResult(RazorPaymentResultEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.TRId > 0)
                {
                    RazorPaymentResultEntity po = new RazorPaymentResultEntity();
                    po = context.razorPaymentResultEntities.Where(a => a.TRId == request.TRId).FirstOrDefault();
                    context.Entry(po).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.razorPaymentResultEntities.Add(request);
                    context.SaveChanges();
                    response.currentId = request.TRId;
                }

                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public POMasterEntity GetPoMasterById(int id)
        {
            return context.pOMasterEntities.Where(a => a.POId == id).FirstOrDefault();
        }

        public ProcessResponse SavePODetails(PODetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                if (request.PODetailId > 0)
                {
                    PODetailsEntity po = new PODetailsEntity();
                    po = context.pODetails.Where(a => a.PODetailId == request.PODetailId).FirstOrDefault();
                    context.Entry(po).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.pODetails.Add(request);
                    context.SaveChanges();
                    response.currentId = request.PODetailId;
                }

                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public PODetailsEntity GetPoDetailById(int id)
        {
            return context.pODetails.Where(a => a.PODetailId == id).FirstOrDefault();
        }
        public PODetailsEntity GetPoDetailByMasterIdId(int id)
        {
            return context.pODetails.Where(a => a.POMasterId == id).FirstOrDefault();
        }
        public List<WishListModel> GetMyWishList(int userid )
        {
            List<WishListModel> response = new List<WishListModel>();
            try
            {
                response = (
                            from w in context.wishListEntities
                            join pd in context.productDetailsEntities on w.ProductDetailId equals pd.ProductDetailId
                            join pi in context.productImagesEntities on w.ProductId equals pi.ProductId
                            join p in context.productMasterEntities on w.ProductId equals p.ProductId
                            where w.IsDeleted == false && w.UserId == userid
                            select new WishListModel
                            {
                                AddedOn = w.AddedOn,
                                CurrentStatus = "Active",
                                IsDeleted = w.IsDeleted,
                                DaimondPrice = 0,
                                MetalMasterId = pd.MetalMasterId,
                                Discount = 0,
                                ProductDetailId = w.ProductDetailId,
                                MetalMasterId_Name = "",
                                MakingCharges = pd.MakingCharges,
                                GST = 0,
                                GoldWeight = pd.ProductWeight,
                                GoldPrice = 0,
                                GoldRate = 0,
                                OldPrice = pd.ActualPrice,
                                ProductId = p.ProductId,
                                ProductImage =  pi.ImageUrl,
                                ProductTitle = p.ProductTitle,
                                SizeId = pd.SizeMasterId,
                                WishListId = w.WishListId
                            }).ToList();


            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public List<WishListModel> APIGetMyWishList(int userid,string url)
        {
            List<WishListModel> response = new List<WishListModel>();
            try
            {
                response = (
                            from w in context.wishListEntities
                            join pd in context.productDetailsEntities on w.ProductDetailId equals pd.ProductDetailId
                            join pi in context.productImagesEntities on w.ProductId equals pi.ProductId
                            join p in context.productMasterEntities on w.ProductId equals p.ProductId
                            where w.IsDeleted == false && w.UserId == userid
                            select new WishListModel
                            {
                                AddedOn = w.AddedOn,
                                CurrentStatus = "Active",
                                IsDeleted = w.IsDeleted,
                                DaimondPrice = 0,
                                MetalMasterId = pd.MetalMasterId,
                                Discount = 0,
                                ProductDetailId = w.ProductDetailId,
                                MetalMasterId_Name = "",
                                MakingCharges = pd.MakingCharges,
                                GST = 0,
                                GoldWeight = pd.ProductWeight,
                                GoldPrice = 0,
                                GoldRate = 0,
                                OldPrice = pd.ActualPrice,
                                ProductId = p.ProductId,
                                ProductImage =pi.ImageUrl.Contains("http")==false?url+ pi.ImageUrl:pi.ImageUrl,
                                 ProductTitle = p.ProductTitle,
                                  SizeId=pd.SizeMasterId,
                                  WishListId = w.WishListId
                            }).ToList();
                    
                     
            }
            catch(Exception ex)
            {

            }

            return response;
        }
        public ProcessResponse AddToWishList(WishListEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                var test = context.wishListEntities
                    .Where(a => a.UserId == request.UserId && a.ProductDetailId == request.ProductDetailId
                    && a.ProductId == request.ProductId && a.IsDeleted == false).FirstOrDefault();
                if(test == null)
                {
                    request.IsDeleted = false;
                    request.AddedOn = DateTime.Now;
                    context.wishListEntities.Add(request);
                    context.SaveChanges();
                    response.statusCode = 1;
                    response.statusMessage = "Success";
                }
                else
                {
                   
                    response.statusCode = 0;
                    response.statusMessage = "You have already added";
                }


             
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }

        public ProcessResponse APIPostReview(UserReviewMaster userReviewMaster)
        {
            ProcessResponse response = new ProcessResponse();

            try
            {
                if (userReviewMaster!=null)
                {
                    context.UserReviewMasters.Add(userReviewMaster);
                    context.SaveChanges();
                    response.statusCode = 1;
                    response.statusMessage = "Success";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }
        public ProcessResponse APIDeleteWishList(int id,int userid)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                WishListEntity wl = new WishListEntity();
                wl = context.wishListEntities.Where(a => a.ProductId == id && a.UserId==userid && a.IsDeleted==false).FirstOrDefault();
                wl.IsDeleted = true;
                context.Entry(wl).CurrentValues.SetValues(wl);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }

        public ProcessResponse DeleteWishList(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                WishListEntity wl = new WishListEntity();
                wl = context.wishListEntities.Where(a => a.WishListId == id).FirstOrDefault();
                wl.IsDeleted = true;
                context.Entry(wl).CurrentValues.SetValues(wl);
                context.SaveChanges();
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


        public ProcessResponse SaveAddress(AddressEntity userMaster)
        {
            ProcessResponse result = new ProcessResponse();
            try
            {

                context.addressEntities.Add(userMaster);
                context.SaveChanges();

                result.currentId = userMaster.Id;
                result.statusCode = 1;
                result.statusMessage = "Registration is Success";
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public ProcessResponse UpdateAddress(AddressEntity userMaster)
        {
            ProcessResponse result = new ProcessResponse();
            try
            {
                var ad = context.addressEntities.Where(a => a.IsDeleted == false && a.Id == userMaster.Id).FirstOrDefault();
                context.Entry(ad).CurrentValues.SetValues(userMaster);
                context.SaveChanges();

                result.currentId = userMaster.Id;
                result.statusCode = 1;
                result.statusMessage = "update is Success";
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public List<UserAddressListModel> GetAllAddress(int userId)
        {
            List<UserAddressListModel> myList = new List<UserAddressListModel>();
            myList = (from a in context.addressEntities
                      join city in context.cityMasterEntities on a.CityId equals city.Id
                      join st in context.stateMasterEntities on a.StateId equals st.Id
                      join c in context.countryMasterEntities on a.CityId equals c.Id
                      where a.IsDeleted == false && a.UserId == userId
                      select new UserAddressListModel
                      {
                          Address1 = a.Address1,
                          Id = a.Id,
                          CityId = a.CityId,
                          Address2 = a.Address2,
                          AddressTypeId = a.AddressTypeId,
                          CityId_Name = city.CityName,
                          CountryId = a.CountryId,
                          CountryId_Name = c.CountryName,
                          IsDeleted = a.IsDeleted,
                          LandMark = a.LandMark,
                          LocationStreet = a.LocationStreet,
                          StateId = a.StateId,
                          StateId_Name = st.StateName
                      }).ToList();
            return myList;
        }
        public AddressModel GetAddressbyId(int id)
        {

            return context.addressEntities.Where(a => a.Id == id)
                .Select(b => new AddressModel
                {
                    Address1 = b.Address1,
                    Address2 = b.Address2,
                    AddressTypeId = b.AddressTypeId,
                    CityId = b.CityId,
                    CountryId = b.CountryId,
                    Id = b.Id,
                    LandMark = b.LandMark,
                    LocationStreet = b.LocationStreet,
                    StateId = b.StateId,
                    ZipCode = b.ZipCode, IsDeliverAddress = b.IsDeliverAddress

                })
                .FirstOrDefault();
        }
            
        public UserMasterProfile GetMyProfile(int id)
        {
            UserMasterProfile response = new UserMasterProfile();
            try
            {
                List<AddressProfileModel> add = new List<AddressProfileModel>();
                add = (from a in context.addressEntities
                       join at in context.addressTypesEntities on a.AddressTypeId equals at.Id
                       join c in context.countryMasterEntities on a.CountryId equals c.Id
                       join s in context.stateMasterEntities on a.StateId equals s.Id
                       join ct in context.cityMasterEntities on a.CityId equals ct.Id
                       where a.IsDeleted == false && a.UserId == id
                       select new AddressProfileModel
                       {
                           Address1 = a.Address1,
                           Id = a.Id,
                           CityId = a.CityId,
                           Address2 = a.Address2,
                           AddressTypeId = a.AddressTypeId,
                           AddressTypeId_Name = at.AddressTypeName,
                           CityId_Name = ct.CityName,
                           CountryId = a.CountryId,
                           CountryId_Name = c.CountryName,
                           LandMark = a.LandMark,
                           LocationStreet = a.LocationStreet,
                           StateId = a.StateId,
                           StateId_Name = s.StateName,
                           ZipCode = a.ZipCode,
                           IsDeliverAddress = a.IsDeliverAddress
                       }).ToList();
                response = context.userMasters.Where(a => a.UserId == id)
                    .Select(b => new UserMasterProfile
                    {
                        ActivatedOn = b.ActivatedOn,
                        addressList = add,
                        CurrentStatus = b.CurrentStatus,
                        EmailId = b.EmailId,
                        IsDeleted = b.IsDeleted,
                        IsEmailVerified = b.IsEmailVerified,
                        MobileNumber = b.MobileNumber,
                        RegisteredOn = b.RegisteredOn,
                        UserId = b.UserId,
                        UserName = b.UserName
                    }).FirstOrDefault();
                
            }
            catch(Exception ex)
            {

            }

            return response;
        }

        public ProcessResponse UpdateCODPayment(CODPaymentUpdateModel request)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                POMasterEntity po = new POMasterEntity();
                po = context.pOMasterEntities.Where(a => a.POId == request.POId).FirstOrDefault();
                po.BankCharges = request.Charges;
                po.PaidAmount = request.PaidAmount;
                po.PaidDate = request.PaidDate;
                po.Remarks = request.Remarks;
                po.CurrentStatus = "PaymentSuccess";
                context.Entry(po).CurrentValues.SetValues(po);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";

            }
            catch(Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }

        public ProcessResponse SaveContactUs(ContactUs contactUs)
        {
           ProcessResponse response = new ProcessResponse();
            try
            {
                context.contactUs.Add(contactUs);
                context.SaveChanges();
                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;

        }
    }
}
