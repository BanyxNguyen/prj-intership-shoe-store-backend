#pragma checksum "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(prjShoeStore.Areas.Admin.Pages.OrderReportPage.Areas_Admin_Pages_OrderReportPage_Index), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/OrderReportPage/Index.cshtml")]
namespace prjShoeStore.Areas.Admin.Pages.OrderReportPage
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
#line 1 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\_ViewImports.cshtml"
using prjShoeStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\_ViewImports.cshtml"
using prjShoeStore.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c", @"/Areas/Admin/Pages/OrderReportPage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"296911d0b7aa9b83934a5372001f685a66160ee4", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_OrderReportPage_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/DashBoardPage/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
  
    ViewData["Title"] = "OrderReport";
    Layout = "Templates/_LayoutIndex";
    ViewData["TableId"] = "OrderReport";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("HeaderLayout", async() => {
                WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>OrderReport</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c5595", async() => {
                    WriteLiteral("Home");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n                    <li class=\"breadcrumb-item active\">OrderReport</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c6965", async() => {
                    WriteLiteral("\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-6\">\r\n                    <div class=\"form-group\">\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c7385", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 27 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Start);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c9075", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 28 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Start);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-6\">\r\n                    <div class=\"form-group\">\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c10906", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 33 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.End);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "285c1c7c9f070a0674ce1c5bdc223d1da0a00b1c12595", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 34 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.End);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-6\">\r\n                    <button class=\"btn btn-success\">Search</button>\r\n                </div>\r\n            </div>\r\n        ");
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
                WriteLiteral("\r\n    </div><!-- /.container-fluid -->\r\n");
            }
            );
            WriteLiteral("\r\n<table class=\"table table-striped table-bordered table-sm\" cellspacing=\"0\" width=\"100%\"");
            BeginWriteAttribute("id", " id=\"", 1625, "\"", 1646, 1);
#nullable restore
#line 45 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
WriteAttributeValue("", 1630, ViewBag.TableId, 1630, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th>#</th>\r\n            <th>\r\n                ");
#nullable restore
#line 50 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].NgayLap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 53 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].TenNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 56 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].DiaChiNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 59 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].SoDienThoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 62 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 65 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].PaymentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 68 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].TongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 73 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
         foreach (var item in Model.DonDatHang)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            WriteLiteral("@\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 80 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NgayLap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 83 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TenNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 86 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DiaChiNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 89 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SoDienThoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 92 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 95 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaymentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 98 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 101 "D:\ProjectOrder\prj-intership-shoe-store-backend\prjShoeStore\Areas\Admin\Pages\OrderReportPage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<prjShoeStore.Areas.Admin.Pages.OrderReportPage.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<prjShoeStore.Areas.Admin.Pages.OrderReportPage.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<prjShoeStore.Areas.Admin.Pages.OrderReportPage.IndexModel>)PageContext?.ViewData;
        public prjShoeStore.Areas.Admin.Pages.OrderReportPage.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591