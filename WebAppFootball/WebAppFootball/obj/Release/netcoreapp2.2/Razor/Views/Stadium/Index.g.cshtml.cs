#pragma checksum "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e9216b1486c91944a3fb6c3bbec3775ad6dbfed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stadium_Index), @"mvc.1.0.view", @"/Views/Stadium/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stadium/Index.cshtml", typeof(AspNetCore.Views_Stadium_Index))]
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
#line 1 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\_ViewImports.cshtml"
using WebAppFootball.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e9216b1486c91944a3fb6c3bbec3775ad6dbfed", @"/Views/Stadium/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1a923d2a0dac882ab03c489a8e1f2347cf7b4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Stadium_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Stadium>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(63, 243, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n<a href=\"/stadium/create\">Create</a>\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <td>ID</td>\r\n        <td>Name</td>\r\n        <td>City</td>\r\n        <td>Year of Beginnign</td>\r\n        <td>Delete</td>\r\n    </tr>\r\n");
            EndContext();
#line 16 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(347, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(378, 7, false);
#line 19 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
           Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(385, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(409, 9, false);
#line 20 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
           Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(418, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(442, 9, false);
#line 21 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
           Write(item.City);

#line default
#line hidden
            EndContext();
            BeginContext(451, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(475, 20, false);
#line 22 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
           Write(item.YearOfBeginning);

#line default
#line hidden
            EndContext();
            BeginContext(495, 43, true);
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 538, "\"", 569, 2);
            WriteAttributeValue("", 545, "/stadium/delete/", 545, 16, true);
#line 24 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
WriteAttributeValue("", 561, item.Id, 561, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(570, 75, true);
            WriteLiteral("><i class=\"fas fa-trash fa-4x\"></i></a>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 27 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Stadium\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(652, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Stadium>> Html { get; private set; }
    }
}
#pragma warning restore 1591
