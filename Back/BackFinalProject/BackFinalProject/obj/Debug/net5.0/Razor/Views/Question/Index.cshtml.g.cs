#pragma checksum "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "306d458a8f608a0894d793ad5e35683f69df65e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Question_Index), @"mvc.1.0.view", @"/Views/Question/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"306d458a8f608a0894d793ad5e35683f69df65e4", @"/Views/Question/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15490e073c7c2c777c5f124e21b763f88e8c6385", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Question_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuestionVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "wishlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("hot-call"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"home-navigation my-3\">\r\n\r\n    <div class=\"container\">\r\n        <div class=\"d-flex justify-content-between\">\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306d458a8f608a0894d793ad5e35683f69df65e47211", async() => {
                WriteLiteral("Ana səhifə");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("/ <a>Sual Cavab</a>\r\n            </div>\r\n            <div>\r\n                <div style=\"width:110px !important; height:20px !important; font-size:15px;\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306d458a8f608a0894d793ad5e35683f69df65e48757", async() => {
                WriteLiteral(@"
                        <svg id=""icon-heart"" viewBox=""0 0 512 512"" style=""width:20%;"">
                            <path d=""m512 147c0-81-62-147-141-147-48 0-89 26-115 62-26-36-67-62-115-62-79 0-141 66-141 147 0 34 11 66 30 91l207 274 40 0-21-27-194-256-8-10c-14-21-22-46-22-72 0-62 48-113 109-113 35 0 69 17 89 49l26 39 26-39c20-30 54-49 89-49 61 0 109 51 109 113 0 26-8 50-22 71l-7 8-153 201-199-259-25 19 203 267 21 28 14-18 171-226c18-24 29-56 29-91z"">
                            </path>
                        </svg>
                        <span>Istək Listi</span>
                        (<span class=""wishlist-count"">");
#nullable restore
#line 21 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                                                 Write(Model.WishListCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>)\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
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

<div class=""container"">
    <div class=""row"">
        <div class=""col-md-9 col-12"">
            <h4>MÜŞTƏRİ XİDMƏTİ - SUALLAR-CAVABLAR</h4>

            <p>
                Siz bizə elektron məktub göndərə və ya ");
#nullable restore
#line 37 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                                                  Write(Model.Settings["Phone"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" nömrəsinə zəng edə bilərsiniz.Müştəri xidməti
                şöbəsinə
                zəng edərkən, nəzərə alın ki, bəzən xətlərdə yaranan tıxanıqlıq zamanı sizin zənginizə cavab
                verməkdə
                gecikmələr ola bilər.Bu zaman bizə —marketing_jyskaz@taroldd.com elektron ünvanına məktub göndərə
                bilərsiniz:
                JYSK mağazalarından alınan məhsullarla bağlı hər hansı bir problem yarandığı təqdirdə,birbaşa
                məhsulu
                aldığınız mağazaya müraciət etməyiniz məsləhət görülür.
            </p>
        </div>
        <div class=""col-md-3 col-12"">
            <div class=""questions-card mt-5"">
                <div class=""question-card-img"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "306d458a8f608a0894d793ad5e35683f69df65e412484", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2279, "~/assets/img/subscription/", 2279, 26, true);
#nullable restore
#line 51 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
AddHtmlAttributeValue("", 2305, Model.Settings["QuestionsImg"], 2305, 31, false);

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
            WriteLiteral("\r\n                </div>\r\n                <div class=\"question-card-text p-3 pt-5\">\r\n                    <h4>MÜŞTƏRİ XİDMƏTİ</h4>\r\n                    <p>");
#nullable restore
#line 55 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                  Write(Model.Settings["Phone"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <a href=\"https://mail.google.com/\" class=\"btn btn-light\">Bize yazin</a>\r\n                    <p>");
#nullable restore
#line 57 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                  Write(Model.Settings["QuestionTime"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>Mağazaların iş qrafiki haqqında məlumat üçün ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306d458a8f608a0894d793ad5e35683f69df65e415062", async() => {
                WriteLiteral("bura");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" daxil olun</p>

                </div>
            </div>
        </div>
    </div>

</div>

<!--Last Added Products-->
<div class=""last-looked py-5 last-looked-secondary"">
    <div class=""container"">
        <h4>Last Added Product</h4>
        <div class=""owl-carousel owl-theme owl-carusel-last-seen owl-carusel-store"">
");
#nullable restore
#line 72 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
             foreach (var lastAddedPictures in Model.Products.OrderByDescending(m => m.Date).Take(5))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"product-owl-field p-3\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306d458a8f608a0894d793ad5e35683f69df65e417188", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "306d458a8f608a0894d793ad5e35683f69df65e417468", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3472, "~/assets/img/products/", 3472, 22, true);
#nullable restore
#line 76 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
AddHtmlAttributeValue("", 3494, lastAddedPictures.ProductImages.FirstOrDefault().Image, 3494, 55, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <br>\r\n                        Carpayi Salling 140*220 natural\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                                                                                  WriteLiteral(lastAddedPictures.Id);

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
#line 80 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                     if (lastAddedPictures.Discount != 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"discounted-price my-2\">\r\n                            <span>\r\n                                ");
#nullable restore
#line 84 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                           Write(Math.Truncate(lastAddedPictures.RealPrice
                           * (100 - lastAddedPictures.Discount) / 100));

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN\r\n                            </span>/ededi\r\n                        </div>\r\n                        <div class=\"real-price\">");
#nullable restore
#line 88 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                                           Write(Math.Truncate(lastAddedPictures.RealPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</div>\r\n                        <div class=\"discount-percentage my-2\">Endirim ");
#nullable restore
#line 89 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                                                                 Write(lastAddedPictures.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</div>\r\n");
#nullable restore
#line 90 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"discounted-price my-2\">\r\n                            <span>\r\n                                ");
#nullable restore
#line 95 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                           Write(Math.Truncate(lastAddedPictures.RealPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" AZN
                            </span>/ededi
                        </div>
                        <div class=""real-price"" style=""visibility:hidden"">P126</div>
                        <div class=""discount-percentage my-2"" style=""visibility:hidden"">P126</div>
");
#nullable restore
#line 100 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"extra-information\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306d458a8f608a0894d793ad5e35683f69df65e424614", async() => {
                WriteLiteral("Daha Etrafli");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 103 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
                                                                                      WriteLiteral(lastAddedPictures.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"wish-list text-center mt-2\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306d458a8f608a0894d793ad5e35683f69df65e427307", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 5231, "\"", 5260, 1);
#nullable restore
#line 107 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
WriteAttributeValue("", 5239, lastAddedPictures.Id, 5239, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""product-wishlist-id"" />
                            <button type=""submit"" class=""btn add-wishlist"">
                                <svg id=""icon-heart"" viewBox=""0 0 512 512"">
                                    <path d=""m512 147c0-81-62-147-141-147-48 0-89 26-115 62-26-36-67-62-115-62-79 0-141 66-141 147 0 34 11 66 30 91l207 274 40 0-21-27-194-256-8-10c-14-21-22-46-22-72 0-62 48-113 109-113 35 0 69 17 89 49l26 39 26-39c20-30 54-49 89-49 61 0 109 51 109 113 0 26-8 50-22 71l-7 8-153 201-199-259-25 19 203 267 21 28 14-18 171-226c18-24 29-56 29-91z"">
                                    </path>
                                </svg>
                                Istek Listi
                            </button>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 118 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Question\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuestionVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
