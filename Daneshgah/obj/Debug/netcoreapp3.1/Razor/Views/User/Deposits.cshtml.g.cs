#pragma checksum "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "926dea0c41c88c1768a91f37141f0d13285cc45d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Deposits), @"mvc.1.0.view", @"/Views/User/Deposits.cshtml")]
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
#line 1 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
using Daneshgah.MethodHa.TabdilTarikh;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"926dea0c41c88c1768a91f37141f0d13285cc45d", @"/Views/User/Deposits.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7e796ac3b28babfde4b04070acbce39a86a4614", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Deposits : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Deposit>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveFromDeposits", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn--danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <div class=""text-center"">
        <h1 class=""mt-5 mb-5 text-title-experts"">امانت های من </h1>
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
                        <th style=""width: 15%"">دستورات</th>
                    </tr>
                </thead>
                <tb");
            WriteLiteral("ody>\r\n");
#nullable restore
#line 28 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                     foreach (var amanat in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.RespiteTime.ToShamsiCalender());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Book.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Book.Topic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Book.ISBN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Book.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Book.PublicationYear.ToShamsiCalender());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                           Write(amanat.Book.Publisher);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"width: 15%\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "926dea0c41c88c1768a91f37141f0d13285cc45d8078", async() => {
                WriteLiteral("عودت کتاب");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-amanatId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
                                                                                                 WriteLiteral(amanat.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["amanatId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-amanatId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["amanatId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 43 "D:\Source\Daneshgah\Daneshgah\Daneshgah\Views\User\Deposits.cshtml"
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