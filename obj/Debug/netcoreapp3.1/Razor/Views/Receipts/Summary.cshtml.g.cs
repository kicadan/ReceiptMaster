#pragma checksum "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eba5dff606c1926d211b9346259302eb42430b13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Receipts_Summary), @"mvc.1.0.view", @"/Views/Receipts/Summary.cshtml")]
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
#line 1 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\_ViewImports.cshtml"
using ReceiptMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\_ViewImports.cshtml"
using ReceiptMaster.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eba5dff606c1926d211b9346259302eb42430b13", @"/Views/Receipts/Summary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"119742d46d1878726c469c64e6701b9746c152bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Receipts_Summary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReceiptMaster.ViewModels.SummariesDataWrapper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
  
    ViewData["Title"] = "Receipts summary";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Receipts</h1>\r\n\r\n<h4>");
#nullable restore
#line 9 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
Write(ViewBag.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral(" on column: ");
#nullable restore
#line 9 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
                           Write(ViewBag.ItemType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                First value\r\n            </th>\r\n");
#nullable restore
#line 16 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
             if (Model.Column.Contains("MonthInShop"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>\r\n                    Second value\r\n                </th>\r\n");
#nullable restore
#line 21 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>\r\n                Rate value\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
 foreach (var item in Model.SummariesDatas) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
#nullable restore
#line 33 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
             if (Model.Column.Contains("MonthInShop"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
               Write(item.SecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 38 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Daniel\source\Repos\ReceiptMaster\ReceiptMaster\Views\Receipts\Summary.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReceiptMaster.ViewModels.SummariesDataWrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
