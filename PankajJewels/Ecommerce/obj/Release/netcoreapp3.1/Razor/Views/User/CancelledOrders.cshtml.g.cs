#pragma checksum "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "402b9e82c06cc344316bc216f4e52da510aab32e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_CancelledOrders), @"mvc.1.0.view", @"/Views/User/CancelledOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"402b9e82c06cc344316bc216f4e52da510aab32e", @"/Views/User/CancelledOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_User_CancelledOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecommerce.Models.ModelClasses.POMasterModel>>
    {
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
#line 2 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
  
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
                <a href=""#""> Cancelled Orders</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">
                    <div class=""inn-title"">
                        <h4>Order Management</h4>
                        <p>Cancelled Orders</p>

                        <!-- Dropdown Structure -->

                    </div>
                    <div class=""tab-inn"">
                        <div class=""table-responsive table-desi"">
                            <table class=""table table-hover"">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                  ");
            WriteLiteral(@"      <th>PO Number</th>
                                        <th>On</th>
                                        <th>Total Amount</th>
                                        <th>Payment Method</th>
                                        <th>TransactionId</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 44 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                     foreach (var r in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 48 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                            Write(rowCount++);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n\r\n                                                <span class=\"list-enq-name\">");
#nullable restore
#line 52 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                                                       Write(r.PONumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                <span class=\"list-enq-city\">");
#nullable restore
#line 53 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                                                       Write(r.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 53 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                                                                    Write(r.UserAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 57 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                            Write(Convert.ToDateTime(r.CreatedOn).ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td class=\"text-right\">\r\n                                                ");
#nullable restore
#line 60 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                           Write(r.PaidAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>");
#nullable restore
#line 62 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                           Write(r.PaymentMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 63 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
                                           Write(r.TransactionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "402b9e82c06cc344316bc216f4e52da510aab32e8486", async() => {
                WriteLiteral("\r\n                                                    <i class=\"fa fa-eye-slash\" aria-hidden=\"true\"></i>\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2888, "~/User/ViewOrderC?id=", 2888, 21, true);
#nullable restore
#line 65 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
AddHtmlAttributeValue("", 2909, r.POId, 2909, 7, false);

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
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 70 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\User\CancelledOrders.cshtml"
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
                    url: GlobalUrl + ""/User/DeleteUserType?id="" + id,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr[""success""](""Successuflly deleted!"");
                       ");
            WriteLiteral(@" window.location.href = window.location.href;
                    }
                });
            }
            else {
                toastr[""error""](""Delete cancelled!"")
            }
            return false;
        });


        //swal.fire({
        //    title: 'Do you want to Delete?',
        //    showDenyButton: true,
        //    showCancelButton: true,
        //    confirmButtonText: `Delete`,
        //}).then((result) => {
        //    /* Read more about isConfirmed, isDenied below */
        //    if (result.isConfirmed) {


        //        toastr[""success""](""Successuflly deleted!"")
        //    } else if (result.isDenied) {

        //        toastr[""error""](""You have cancelled!"")
        //    }
        //});
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecommerce.Models.ModelClasses.POMasterModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
