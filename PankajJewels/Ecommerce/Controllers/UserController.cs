using Ecommerce.Models.BAL;
using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IMasterDataMgmtService _mService;
        private readonly IOrderMgmtService _ordService;
        private readonly IUserMgmtService _uService;
        private readonly ICommonService _cService;
        private readonly IProductManagementService _pService;
        private readonly INotificationService _nService;
        private readonly IConfiguration _config;
        public UserController(IMasterDataMgmtService mService, IConfiguration config,
            IOrderMgmtService ordService, IUserMgmtService uService, ICommonService cService, IProductManagementService pService,
            INotificationService nService)
        {
            _mService = mService;
            _ordService = ordService;
            _uService = uService;
            _cService = cService;
            _pService = pService;
            _nService = nService;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// User type data master management
        /// </summary>
        /// <returns></returns>

        public IActionResult Usertypes()
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

            List<UserTypeMasterEnity> uList = new List<UserTypeMasterEnity>();
            uList = _mService.GetAllUserTypes();
            return View(uList);
        }

        public IActionResult UserTypeData(int id = 0)
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
            UserTypeMasterEnity utm = new UserTypeMasterEnity();
            if (id > 0)
            {
                utm = _mService.GetUserTypeById(id);
            }
            else
            {
                utm = new UserTypeMasterEnity();
            }

            return View(utm);
        }

        [HttpPost]
        public IActionResult UserTypeData(UserTypeMasterEnity request)
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

            if (ModelState.IsValid)
            {
                var checkUserType = _mService.CheckUserType(request.TypeName, request.TypeId);
                if (checkUserType == false)
                {
                    ModelState.AddModelError("TypeName", "Typename not available");
                }
                if (ModelState.IsValid)
                {
                    if (request.TypeId == 0)
                    {
                        request.IsDeleted = false;
                        var result = _mService.AddUserType(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Usertypes");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.statusMessage;
                        }
                    }
                    else
                    {
                        request.IsDeleted = false;
                        var result = _mService.UpdateUserType(request);
                        if (result.statusCode == 1)
                        {
                            return RedirectToAction("Usertypes");
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
        public IActionResult DeleteUserType(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                UserTypeMasterEnity request = new UserTypeMasterEnity();
                request = _mService.GetUserTypeById(id);
                request.IsDeleted = true;
                response = _mService.UpdateUserType(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }

        /// <summary>
        /// profile settings
        /// </summary>
        /// <returns></returns>
        public IActionResult Profile()
        {
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA"; return RedirectToAction("Login", "Authenticate");
            }
            UserMasterProfile myObject = new UserMasterProfile();
            myObject = _uService.GetMyProfile(loginCheckResponse.userId);
            ViewBag.LoggedUser = loginCheckResponse;
            return View(myObject);
        }

        public IActionResult UpdateAddress(int id = 0)
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
            AddressModel am = new AddressModel();
            if (id > 0)
            {
                am = _uService.GetAddressbyId(id);
            }
            am.countryList = _cService.GetAllCountryies();
            am.stateList = _cService.GetAllStates(am.countryList[0].Id);
            am.cityList = _cService.GetallCities(am.stateList[0].Id);
            am.addtypeList = _cService.GetAllAddressTypes();
            return View(am);
        }
        [HttpPost]
        public IActionResult UpdateAddress(AddressModel request)
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
                request.UserId = loginCheckResponse.userId;
                if (request.Id > 0)
                {
                    AddressEntity ae = new AddressEntity();
                    CloneObjects.CopyPropertiesTo(request, ae);
                    ae.IsDeleted = false;
                    var r = _uService.UpdateAddress(ae);
                    if (request.IsDeliverAddress == "Yes")
                    {
                        List<UserAddressListModel> myAddress = new List<UserAddressListModel>();
                        myAddress = _uService.GetAllAddress(request.UserId).Where(a => a.Id != request.Id).ToList();
                        if (myAddress.Count > 0)
                        {
                            foreach (var a in myAddress)
                            {

                                AddressModel am = new AddressModel();
                                request = _uService.GetAddressbyId(a.Id);
                                AddressEntity aeUpdate = new AddressEntity();
                                CloneObjects.CopyPropertiesTo(request, aeUpdate);
                                aeUpdate.IsDeleted = false;
                                aeUpdate.UserId = loginCheckResponse.userId;
                                aeUpdate.IsDeliverAddress = "No";
                                var v = _uService.UpdateAddress(aeUpdate);

                            }
                        }
                    }
                }
                else
                {
                    AddressEntity ae = new AddressEntity();
                    CloneObjects.CopyPropertiesTo(request, ae);
                    ae.IsDeleted = false;
                    var r = _uService.SaveAddress(ae);
                }
                return RedirectToAction("Profile");
            }

            request.countryList = _cService.GetAllCountryies();
            request.stateList = _cService.GetAllStates((int)request.CountryId);
            request.cityList = _cService.GetallCities((int)request.StateId);
            request.addtypeList = _cService.GetAllAddressTypes();
            return View(request);
        }
        [HttpPost]
        public IActionResult DeleteAddress(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                AddressModel request = new AddressModel();
                request = _uService.GetAddressbyId(id);
                AddressEntity ae = new AddressEntity();
                CloneObjects.CopyPropertiesTo(request, ae);
                ae.IsDeleted = true;
                response = _uService.UpdateAddress(ae);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }
        /// <summary>
        /// user roles management
        /// </summary>
        /// <returns></returns>
        public IActionResult UserRoles()
        {
            return View();
        }

        public IActionResult AddressTypes()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View();
        }
        public IActionResult Vendors()
        {
            return View();
        }

        [HttpGet]
        public IActionResult APIAllOpenOrderDetails(int userid) {

            List<POMasterModel> orderDetails = new List<POMasterModel>();
            orderDetails = _ordService.GetAllOpenOrders(userid);
            return StatusCode(200, new {status=1,message="success" , orderDetails });
        }


        [HttpGet]
        public IActionResult APIAllOrderDetails(int userid)
        {
            string url = HttpContext.Request.Scheme + @"://" + HttpContext.Request.Host.Value + @"/ProductImages/";

            List<APIPOMasterModel> orderDetails = new List<APIPOMasterModel>();
            orderDetails = _ordService.APIGetAllOrders(userid,url);
            return StatusCode(200, new { status = 1, message = "success", orderDetails });
        }

        [HttpGet]
        public IActionResult APIRefundOrders(int userid, int orderid)
        {

            List<APIPOMasterModel> orderDetails = new List<APIPOMasterModel>();
            string url = HttpContext.Request.Scheme + @"://" + HttpContext.Request.Host.Value + @"/ProductImages/";
            orderDetails = _ordService.APIGetRefundOrders(userid, url);

            return StatusCode(200, new { status = 1, message = "success", orderDetails });
        }


        [HttpGet]
        public IActionResult APIOpenOrderDetails(int userid, int orderid)
        {

            List<APIPOMasterModel> orderDetails = new List<APIPOMasterModel>();
            string url = HttpContext.Request.Scheme + @"://" + HttpContext.Request.Host.Value + @"/ProductImages/";
            orderDetails = _ordService.APIOpenOrders(userid,orderid,url);

            return StatusCode(200, new { status = 1, message = "success", orderDetails });
        }

        // customer
        public IActionResult OpenOrders()
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

            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllOpenOrders(loginCheckResponse.userId);

            return View(myList);
        }


        public IActionResult ClosedOrders()
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
            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllClosedOrders(loginCheckResponse.userId);

            return View(myList);

        }
        public IActionResult CancelledOrders()
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

            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllCancelledOrders(loginCheckResponse.userId);

            return View(myList);
        }

        public IActionResult ReturnedOrders()
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


            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllRetunedOrders(loginCheckResponse.userId);

            return View(myList);
        }
        public IActionResult MyPayments()
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
        public IActionResult ViewOrderC(int id = 0)
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

            POMasterEntity po = _uService.GetPoMasterById(id);
            PODetailsEntity pd = _uService.GetPoDetailByMasterIdId(po.POId);
            PostProductModel_Web product = _pService.GetProductDetails_Web((int)pd.ProductId);
            product.ProductDetails = product.ProductDetails.Where(a => a.ProductDetailId == pd.ProductDetailId).ToList();
            ProductDisplayForAdmin myobject = new ProductDisplayForAdmin();
            myobject.folloup = _pService.GetPOFollowups(po.POId);
            myobject.po = po;
            myobject.pd = pd;
            myobject.product = product;
            return View(myobject);
        }


        // admin
        public IActionResult OpenOrdersA()
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

            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllOpenOrders(loginCheckResponse.userId, "Admin");

            return View(myList);
        }
        public IActionResult ClosedOrdersA()
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

            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllClosedOrders(loginCheckResponse.userId, "Admin");
            return View(myList);
        }
        public IActionResult ReturnedOrdersA()
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


            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllRetunedOrders(loginCheckResponse.userId, "Admin");
            return View(myList);
        }
        public IActionResult CancelledOrdersA()
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


            List<POMasterModel> myList = new List<POMasterModel>();
            myList = _ordService.GetAllCancelledOrders(loginCheckResponse.userId, "Admin");
            return View(myList);
        }
        public IActionResult RecieptsA()
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
        public IActionResult PaymentsA()
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

        public void NotifyUser(int userid, string orderId) { 
                    string serverKey = _config.GetValue<string>("FCMConfig:ServerKey");
            string senderID = _config.GetValue<string>("FCMConfig:SenderID");
            var userInfo=_uService.APIGetUserByID(userid);
         
           FCM notifyUser= new FCM(serverKey, senderID, userInfo.DeviceId) ;
            notifyUser.SendNotification("Order Cancelled ","Successfully Cancelled the order "+orderId + " will notify further updates","Order Cancellation");
         //   return StatusCode(200, new { status = 1, message = "Payment Success" });
        }
        

        public IActionResult APICancellOrder(int userid, int orderId)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                POMasterEntity request = new POMasterEntity();
                request = _ordService.GetPoMasterbyId(orderId);
                request.IsDeleted = true;
                request.OrderStatus = "Cancelled";
                response = _ordService.UpdatePOMasterStatus(request);

                NotifyUser(userid, request.InstrumentDetails);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
                return Json(new { status = 0, message = "Failed Operation" });

            }

            return Json(new { status=1 , message="Cancelled Order",result = response });
        }

        
        public IActionResult CancellOrder(int orderId)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                POMasterEntity request = new POMasterEntity();
                request = _ordService.GetPoMasterbyId(orderId);
                request.IsDeleted = true;
                request.OrderStatus = "Cancelled";
                response = _ordService.UpdatePOMasterStatus(request);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Delete";
            }

            return Json(new { result = response });
        }

        public IActionResult UpdatePOStaus(int orderId, string status, string remarks = "", int userid=0)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                POMasterEntity request = new POMasterEntity();
                request = _ordService.GetPoMasterbyId(orderId);
                request.IsDeleted = false;
                if(status == "Delivered")
                {
                    request.OrderStatus = "Closed";
                }
                else
                {
                    request.OrderStatus = status;
                }
                
                response = _ordService.UpdatePOMasterStatus(request);
                // place an entry in followup
                POFollowUpEntity pfo = new POFollowUpEntity();
                pfo.FollowUpBy = userid;
                pfo.FollowUpOn = DateTime.Now;
                pfo.FollowUpRemarks = remarks;
                pfo.IsDeleted = false;
                pfo.PODetialId = 0;
                pfo.POId = orderId;
                _pService.SaveFollowUp(pfo);
                //send emails
                _nService.SendOrderUpdateEmail(userid, orderId, status);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to Update";
            }

            return Json(new { result = response });
        }



        // users
        public IActionResult AllUsers()
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
            List<UserMasterDisplay> myList = new List<UserMasterDisplay>();
            myList = _uService.GetAllUsers("All");
            return View(myList);
        }

        public IActionResult ViewOrder(int id = 0)
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

            POMasterEntity po = _uService.GetPoMasterById(id);
            PODetailsEntity pd = _uService.GetPoDetailByMasterIdId(po.POId);
            PostProductModel_Web product = _pService.GetProductDetails_Web((int)pd.ProductId);
            product.ProductDetails = product.ProductDetails.Where(a => a.ProductDetailId == pd.ProductDetailId).ToList();
            ProductDisplayForAdmin myobject = new ProductDisplayForAdmin();
            myobject.folloup = _pService.GetPOFollowups(po.POId);
            myobject.po = po;
            myobject.pd = pd;
            myobject.product = product;
            return View(myobject);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(string remarks, int poid,int cuserid, string status)
        {
            ProcessResponse resp = new ProcessResponse();
            try
            {
                POMasterEntity po = _uService.GetPoMasterById(poid);
                po.OrderStatus = status;
                var r = _uService.SavePOMaster(po);
                POFollowUpEntity poF = new POFollowUpEntity();
                poF.FollowUpBy = cuserid;
                poF.FollowUpOn = DateTime.Now;
                poF.FollowUpRemarks = remarks;
                poF.PODetialId = 0;
                poF.POId = poid;
                var s = _pService.SaveFollowUp(poF);
                // send email
                var e = _nService.SendOrderUpdateEmail((int)po.UserId, po.POId, status);
                    
            }
            catch(Exception ex)
            {

            }
            return Json(new { result = resp });
        }


        public IActionResult CODPayment(int pid=0)
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
           
            CODPaymentUpdateModel cm = new CODPaymentUpdateModel();
            POMasterEntity pm = new POMasterEntity();
            pm = _uService.GetPoMasterById(pid);
            ViewBag.PM = pm;
            return View(cm);
        }
        [HttpPost]
        public IActionResult CODPayment(CODPaymentUpdateModel request)
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
            if(ModelState.IsValid)
            {
                var res = _uService.UpdateCODPayment(request);
                if(res.statusCode ==1)
                {
                    return RedirectToAction("ViewOrder", new {id=request.POId });
                }
            }
            POMasterEntity pm = new POMasterEntity();
            pm = _uService.GetPoMasterById(request.POId);
            ViewBag.PM = pm;
            return View(request);
        }


        public IActionResult CustomizedOrders()
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

            List<CustomizedOrderModel> myList = new List<CustomizedOrderModel>();
            myList = _ordService.GetCustomizedOrders();
            return View(myList);
        }
    }
}
