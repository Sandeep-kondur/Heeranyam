#pragma checksum "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40cef346e6520f84444ab28afda7ef46cb9f6455"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OthersMasters_CategoryData), @"mvc.1.0.view", @"/Views/OthersMasters/CategoryData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40cef346e6520f84444ab28afda7ef46cb9f6455", @"/Views/OthersMasters/CategoryData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_OthersMasters_CategoryData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecommerce.Models.Entity.CategoryMasterEntity>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/OthersMasters/Categories"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/OthersMasters/CategoryData"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
  
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
                <a href=""#""> Add-Edit Category Master</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">
                    <div class=""inn-title"">
                        <div class=""row"">
                            <h4>Category Master</h4>
                            <p>Master data management</p>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40cef346e6520f84444ab28afda7ef46cb9f64555467", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40cef346e6520f84444ab28afda7ef46cb9f64556717", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 31 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
                       Write(Html.HiddenFor(b => b.CategoryId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            <div class=\"row\">\r\n                                <div class=\"input-field col s4\">\r\n                                    ");
#nullable restore
#line 34 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
                               Write(Html.TextBoxFor(a => a.CategoryName, null, new { @class = "validate", @placeholder = "Category Name" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 35 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
                               Write(Html.ValidationMessageFor(b => b.CategoryName, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"input-field col s4\">\r\n                                    ");
#nullable restore
#line 38 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
                               Write(Html.TextBoxFor(a => a.CategoryCode, null, new { @class = "validate", @placeholder = "Category Code" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 39 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
                               Write(Html.ValidationMessageFor(b => b.CategoryCode, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>
                                <div class=""input-field col s4"">
                                    <div class=""single-input-item"">
                                        <div class=""login-reg-form-meta d-flex align-items-center justify-content-between"">
                                            <div class=""remember-meta"">
                                                <div class=""custom-control custom-checkbox"">
                                                    ");
#nullable restore
#line 46 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\CategoryData.cshtml"
                                               Write(Html.CheckBoxFor(m => m.DisplayInHome,new { @id="rememberMe"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    
                                                    <label class=""custom-control-label"" for=""rememberMe"">Display in Home ?</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 
                            </div>
");
                WriteLiteral("                            <div class=\"row\">\r\n                                <div class=\"input-field col s12\">\r\n                                    <i class=\"waves-effect waves-light btn-large waves-input-wrapper\"");
                BeginWriteAttribute("style", " style=\"", 5824, "\"", 5832, 0);
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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecommerce.Models.Entity.CategoryMasterEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591
