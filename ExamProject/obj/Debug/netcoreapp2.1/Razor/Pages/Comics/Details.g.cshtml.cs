#pragma checksum "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a778ba2d3d8d08479b14b1a163d019cb7cb597b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Comics_Details), @"mvc.1.0.razor-page", @"/Pages/Comics/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Comics/Details.cshtml", typeof(AspNetCore.Pages_Comics_Details), @"{id:int}")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id:int}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a778ba2d3d8d08479b14b1a163d019cb7cb597b", @"/Pages/Comics/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1a451c1f60420a58f7cf83e29197a5e068c5f9c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Comics_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ComicPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(150, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(152, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "50e02596c5ba4f89a1c6eafef6ac030a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(184, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 10 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
 if (Model.Comic.OwnerUsername == Model.User.Identity.Name)
{

#line default
#line hidden
            BeginContext(252, 6, true);
            WriteLiteral("    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 258, "\"", 298, 2);
            WriteAttributeValue("", 265, "/comic/addchapter/", 265, 18, true);
#line 12 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
WriteAttributeValue("", 283, Model.Comic.Id, 283, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(299, 39, true);
            WriteLiteral("><p align=\"right\">Add Chapter</p></a>\r\n");
            EndContext();
#line 13 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
}

#line default
#line hidden
            BeginContext(341, 134, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <tbody>\r\n        <tr style=\"text-align: left;\">\r\n            <td style=\"height: 190px; width: 250px\"><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 475, "\"", 504, 2);
            WriteAttributeValue("", 481, "/", 481, 1, true);
#line 18 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
WriteAttributeValue("", 482, Model.Comic.Cover.Url, 482, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(505, 121, true);
            WriteLiteral(" style=\"width: 190px; height: 250px\" /></td>\r\n            <td align=\"right\"></td>\r\n            <td>\r\n                <h2>");
            EndContext();
            BeginContext(627, 17, false);
#line 21 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
               Write(Model.Comic.Title);

#line default
#line hidden
            EndContext();
            BeginContext(644, 43, true);
            WriteLiteral("</h2>\r\n                <p>Year of Release:\t");
            EndContext();
            BeginContext(688, 10, false);
#line 22 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
                                  Write(Model.Year);

#line default
#line hidden
            EndContext();
            BeginContext(698, 33, true);
            WriteLiteral("</p>\r\n                <p>Genres: ");
            EndContext();
            BeginContext(732, 10, false);
#line 23 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
                      Write(Model.Tags);

#line default
#line hidden
            EndContext();
            BeginContext(742, 89, true);
            WriteLiteral("</p>\r\n                <p>Reading Direction:\t<b>Right to Left</b></p>\r\n                <p>");
            EndContext();
            BeginContext(832, 23, false);
#line 25 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
              Write(Model.Comic.Description);

#line default
#line hidden
            EndContext();
            BeginContext(855, 261, true);
            WriteLiteral(@"</p>
            </td>
        </tr>
    </tbody>
</table>

<table class=""table table-hover"">
    <thead>
        <tr>
            <th scope=""col"">Chapter Name</th>
            <th scope=""col"">Day Added</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 39 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
         foreach (var chapter in Model.Chapters)
        {

#line default
#line hidden
            BeginContext(1177, 123, true);
            WriteLiteral("            <tr style=\"text-align: left;\">\r\n                <td align=\"left\"><a style=\"text-decoration: none; color: black\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1300, "\"", 1333, 2);
            WriteAttributeValue("", 1307, "/chapters/read/", 1307, 15, true);
#line 42 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
WriteAttributeValue("", 1322, chapter.Id, 1322, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1334, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1336, 13, false);
#line 42 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
                                                                                                             Write(chapter.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1349, 56, true);
            WriteLiteral("</a></td>\r\n                <td>\r\n                    <p>");
            EndContext();
            BeginContext(1406, 38, false);
#line 44 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
                  Write(chapter.UploadDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1444, 48, true);
            WriteLiteral("</p>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 47 "C:\Users\User\source\repos\ExamProject\ExamProject\Pages\Comics\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1503, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Art.App.Pages.Comics.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Art.App.Pages.Comics.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Art.App.Pages.Comics.DetailsModel>)PageContext?.ViewData;
        public Art.App.Pages.Comics.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591