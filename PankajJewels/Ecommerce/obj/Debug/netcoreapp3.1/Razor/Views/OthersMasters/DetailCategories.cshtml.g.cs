#pragma checksum "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c72b48d7d7b740bc906e0d279d76c5806fe7ee53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OthersMasters_DetailCategories), @"mvc.1.0.view", @"/Views/OthersMasters/DetailCategories.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c72b48d7d7b740bc906e0d279d76c5806fe7ee53", @"/Views/OthersMasters/DetailCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_OthersMasters_DetailCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecommerce.Models.Entity.DetailCategoryMasterEntity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/OthersMasters/DetailCategories"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/OthersMasters/DetailCategoryData"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
  
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
                <a href=""#""> Detail Categories</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">

                    <div class=""tab-inn"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee535812", async() => {
                WriteLiteral("\r\n\r\n                            <div class=\"row\">\r\n                                <div class=\"col s4\">\r\n                                    <select id=\"catid\" name=\"catid\">\r\n");
#nullable restore
#line 29 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                         foreach (var v in ViewBag.cats)
                                        {
                                            if (ViewBag.currentCatId == v.CategoryId)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee536765", async() => {
#nullable restore
#line 33 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                                                  Write(v.CategoryName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                   WriteLiteral(v.CategoryId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee539444", async() => {
#nullable restore
#line 37 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                                         Write(v.CategoryName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                   WriteLiteral(v.CategoryId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 38 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                            }

                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </div>\r\n                                <div class=\"col s4\">\r\n                                    <select id=\"subcatid\" name=\"subcatid\">\r\n");
#nullable restore
#line 45 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                         foreach (var v in ViewBag.subcats)
                                        {
                                            if (ViewBag.currentSubCatId == v.SubCategoryId)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee5312437", async() => {
#nullable restore
#line 49 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                                                     Write(v.SubCategoryName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                   WriteLiteral(v.SubCategoryId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee5315126", async() => {
#nullable restore
#line 53 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                                            Write(v.SubCategoryName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                   WriteLiteral(v.SubCategoryId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                            }

                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </select>
                                </div>
                                <div class=""input-field col s4"">
                                    <button type=""submit"" class=""btn btn-success"">Search</button>
                                </div>


                            </div>

                            <div class=""row"">
                                <div class=""input-field col s12"">

                                </div>
                            </div>

                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
                                <h4>Detail Categories Master</h4>
                                <p>Defines Categories of products</p>
                            </div>


                            <a class=""dropdown-button drop-down-meta"" href=""#"" data-activates=""dr-users""><i class=""material-icons"">more_vert</i></a>
                            <ul id=""dr-users"" class=""dropdown-content"">
                                <li>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee5320367", async() => {
                WriteLiteral("Add New");
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
                                            <th>Detail  Category Name</th>
                                            <th>Category Code</th>

                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 116 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                         foreach (var r in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 120 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                Write(rowCount++);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n\r\n                                                    <span class=\"list-enq-name\">");
#nullable restore
#line 124 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                                           Write(r.DetailCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                                    <span class=""list-enq-city""></span>

                                                </td>
                                                <td>
                                                    <span class=""list-enq-name"">");
#nullable restore
#line 129 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
                                                                           Write(r.DetailCategoryCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72b48d7d7b740bc906e0d279d76c5806fe7ee5324331", async() => {
                WriteLiteral("\r\n                                                        <i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i>\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5856, "~/OthersMasters/DetailCategoryData?id=", 5856, 38, true);
#nullable restore
#line 132 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
AddHtmlAttributeValue("", 5894, r.DetailCategoryId, 5894, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6183, "\"", 6224, 3);
            WriteAttributeValue("", 6193, "ShowDelete(", 6193, 11, true);
#nullable restore
#line 135 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
WriteAttributeValue("", 6204, r.DetailCategoryId, 6204, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6223, ")", 6223, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" title=""Delete"">
                                                        <i class=""fa fa-trash-o"" aria-hidden=""true""></i>
                                                    </a>
                                                </td>
                                            </tr>
");
#nullable restore
#line 140 "C:\Users\User\Downloads\PankajJewels\Ecommerce\Views\OthersMasters\DetailCategories.cshtml"
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
                    url: GlobalUrl + ""/OthersMasters/DeleteCategoryMaster?id="" + id,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr[");
            WriteLiteral(@"""success""](""Successuflly deleted!"");
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
</script>
<script>
    $(document).ready(function () {

        $(""select[name=catid]"").change(function () {
            var catid = this.value;
            $.ajax({
                url: GlobalUrl + ""/OthersMasters/GetAllSubCatsDrop?catid="" + catid,
                type: 'post',
                data: '{}',
                success: function (res) {
                    var r = res.result.length;
                    var row = '';

                    if (r > 0) {

                        for (var i = 0; i < r; i++) {
                            row = row + '<option value=""' + res.result[i].subCategoryId + '"">' + res.result[i].subCategoryName + '</option>';
                            //$('#SubCate");
            WriteLiteral(@"goryId').append('<option value=""' + res.result[i].subCategryId + '"">' + res.result[i].subCategoryName + '</option>');
                        }
                    }
                    $('#subcatid').html('');
                    $('#subcatid').html(row);
                    $('#subcatid').material_select();
                }
            });
        });
    });


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecommerce.Models.Entity.DetailCategoryMasterEntity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
