#pragma checksum "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\DiscountCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6adf15a77b6b168f52e45a0b6660f842cbc3d552"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_DiscountCategory_Index), @"mvc.1.0.view", @"/Areas/AdminArea/Views/DiscountCategory/Index.cshtml")]
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
#line 1 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackFinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackFinalProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackFinalProject.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackFinalProject.Utilities.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackFinalProject.Areas.AdminArea.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6adf15a77b6b168f52e45a0b6660f842cbc3d552", @"/Areas/AdminArea/Views/DiscountCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d94402d6d017b21cc436ae92d94fadd5bfae51f3", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_DiscountCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiscountCategroy>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternative Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; height:100px;border-radius:10%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "discountcategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\DiscountCategory\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/AdminArea/Views/Shared/_AdminLayout.cshtml";
    int count = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""justify-content-between d-flex mt-3 justify-content-between"" style=""width:100%;"">
            <div>
                <h1>Categories</h1>
            </div>
        </div>
        <div class=""table-responsive"">
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th>
                            Number
                        </th>
                        <th>
                            Category Image
                        </th>
                        <th>
                            Category Name
                        </th>
                        <th>
                            Settings
                        </th>

                    </tr>
                </thead>
                <tbody>
                        <tr>
                            <td>
                                ");
#nullable restore
#line 36 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\DiscountCategory\Index.cshtml"
                           Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6adf15a77b6b168f52e45a0b6660f842cbc3d5527801", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1237, "~/Assets/img/categoriesDiscount/", 1237, 32, true);
#nullable restore
#line 39 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\DiscountCategory\Index.cshtml"
AddHtmlAttributeValue("", 1269, Model.Image, 1269, 12, false);

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
            WriteLiteral("\r\n\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 43 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\DiscountCategory\Index.cshtml"
                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6adf15a77b6b168f52e45a0b6660f842cbc3d55210054", async() => {
                WriteLiteral("\r\n                                    <i class=\"mdi mdi-credit-card\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiscountCategroy> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
