#pragma checksum "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e633b51d86d35217edb057a3f5db9f15ec9542a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_LikedPictures), @"mvc.1.0.razor-page", @"/Pages/LikedPictures.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/LikedPictures.cshtml", typeof(AspNetCore.Pages_LikedPictures), @"{username}")]
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
#line 1 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\_ViewImports.cshtml"
using Art;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\_ViewImports.cshtml"
using Art.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{username}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e633b51d86d35217edb057a3f5db9f15ec9542a", @"/Pages/LikedPictures.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1a451c1f60420a58f7cf83e29197a5e068c5f9c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_LikedPictures : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
  
    ViewData["Title"] = "LikedPictures";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(157, 57, true);
            WriteLiteral("\r\n\r\n<table class=\"table table-borderless\">\r\n    <tbody>\r\n");
            EndContext();
#line 11 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
         for (int i = 0; i < Model.LikedPictures.Count; i += 3)
        {

#line default
#line hidden
            BeginContext(290, 291, true);
            WriteLiteral(@"            <tr>
                <td>
                    <div class=""text-center"">
                        <div class=""card"" style=""background-color: #fafafa; max-width: 400px"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">");
            EndContext();
            BeginContext(582, 28, false);
#line 18 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                  Write(Model.LikedPictures[i].Title);

#line default
#line hidden
            EndContext();
            BeginContext(610, 325, true);
            WriteLiteral(@"</h5>
                                <div class=""container"">
                                    <div class=""row"">
                                        <div style=""text-align: left"" class=""col-lg-8 d-flex align-items-stretch"">
                                            <a style=""text-decoration: none; color: black""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 935, "\"", 983, 2);
            WriteAttributeValue("", 942, "/profile/", 942, 9, true);
#line 22 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 951, Model.LikedPictures[i].UserName, 951, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(984, 47, true);
            WriteLiteral("><p style=\"text-align: left\" class=\"card-text\">");
            EndContext();
            BeginContext(1032, 31, false);
#line 22 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                                                                                                                                                     Write(Model.LikedPictures[i].UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1063, 265, true);
            WriteLiteral(@"</p></a>
                                        </div>
                                        <div style=""text-align: right"" class=""col-lg-4 d-flex align-items-stretch"">
                                            <a style=""text-decoration: none; color: black""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1328, "\"", 1378, 2);
            WriteAttributeValue("", 1335, "/viewimage/image/", 1335, 17, true);
#line 25 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 1352, Model.LikedPictures[i].Id, 1352, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1379, 47, true);
            WriteLiteral("><p style=\"text-align: left\" class=\"card-text\">");
            EndContext();
            BeginContext(1427, 28, false);
#line 25 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                                                                                                                                                       Write(Model.LikedPictures[i].Likes);

#line default
#line hidden
            EndContext();
            BeginContext(1455, 214, true);
            WriteLiteral(" Likes</p></a>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1669, "\"", 1719, 2);
            WriteAttributeValue("", 1676, "/viewimage/image/", 1676, 17, true);
#line 30 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 1693, Model.LikedPictures[i].Id, 1693, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1720, 29, true);
            WriteLiteral("><img class=\"card-img-bottom\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1749, "\"", 1783, 2);
            WriteAttributeValue("", 1755, "/", 1755, 1, true);
#line 30 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 1756, Model.LikedPictures[i].Url, 1756, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1784, 133, true);
            WriteLiteral(" style=\"max-height: 200px; height: auto;\" /></a>\r\n                        </div>\r\n                    </div>\r\n                </td>\r\n");
            EndContext();
#line 34 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                 if (Model.LikedPictures.ElementAtOrDefault(i + 1) != null)
                {

#line default
#line hidden
            BeginContext(2013, 293, true);
            WriteLiteral(@"                    <td>
                        <div class=""text-center"">
                            <div class=""card"" style=""background-color: #fafafa; max-width: 400px"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">");
            EndContext();
            BeginContext(2307, 32, false);
#line 40 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                      Write(Model.LikedPictures[i + 1].Title);

#line default
#line hidden
            EndContext();
            BeginContext(2339, 89, true);
            WriteLiteral("</h5>\r\n                                    <a style=\"text-decoration: none; color: black\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2428, "\"", 2480, 2);
            WriteAttributeValue("", 2435, "/profile/", 2435, 9, true);
#line 41 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 2444, Model.LikedPictures[i + 1].UserName, 2444, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2481, 47, true);
            WriteLiteral("><p style=\"text-align: left\" class=\"card-text\">");
            EndContext();
            BeginContext(2529, 35, false);
#line 41 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                                                                                                                                                 Write(Model.LikedPictures[i + 1].UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2564, 84, true);
            WriteLiteral("</p></a>\r\n                                </div>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2648, "\"", 2702, 2);
            WriteAttributeValue("", 2655, "/viewimage/image/", 2655, 17, true);
#line 43 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 2672, Model.LikedPictures[i + 1].Id, 2672, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2703, 29, true);
            WriteLiteral("><img class=\"card-img-bottom\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2732, "\"", 2770, 2);
            WriteAttributeValue("", 2738, "/", 2738, 1, true);
#line 43 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 2739, Model.LikedPictures[i + 1].Url, 2739, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2771, 146, true);
            WriteLiteral(" style=\"max-height: 200px; height: auto\" /></a>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </td>\r\n");
            EndContext();
#line 48 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                }

#line default
#line hidden
            BeginContext(2936, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 49 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                 if (Model.LikedPictures.ElementAtOrDefault(i + 2) != null)
                {

#line default
#line hidden
            BeginContext(3032, 293, true);
            WriteLiteral(@"                    <td>
                        <div class=""text-center"">
                            <div class=""card"" style=""background-color: #fafafa; max-width: 400px"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">");
            EndContext();
            BeginContext(3326, 32, false);
#line 55 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                      Write(Model.LikedPictures[i + 2].Title);

#line default
#line hidden
            EndContext();
            BeginContext(3358, 89, true);
            WriteLiteral("</h5>\r\n                                    <a style=\"text-decoration: none; color: black\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3447, "\"", 3499, 2);
            WriteAttributeValue("", 3454, "/profile/", 3454, 9, true);
#line 56 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 3463, Model.LikedPictures[i + 2].UserName, 3463, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3500, 47, true);
            WriteLiteral("><p style=\"text-align: left\" class=\"card-text\">");
            EndContext();
            BeginContext(3548, 19, false);
#line 56 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                                                                                                                                                                                 Write(Model.LikedPictures);

#line default
#line hidden
            EndContext();
            BeginContext(3567, 101, true);
            WriteLiteral(".[i + 2].UserName</p></a>\r\n                                </div>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3668, "\"", 3722, 2);
            WriteAttributeValue("", 3675, "/viewimage/image/", 3675, 17, true);
#line 58 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 3692, Model.LikedPictures[i + 2].Id, 3692, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3723, 29, true);
            WriteLiteral("><img class=\"card-img-bottom\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3752, "\"", 3790, 2);
            WriteAttributeValue("", 3758, "/", 3758, 1, true);
#line 58 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
WriteAttributeValue("", 3759, Model.LikedPictures[i + 2].Url, 3759, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3791, 146, true);
            WriteLiteral(" style=\"max-height: 200px; height: auto\" /></a>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </td>\r\n");
            EndContext();
#line 63 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
                }

#line default
#line hidden
            BeginContext(3956, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 65 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\LikedPictures.cshtml"
        }

#line default
#line hidden
            BeginContext(3986, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Art.App.Pages.LikedPicturesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Art.App.Pages.LikedPicturesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Art.App.Pages.LikedPicturesModel>)PageContext?.ViewData;
        public Art.App.Pages.LikedPicturesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591