#pragma checksum "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Upload\FromUrl.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86f8b60609b5f2b8df2da61c81832d94678a8991"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Upload_FromUrl), @"mvc.1.0.view", @"/Views/Upload/FromUrl.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Upload/FromUrl.cshtml", typeof(AspNetCore.Views_Upload_FromUrl))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86f8b60609b5f2b8df2da61c81832d94678a8991", @"/Views/Upload/FromUrl.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1a923d2a0dac882ab03c489a8e1f2347cf7b4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Upload_FromUrl : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Programing\ASP.NET\Learn\Module_2\WebAppFootball\WebAppFootball\Views\Upload\FromUrl.cshtml"
  
    ViewData["Title"] = "FromUrl";

#line default
#line hidden
            BeginContext(45, 114, true);
            WriteLiteral("\r\n<h1>FromUrl</h1>\r\n<form method=\"post\">\r\n    <input type=\"url\" name=\"u\"/>\r\n    <button>Save</button>\r\n</form>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
