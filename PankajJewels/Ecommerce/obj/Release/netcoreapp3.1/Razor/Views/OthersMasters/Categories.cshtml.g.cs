#pragma checksum "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d4b7597d92935a429129b5d9be0a6328f607159"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OthersMasters_Categories), @"mvc.1.0.view", @"/Views/OthersMasters/Categories.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d4b7597d92935a429129b5d9be0a6328f607159", @"/Views/OthersMasters/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_OthersMasters_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecommerce.Models.Entity.CategoryMasterEntity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/OthersMasters/CategoryData"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
  
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
                <a href=""#""> Categories</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">
                    <div class=""inn-title"">
                        <h4>Categories Master</h4>
                        <p>Defines Categories of products</p>
                        <a class=""dropdown-button drop-down-meta"" href=""#"" data-activates=""dr-users""><i class=""material-icons"">more_vert</i></a>
                        <ul id=""dr-users"" class=""dropdown-content"">
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d4b7597d92935a429129b5d9be0a6328f6071595099", async() => {
                WriteLiteral("Add New");
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
            WriteLiteral(@"
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
                                        <th>Category Name</th>
                                        <th>Category Code</th>
                                        <th>Display in Home</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 48 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
                                     foreach (var r in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 52 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
                                            Write(rowCount++);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n\r\n                                                <span class=\"list-enq-name\">");
#nullable restore
#line 56 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
                                                                       Write(r.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                                <span class=""list-enq-city""></span>

                                            </td>
                                            <td>
                                                <span class=""list-enq-name"">");
#nullable restore
#line 61 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
                                                                       Write(r.CategoryCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </td>\r\n                                            <td>\r\n                                                <span class=\"list-enq-name\">");
#nullable restore
#line 64 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
                                                                       Write(r.DisplayInHome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </td>\r\n                                            \r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d4b7597d92935a429129b5d9be0a6328f6071599527", async() => {
                WriteLiteral("\r\n                                                <i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3082, "~/OthersMasters/CategoryData?id=", 3082, 32, true);
#nullable restore
#line 68 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
AddHtmlAttributeValue("", 3114, r.CategoryId, 3114, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3331, "\"", 3366, 3);
            WriteAttributeValue("", 3341, "ShowDelete(", 3341, 11, true);
#nullable restore
#line 70 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
WriteAttributeValue("", 3352, r.CategoryId, 3352, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3365, ")", 3365, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" title=""Delete"">
                                                    <i class=""fa fa-trash-o"" aria-hidden=""true""></i>
                                                </a>
                                            </td>
                                        </tr>
");
#nullable restore
#line 75 "C:\Users\User\Downloads\Heeranyam\PankajJewels\Ecommerce\Views\OthersMasters\Categories.cshtml"
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
                    url: GlobalUrl + ""/OthersMasters/DeleteCategoryMaster?id="" + id,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr[""success""](""Successuflly deleted!"");
        ");
            WriteLiteral(@"                window.location.href = window.location.href;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecommerce.Models.Entity.CategoryMasterEntity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
