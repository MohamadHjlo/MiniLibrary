#pragma checksum "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73b01db2599c84ae7a8ad94eb8bcb1af86ee09ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Non_performingDeposites), @"mvc.1.0.view", @"/Views/Admin/Non-performingDeposites.cshtml")]
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
#line 1 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\_ViewImports.cshtml"
using Daneshgah;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\_ViewImports.cshtml"
using Daneshgah.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
using Daneshgah.MethodHa.TabdilTarikh;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73b01db2599c84ae7a8ad94eb8bcb1af86ee09ce", @"/Views/Admin/Non-performingDeposites.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7e796ac3b28babfde4b04070acbce39a86a4614", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Non_performingDeposites : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Deposit>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <div class=""text-center"">
        <h1 class=""mt-5 mb-5 text-title-experts"">امانت های به موقع تحویل داده نشده </h1>
        <div class=""col-md-12 col-lg-12 col-xl-12 col-sm-12 col-12 box-shadow pt-5 box-container mt-5 pb-3"">
            <table class=""table table-bordered table-responsive-sm table-hover"">
                <thead class=""thead-custom"">
                    <tr class=""text-center"">
                        <th height=""20"" class=""xl636160"" align=""left"" width=""20"" style=""height: 15.0pt; width: 15pt"">
                            شماره
                        </th>
                        <th>مهلت عودت</th>
                        <th>عنوان</th>
                        <th>موضوع</th>
                        <th>شابک</th>
                        <th>تعداد صفحات</th>
                        <th>سال انتشار</th>
                        <th>ناشر</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 27 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                     foreach (var amanat in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 30 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.RespiteTime.ToShamsiCalender());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Book.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Book.Topic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Book.ISBN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Book.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Book.PublicationYear.ToShamsiCalender());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                           Write(amanat.Book.Publisher);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 39 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\Admin\Non-performingDeposites.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Deposit>> Html { get; private set; }
    }
}
#pragma warning restore 1591
