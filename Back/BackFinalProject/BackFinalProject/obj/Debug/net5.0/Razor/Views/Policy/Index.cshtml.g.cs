#pragma checksum "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a0aeb2c3ffc7fb3a9d41098a4a18f299e683c37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Policy_Index), @"mvc.1.0.view", @"/Views/Policy/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0aeb2c3ffc7fb3a9d41098a4a18f299e683c37", @"/Views/Policy/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15490e073c7c2c777c5f124e21b763f88e8c6385", @"/Views/_ViewImports.cshtml")]
    public class Views_Policy_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PolicyVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int policyCount = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""policy-accardion"">
    <div class=""container"">
        <div class=""policy-accardion-text"">
            <h4>İSTIFADƏÇI RAZILAŞMASI</h4>
            <p>
                Aşağıdakı satış və çatdırılma şərtləri JYSK mağazalar şəbəkəsində və JYSK.az saytında edilən Bakı və Bakı ətrafı ərazilərə çatdırılacaq olan bütün alışlara şamil olunur.

                JYSK az saytında və JYSK dukanlarındakı olan bütün razılaşmalar rus və azərbaycan dilində tərtib olunur.JYSK mağazaları və JYSK.az saytından alış etmə hüququna malik olan alıcının minimal yaş həddi 18 yaşdır.

            </p>
        </div>
        <div class=""accordion"" id=""accordionExample"">
");
#nullable restore
#line 21 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
             foreach (var policy in Model.Policies)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"accordion-item\">\r\n                    <h2 class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 926, "\"", 959, 2);
            WriteAttributeValue("", 931, "accardionHeader-", 931, 16, true);
#nullable restore
#line 24 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
WriteAttributeValue("", 947, policyCount, 947, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <button class=\"accordion-button\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#accardionText-");
#nullable restore
#line 25 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                                                                                                                           Write(policyCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\" aria-controls=\"collapseOne\">\r\n                            ");
#nullable restore
#line 26 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                       Write(policyCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(". ");
#nullable restore
#line 26 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                                     Write(policy.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </button>\r\n                    </h2>\r\n                    <div");
            BeginWriteAttribute("id", " id=\"", 1298, "\"", 1329, 2);
            WriteAttributeValue("", 1303, "accardionText-", 1303, 14, true);
#nullable restore
#line 29 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
WriteAttributeValue("", 1317, policyCount, 1317, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"accordion-collapse collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1366, "\"", 1413, 3);
            WriteAttributeValue("", 1384, "accardionHeader-", 1384, 16, true);
#nullable restore
#line 29 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
WriteAttributeValue("", 1400, policyCount, 1400, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1412, ";", 1412, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-bs-parent=\"#accordionExample\">\r\n                        <div class=\"accordion-body\">\r\n");
#nullable restore
#line 31 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                             if (policy.Detail != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                           Write(policy.Detail);

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                                              
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 39 "C:\Users\Baxtiyar\Documents\CodeAcademyFinalProject\Back\BackFinalProject\BackFinalProject\Views\Policy\Index.cshtml"
                policyCount++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PolicyVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
