#pragma checksum "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\Brend\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be9c4925fd6b5c383f641d25b63e177d0a1a292c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Brend_Detail), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Brend/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be9c4925fd6b5c383f641d25b63e177d0a1a292c", @"/Areas/AdminArea/Views/Brend/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d94402d6d017b21cc436ae92d94fadd5bfae51f3", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    public class Areas_AdminArea_Views_Brend_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Brend>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Category Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\Brend\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/AdminArea/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <h1>Detail</h1>\r\n    <div class=\"form-group\">\r\n        <h3>Brend Name</h3>\r\n        <p>");
#nullable restore
#line 12 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\Brend\Detail.cshtml"
      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <h3>Brend Text</h3>\r\n        <p>");
#nullable restore
#line 16 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\Brend\Detail.cshtml"
      Write(Html.Raw(Model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <h3>Brend Image</h3>\r\n        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "be9c4925fd6b5c383f641d25b63e177d0a1a292c5690", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 479, "~/assets/img/brendSearch/", 479, 25, true);
#nullable restore
#line 21 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Areas\AdminArea\Views\Brend\Detail.cshtml"
AddHtmlAttributeValue("", 504, Model.Image, 504, 12, false);

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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Brend> Html { get; private set; }
    }
}
#pragma warning restore 1591
