using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
    public interface IUserMgmtService
    {
        ProcessResponse APIDeleteAddress(AddressEntity ae);
        ProcessResponse APIUpdateAddressSetDeliver(AddressEntity ae);
        List<AddressModel> APIGetAddressbyId(int id);
        int GetLoginType(string code);
        ProcessResponse SocialRegisterUser(UserMasterEntity userMaster);
        ApiResponse<LoginResponse> SocialLoginCheck(LoginRequest request);
        APIUser APIGetUserByID(int userid);
        ProcessResponse APISaveAddress(AddressEntity ae);
        ProcessResponse APIUpdateAddress(AddressEntity ae);
        List<APIProductListDisplay> StockDetails(int userid, string url);
        bool ProductSizeUpdate(int productid, int userid, int sizeid);
        ProcessResponse APIPostReview(UserReviewMaster userReviewMaster);
        ProcessResponse APIDeleteWishList(int id, int userid);
        ProcessResponse UpdateCODPayment(CODPaymentUpdateModel request);
        ProcessResponse SaveRazorPaymentResult(RazorPaymentResultEntity request);
        PODetailsEntity GetPoDetailByMasterIdId(int id);
        UserMasterProfile GetMyProfile(int id);
        List<WishListModel> GetMyWishList(int userid);
        List<WishListModel> APIGetMyWishList(int userid, string url);

        ProcessResponse AddToWishList(WishListEntity request);
        ProcessResponse DeleteWishList(int id);
        ProcessResponse UpdateCartDetails(CartDetailsEntity request);
        CartMasterEntity GetCartById(int id);
        PODetailsEntity GetPoDetailById(int id);
        CartDetailsEntity GetCartDetailById(int id);
        ProcessResponse UpdateCartMaster(CartMasterEntity request);
        bool EmailAvailablityCheck(string emailId);
        bool MobileAvailablityCheck(string mobileNumber);
        List<UserMasterDisplay> GetAllUsers(string type);
        void UpdatePassword(UserMasterEntity request);
        ProcessResponse UpdateUser(UserMasterEntity request);
        void UpdateUserMaster(APIUser request);
        APIUser GetUserByEmail(string email);
        IQueryable<UserTypeMasterEnity> GetUserTypes();
        UserTypeMasterEnity GetUserTypeById(int id);

        ProcessResponse RegisterUser(UserMasterEntity userMaster);

        UserMasterEntity GetUserById(int userId);

        ApiResponse<LoginResponse> LoginCheck(LoginRequest request);

        OtpTransactionsEntity GetOTPInformation(int userId);
        ProcessResponse SaveOtpInformation(OtpTransactionsEntity request);
        ProcessResponse UpdateOtpInformation(OtpTransactionsEntity request);
        ProcessResponse SendRegistrationEmail(string moduleName, string toEamil, string userName,
           int userId);
        ProcessResponse SaveUserVerification(UserVerificationEntity request);


        ProcessResponse InitiateResetPassword(string emailId);
        ProcessResponse CompletePasswordRequest(string key);

        ProcessResponse UpdatePassword(LoginCheckRequest request);

        int GetUserCartCount(int userId);

        ProcessResponse AddToCart(CartDetailsModel requst, int userId);
        ProcessResponse DeleteFromCart(int detId);
        ProcessResponse APIDeleteFromCart(int userid, int productid);
        ProcessResponse APIDecrementFromCart(int userid, int productid);
        ProcessResponse UpdateCart(CartDetailsModel request);

        UserCartModel GetMyCart(int userId);

        ProcessResponse SavePOMaster(POMasterEntity request);
        POMasterEntity GetPoMasterById(int id);

        ProcessResponse SavePODetails(PODetailsEntity request);

        ProcessResponse SaveAddress(AddressEntity userMaster);
        ProcessResponse UpdateAddress(AddressEntity userMaster);
        List<UserAddressListModel> GetAllAddress(int userId);
        AddressModel GetAddressbyId(int id);
        ProcessResponse SaveContactUs(ContactUs contactUs);
        LoginResponse IsValidUser(string emailId);
        List<SubCategory> APIGetMenuSubCat(string urlhost);
        List<Category> APIGetMenuCat(string urlhost);
        CartDetailsEntity IsProdcutInCart(int userid, int productid);
    }
}
