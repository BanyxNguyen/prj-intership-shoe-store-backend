#pragma checksum "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b9644d481b85c0153b38457e4d62d3302eb7ba1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(prjShoeStore.Areas.Admin.Pages.OrderPage.Areas_Admin_Pages_OrderPage_Index), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/OrderPage/Index.cshtml")]
namespace prjShoeStore.Areas.Admin.Pages.OrderPage
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
#line 1 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\_ViewImports.cshtml"
using prjShoeStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\_ViewImports.cshtml"
using prjShoeStore.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b9644d481b85c0153b38457e4d62d3302eb7ba1", @"/Areas/Admin/Pages/OrderPage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"296911d0b7aa9b83934a5372001f685a66160ee4", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_OrderPage_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/DashBoardPage/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Merchandise return"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/order-index.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "Templates/_LayoutIndex";
    ViewData["TableId"] = "Order";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("HeaderLayout", async() => {
                WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Order</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b9644d481b85c0153b38457e4d62d3302eb7ba16918", async() => {
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
                WriteLiteral("</li>\r\n                    <li class=\"breadcrumb-item active\">Order</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div><!-- /.container-fluid -->\r\n");
            }
            );
            WriteLiteral("\r\n<table class=\"table table-striped table-bordered table-sm\" cellspacing=\"0\" width=\"100%\"");
            BeginWriteAttribute("id", " id=\"", 813, "\"", 834, 1);
#nullable restore
#line 26 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
WriteAttributeValue("", 818, ViewBag.TableId, 818, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th>#</th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].TenNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].DiaChiNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].NgayLap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].SoDienThoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].PaymentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DonDatHang[0].KhachHang));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 57 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
         foreach (var item in Model.DonDatHang)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b9644d481b85c0153b38457e4d62d3302eb7ba112129", async() => {
                WriteLiteral("<i class=\"fas fa-cookie-bite\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b9644d481b85c0153b38457e4d62d3302eb7ba114541", async() => {
                WriteLiteral("<i class=\"fas fa-receipt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TenNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DiaChiNguoiNhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NgayLap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 74 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SoDienThoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 77 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 80 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaymentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <div class=\"dropdown\">\r\n                        <button class=\"btn btn-default dropdown-toggle\" type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 3119, "\"", 3132, 1);
#nullable restore
#line 84 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
WriteAttributeValue("", 3124, item.Id, 3124, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n                            ");
#nullable restore
#line 85 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </button>\r\n");
#nullable restore
#line 87 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                          
                            var temps = Html.GetOrderStatus(item.TrangThai);
                            if (temps != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"dropdown-menu\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 3555, "\"", 3581, 1);
#nullable restore
#line 91 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
WriteAttributeValue("", 3573, item.Id, 3573, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 92 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                     foreach (var status in Html.GetOrderStatus(item.TrangThai))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a style=\"width:100px\" class=\"dropdown-item btn-status\" href=\"#\" data-status=\"");
#nullable restore
#line 94 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                                                                                                 Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-order-id=\"");
#nullable restore
#line 94 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                                                                                                                         Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 94 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                                                                                                                                   Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 95 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n");
#nullable restore
#line 97 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 103 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.KhachHang.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 106 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b9644d481b85c0153b38457e4d62d3302eb7ba123863", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#nullable restore
#line 110 "C:\Users\devil\Desktop\intership\prjShoeStore\prjShoeStore\Areas\Admin\Pages\OrderPage\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<prjShoeStore.Areas.Admin.Pages.OrderPage.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<prjShoeStore.Areas.Admin.Pages.OrderPage.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<prjShoeStore.Areas.Admin.Pages.OrderPage.IndexModel>)PageContext?.ViewData;
        public prjShoeStore.Areas.Admin.Pages.OrderPage.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
