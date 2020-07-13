#pragma checksum "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc617fe3d46a7698bc5d501f89324729c5384fbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Products), @"mvc.1.0.view", @"/Views/Home/Products.cshtml")]
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
#line 1 "D:\APS NETCORE\Casetudy\Views\_ViewImports.cshtml"
using Casetudy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\APS NETCORE\Casetudy\Views\_ViewImports.cshtml"
using Casetudy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\APS NETCORE\Casetudy\Views\_ViewImports.cshtml"
using Casetudy.Views.ViewsModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\APS NETCORE\Casetudy\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\APS NETCORE\Casetudy\Views\_ViewImports.cshtml"
using Casetudy.Views.ViewsModel.Order;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc617fe3d46a7698bc5d501f89324729c5384fbc", @"/Views/Home/Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc9cbadba6c8992287d4faf64a98beb719f857d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Products : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Employees>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("level-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("range-field"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
  
    ViewBag.Title = "Products ";
    List<Carbrand> carbrands = ViewBag.Category;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container-lg mt-2 "">
    <div class=""row"">
        <div class=""col"">
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb"">
                    <li class=""breadcrumb-item""><a href=""#"">Tất Cả Sản Phẩm</a></li>
                    <li class=""breadcrumb-item active"" aria-current=""page"">Danh Mục Sản Phẩm</li>
                </ol>
            </nav>
        </div>
    </div>
</div>


<section>
    <div class=""row"">
        <!--Grid column-->
        <div class=""col-lg-3   border p-4 "">

            <!-- Filter panel -->
            <div class=""mb-5"">
                <h5 class=""font-weight-bold mb-3 text-warning"">Danh Mục Sản Phẩm</h5>

                <div class=""divider-small mb-3""></div>

                <ul class=""list-unstyled link-black"">

                    <li class=""card-footer"">

");
#nullable restore
#line 37 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                         if (carbrands != null)
                        {
                            foreach (Carbrand carbrand in carbrands)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc617fe3d46a7698bc5d501f89324729c5384fbc7222", async() => {
                WriteLiteral("\r\n                                    <i class=\"fas fa-car text-danger\"></i>\r\n                                    <span class=\"text-white\">");
#nullable restore
#line 44 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                                                        Write(carbrand.CarbrandName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span><br /><hr />\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                                                                                                   WriteLiteral(carbrand.CarbrandId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 46 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"

                            }

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("                </ul>\r\n                <hr />\r\n            </div>\r\n            <!-- Filter panel -->\r\n            <!-- Filter panel -->\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 3306, "\"", 3314, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                <h5 class=\"font-weight-bold text-warning\">Hỗ Trợ Trực Tuyến</h5>\r\n");
            WriteLiteral(@"
                <div class=""block-content"">
                    <div class=""sp_1"">
                        <p> <i class=""fas fa-phone-square-alt""></i>Tư vấn bán hàng 1</p>
                        <p class=""text-white"">Mr.Tuấn: <span>098.590.8888</span></p>
                    </div>
                    <div class=""sp_2"">
                        <p>Tư vấn bán hàng 2</p>
                        <p class=""text-white"">Mr.Cường: <span>093.564.6666</span></p>
                    </div>
                    <div class=""sp_mail"">
                        <p>Email liên hệ</p>
                        <p class=""text-white"">Xuanc25@gmail.com</p>
                    </div>
                </div>
            </div>
            <!-- Filter panel -->
            <!-- Filter panel -->
            <div class=""mb-5"">

                <h5 class=""font-weight-bold mb-3"">Price</h5>

                <div class=""divider-small mb-3""></div>

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc617fe3d46a7698bc5d501f89324729c5384fbc11895", async() => {
                WriteLiteral("\r\n                    <input type=\"range\" min=\"0\" max=\"319\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                <div class=""row justify-content-center"">

                    <!-- Grid column -->
                    <div class=""col-md-6 text-left"">
                        <p class=""dark-grey-text""><strong id=""resellerEarnings"">0$</strong></p>
                    </div>
                    <!-- Grid column -->
                    <!-- Grid column -->
                    <div class=""col-md-6 text-right"">
                        <p class=""dark-grey-text""><strong id=""clientPrice"">1000$</strong></p>
                    </div>
                    <!-- Grid column -->
                </div>

            </div>
            <!-- Filter panel -->
            <!-- Filter panel -->
            <div class=""link-black"">

                <h5 class=""font-weight-bold mb-3"">Rating</h5>

                <div class=""divider-small mb-3""></div>

                <div class=""amber-text fa-sm mb-1"">
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
     ");
            WriteLiteral("               <i class=\"fas fa-star\"></i>\r\n                    <i class=\"fas fa-star\"></i>\r\n                    <i class=\"fas fa-star\"></i>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 5788, "\"", 5795, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""ml-2 active"">4 and more</a>
                </div>

                <div class=""amber-text fa-sm mb-1"">
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <a");
            BeginWriteAttribute("href", " href=\"", 6179, "\"", 6186, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""ml-2"">3 - 3,99</a>
                </div>

                <div class=""amber-text fa-sm mb-1"">
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <i class=""fas fa-star""></i>
                    <a");
            BeginWriteAttribute("href", " href=\"", 6561, "\"", 6568, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"ml-2\">3.00 and less</a>\r\n                </div>\r\n\r\n\r\n                <!-- Filter panel -->\r\n            </div>\r\n        </div>\r\n        <!--Grid column-->\r\n");
#nullable restore
#line 174 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
         foreach (var pb in Model)
        {
            var avatarPath = $"/images/{(pb.AvatarPath ?? "FORRD")}";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container col-lg-3 \">\r\n        <div class=\"row\">\r\n            <div class=\"card mx-2\" style=\"width:400px\">\r\n");
            WriteLiteral("\r\n                <img class=\"MyImage\"");
            BeginWriteAttribute("src", " src=\"", 7137, "\"", 7154, 1);
#nullable restore
#line 184 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
WriteAttributeValue("", 7143, avatarPath, 7143, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <div class=\"card-footer text-center\">\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc617fe3d46a7698bc5d501f89324729c5384fbc16853", async() => {
                WriteLiteral("<h6>");
#nullable restore
#line 187 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                                                                                                         Write(pb.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 187 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                                                                    WriteLiteral(pb.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <span class=\"woocommerce-Price-amount amount text-danger\">");
#nullable restore
#line 188 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                                                                         Write(pb.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;<span class=\"woocommerce-Price-currencySymbol\">₫</span></span>\r\n                </div>\r\n                <div class=\"card-body text-center\"  style=\"color:#fdd835\">\r\n                    <a>Hộp số:Số tự động</a>\r\n");
            WriteLiteral("\r\n                </div>\r\n\r\n");
            WriteLiteral("\r\n            </div>\r\n\r\n\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 220 "D:\APS NETCORE\Casetudy\Views\Home\Products.cshtml"
                  

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n");
            WriteLiteral("\r\n        </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#myInput"").on(""keyup"", function () {
                var value = $(this).val().toLowerCase();
                $(""#search h2"").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Employees>> Html { get; private set; }
    }
}
#pragma warning restore 1591