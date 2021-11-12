using Ecommerce.Models.BAL;
using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Ecommerce.Models.Utilities.AppSettings;

namespace Ecommerce.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly ILogger<AuthenticateController> _logger;
        private readonly INotificationService _nService;
        private readonly IUserMgmtService _uService;
        private readonly ICommonService _cService;
        public AuthenticateController(ILogger<AuthenticateController> logger, 
            INotificationService nService,
            IUserMgmtService uService,
            ICommonService cService)
        {
            _logger = logger;
            _nService = nService;
            _uService = uService;
            _cService = cService;
        }

        public IActionResult Login(string url = "Home/Index")
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            ViewBag.url = url;
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            ViewBag.url = request.url;
            
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;

            if (string.IsNullOrEmpty(request.emailid) || string.IsNullOrEmpty(request.pword))
            {
                ViewBag.ErrorMessage = "Fill Mandatory fields";
                return View(request);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var loginCheck = _uService.LoginCheck(request).Response;
                    if (loginCheck.statusCode == 1)
                    {
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "loggedUser", loginCheck);
                        return Redirect("~/" + request.url);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = loginCheck.statusMessage;
                      //  ViewBag.CaptchaKey = "6LeplcYUAAAAAJlmUhStKiuJ6ucEqdotoWTYomZf";
                        ViewBag.src = request.url;
                        return View(request);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid emailid / mobile number or password";
                   // ViewBag.CaptchaKey = "6LeplcYUAAAAAJlmUhStKiuJ6ucEqdotoWTYomZf";
                    ViewBag.src = request.url;
                    return View(request);
                }
            }
        }




        public IActionResult Register()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            UserMasterModel um = new UserMasterModel();
            um.countryList = _cService.GetAllCountryies();
            um.stateList = _cService.GetAllStates(um.countryList[0].Id);
            um.cityList = _cService.GetallCities(um.stateList[0].Id);
            um.addtypeList = _cService.GetAllAddressTypes();
            return View(um);
        }

        [HttpPost]
        public IActionResult Register(UserMasterModel request)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            if (ModelState.IsValid)
            {
                bool isFine = true;
                var emailCheck = _uService.EmailAvailablityCheck(request.EmailId);
                if (emailCheck == false)
                {
                    ModelState.AddModelError("EmailId", "Email Id not avaialable");
                    isFine = false;
                }
                var mobiblecheck = _uService.MobileAvailablityCheck(request.MobileNumber);
                if (mobiblecheck == false)
                {
                    ModelState.AddModelError("MobileNumber", "Mobile number not available");
                    isFine = false;
                }
                if (isFine == false)
                {
                    request.countryList = _cService.GetAllCountryies();
                    request.stateList = _cService.GetAllStates((int)request.CountryId);
                    request.cityList = _cService.GetallCities((int)request.StateId);
                    request.addtypeList = _cService.GetAllAddressTypes();
                    return View(request);
                }
                else
                {
                    UserMasterEntity um = new UserMasterEntity();
                    request.CurrentStatus = "Active";
                    request.IsDeleted = false;
                    request.IsEmailVerified = true;
                    request.RegisteredOn = DateTime.Now;
                    var usertypes = _uService.GetUserTypes().Where(a => a.TypeName == "Customer").FirstOrDefault();
                    request.UserTypeId = usertypes.TypeId;
                    CloneObjects.CopyPropertiesTo(request, um);
                    var result = _uService.RegisterUser(um);
                    if (result.statusCode == 1)
                    {
                        LoginResponse lr = new LoginResponse();
                        lr.userId = result.currentId;
                        lr.userName = request.UserName;
                        lr.userTypeName = usertypes.TypeName;
                        lr.emailId = request.EmailId;
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "loggedUser", lr);

                        AddressEntity ad = new AddressEntity();
                        CloneObjects.CopyPropertiesTo(request, ad);
                        ad.IsDeleted = false;
                        ad.IsDeliverAddress = "Yes";
                        ad.UserId = result.currentId;
                        var aa = _uService.SaveAddress(ad);
                        var ps = _nService.SendRegistrationEmail(EmailTemplateModules.RegistrationEmail,
                           request.EmailId, request.UserName, loginCheckResponse.userId);
                        
                        return RedirectToAction("Index", "Home");
                    }
                    if (result.statusCode == 0)
                    {
                        ViewBag.ErrorMessage = "Unable to complete registration now, please try after some time.";
                    }
                    else
                    {


                        //send email
                       
                    }
                }
            }
            request.countryList = _cService.GetAllCountryies();
            request.stateList = _cService.GetAllStates((int)request.CountryId);
            request.cityList = _cService.GetallCities((int) request.StateId);
            request.addtypeList = _cService.GetAllAddressTypes();
            return View(request);
        }
        public IActionResult ForgotPassword()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(LoginRequestForPWChange reqest)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            if (ModelState.IsValid)
            {
                ProcessResponse ps = new ProcessResponse();
                ps = _uService.InitiateResetPassword(reqest.emailId);


                if (ps.statusCode == 1)
                {
                    var userData = _uService.GetAllUsers("All").Where(a => a.UserId == ps.currentId).FirstOrDefault();
                    var res = _nService.SendResetPasswordEmail(EmailTemplateModules.ResetPassword,
                        ps.statusMessage, reqest.emailId, userData.UserName, userData.UserId);
                    ps.statusMessage = "Passcode sent to your Email ID";
                    ps.statusCode = 1;
                }
                if (ps.statusCode == 0)
                {
                    ViewBag.ErrorMessage = ps.statusMessage;
                    return View(reqest);
                }
                else
                {
                    return RedirectToAction("ResetPassword");
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Enter email id";
            }
            return View();
        }
        public IActionResult ResetPassowrdSuccess()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            return View();
        }
        public IActionResult ResetPassword()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ForgotPasswordReset req)
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            if (ModelState.IsValid)
            {
                var ps = _uService.CompletePasswordRequest(req.key);
                if (ps.statusCode == 1)
                {
                    LoginCheckRequest request = new LoginCheckRequest();
                    request.UserId = ps.currentId;
                    request.password = req.pword;
                    var res = _uService.UpdatePassword(request);
                    if (res.statusCode == 1)
                    {
                        return RedirectToAction("ResetPassowrdSuccess");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = res.statusMessage;
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = ps.statusMessage;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Fill all the details";
            }
            return View();
        }

         
        //public IActionResult PasswordReset(string passkey = "")
        //{
        //    LoginResponse loginCheckResponse = new LoginResponse();
        //    loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
        //    if (loginCheckResponse == null)
        //    {
        //        loginCheckResponse = new LoginResponse();
        //        loginCheckResponse.userId = 0;
        //        loginCheckResponse.userName = "NA";
        //    }
        //    ViewBag.LoggedUser = loginCheckResponse;
        //    ViewBag.passkey = passkey;

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult PasswordReset(PasswordResetKeys request)
        //{
        //    ViewBag.passkey = request.passkey;
        //    if (ModelState.IsValid)
        //    {
        //        bool isFine = true;
        //        string trId = PasswordEncryption.Decrypt(request.passkey);
        //        int pkId = Convert.ToInt32(trId);
        //        var pkeys = _uService.GetOTPInformation(pkId);
        //        var user = _uService.GetUserById(pkeys.UserId);

        //        if (!string.IsNullOrEmpty(request.mobileOtp) && request.mobileOtp != pkeys.MobileOTP)
        //        {
        //            isFine = false;
        //        }
        //        if (!string.IsNullOrEmpty(request.emailOtp) && request.emailOtp != pkeys.EmailOTP)
        //        {
        //            isFine = false;
        //        }
        //        if (isFine)
        //        {
        //            user.PWord = PasswordEncryption.Encrypt(request.pword);
        //            _uService.UpdatePassword(user);

        //            pkeys.CurrentStatus = "Used";
        //            pkeys.IsDeleted = true;
        //            pkeys.UsedOn = DateTime.Now;
        //            _uService.UpdateOtpInformation(pkeys);
        //            return RedirectToAction("ResetSuccess");
        //        }
        //        else
        //        {
        //            ViewBag.ErrorMessage = "Please enter valid details";
        //            return View(request);
        //        }
        //    }

        //    LoginResponse loginCheckResponse = new LoginResponse();
        //    loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
        //    if (loginCheckResponse == null)
        //    {
        //        loginCheckResponse = new LoginResponse();
        //        loginCheckResponse.userId = 0;
        //        loginCheckResponse.userName = "NA";
        //    }
        //    ViewBag.LoggedUser = loginCheckResponse;
        //    return View(request);
        //}
        //public IActionResult ResetSuccess()
        //{
        //    LoginResponse loginCheckResponse = new LoginResponse();
        //    loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
        //    if (loginCheckResponse == null)
        //    {
        //        loginCheckResponse = new LoginResponse();
        //        loginCheckResponse.userId = 0;
        //        loginCheckResponse.userName = "NA";
        //    }
        //    ViewBag.LoggedUser = loginCheckResponse;
        //    return View();
        //}
        //public IActionResult InitiatePasswordReset()
        //{
        //    LoginResponse loginCheckResponse = new LoginResponse();
        //    loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
        //    if (loginCheckResponse == null)
        //    {
        //        loginCheckResponse = new LoginResponse();
        //        loginCheckResponse.userId = 0;
        //        loginCheckResponse.userName = "NA";
        //    }
        //    ViewBag.LoggedUser = loginCheckResponse;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult InitiatePasswordReset(LoginRequestReset request)
        //{

        //    ModelState.Remove("pword");
        //    if (ModelState.IsValid)
        //    {
        //        bool isFine = true;
        //        var emailchck = _uService.EmailAvailablityCheck(request.emailid);
        //        var mobileCheck = _uService.MobileAvailablityCheck(request.mobileNumber);
        //        if (!string.IsNullOrEmpty(request.emailid) && emailchck)
        //        {
        //            isFine = false;
        //        }
        //        if (!string.IsNullOrEmpty(request.mobileNumber) && mobileCheck)
        //        {
        //            isFine = false;
        //        }
        //        if (isFine == false)
        //        {
        //            ViewBag.ErrorMessage = "Email/Mobile Number not registered";
        //            return View(request);
        //        }
        //        else
        //        {
        //            var um = _uService.GetUserByEmail(request.emailid);
        //            OtpTransactions otp = new OtpTransactions();
        //            otp.CreatedOn = DateTime.Now;
        //            otp.CurrentStatus = "Draft";
        //            otp.EmailOTP = RandomGenerator.RandomNumber(1000, 9999).ToString();
        //            otp.MobileOTP = RandomGenerator.RandomNumber(1000, 9999).ToString();
        //            otp.IsDeleted = false;
        //            otp.UserId = um.UserId;
        //            ProcessResponse ps = _uService.SaveOtpInformation(otp);
        //            string encKey = PasswordEncryption.Encrypt(ps.currentId.ToString());
        //            if (ps.statusCode == 1)
        //            {
        //                string email = "<h3>Hello " + um.UserName + ".";
        //                email += "Use the below otp for reset password </br>";
        //                email += "Email OTP : " + otp.EmailOTP;
        //                _nService.PushEmail(email, um.EmailId, "Password Reset");
        //                return RedirectToAction("PasswordReset", new { passkey = encKey });
        //            }
        //            else
        //            {
        //                ViewBag.ErrorMessage = "Unable to genereate now, try later.";
        //            }

        //        }


        //    }
        //    LoginResponse loginCheckResponse = new LoginResponse();
        //    loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
        //    if (loginCheckResponse == null)
        //    {
        //        loginCheckResponse = new LoginResponse();
        //        loginCheckResponse.userId = 0;
        //        loginCheckResponse.userName = "NA";
        //    }
        //    ViewBag.LoggedUser = loginCheckResponse;
        //    return View(request);
        //}

        public IActionResult Logout()
        {
            LoginResponse lr = new LoginResponse();
            lr.userId = 0;
            lr.userName = "NA";
            lr.userTypeName = "";
            lr.emailId = "";
            SessionHelper.SetObjectAsJson(HttpContext.Session, "loggedUser", lr);
            return RedirectToAction("Index", "Home");
        }

        #region API for Mobile Consumers

        [HttpPost]
        public IActionResult APILogin(  LoginRequest request)
        {
            try
            {
                LoginResponse loginCheckResponse = new LoginResponse();
                loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
                if (loginCheckResponse == null)
                {
                    loginCheckResponse = new LoginResponse();
                    loginCheckResponse.userId = 0;
                    loginCheckResponse.userName = "NA";
                }
                if (string.IsNullOrEmpty(request.emailid) || string.IsNullOrEmpty(request.pword))
                {
                    return StatusCode(200, new { statusCode = 0, statusMessage = "Fill Mandatory Fields" });
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var loginCheck = _uService.LoginCheck(request).Response;
                        if (loginCheck.statusCode == 1)
                        {
                            SessionHelper.SetObjectAsJson(HttpContext.Session, "loggedUser", loginCheck);
                            _uService.UpdateUserMaster(new UserMasterEntity() { UserName = loginCheck.userName, UserId = loginCheck.userId, DeviceId = request.deviceID, EmailId = request.emailid });
                            if (!string.IsNullOrEmpty(loginCheck.userImageURL) &&!loginCheck.userImageURL.Contains(Request.Host.Value))
                            {
                                loginCheck.userImageURL = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + @"/UserImages/" + loginCheck.userImageURL;
                            }
                            return StatusCode(200, new { statusCode = 1, UserDetails =loginCheck,statusMessage = "Login Success" });
                        }
                        else
                        {
                            return StatusCode(200, new { statusCode = 0, statusMessage = "login failure" });
                        }
                    }
                    else
                    {
                        return StatusCode(200, new { statusCode = 0, request= request,statusMessage = "Invalid emailid / mobile number or password" });
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(200, new { statusCode = 0, statusMessage = "User Login Failed" });
            }
        }

        [HttpGet]
        public IActionResult APIGetProfile(APIUserMasterModel request)
        {

            LoginResponse loginCheckResponse = new LoginResponse();
            UserMasterEntity user;
            try
            { 

              var  loginCheck = _uService.IsValidUser(request.EmailId);
                if (loginCheck.statusCode != 1)
                {
                    return StatusCode(200, new { statusCode = 0, request = request, statusMessage = "Invalid User" });
                }
                user = _uService.GetUserByEmail(request.EmailId);
                if (user.ProfileImage != null && user.ProfileImage.Length > 0 && !user.ProfileImage.ToLower().Contains("http"))
                {
                    user.ProfileImage = HttpContext.Request.Scheme + ":\\" + user.ProfileImage;
                }
            }
            catch (Exception)
            {
                return StatusCode(200, new { statusCode = 0, statusMessage = "Fetch User Failed" }); 
            }
            return Json(new
            {
                status = 1,
                UserId = user.UserId,
                UserName = user.UserName,
                UserTypeId = user.UserTypeId,
                EmailId = user.EmailId,
                DeviceId = user.DeviceId != null ? user.DeviceId : string.Empty,
     
                ProfileImage = user.ProfileImage!= null ? user.ProfileImage: string.Empty,
                MobileNumber = user.MobileNumber,
                Address = user.Address != null ? user.Address : string.Empty
            });

        }

        [HttpPut]
        public IActionResult APIUpdateProfile(UserMasterEntity request)
        {
            try
            {
                LoginResponse loginCheck = null;
                //LoginResponse loginCheckResponse = new LoginResponse();
                //loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
                //if (loginCheckResponse == null)
                //{
                //    loginCheckResponse = new LoginResponse();
                //    loginCheckResponse.userId = 0;
                //    loginCheckResponse.userName = "NA";
                //    return StatusCode(401, new { statusCode = 0, statusMessage = "Invalid User, Please try log in with proper User Details" });
                //}
                //if (string.IsNullOrEmpty(request.EmailId) )//|| string.IsNullOrEmpty(request.pword))
                //{
                //    return StatusCode(401, new { statusCode = 0, statusMessage = "Fill Mandatory Fields" });
                //}
                //else
                {
                    //if (ModelState.IsValid)
                    {
                          loginCheck = _uService.IsValidUser(request.EmailId);
                        if (loginCheck.statusCode!=1)
                        {
                            return StatusCode(200, new { statusCode = 0, request = request, statusMessage = "Invalid User" });
                        }
                    }
                }
                if (Request.Form.Files[0] != null)
                {
                    try
                    {
                        request.ProfileImage = SaveProfilePicture(request.EmailId, loginCheck.userName);
                    }
                    catch (Exception)
                    {
                        return StatusCode(200, new { statusCode = 0, statusMessage = "Update Failed" });
                    }
                }
                _uService.UpdateUserMaster(request);
            }
            catch (Exception)
            {
                return StatusCode(200, new { statusCode = 0, statusMessage = "Update Failed" });
            }
            return StatusCode(200, new { statusCode = 1, statusMessage = "Update Successful" }); 
        }

        [HttpPost]
        public IActionResult APIRegister(  APIUserMasterModel request)
        {
            try
            {
                string httpLead = @"http:\\";
                LoginResponse loginCheckResponse = new LoginResponse();
                loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
                if (loginCheckResponse == null)
                {
                    loginCheckResponse = new LoginResponse();
                    loginCheckResponse.userId = 0;
                    loginCheckResponse.userName = "NA";
                }
                string imagepath = string.Empty;
                if (ModelState.IsValid)
                {
                    bool isFine = true;
                    var emailCheck = _uService.EmailAvailablityCheck(request.EmailId);
                    if (emailCheck == false)
                    {
                        isFine = false;
                    }
                    var mobiblecheck = _uService.MobileAvailablityCheck(request.MobileNumber);
                    if (mobiblecheck == false)
                    {
                        isFine = false;
                    }
                    if (isFine==false)
                    {
                        return Json(new
                        {
                            status = 0,
                            message = "User Already Exists"
                        });
                    //if (isFine == false)
                    //{
                    //    request.countryList = _cService.GetAllCountryies();
                    //    if (request.CountryId != null )
                    //    {
                    //        request.stateList = _cService.GetAllStates((int)request.CountryId);
                    //    }
                    //    if ( request.StateId != null)
                    //    {
                    //        request.cityList = _cService.GetallCities((int)request.StateId);

                    //    }
                    //    request.addtypeList = _cService.GetAllAddressTypes();
                    //    return Ok(request);
                    }
                    else
                    {
                        UserMasterEntity um = new UserMasterEntity();
                        request.CurrentStatus = "Active";
                        request.IsDeleted = false;
                        request.IsEmailVerified = true;
                        request.RegisteredOn = DateTime.Now;
                        if (Request.Form.Files!=null && Request.Form.Files.Count>0 && Request.Form.Files[0] != null)
                        {
                            um.ProfileImage = SaveProfilePicture("", request.UserName);
                        }
                        var usertypes = _uService.GetUserTypes().Where(a => a.TypeName == "Customer").FirstOrDefault();
                        request.UserTypeId = usertypes.TypeId;
                        CloneObjects.CopyPropertiesTo(request, um);
                        var result = _uService.RegisterUser(um);
                        if (result.statusCode == 1)
                        {
                            LoginResponse lr = new LoginResponse();
                            lr.userId = result.currentId;
                            lr.userName = request.UserName;
                            lr.userTypeName = usertypes.TypeName;
                            lr.emailId = request.EmailId;
                            SessionHelper.SetObjectAsJson(HttpContext.Session, "loggedUser", lr);
                            AddressEntity ad = new AddressEntity();
                            CloneObjects.CopyPropertiesTo(request, ad);
                            ad.IsDeleted = false;
                            ad.IsDeliverAddress = "Yes";
                            ad.UserId = result.currentId;
                            var aa = _uService.SaveAddress(ad);
                            var ps = _nService.SendRegistrationEmail(EmailTemplateModules.RegistrationEmail,
                               request.EmailId, request.UserName, loginCheckResponse.userId);

                            return Json(new { status = 1, message = result.statusMessage, Emailid = request.EmailId, UserId = result.currentId, UserName = request.UserName, Mobile = request.MobileNumber, profilePicUrl = um!=null ?um.ProfileImage!=null?um.ProfileImage:"":"" });// Ok(result);
                        }
                        if (result.statusCode == 0)
                        {
                            return StatusCode(200, new { status = 0, message = "Unable to complete registration now, please try after some time." });
                        }
                        else
                        {
                            //send email
                        }
                    }
                }
                request.countryList = _cService.GetAllCountryies();
                request.stateList = _cService.GetAllStates((int)request.CountryId);
                request.cityList = _cService.GetallCities((int)request.StateId);
                request.addtypeList = _cService.GetAllAddressTypes();
                //return Ok(request);
                return StatusCode(200, new { status = 1, request= request, message = "Registration Success" });

            }
            catch (Exception ex)
            {
                return StatusCode(200, new { status = 0, Message = "Registration Failed" });
            }
        }

        private string SaveProfilePicture(string emailId, string userName)
        {
            string fullPath = string.Empty;
            string contenttype= string.Empty;
            string pathToSave = string.Empty;
                pathToSave= HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + @"/UserImages/";

            try
            {
                if (Request.Form.Files[0] != null)
                {
                    var file = Request.Form.Files[0];
                      contenttype = file.FileName.Split('.').Count() > 1 ? file.FileName.Split('.')[1] : "";
                    var folderName = Path.Combine(@"\WWWROOT"+@"\UserImages");
                    //  pathToSave = Path.Combine(Directory.GetCurrentDirectory()+ folderName);
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                          fullPath =pathToSave+  userName + "." + contenttype;
                        // var dbPath = Path.Combine(folderName, fileName);
                        if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory()+ @"\wwwroot\WWWROOT\UserImages\" + userName + "." + contenttype)))
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory()+ @"\wwwroot\WWWROOT\UserImages\" + userName + "." + contenttype));
                        }
                        _logger.LogDebug(pathToSave + userName + "." + contenttype);
                        Console.WriteLine(pathToSave + userName + "." + contenttype);
                        using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory()+ @"\WWWROOT\UserImages\" + userName+ "." + contenttype), FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        if (!string.IsNullOrEmpty(emailId))
                        {
                            _uService.UpdateUserMaster(new UserMasterEntity() { EmailId = emailId, ProfileImage = fullPath });

                        }
                        return fullPath;
                    }
                    else
                    {
                        return fullPath;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fullPath;
        }

        #endregion
    }
}
