#pragma checksum "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Authenticate\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1639e1e7135bfc66f8148b3911df158113085cbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authenticate_ResetPassword), @"mvc.1.0.view", @"/Views/Authenticate/ResetPassword.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1639e1e7135bfc66f8148b3911df158113085cbc", @"/Views/Authenticate/ResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Authenticate_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecommerce.Models.ModelClasses.ForgotPasswordReset>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Authenticate/ResetPassword"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Authenticate\ResetPassword.cshtml"
  
    Layout = "~/Views/Shared/_MasterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- breadcrumb area start -->
<div class=""breadcrumb-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""breadcrumb-wrap"">
                    <nav aria-label=""breadcrumb"">
                        <ul class=""breadcrumb"">
                            <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1639e1e7135bfc66f8148b3911df158113085cbc5118", async() => {
                WriteLiteral("<i class=\"fa fa-home\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">login-Register</li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- breadcrumb area end -->
<!-- login register wrapper start -->
<div class=""login-register-wrapper section-padding loginBanner"">
    <div class=""container"">
        <div class=""member-area-from-wrap"">
            <div class=""row"">
                <!-- Login Content Start -->
                <div class=""offset-md-6 col-lg-6"">
                    <div class=""login-reg-form-wrap"">
                        <h5>Reset your password</h5>
                        <h4>An email sent you with reset key.</h4>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1639e1e7135bfc66f8148b3911df158113085cbc7017", async() => {
                WriteLiteral("\r\n                            <div class=\"single-input-item\">\r\n                                <input type=\"text\" placeholder=\"Key\" required name=\"key\" />\r\n                                ");
#nullable restore
#line 37 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Authenticate\ResetPassword.cshtml"
                           Write(Html.ValidationMessageFor(a => a.key, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"single-input-item\">\r\n                                <input type=\"password\" placeholder=\"Enter your Password\" required name=\"pword\" />\r\n                                ");
#nullable restore
#line 42 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Authenticate\ResetPassword.cshtml"
                           Write(Html.ValidationMessageFor(a => a.pword, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n\r\n                            <div class=\"single-input-item\">\r\n                                <input type=\"password\" placeholder=\"confirm password\" required name=\"confpword\" />\r\n                                ");
#nullable restore
#line 47 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Authenticate\ResetPassword.cshtml"
                           Write(Html.ValidationMessageFor(a => a.confpword, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </div>
                            <div class=""single-input-item"">
                                <button class=""btn btn-sqr"">Reset</button>
                            </div>
                            <div class=""single-input-item"">

                                <span class=""text-danger"">");
#nullable restore
#line 54 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Authenticate\ResetPassword.cshtml"
                                                     Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
                <!-- Login Content End -->
                <!--
                                        <div class=""col-lg-6"">
                                            <div class=""login-reg-form-wrap sign-up-form"">
                                                <h5>Singup Form</h5>
                                                <form action=""#"" method=""post"">
                                                    <div class=""single-input-item"">
                                                        <input type=""text"" placeholder=""Full Name"" required />
                                                    </div>
                                                    <div class=""single-input-item"">
                                                        <input type=""email"" placeholder=""Enter your Email"" required />
                                                    </div>
                                                    <div class=""row"">
    ");
            WriteLiteral(@"                                                    <div class=""col-lg-6"">
                                                            <div class=""single-input-item"">
                                                                <input type=""password"" placeholder=""Enter your Password"" required />
                                                            </div>
                                                        </div>
                                                        <div class=""col-lg-6"">
                                                            <div class=""single-input-item"">
                                                                <input type=""password"" placeholder=""Repeat your Password"" required />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class=""single-input-item"">
    ");
            WriteLiteral(@"                                                    <div class=""login-reg-form-meta"">
                                                            <div class=""remember-meta"">
                                                                <div class=""custom-control custom-checkbox"">
                                                                    <input type=""checkbox"" class=""custom-control-input"" id=""subnewsletter"">
                                                                    <label class=""custom-control-label"" for=""subnewsletter"">Subscribe
                                                                        Our Newsletter</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class=""single-input-item"">
                 ");
            WriteLiteral(@"                                       <button class=""btn btn-sqr"">Register</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                -->
            </div>
        </div>
    </div>
</div>
<!-- login register wrapper end --");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecommerce.Models.ModelClasses.ForgotPasswordReset> Html { get; private set; }
    }
}
#pragma warning restore 1591
