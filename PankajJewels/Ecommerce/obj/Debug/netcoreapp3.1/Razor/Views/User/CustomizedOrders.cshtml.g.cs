#pragma checksum "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4c7c3583e512e0432da8bb466276a1228578a0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_CustomizedOrders), @"mvc.1.0.view", @"/Views/User/CustomizedOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4c7c3583e512e0432da8bb466276a1228578a0e", @"/Views/User/CustomizedOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_User_CustomizedOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecommerce.Models.ModelClasses.CustomizedOrderModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
  
    Layout = "~/Views/Shared/_AdminMaster.cshtml";
    int rowCount = 1;

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
                <a href=""#""> Customized Orders</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">

                    <div class=""tab-inn"">
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""sb2-2-3"">

        <div class=""row"">
            <div class=""col-md-12"">

                <div class=""box-inn-sp"">

                    <div class=""inn-title"">
                        <div class=""row"">
                            <div class=""col-4"">
                                <h4>Customized Orders</h4>
                                <p>Order management</p>
     ");
            WriteLiteral(@"                       </div>


                            <a class=""dropdown-button drop-down-meta"" href=""#"" data-activates=""dr-users""><i class=""material-icons"">more_vert</i></a>
                            <ul id=""dr-users"" class=""dropdown-content"">
                                <li>
                                    
                                </li>
                            </ul>

                            <!-- Dropdown Structure -->

                        </div>
                        <div class=""tab-inn"">
                            <div class=""table-responsive table-desi"">
                                <table class=""table table-hover"">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Customer Name</th>
                                            <th>Customer Mobile</th>
                                            <th>Custo");
            WriteLiteral(@"mer Address</th>
                                            <th>Product Title</th>

                                            <th>Image</th>
                                            <th>Requirements</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 74 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                         foreach (var r in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 78 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                                Write(rowCount++);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    <span class=\"list-enq-name\">");
#nullable restore
#line 81 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                                                           Write(r.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                    <span class=\"list-enq-city\">");
#nullable restore
#line 82 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                                                           Write(r.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td>\r\n                                                    <span class=\"list-enq-name\">");
#nullable restore
#line 85 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                                                           Write(r.CustomerMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td>");
#nullable restore
#line 87 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                               Write(r.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d4c7c3583e512e0432da8bb466276a1228578a0e9028", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3623, "~/ProductImages/", 3623, 16, true);
#nullable restore
#line 88 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
AddHtmlAttributeValue("", 3639, r.ProductImage, 3639, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>");
#nullable restore
#line 90 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                               Write(r.CustomerRequirements);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n                                                    \r\n\r\n                                                    <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4003, "\"", 4035, 3);
            WriteAttributeValue("", 4013, "ShowDelete(", 4013, 11, true);
#nullable restore
#line 94 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
WriteAttributeValue("", 4024, r.OrderId, 4024, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4034, ")", 4034, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" title=""Delete"">
                                                        <i class=""fa fa-trash-o"" aria-hidden=""true""></i>
                                                    </a>
                                                </td>
                                            </tr>
");
#nullable restore
#line 99 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\User\CustomizedOrders.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    function ShowDelete(id) {

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
                    url: GlobalUrl + ""/OthersMasters/DeleteBannerAd?id="" + id,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr[""succe");
            WriteLiteral(@"ss""](""Successuflly deleted!"");
                        window.location.href = window.location.href;
                    }
                });
            }
            else {
                toastr[""error""](""Delete cancelled!"")
            }
            return false;
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecommerce.Models.ModelClasses.CustomizedOrderModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
