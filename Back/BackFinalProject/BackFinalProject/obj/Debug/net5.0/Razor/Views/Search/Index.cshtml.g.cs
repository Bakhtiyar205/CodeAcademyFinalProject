#pragma checksum "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c785db0790d78d679c0b6131c2693045c3d5f3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.view", @"/Views/Search/Index.cshtml")]
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
#line 1 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\_ViewImports.cshtml"
using BackFinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\_ViewImports.cshtml"
using BackFinalProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\_ViewImports.cshtml"
using BackFinalProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c785db0790d78d679c0b6131c2693045c3d5f3e", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15490e073c7c2c777c5f124e21b763f88e8c6385", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 8 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
         if (Model.Count == 0)
        {



#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\r\n                There are not products under this name\r\n            </div>\r\n");
#nullable restore
#line 15 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
             foreach (var product in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-12 col-md-4 my-3\">\r\n                    <div class=\"product-field p-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c785db0790d78d679c0b6131c2693045c3d5f3e6294", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c785db0790d78d679c0b6131c2693045c3d5f3e6577", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 607, "~/assets/img/products/", 607, 22, true);
#nullable restore
#line 23 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
AddHtmlAttributeValue("", 629, product.ProductImages.FirstOrDefault().Image, 629, 45, false);

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
                WriteLiteral("\r\n                            <br>\r\n                            ");
#nullable restore
#line 25 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                       Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                                                                                      WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                         if (product.Discount != 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"discounted-price my-2\"><span>");
#nullable restore
#line 29 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                                                                Write(Math.Truncate(product.RealPrice * (100 - product.Discount) / 100));

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</span>/ededi</div>\r\n                            <div class=\"real-price\">");
#nullable restore
#line 30 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                                               Write(Math.Truncate(product.RealPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</div>\r\n                            <div class=\"discount-percentage my-2\">");
#nullable restore
#line 31 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                                                             Write(Math.Truncate(product.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("% ENDIRIM</div>\r\n");
#nullable restore
#line 32 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"discounted-price my-2\"><span>");
#nullable restore
#line 35 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                                                                Write(product.RealPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</span>/ededi</div>\r\n                            <div class=\"real-price\" style=\"visibility:hidden\">P126</div>\r\n                            <div class=\"discount-percentage my-2\" style=\"visibility:hidden\">P126</div>\r\n");
#nullable restore
#line 38 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"extra-information\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c785db0790d78d679c0b6131c2693045c3d5f3e13739", async() => {
                WriteLiteral("Daha Etrafli");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
                                                                                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""wish-list text-center mt-2"">
                            <a href=""#"">
                                <svg id=""icon-heart"" viewBox=""0 0 512 512"">
                                    <path d=""m512 147c0-81-62-147-141-147-48 0-89 26-115 62-26-36-67-62-115-62-79 0-141 66-141 147 0 34 11 66 30 91l207 274 40 0-21-27-194-256-8-10c-14-21-22-46-22-72 0-62 48-113 109-113 35 0 69 17 89 49l26 39 26-39c20-30 54-49 89-49 61 0 109 51 109 113 0 26-8 50-22 71l-7 8-153 201-199-259-25 19 203 267 21 28 14-18 171-226c18-24 29-56 29-91z"">
                                    </path>
                                </svg>
                                Istek Listi
                            </a>
                        </div>
                    </div>


                </div>
");
#nullable restore
#line 57 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Search\Index.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
