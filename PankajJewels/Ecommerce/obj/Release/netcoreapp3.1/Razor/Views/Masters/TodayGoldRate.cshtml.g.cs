#pragma checksum "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fae17393335436acf6b598f2166432cce99b13d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Masters_TodayGoldRate), @"mvc.1.0.view", @"/Views/Masters/TodayGoldRate.cshtml")]
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
#line 1 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fae17393335436acf6b598f2166432cce99b13d4", @"/Views/Masters/TodayGoldRate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Masters_TodayGoldRate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecommerce.Models.Entity.GoldRateMasterEntity>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Masters/Dashboard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Masters/TodayGoldRate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
  
    Layout = "~/Views/Shared/_AdminMaster.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""sb2-2"">
    <div class=""sb2-2-2"">
        <ul>
            <li>
                <a href=""#""><i class=""fa fa-home"" aria-hidden=""true""></i> Home</a>
            </li>
            <li class=""active-bre"">
                <a href=""#""> Add-Edit</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">
                    <div class=""inn-title"">
                        <div class=""row"">
                            <h4>Today Gold Rate</h4>
                            <p>Master data management</p>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fae17393335436acf6b598f2166432cce99b13d45408", async() => {
                WriteLiteral("<h5 class=\"pull-right\">Back to list</h5>");
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
            WriteLiteral("\r\n                        </div>\r\n\r\n                    </div>\r\n                    <div class=\"tab-inn\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fae17393335436acf6b598f2166432cce99b13d46658", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 33 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                       Write(Html.HiddenFor(b => b.MasterId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                            <div class=\"row\">\r\n                                <div class=\"input-field col s4\">\r\n                                    ");
#nullable restore
#line 37 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                               Write(Html.Label("Gold Rate (for GRAM)"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 38 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                               Write(Html.TextBoxFor(a => a.Rate, null, new { @class = "validate", @placeholder = "Gold Rate" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 39 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                               Write(Html.ValidationMessageFor(b => b.Rate, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"input-field col s2\">\r\n                                    ");
#nullable restore
#line 42 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                               Write(Html.Label("Last Updated at :"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    \r\n                                </div>\r\n                                <div class=\"input-field col s2\">\r\n\r\n                                    ");
#nullable restore
#line 47 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                                Write(Convert.ToDateTime(Model.DateOfLastUpdate).ToString("dd-MMM-yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 48 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\Masters\TodayGoldRate.cshtml"
                                Write(Convert.ToDateTime(Model.DateOfLastUpdate).ToShortTimeString());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>
                            </div>
                             
                            <div class=""row"">
                                <div class=""input-field col s12"">
                                    <i class=""waves-effect waves-light btn-large waves-input-wrapper""");
                BeginWriteAttribute("style", " style=\"", 2398, "\"", 2406, 0);
                EndWriteAttribute();
                WriteLiteral(@"><input type=""submit"" class=""waves-button-input""></i>
                                </div>
                            </div>
                            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                        ");
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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecommerce.Models.Entity.GoldRateMasterEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591
