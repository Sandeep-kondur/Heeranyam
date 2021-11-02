using Ecommerce.Models;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.Entity;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http.Headers;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotificationService _nService;
        private readonly IProductManagementService _pService;
        private readonly IMasterDataMgmtService _mService;
        private readonly ICommonService _cServce;
        private readonly IOtherMgmtService _oServce;
        private readonly IUserMgmtService _uService;
        private readonly IConfiguration _config;
        private readonly IOrderMgmtService _ordService;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, IProductManagementService pService,
            ICommonService cService,
            IMasterDataMgmtService mService, IUserMgmtService uService, IOtherMgmtService oService, 
            INotificationService nService,
            IOrderMgmtService ordService)
        {
            _logger = logger;
            _pService = pService;
            _cServce = cService;
            _mService = mService;
            _uService = uService;
            _oServce = oService;
            _nService = nService;
            _config = config;
            _ordService = ordService;
        }

        public IActionResult Index()
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
            HomeProductsModels myObj = new HomeProductsModels();

            myObj.allGold = _pService.GetLatestProducts("AG");
            myObj.featured = _pService.GetLatestProducts();
            myObj.hotDeals = _pService.GetLatestProducts("HT");
            myObj.newArrivals = _pService.GetLatestProducts();
            myObj.mainMenus = _cServce.GetMainMenu();
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
           
            return View(myObj);
        }



        public IActionResult APIAboutUS() {

            string abouthtml = @"< section  > <div  >
        <div  ><div > <div ></div></div><div ><h4  >Who We Are?</h4>
                <p>Heeranyam has been a fast-growing online e-commerce jewellery store that started its journey in 2021, under the patronage of Hiranya India Jewels Pvt Ltd.a leading brand in precious jewellery in India.With more than a decade of experience in the exquisite class of jewellery, Hiranya has become a renowned brand in India. </p>
                <h4  >At Heeranyam, We Are Committed To You! </h4>
                <p>Right from manufacturing to wholesale deals on gorgeous jewellery items, Hiranya has come along a long distance to become a household name in India.With a strong desire to make fascinating jewellery items available to everyone, we have been busily engaged in finding top deals at a manageable cost.However, we are very pertinent when it comes to maintaining the standard of our products.We have been successful in creating waves among jewellery lovers from everywhere.Our online availability has revolutionized the market in India. </p>
                <p>Our destination is extending fast as we target the potential market to impress global customers with the fascinating Indian jewellery!  We pay a close look at every detail for a vast array of attractive jewellery items.Our team of experts is dedicated to make Heeranyam a global brand from India! </p>
            </div></div></div></section>
            < section  ><div  ><h4>Heeranyam Online Jewellery Store: </h4><p>A name to celebrate in the near future! Heeranyam has the potential to bring exclusive jewellery items in gold, silver, platinum, diamond, and other gemstones to those who love to adorn them with beautiful items.The idea of going online was not new! Rather, we had a long-term goal for everyone at Hiranya India Jewels Pvt Ltd. </p>
        <p>Our online store has numerous jewellery items that our clients can buy on their willpower.A fully automated website cannot embarrass customers at any point in time.We guarantee smooth deliveries after all the formalities are complete.We ensure successful deliveries to every order that we receive.Our deliveries reach the customers’ place through recognized courier agencies that have worldwide recognition for their deliveries. </p>
    </div></section>";
           return Json(new {  status=1,message="aboutus",aboutus = abouthtml });
    }
        public IActionResult APITermsAndConditions() {

            string termsandconditions = @"<section class='about - us section - padding'>
        < div class='container'>
        <h4 class='about-sub-title'>HEERANYAM-PRIVACY POLICY</h4>
        <h4>Privacy Policy: </h4>
        <p>Heeranyam Jewellery Online Store hereby declares that we take the privacy matters of the customers very seriously.We request you to read this Privacy statement very carefully as it contains vital information about the things you should expect when we collect your personal information. We appreciate all your concerns, including how we will use your personal data and the steps that we take to ensure it is safe from any abuse.</p>
        <p>Heeranyam Jewellery Online Store shall use and take care of all personal data and information in accordance with data safety regulations and protocols related to the processing of personal data and privacy, including but not limited to the General Data Protection Regulation. We are responsible as ‘controller’ of the personal information of every client for the purposes of those laws.</p>
        <p>We follow our privacy policy with the utmost sincerity so that our clients can live with complete peace of mind.  We wish you to reach every statement carefully before you continue shopping with us!  </p>
        <h4>Collection of Personal Information: </h4>
        <ul>
            <li style = 'list-style-type: disc;margin-left: 40px;' > This statement validates the process that we use to collect the personal information of the customers.This information includes Name, Address, Email, and Phone Number.Here, the phone number should be used while registering the customer on our website or using the Mobile APP.Additionally we look for additional information such as location, network carrier, and device the client is using to browse.</li>
            <li style = 'list-style-type: disc; margin-left: 40px;' > The solitary purpose of this activity is to sync customer preference and wish lists to serve them better and provide better recommendations based on their previous buying behavior, habit, and browsing history.</li>
            <li style = 'list-style-type: disc; margin-left: 40px;' > We would also like to use a disclaimer here that we will be sharing the above information with our vendor (Third Party) in order to process a purchase.This is done in order to personalize the app and performing behavioral analytics</li>
            </ul>
        <p>At Heeranyam Jewellery Online Store, our primary purpose is to collect individual information. This aims at providing you with a benign, flawless, well-organized, larger customized online experience. Your consent to use the information would mean that you agree that we may use your personal information to:</p>
        <ul>
            <li style = 'list-style-type: disc; margin-left: 40px;' > Apply our Terms and Conditions</li>
            <li style = 'list-style-type: disc; margin-left: 40px;' > Notify you about our products, services, and promotional offers</li>
                <li style = 'list-style-type: disc; margin-left: 40px;' > Modify, measure, and recover our services and content</li>
            <li style = 'list-style-type: disc; margin-left: 40px;' > Gather and process payments and complete dealings</li>
            <li style = 'list-style-type: disc; margin-left: 40px;' > Deliver the products, services, and customer support you request</li>
                <li style = 'list-style-type: disc; margin-left: 40px;' > Resolve problems</li>
                <li style = 'list-style-type: disc; margin-left: 40px;' > Stop hypothetically forbidden or unlawful actions</li>
                <li style = 'list-style-type: disc; margin-left: 40px;' > Solve disagreements</li>
            </ul>
        <h4>2. Collection of Payment & Billing Information</h4>
        <p>We will collect the preferred payment information of the customer. This information would include billing name, billing address, and payment mode.Here, we would like to mention that we do not collect personal banking information such as your Bank Account, Credit or Debit Card Number, PayPal Account Details or Net banking Details or CVV details, or any other payment instrument one is using to pay the purchased item.Instead, we route such information directly to the preferred payment gateways. We consider it 100% secure in nature. </p>
        <h4>3. Usage of Information That We Collect From You </h4>
        <ul>
            <li style = 'list-style-type: disc; margin-left: 40px;' > Refining the overall service that we provide to our customers</li>
            <li style = 'list-style-type: disc; margin-left: 40px;' > Using this information for communication purposes using different mediums such as Email/SMS/Calling for updates regarding your purchase, new arrival, new update related to service, branding, and other marketing-related activity. </li>
           </ul>
        <h4>4. Your Consent is the Key</h4>
        <p>We value your consent at most! We look for your consent and written permission to obtain this. Our customers are free to edit, remove, or delete all information and credentials provided by them while visiting our website or using our mobile application/platform specifically while signing in or logging in to our website/ application/platform.The decision is entirely personal and we would never interfere with it.However, we always encourage them to talk to us if they have any queries or issues.We can talk and sort out the issues. To do this, the clients can always connect with our customer support team to seek specialist help and then proceed accordingly.</p>
        <h4>5. Use of Cookies on Website</h4>
        <p>As an essential part of the business websites or other website operators, Heeranyam Jewellery Online Store may also use standard technology called ‘cookies’ on this site.These are small programs or pieces of information that your browser stores on the hard drive of your computer system.  Our cookies help us with valuable information that we use to understand our customers and their behavior on the website once they visit us. We get to know who has seen which pages and advertisements. </p>
        <p>The cookies help us to determine how frequently particular pages are visited by particular customers.It also brings us potential information as to how to determine the most popular areas of the website.Our cookies also enable us to enhance your visitor experience by storing information about the products and services that you select between visits so that we can provide you with focused information each time you visit our website.</p>
        <p>Most popular web browsers inevitably admit cookies, but you can usually change your browser settings to prevent cookies from getting stored on your system.However, if you do turn cookies off, then you would not be able to get full access to the website.Turning off the cookies will limit the service that we are able to provide you.</p>
        <p>Our cookies do not stock delicate information such as your name, address, or payment details.Instead, they simply hold the ‘key’, once you sign in, or get associated with this information.However, if you like to restrict, block, or delete cookies from our websites, or any other website, then you can use the options available with the browser. Since all the browsers are different, therefore you would need to check the ‘Help’ menu of your particular browser.You can learn how to change your cookie preferences.</p>
        <h4>6. Security & Storage Procedure</h4>
        <p>Heeranyam Jewellery Online Store has potential reasons and methods for storing your personal information. We transmit information via the highest industry standard secure server (SSL). This SSL creates a secure and encrypted website URL.When you see the https:// website address, you may consider that information you are providing is safe and secured.</p>
        <p>Heeranyam Jewellery Online Store has applied and upheld usually recognized standards to protect against the illegal access, usage, alteration, obliteration, or disclosure of your personal information. The safety of your private information is important to us.When you enter sensitive information during the registration process, we encrypt that information using state-of-the-art technology. </p>
        <p>Heeranyam Jewellery Online Store guarantees you that we will use your secluded information only for the purposes stated in this Privacy Policy. We will not rent or sell your personal information to unauthorized third parties.Additionally, we will avoid your email address from being recorded by web robots to the best of our ability. If you have found that your email address has been chronicled in this way, please let us know immediately.</p>
        <p>The time periods for which we recall your private information depend on the determinations for which we use it.We will keep the information for as long as you are a registered user of our products. </p>
        <h4>7. Children Privacy and Parental Consent</h4>
        <p>This site is meant for some with ages above 18 years.We do not take or collect information from some below 18 years knowingly or to the best of our knowledge.In circumstances where we take information from someone below 18 years, we will not share such data with any third party for further use without the consent of the parents. </p>
        <h4>8. Not Responsible for Other Website</h4>
        <p>Heeranyam Jewellery Online Store is not responsible for other websites which you are redirected to from our page. We are solely responsible for our website and its privacy policy.</p>
        <h4>9.  Prohibited Use </h4>
        <p>As a condition of your use of the website/mobile application/ platform, you agree that you will not use this website/mobile application or the information or software contained herein for any purpose that is unlawful or prohibited by these terms and conditions.</p>
        <h4>10. Linked Service </h4>
        <p>Our website is embedded with social media platforms such as Facebook, Instagram, Twitter, Pinterest, LinkedIn, or any other social media platform. We are not bound by their privacy policy and their policy may vary as per their own standard. Heeranyam is not responsible for their policy. </p>
        <h4>11. Disclaimer</h4>
        <p>Though we put take all possible efforts to safeguard the customer data and information using our website or mobile application, we deny all accountability for any kind of liabilities for error, omission, and any inadequacies of information contained.Website data are subject to change as per the standard procedure we are not liable for any notification for such changes made on our website/Mobile App.</p>
        <p>We hereby declare that your use of our website is completely at your own risk.One should not keep us accountable for any issue which we are not responsible for and should not sue on using a website. </p>
        <p>The information, documentation, software, products, and services contained on the website/mobile application/platform are provided “as is” without any warranty of any kind. </p>
        <p>We shall not be liable for damages, whether direct, indirect, special, incidental, or consequential, as a result of the reproduction, modification, distribution, or use of the information, documentation, software, products, and services.</p>

    </div>
</section>";
            string tandc = "HEERANYAM-PRIVACY POLICY Privacy Policy:Heeranyam Jewellery Online Store hereby declares that we take the privacy matters of the " +
                "customers very seriously.We request you to read this Privacy statement very carefully as it contains vital" +
                " information about the things you should expect when we collect your personal information.We appreciate all your concerns,   " +
                "             including how we will use your personal data and the steps that we take to ensure it is safe from any abuse.";
            return Json(new { status = 1, message = "aboutus", tandc = termsandconditions });

        }

        [HttpPost]
        public IActionResult APIContactus(ContactUs request)
        {

            return Json(new { status = 1, message = "contactus" , notify= "Thank you "+request.Name +" for contacting us our " +
                "team will be looking into it and reach out to you."});

        }

        [HttpGet]
        public IActionResult APIGetMenu()
        {
            var urlhost = HttpContext.Request.Host.Value;
            Categories categories = new Categories();
            List<Category> lstCategory = new  List<Category>();
            //string urlhost = Path.Combine(Directory.GetCurrentDirectory(), "WWWROOT\\icons");
            lstCategory.Add(new Category() { Name = "Rings", ParentMenuId = 0, Id = 1, Permitted = true ,Image= urlhost + @"\icons\rings.png",
                SubCategory= new List<SubCategory>(){
                    new SubCategory(){ Name = "Home Made Rings", ParentMenuId = 1, Id = 9, Permitted = true, Image = urlhost + @"\icons\rings.png" } ,
                    new SubCategory(){ Name = "Hookup Bands", ParentMenuId = 1, Id = 10, Permitted = true, Image = urlhost + @"\icons\rings.png" }

                }
            });
            lstCategory.Add(new Category() { Name = "EarRings", ParentMenuId = 0, Id = 2, Permitted = true, Image = urlhost  + @"\icons\earrings.png",
                SubCategory = new List<SubCategory>(){
                    new SubCategory(){ Name = "Fancy EarRings", ParentMenuId = 2, Id = 11, Permitted = true, Image = urlhost + @"\icons\rings.png",
                    SubCategories= new List<SubCategory>(){ 
                    new SubCategory(){ Name = "Fancy EarRings", ParentMenuId = 11, Id = 12, Permitted = true, Image = urlhost + @"\icons\rings.png"}
                    } } 

                }
            });
            lstCategory.Add(new Category() { Name = "Chains", ParentMenuId = 0, Id = 4, Permitted = true, Image = urlhost + @"\icons\pendants.png" });
            lstCategory.Add(new Category() { Name = "Bangles", ParentMenuId = 0, Id = 5, Permitted = true, Image = urlhost + @"\icons\bangles.png" });
            lstCategory.Add(new Category() { Name = "Bracelets", ParentMenuId = 0, Id = 6, Permitted = true, Image = urlhost + @"\icons\bracelets.png" });
            lstCategory.Add(new Category() { Name = "All Gold", ParentMenuId = 0, Id = 7, Permitted = true, Image = urlhost + @"\icons\allgold.png" });
            lstCategory.Add(new Category() { Name = "Contact Us", ParentMenuId = 0, Id = 8, Permitted = true, Image = urlhost + @"\icons\contactus.png" });
            //lstCategory.Add(new Category() { Name = "Home Made Rings", ParentMenuId = 1, Id = 9, Permitted = true, Image = urlhost + @"\rings.png" });
            //lstCategory.Add(new Category() { Name = "Hookup Bands", ParentMenuId = 1, Id = 10, Permitted = true, Image = urlhost + @"\rings.png" });
            //lstCategory.Add(new Category() { Name = "Fancy EarRings", ParentMenuId = 2, Id = 11, Permitted = true, Image = urlhost + @"\rings.png" });
            //lstCategory.Add(new Category() { Name = "Fancy EarRings", ParentMenuId = 11, Id = 12, Permitted = true, Image = urlhost + @"\rings.png" });
            categories.Category = lstCategory;

           return Json(new {  status=1,message="Menu" , category = lstCategory });
            
        }

        public bool SaveProfilePicture(string emailId , string userName) 
        {
            try
            {
               string path=  HttpContext.Request.Host.Value + @"\UserImages\";//server path
                if (Request.Form.Files[0] != null)
                {
                    var file = Request.Form.Files[0];
                    string contenttype = file.FileName.Split('.').Count() > 1 ? file.FileName.Split('.')[1] : "";
                    var folderName = Path.Combine("WWWROOT", "UserImages");
                    //to test locally
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, userName+"."+ contenttype);
                        // var dbPath = Path.Combine(folderName, fileName);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            return true;
                    }
                    else
                    {
                        return true;
                    }
                }
              
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadProfilePicture()
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
                    return StatusCode(401, "Invalid User, Please try log in with proper User Details");
                }
                SaveProfilePicture(loginCheckResponse.emailId.Split('.')[0].ToString(), loginCheckResponse.userName);

            }
            catch (Exception)
            {

                return StatusCode(501,"Error While Processing Upload Profile Picture");
            }

            return Ok();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        public IActionResult Listing(int cid = 0, int sid = 0, int did = 0, int pageNumber = 1,
            int pageSize = 10, string search = "", decimal price = 0, int metalid = 0,
            string gender = "", int discountid = 0, bool isFA = false)
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

            HomeProductsModels myObj = new HomeProductsModels();
            List<SubCategoryMasterEntity> subCatDrop = new List<SubCategoryMasterEntity>();
            List<DetailCategoryMasterEntity> detCatDrops = new List<DetailCategoryMasterEntity>();
            List<CategoryMasterEntity> catDrops = new List<CategoryMasterEntity>();
            PaginationRequest pr = new PaginationRequest();
            GenericRequest gr = new GenericRequest();
            gr.pageNumber = 1;
            gr.pageSize = 1000;
            pr.pageNumber = 1;
            pr.pageSize = 1000;
            catDrops = _oServce.GetAllCategories(pr);
            if (isFA)
            {
                string q1 = @"select pm.CategoryId, pm.ProductDescription, cat.CategoryName CategoryId_name, pm.DetailCategoryId, dcat.DetailCategoryName DetailCategoryId_name,
                            pm.ProductId, pm.DiscountApplicableId, pm.DiscountApplicableId DiscountMasterId,
                            pm.IsCustomizable, pm.IsSizeApplicable, pm.MaxDelivaryDays, pm.PostedBy, pm.PostedOn, pm.ProductTitle,
                            pm.SubCategoryId, scat.SubCategoryName SubCategoryId_name,
                            (select top(1) ImageUrl from ProductImages where ProductImages.ProductId = pm.ProductId) ProductMainImages_List,
                            (select top(1) pd.ActualPrice from ProductDetails pd where pd.ProductId = pm.ProductId) ActualPrice,
                            (select top(1) pd.SellingPrice from ProductDetails pd where pd.ProductId = pm.ProductId) SellingPrice
                            from ProductMaster pm
                            join CategoryMaster cat on pm.CategoryId = cat.CategoryId
                            join SubCategoryMaster scat on pm.SubCategoryId = scat.SubCategoryId
                            join DetailCategoryMaster dcat on pm.DetailCategoryId = dcat.DetailCategoryId
                            join ProductDetails pdet on pm.ProductId = pdet.ProductId
                            join MetalMaster mm on pdet.metalmasterid = mm.MasterId
                            join DiscountMaster dm on pm.DiscountApplicableId = dm.dmasterid 
                            where pm.IsDeleted = 0 ";
                string q2 = string.Empty;
                if (price != -1)
                {
                    q2 = " and SellingPrice < " + price.ToString();
                }
                if (metalid > 0)
                {
                    q2 += " and mm.MasterId = " + metalid;
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    q2 += " and pm.PrefferedGender = '" + gender + "'";
                }
                if (discountid > 0)
                {
                    q2 += " and pm.DiscountApplicableId = " + discountid;
                }
                int skipSize = pageNumber == 1 ? 0 : (pageNumber - 1) * pageSize;
                string q3 = " order by pm.postedon desc offset " + skipSize + " rows fetch next " + pageSize + " rows only";
                q1 = q1 + q2 + q3;
                myObj.listProducts = _pService.GetProductsByFilter(q1);


                string countQ = @"select count(pm.CategoryId) as cnt
                            from ProductMaster pm
                            join CategoryMaster cat on pm.CategoryId = cat.CategoryId
                            join SubCategoryMaster scat on pm.SubCategoryId = scat.SubCategoryId
                            join DetailCategoryMaster dcat on pm.DetailCategoryId = dcat.DetailCategoryId
                            join ProductDetails pdet on pm.ProductId = pdet.ProductId
                            join MetalMaster mm on pdet.metalmasterid = mm.MasterId
                            join DiscountMaster dm on pm.DiscountApplicableId = dm.dmasterid 
                            where pm.IsDeleted = 0 ";
                string countQF = countQ + " " + q2;
                myObj.totalRecords = _pService.GetProductsByFilter_count(countQF);
            }
            else
            {
                if (!string.IsNullOrEmpty(search))
                {
                    myObj.listProducts = _pService.GetProductsBySearch(cid, pageNumber, pageSize, search);
                    myObj.totalRecords = _pService.GetProductsBySearch_count(cid, pageNumber, pageSize, search);
                }
                else if (cid > 0)
                {
                    myObj.listProducts = _pService.GetProductsByCatId(cid, pageNumber, pageSize, search);
                    myObj.totalRecords = _pService.GetProductsByCatId_Count(cid, pageNumber, pageSize, search);

                }
                else if (did > 0)
                {
                    myObj.listProducts = _pService.GetProductsByDetId(did, pageNumber, pageSize, search);
                    myObj.totalRecords = _pService.GetProductsByDetId_Count(did, pageNumber, pageSize, search);

                }
            }
            gr.Id = cid;
            subCatDrop = _oServce.GetAllSubCategories(gr);
            gr.Id = sid;
            detCatDrops = _oServce.GetAllDetailCategories(gr);

            ViewBag.TotalCount = myObj.totalRecords;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.search = search;
            ViewBag.cid = cid;
            ViewBag.did = did;
            ViewBag.sid = sid;
            ViewBag.price = price;
            ViewBag.metalid = metalid;
            ViewBag.gender = gender;
            ViewBag.discountid = discountid;
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);

            // for filters drop downs

            List<MetalMasterEntity> metalDrop = _mService.GetMetalMaster(pr, "List");

            StaticDropDowns staticDrops = new StaticDropDowns();
            List<DiscountMasterEntity> discDrops = _mService.GetAllDiscounts(gr);

            myObj.detCatDrops = detCatDrops;
            myObj.subCateDrop = subCatDrop;
            myObj.catDrops = catDrops;
            myObj.staticDrops = staticDrops;
            myObj.metalDrop = metalDrop;
            myObj.discDrops = discDrops;

            return View(myObj);
        }

        public IActionResult Product(int pid = 0, int pdid = 0)
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
            if (pid < 1)
            {
                return RedirectToAction("Listing");
            }
            List<SizeMasterEntity> sizes = new List<SizeMasterEntity>();
            GenericRequest gr = new GenericRequest();

            PostProductModel_Web product = _pService.GetProductDetails_Web(pid);
            gr.Id = (int)product.CategoryId;
            sizes = _mService.GetAllSizes_Web(gr);
            List<SizeMasterForDeailPage> mySizes = new List<SizeMasterForDeailPage>();
            mySizes = _mService.GetSizesForDetailPage(pid);
            product.Sizes = sizes;
            product.MySizes = mySizes;

            if (product.ProductDetails.Count > 0)
            {
                if (pdid > 0)
                {
                    product.ProductDetails = product.ProductDetails.Where(a => a.ProductDetailId == pdid).ToList();
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
                PriceBreakUpModel pm = new PriceBreakUpModel();
                pm.DaimondRate = daimondRate;

                pm.GoldRate = goldRate;
                pm.GST = (decimal)product.GST[0].GSTTaxValue * goldRate / 100;
                pm.MakingCharges = (decimal)product.ProductDetails[0].MakingCharges;
                pm.discount = (decimal)product.DiscountAmount * pm.MakingCharges / 100;
                pm.totalAmount = (daimondRate + goldRate + pm.MakingCharges + pm.GST) - pm.discount;
                pm.oldAmount = daimondRate + goldRate + pm.GST + pm.MakingCharges;
                product.priceBreakup = pm;

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);

            return View(product);
        }

        public PartialViewResult RenderMenu()
        {
            return PartialView(_cServce.GetMainMenu());
        }


        [HttpPost]
        public IActionResult AddToCart(int userId, int productId, int detailId, int qty, int numberOfItems = 1)
        {
            ProcessResponse response = new ProcessResponse();
            CartDetailsModel pd = new CartDetailsModel();
            pd.ProductId = productId;
            pd.ProductDetailId = detailId;
            pd.NumberOfItems = numberOfItems;

            PostProductModel_Web product = _pService.GetProductDetails_Web(productId);
            PriceBreakUpModel pm = new PriceBreakUpModel();
            decimal goldOriginalRate = 0;
            if (product.ProductDetails.Count > 0)
            {
                if (detailId > 0)
                {
                    product.ProductDetails = product.ProductDetails.Where(a => a.ProductDetailId == detailId).ToList();
                }
                else
                {
                    detailId = product.ProductDetails[0].ProductDetailId;
                }
                decimal goldWeight = (decimal)product.ProductDetails[0].ProductWeight;
                goldOriginalRate = (decimal)product.GoldRate.Rate;
                decimal goldKaratPercentatge = (decimal)product.MetalMaster.Where(a => a.MasterId == product.ProductDetails[0].MetalMasterId).Select(b => b.PriceCalPercentage).FirstOrDefault();
                decimal goldRate = goldWeight * ((goldOriginalRate * goldKaratPercentatge) / 100);

                decimal daimondRate = 0;
                if (product.ProductDetails[0].DaimondsMain != null)
                {
                    decimal individualPrice = 0;
                    foreach (var v in product.ProductDetails[0].DaimondsDetail)
                    {
                        decimal dmPrice = (decimal)product.DiamondRate
                            .Where(a => a.MasterId == v.DaimondTypeId).Select(b => b.PriceTag).FirstOrDefault();
                        individualPrice += (decimal)v.TotalWaight * dmPrice;
                        daimondRate += individualPrice;
                    }
                }

                pm.DaimondRate = daimondRate;

                pm.GoldRate = goldRate;
                pm.GST = (decimal)product.GST[0].GSTTaxValue * goldRate / 100;
                pm.MakingCharges = goldRate * 10 / 100;
                pm.discount = (decimal)product.DiscountAmount * pm.MakingCharges / 100;
                pm.totalAmount = (daimondRate + goldRate + pm.MakingCharges + pm.GST) - pm.discount;
                pm.oldAmount = daimondRate + goldRate + pm.GST + pm.MakingCharges;
                product.priceBreakup = pm;

            }
            pd.MetalMasterId = product.ProductDetails[0].MetalMasterId;
            pd.MetalMasterId_Name = product.ProductDetails[0].MetalMasterId_Name;
            pd.GoldPrice = goldOriginalRate;
            pd.GoldRate = pm.GoldRate;
            pd.SizeId = (int)product.ProductDetails[0].SizeMasterId;
            pd.SizeName = product.ProductDetails[0].SizeMasterId_name;
            pd.GoldWeight = (int)product.ProductDetails[0].MetalWeight;
            pd.CurrentStatus = "Open";
            pd.DaimondPrice = pm.DaimondRate;
            pd.Discount = pm.discount;
            pd.GST = pm.GST;
            pd.MakingCharges = pm.MakingCharges;
            pd.NumberOfItems = numberOfItems;
            pd.OldPrice = pm.oldAmount;
            pd.ProductDetailId = detailId;
            pd.ProductId = productId;
            pd.ProductTitle = product.ProductTitle;
            pd.TotalPrice = pm.totalAmount;
            pd.AddedOn = DateTime.Now;
            response = _uService.AddToCart(pd, userId);
            ViewBag.CartCount = _uService.GetUserCartCount(userId);
            response.cartcount = ViewBag.CartCount;

                        RenderCart(userId);
            return Json(new { result = response });
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                response = _uService.DeleteFromCart(id);
            } catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to delete";
            }
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);

            return Json(new { result = response });
        }


        public IActionResult MyCart(int productId)
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            UserCartModel myObject = new UserCartModel();
            myObject = _uService.GetMyCart(loginCheckResponse.userId);
            return View(myObject);
        }

        public PartialViewResult RenderCart(int id)
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            return PartialView(_uService.GetMyCart(id));
        }

        public IActionResult CheckOut()
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            UserCartModel myObject = new UserCartModel();
            myObject = _uService.GetMyCart(loginCheckResponse.userId);
            // create order
            //string rKey = _config.GetValue<string>("OtherConfig:RazorKey");
            //string rSecret = _config.GetValue<string>("OtherConfig:RazorSecret");
            //Random randomObj = new Random();
            //string transactionId = randomObj.Next(10000000, 100000000).ToString();
            //Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(rKey, rSecret);
            //Dictionary<string, object> options = new Dictionary<string, object>();
            //int toPayAmount = (int)((myObject.CartDetails.Sum(b => b.TotalPrice) + myObject.CartDetails.Sum(b => b.BankTax) + myObject.CartDetails.Sum(b => b.BankChareges)) * 100);
            //options.Add("amount", toPayAmount);
            //options.Add("receipt", transactionId);
            //options.Add("currency", "INR");
            //options.Add("payment_capture", "0");

            //Razorpay.Api.Order orderResponse = client.Order.Create(options);
            //string orderId = orderResponse["id"].ToString();
            //OrderModel orderModel = new OrderModel
            //{
            //    orderId = orderResponse.Attributes["id"],
            //    address = myObject.CustomerAddress,
            //    amount = toPayAmount,
            //    contactNumber = myObject.CustomerMobile,
            //    currency = "INR",
            //    description = "Purchase of items",
            //    email = myObject.CustomerEmail,
            //    name = myObject.CustomerName,
            //    razorpayKey = rKey
            //};
            //myObject.orderModel = orderModel;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "currentOrder", myObject);
            return View(myObject);
        }

         
        public IActionResult CreateOrder()
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);


            UserCartModel myObject = SessionHelper.GetObjectFromJson<UserCartModel>(HttpContext.Session, "currentOrder");
            // create order
            string rKey = _config.GetValue<string>("OtherConfig:RazorKey");
            string rSecret = _config.GetValue<string>("OtherConfig:RazorSecret");
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(rKey, rSecret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            int toPayAmount = (int)((myObject.CartDetails.Sum(b => b.TotalPrice) + myObject.CartDetails.Sum(b => b.BankTax) + myObject.CartDetails.Sum(b => b.BankChareges)) * 100);
            options.Add("amount", toPayAmount);
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0");

            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();
            OrderModel orderModel = new OrderModel
            {
                orderId = orderResponse.Attributes["id"],
                address = myObject.CustomerAddress,
                amount = toPayAmount,
                contactNumber = myObject.CustomerMobile,
                currency = "INR",
                description = "Purchase of items",
                email = myObject.CustomerEmail,
                name = myObject.CustomerName,
                razorpayKey = rKey
            };
            myObject.orderModel = orderModel;
            return View(orderModel);
        }
        
        public IActionResult CreateCODOrder()
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            UserCartModel myObject = new UserCartModel();
            myObject = _uService.GetMyCart(loginCheckResponse.userId);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "currentOrder", myObject);
            return View(myObject);
        }
        public IActionResult CODSuccess()
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
             

                // Create these action method

                UserCartModel myObject = new UserCartModel();
                myObject = SessionHelper.GetObjectFromJson<UserCartModel>(HttpContext.Session, "currentOrder");
                // update cart as paid 
                try
                {
                    if (myObject != null)
                    {
                        //place entries in PO Master and details
                        POMasterEntity poM = new POMasterEntity();
                        poM.CartId = myObject.CartId;
                        poM.CreatedOn = DateTime.Now;
                        poM.CurrentStatus = "Unpaid";
                        poM.InstrumentDetails = "COD";
                        poM.IsDeleted = false;
                        poM.OrderStatus = "Open";
                        poM.OrderAmount = (decimal)myObject.CartDetails.Sum(a => a.TotalPrice);
                        poM.PaidAmount = 0;
                        poM.PaidDate = null;
                        poM.BankCharges = 0;
                        poM.BankTaxes = 0;
                        poM.PaymentMethod ="COD";
                        poM.PONumber = "PO-HJ-" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + loginCheckResponse.userId.ToString() + "-" + RandomGenerator.RandomString(3, false);
                        poM.TransactionId = "NA";
                        poM.UserId = myObject.CartUserId;
                        ProcessResponse pomResponse = _uService.SavePOMaster(poM);
                        if (pomResponse.currentId > 0)
                        {
                            poM.POId = pomResponse.currentId;
                            foreach (var v in myObject.CartDetails)
                            {
                                PODetailsEntity pde = new PODetailsEntity();
                                CloneObjects.CopyPropertiesTo(v, pde);
                                pde.POMasterId = pomResponse.currentId;
                                var vRes = _uService.SavePODetails(pde);
                            }

                            // place an entry in followup 
                            POFollowUpEntity pf = new POFollowUpEntity();
                            pf.FollowUpBy = loginCheckResponse.userId;
                            pf.FollowUpOn = DateTime.Now;
                            pf.FollowUpRemarks = "Order Created on " + DateTime.Now.ToString() + ". Making process will be initiated shortly";
                            pf.POId = pomResponse.currentId;
                            pf.PODetialId = 0;
                            pf.IsDeleted = false;
                            _pService.SaveFollowUp(pf);

                            // send emails 
                            _nService.SendOrderCreatedEmail(poM);
                        }

                        
                        // update cart and details status

                        CartMasterEntity cm = new CartMasterEntity();
                        cm = _uService.GetCartById(myObject.CartId);
                        cm.IsDeleted = true;
                        cm.CurrentStatus = "Purchased";
                        var t = _uService.UpdateCartMaster(cm);

                        foreach (var d in myObject.CartDetails)
                        {
                            CartDetailsEntity cd = new CartDetailsEntity();
                            cd = _uService.GetCartDetailById(d.CartDetailId);
                            cd.IsDeleted = true;
                            cd.CurrentStatus = "Purchased";
                            var dR = _uService.UpdateCartDetails(cd);
                        }

                    }
                }
                catch (Exception ex)
                {

                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "currentOrder", null);
               
            
                return View();
        }
        public ActionResult Complete()
        {
            // Payment data comes in url so we have to get it from url
            LoginResponse loginCheckResponse = new LoginResponse();
            loginCheckResponse = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "loggedUser");
            if (loginCheckResponse == null)
            {
                loginCheckResponse = new LoginResponse();
                loginCheckResponse.userId = 0;
                loginCheckResponse.userName = "NA";
            }
            ViewBag.LoggedUser = loginCheckResponse;
            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            string paymentId = Request.Form["rzp_paymentid"];

            // This is orderId  
            var orderId = Request.Form["rzp_orderid"];
            string rKey = _config.GetValue<string>("OtherConfig:RazorKey");
            string rSecret = _config.GetValue<string>("OtherConfig:RazorSecret");
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(rKey, rSecret);

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];
            RazorOrderResult rResult = new RazorOrderResult();
            rResult.id = paymentCaptured.Attributes["id"];
            ///rResult.acquirer_data.bank_transaction_id = paymentCaptured.Attributes["acquirer_data"]["bank_transaction_id"];
            rResult.amount = paymentCaptured.Attributes["amount"];
            rResult.amount_refunded= paymentCaptured.Attributes["amount_refunded"];
            rResult.bank = paymentCaptured.Attributes["bank"];
            rResult.captured= paymentCaptured.Attributes["captured"];
            rResult.card_id= paymentCaptured.Attributes["card_id"];
            rResult.contact= paymentCaptured.Attributes["contact"];
            rResult.created_at= paymentCaptured.Attributes["created_at"];
            rResult.currency= paymentCaptured.Attributes["currency"];
            rResult.description= paymentCaptured.Attributes["description"];
            rResult.email= paymentCaptured.Attributes["email"];
            rResult.entity= paymentCaptured.Attributes["entity"];
            rResult.error_code= paymentCaptured.Attributes["error_code"]; 
            rResult.error_description= paymentCaptured.Attributes["error_description"];
            rResult.error_reason= paymentCaptured.Attributes["error_reason"];
            rResult.error_source= paymentCaptured.Attributes["error_source"];
            rResult.error_step= paymentCaptured.Attributes["error_step"]; 
            rResult.fee= paymentCaptured.Attributes["fee"];
            rResult.id = paymentCaptured.Attributes["id"];
            rResult.international= paymentCaptured.Attributes["international"];
            rResult.invoice_id= paymentCaptured.Attributes["invoice_id"];
            rResult.method= paymentCaptured.Attributes["method"];
           // rResult.notes.address= paymentCaptured.Attributes["notes"]["address"];
            rResult.order_id= paymentCaptured.Attributes["order_id"];
            rResult.refund_status= paymentCaptured.Attributes["refund_status"];
            rResult.status= paymentCaptured.Attributes["status"];
            rResult.tax= paymentCaptured.Attributes["tax"];
            rResult.vpa= paymentCaptured.Attributes["vpa"];
            rResult.wallet= paymentCaptured.Attributes["wallet"];


            // Check payment made successfully

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                // Create these action method
               
                UserCartModel myObject = new UserCartModel();
                myObject = SessionHelper.GetObjectFromJson<UserCartModel>(HttpContext.Session, "currentOrder");
                // update cart as paid 
                try
                {
                    if (myObject != null)
                    {
                        //place entries in PO Master and details
                        POMasterEntity poM = new POMasterEntity();
                        poM.CartId = myObject.CartId;
                        poM.CreatedOn = DateTime.Now;
                        poM.CurrentStatus = "PaymentSuccess";
                        poM.InstrumentDetails = rResult.order_id;
                        poM.IsDeleted = false;
                        poM.OrderStatus = "Open";
                        poM.OrderAmount = (decimal) myObject.CartDetails.Sum(a => a.TotalPrice);
                        poM.PaidAmount = rResult.amount / 100;
                        poM.PaidDate = DateTime.Now;
                        poM.BankCharges = rResult.fee / 100;
                        poM.BankTaxes = rResult.tax / 100; 
                        poM.PaymentMethod = rResult.method;
                        poM.PONumber = "PO-HJ-" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + loginCheckResponse.userId.ToString() + "-" + RandomGenerator.RandomString(3, false);
                        poM.TransactionId = rResult.id;
                        poM.UserId = myObject.CartUserId;
                        ProcessResponse pomResponse = _uService.SavePOMaster(poM);
                        if (pomResponse.currentId > 0)
                        {
                            poM.POId = pomResponse.currentId;
                            foreach (var v in myObject.CartDetails)
                            {
                                PODetailsEntity pde = new PODetailsEntity();
                                CloneObjects.CopyPropertiesTo(v, pde);
                                pde.POMasterId = pomResponse.currentId;
                                var vRes = _uService.SavePODetails(pde);
                            }

                            // place an entry in followup 
                            POFollowUpEntity pf = new POFollowUpEntity();
                            pf.FollowUpBy = loginCheckResponse.userId;
                            pf.FollowUpOn = DateTime.Now;
                            pf.FollowUpRemarks = "Order Created on " + DateTime.Now.ToString() + ". Making process will be initiated shortly";
                            pf.POId = pomResponse.currentId;
                            pf.PODetialId = 0;
                            pf.IsDeleted = false;
                            _pService.SaveFollowUp(pf);

                            // send emails 
                            _nService.SendOrderCreatedEmail(poM);
                        }

                        // post values in razor result table
                        RazorPaymentResultEntity rm = new RazorPaymentResultEntity();
                        rm.id = rResult.id;
                        rm.amount = rResult.amount;
                        rm.order_id = rResult.order_id;
                        rm.method = rResult.method;
                        rm.bank = rResult.bank;
                        rm.card_id = rResult.card_id;
                        rm.wallet = rResult.wallet;
                        rm.vpa = rResult.vpa;
                        rm.fee = rResult.fee;
                        rm.tax = rResult.tax;

                        rm.POID = pomResponse.currentId;
                        rm.IsDeleted = false;
                        var rms = _uService.SaveRazorPaymentResult(rm);
                        // update cart and details status

                        CartMasterEntity cm = new CartMasterEntity();
                        cm = _uService.GetCartById(myObject.CartId);
                        cm.IsDeleted = true;
                        cm.CurrentStatus = "Purchased";
                        var t = _uService.UpdateCartMaster(cm);

                        foreach (var d in myObject.CartDetails)
                        {
                            CartDetailsEntity cd = new CartDetailsEntity();
                            cd = _uService.GetCartDetailById(d.CartDetailId);
                            cd.IsDeleted = true;
                            cd.CurrentStatus = "Purchased";
                            var dR = _uService.UpdateCartDetails(cd);
                        }

                    }
                }
                catch(Exception ex)
                {

                }
                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "currentOrder", null);
                return RedirectToAction("PaymentSuccess");
            }
            else
            {
                return RedirectToAction("PaymentFailed");
            }
        }
        public IActionResult PaymentSuccess()
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            

            

            return View();
        }

        public IActionResult PaymentFailed()
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            return View();
        }
        public IActionResult About()
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
            HomeProductsModels myObj = new HomeProductsModels();

          
          
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);

            return View(myObj);
        }

        public IActionResult Terms()
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
            HomeProductsModels myObj = new HomeProductsModels();



            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);

            return View(myObj);
        }

        public IActionResult Wishlist()
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
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);
            List<WishListModel> myObject = new List<WishListModel>();
            myObject = _uService.GetMyWishList(loginCheckResponse.userId);
            return View(myObject);
        }

        [HttpPost]
        public IActionResult DeleteWishlist(int id)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                response = _uService.DeleteWishList(id);
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to delete";
            }
            return Json(new { result = response });
        }

        [HttpPost]
        public IActionResult AddToWishlist(int userId, int productId, int detailId)
        {
            ProcessResponse response = new ProcessResponse();

            WishListEntity test = new WishListEntity();
            test.AddedOn = DateTime.Now;
            test.IsDeleted = false;
            test.ProductId = productId;
            if(detailId == 0)
            {
                var details = _pService.GetProductDetails(productId);
                test.ProductDetailId = details.ProductDetails[0].ProductDetailId;
            }
            else
            {
                test.ProductDetailId = detailId;
            }
            test.UserId = userId;
            response = _uService.AddToWishList(test);
            return Json(new { result = response });
        }



        public IActionResult AllGold(int cid = 0, int sid = 0, int did = 0, int pageNumber = 1,
            int pageSize = 10, string search = "", decimal price = 0, int metalid = 0,
            string gender = "", int discountid = 0, bool isFA = false)
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

            HomeProductsModels myObj = new HomeProductsModels();
            List<SubCategoryMasterEntity> subCatDrop = new List<SubCategoryMasterEntity>();
            List<DetailCategoryMasterEntity> detCatDrops = new List<DetailCategoryMasterEntity>();
            List<CategoryMasterEntity> catDrops = new List<CategoryMasterEntity>();
            PaginationRequest pr = new PaginationRequest();
            GenericRequest gr = new GenericRequest();
            gr.pageNumber = 1;
            gr.pageSize = 1000;
            pr.pageNumber = 1;
            pr.pageSize = 1000;
            catDrops = _oServce.GetAllCategories(pr);
            if (isFA)
            {
                string q1 = @"select pm.CategoryId, pm.ProductDescription, cat.CategoryName CategoryId_name, pm.DetailCategoryId, dcat.DetailCategoryName DetailCategoryId_name,
                            pm.ProductId, pm.DiscountApplicableId, pm.DiscountApplicableId DiscountMasterId,
                            pm.IsCustomizable, pm.IsSizeApplicable, pm.MaxDelivaryDays, pm.PostedBy, pm.PostedOn, pm.ProductTitle,
                            pm.SubCategoryId, scat.SubCategoryName SubCategoryId_name,
                            (select top(1) ImageUrl from ProductImages where ProductImages.ProductId = pm.ProductId) ProductMainImages_List,
                            (select top(1) pd.ActualPrice from ProductDetails pd where pd.ProductId = pm.ProductId) ActualPrice,
                            (select top(1) pd.SellingPrice from ProductDetails pd where pd.ProductId = pm.ProductId) SellingPrice
                            from ProductMaster pm
                            join CategoryMaster cat on pm.CategoryId = cat.CategoryId
                            join SubCategoryMaster scat on pm.SubCategoryId = scat.SubCategoryId
                            join DetailCategoryMaster dcat on pm.DetailCategoryId = dcat.DetailCategoryId
                            join ProductDetails pdet on pm.ProductId = pdet.ProductId
                            join MetalMaster mm on pdet.metalmasterid = mm.MasterId
                            join DiscountMaster dm on pm.DiscountApplicableId = dm.dmasterid 
                            where pm.IsDeleted = 0 and pm.IsAllGold = 'Yes' ";
                string q2 = string.Empty;
                if (price != -1)
                {
                    q2 = " and SellingPrice < " + price.ToString();
                }
                if (metalid > 0)
                {
                    q2 += " and mm.MasterId = " + metalid;
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    q2 += " and pm.PrefferedGender = '" + gender + "'";
                }
                if (discountid > 0)
                {
                    q2 += " and pm.DiscountApplicableId = " + discountid;
                }
                int skipSize = pageNumber == 1 ? 0 : (pageNumber - 1) * pageSize;
                string q3 = " order by pm.postedon desc offset " + skipSize + " rows fetch next " + pageSize + " rows only";
                q1 = q1 + q2 + q3;
                myObj.listProducts = _pService.GetProductsByFilter(q1);


                string countQ = @"select count(pm.CategoryId) as cnt
                            from ProductMaster pm
                            join CategoryMaster cat on pm.CategoryId = cat.CategoryId
                            join SubCategoryMaster scat on pm.SubCategoryId = scat.SubCategoryId
                            join DetailCategoryMaster dcat on pm.DetailCategoryId = dcat.DetailCategoryId
                            join ProductDetails pdet on pm.ProductId = pdet.ProductId
                            join MetalMaster mm on pdet.metalmasterid = mm.MasterId
                            join DiscountMaster dm on pm.DiscountApplicableId = dm.dmasterid 
                            where pm.IsDeleted = 0 and pm.IsAllGold = 'Yes'  ";
                string countQF = countQ + " " + q2;
                myObj.totalRecords = _pService.GetProductsByFilter_count(countQF);
            }
            else
            {
                if (!string.IsNullOrEmpty(search))
                {
                    myObj.listProducts = _pService.GetProductsBySearch(cid, pageNumber, pageSize, search);
                    myObj.totalRecords = _pService.GetProductsBySearch_count(cid, pageNumber, pageSize, search);
                }
                else if (cid > 0)
                {
                    myObj.listProducts = _pService.GetProductsByCatId(cid, pageNumber, pageSize, search);
                    myObj.totalRecords = _pService.GetProductsByCatId_Count(cid, pageNumber, pageSize, search);

                }
                else if (did > 0)
                {
                    myObj.listProducts = _pService.GetProductsByDetId(did, pageNumber, pageSize, search);
                    myObj.totalRecords = _pService.GetProductsByDetId_Count(did, pageNumber, pageSize, search);

                }
            }
            gr.Id = cid;
            subCatDrop = _oServce.GetAllSubCategories(gr);
            gr.Id = sid;
            detCatDrops = _oServce.GetAllDetailCategories(gr);

            ViewBag.TotalCount = myObj.totalRecords;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.search = search;
            ViewBag.cid = cid;
            ViewBag.did = did;
            ViewBag.sid = sid;
            ViewBag.price = price;
            ViewBag.metalid = metalid;
            ViewBag.gender = gender;
            ViewBag.discountid = discountid;
            ViewBag.CartCount = _uService.GetUserCartCount(loginCheckResponse.userId);

            // for filters drop downs

            List<MetalMasterEntity> metalDrop = _mService.GetMetalMaster(pr, "List");

            StaticDropDowns staticDrops = new StaticDropDowns();
            List<DiscountMasterEntity> discDrops = _mService.GetAllDiscounts(gr);

            myObj.detCatDrops = detCatDrops;
            myObj.subCateDrop = subCatDrop;
            myObj.catDrops = catDrops;
            myObj.staticDrops = staticDrops;
            myObj.metalDrop = metalDrop;
            myObj.discDrops = discDrops;

            return View(myObj);
        }


        [HttpPost]
        public IActionResult SaveCustomization(CustomizeOrderEntity request)
        {
            request.CurrentStatus = "New";
            request.IsDeleted = false;
            request.RequestedOn = DateTime.Now;
            var v = _ordService.UpdateCustomizedOrder(request);
            return Json(new { result = v });
        }

    }
}
