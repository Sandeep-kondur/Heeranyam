#pragma checksum "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e59f1d1636f53a562b2ebf2f6500d73c953d0e7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_RenderCart), @"mvc.1.0.view", @"/Views/Home/RenderCart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e59f1d1636f53a562b2ebf2f6500d73c953d0e7e", @"/Views/Home/RenderCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_RenderCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecommerce.Models.ModelClasses.UserCartModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/MyCart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
   
    decimal totalPrice = 0;
    if(Model != null)
    {
        if (Model.CartDetails != null)
        {
            if (Model.CartDetails.Count > 0)
            {
                totalPrice = (decimal)Model.CartDetails.Sum(b => b.TotalPrice);
            }
        }
    }



#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
 if (Model != null && Model.CartDetails != null && Model.CartDetails.Count>0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"minicart-item-wrapper\">\r\n        <ul>\r\n");
#nullable restore
#line 21 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
             foreach (var v in Model.CartDetails)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"minicart-item\">\r\n                    <div class=\"minicart-thumb\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59f1d1636f53a562b2ebf2f6500d73c953d0e7e5353", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e59f1d1636f53a562b2ebf2f6500d73c953d0e7e5636", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 776, "~/ProductImages/", 776, 16, true);
#nullable restore
#line 26 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
AddHtmlAttributeValue("", 792, v.ProductImage, 792, 15, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 679, "~/Home/Product?pid=", 679, 19, true);
#nullable restore
#line 25 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
AddHtmlAttributeValue("", 698, v.ProductId, 698, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 710, "&pdid=", 710, 6, true);
#nullable restore
#line 25 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
AddHtmlAttributeValue("", 716, v.ProductDetailId, 716, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"minicart-content\">\r\n                        <h3 class=\"product-name\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59f1d1636f53a562b2ebf2f6500d73c953d0e7e9147", async() => {
#nullable restore
#line 31 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
                                                                                         Write(v.ProductTitle);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1037, "~/Home/Product?pid=", 1037, 19, true);
#nullable restore
#line 31 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
AddHtmlAttributeValue("", 1056, v.ProductId, 1056, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 1068, "&pdid=", 1068, 6, true);
#nullable restore
#line 31 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
AddHtmlAttributeValue("", 1074, v.ProductDetailId, 1074, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </h3>\r\n                        <p>\r\n                            <span class=\"cart-quantity\">");
#nullable restore
#line 34 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
                                                   Write(v.NumberOfItems);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <strong>&times;</strong></span>\r\n                            <span class=\"cart-price\">Rs. ");
#nullable restore
#line 35 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
                                                    Write(v.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </p>\r\n                    </div>\r\n                    <button class=\"minicart-remove\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1469, "\"", 1510, 3);
            WriteAttributeValue("", 1479, "ShowDeleteCart(", 1479, 15, true);
#nullable restore
#line 38 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
WriteAttributeValue("", 1494, v.CartDetailId, 1494, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1509, ")", 1509, 1, true);
            EndWriteAttribute();
            WriteLiteral(" href=\"javascript:void(0);\" ><i class=\"pe-7s-close\"></i></button>\r\n                </li>\r\n");
#nullable restore
#line 40 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n        </ul>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"minicart-pricing-box\">\r\n        <ul>\r\n            \r\n            \r\n");
            WriteLiteral("            <li class=\"total\">\r\n                <span>total</span>\r\n                <span><strong>Rs ");
#nullable restore
#line 58 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
                            Write(totalPrice.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"minicart-button\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59f1d1636f53a562b2ebf2f6500d73c953d0e7e13683", async() => {
                WriteLiteral("<i class=\"fa fa-shopping-cart\"></i> View Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e59f1d1636f53a562b2ebf2f6500d73c953d0e7e14808", async() => {
                WriteLiteral("<i class=\"fa fa-share\"></i> Checkout");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 67 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"minicart-button\">\r\n       \r\n        <a href=\"#\"><i class=\"fa fa-share\"></i> You have no items in the cart</a>\r\n    </div>\r\n");
#nullable restore
#line 74 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\Home\RenderCart.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function ShowDeleteCart(id) {

        swal(""Are you sure?"", {
            buttons: {
                yes: {
                    text: ""Yes"",
                    value: ""yes""
                },
                no: {
                    text: ""No"",
                    value: ""no""
                }
            }
        }).then((value) => {
            if (value === ""yes"") {
                $.ajax({
                    url: GlobalUrl + ""/Home/DeleteFromCart?id="" + id,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr[""success""](""Successuflly deleted!"");
                        window.location.href = window.location.href;
                        var cuid = $('#cuid').val();
                        GetCart(cuid);

                    }
                });
            }
            else {
                toastr[""error""](""Delete cancelled!"")
            }
            return ");
            WriteLiteral("false;\r\n        });\r\n\r\n\r\n    }\r\n  \r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecommerce.Models.ModelClasses.UserCartModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
