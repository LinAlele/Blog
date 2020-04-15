#pragma checksum "D:\代码库\AleBlog\AleBlog.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b64d55c38f1da359b3784398825ef1d6721465b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\代码库\AleBlog\AleBlog.Web\Views\_ViewImports.cshtml"
using AleBlog.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\代码库\AleBlog\AleBlog.Web\Views\_ViewImports.cshtml"
using AleBlog.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b64d55c38f1da359b3784398825ef1d6721465b9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a21d674a05ba9f344b0e0db812106ea22ac56d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/axios.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/template-web.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\代码库\AleBlog\AleBlog.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Test";

#line default
#line hidden
#nullable disable
            DefineSection("CSS", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b64d55c38f1da359b3784398825ef1d6721465b94649", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
<style>
    .paging {
        display: flex;
        flex-direction: row;
        justify-content: center;
        list-style: none;
        white-space: nowrap;
        width: 100%;
    }
    .paging .pagnum {
        font-size:20px;
        padding: 6px 6px;
    }

</style>
");
            }
            );
            WriteLiteral(@"<div class=""main"">
    <div id=""page-title-tpl"" class=""page-wrap pmobile"">
        <script id=""tpl"" type=""text/template"">
            {{each data}}
            <h3>
                {{$value.year}}
            </h3>
            {{each $value.pageTitleDtos}}
            <article>
                <a href=""/Blog/Page?page_id={{$value.page_Id}}"">{{$value.page_Title}} </a>
                <span class=""article-item-createdt"">{{$value.create_Dt}}</span>
            </article>
            {{/each}}
            {{/each}}
        </script>
        <nav class=""paging""></nav>
    </div>
    
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b64d55c38f1da359b3784398825ef1d6721465b96903", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b64d55c38f1da359b3784398825ef1d6721465b98006", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <script>
            //dev
            var api_domain = ""http://localhost:5002"";
            //produce
            //var api_domain = ""http://47.95.255.71:7002"";

            var page = getQueryVariable(""page"");
            page = page ? Number(page): 1;
            var limit = 4;
            
            axios.get(`${api_domain}/blog/page/querypage?Page=${page == false ? '1' : page}&Limit=${limit == false ? '4' : limit} `, { withCredentials: true }).then(function (response) {

                if (response.status == '200') {
                    var html = template('tpl', response.data);
                    document.querySelector('#page-title-tpl').insertAdjacentHTML('afterbegin',html);

                    var totalPaging = Math.ceil(response.data.total / limit);
                    var pagingHtml = """";

                    var InitPageNum = 5;//分页一行显示5页

                   

                   


                    var halve = Math.floor(totalPaging / 2);
               ");
                WriteLiteral(@"     var mp = Math.floor(InitPageNum / 2); 

                    var pageIndex = 1;

                    if (halve < InitPageNum) {
                        for (pageIndex = 1; pageIndex <= totalPaging; pageIndex++) {
                            //当总页数低于页码行数
                            pagingHtml += page == pageIndex ? `<span class=""pagnum curr"">${pageIndex}</span>` : `<a class=""pagnum"" href=""?page=${pageIndex}&limit=${limit}"">${pageIndex}</a>`;
                        }
                    }

                    if (halve >= InitPageNum) {
                        pagingHtml += page == 1 ? `<span class=""pagnum curr"">▲</span>` : `<a class=""pagnum"" href=""?page=${page - 1}&limit=${limit}"">▲</a>`;
                        if (page >= 1 && page < InitPageNum) {
                            for (pageIndex = 1; pageIndex <= InitPageNum; pageIndex++) {
                                pagingHtml += page == pageIndex ? `<span class=""pagnum curr"">${pageIndex}</span>` : `<a class=""pagnum"" href=""?page=${pageIn");
                WriteLiteral(@"dex}&limit=${limit}"">${pageIndex}</a>`;
                            }
                            pagingHtml += '<span class=""pagnum"">...</span>';
                            pagingHtml += `<a class=""pagnum"" href=""?page=${totalPaging}&limit=${limit}"">${totalPaging}</a>`;
                        }

                        if (page >= InitPageNum && page <= totalPaging - InitPageNum) {
                            pagingHtml += `<a class=""pagnum"" href=""?page=${1}&limit=${limit}"">1</a>`;
                            pagingHtml += '<span class=""pagnum"">...</span>';
                            for (pageIndex = (page - mp); pageIndex <= (page + mp); pageIndex++) {
                                pagingHtml += page == pageIndex ? `<span class=""pagnum curr"">${pageIndex}</span>` : `<a class=""pagnum"" href=""?page=${pageIndex}&limit=${limit}"">${pageIndex}</a>`;
                            }
                            pagingHtml += '<span class=""pagnum"">...</span>';
                            pagingHtml += `<");
                WriteLiteral(@"a class=""pagnum"" href=""?page=${totalPaging}&limit=${limit}"">${totalPaging}</a>`;
                        }

                        if (page <= totalPaging && page > totalPaging - InitPageNum) {
                            pagingHtml += `<a class=""pagnum"" href=""?page=${1}&limit=${limit}"">1</a>`;
                            pagingHtml += '<span class=""pagnum"">...</span>';
                            for (pageIndex = (totalPaging - InitPageNum); pageIndex <= totalPaging; pageIndex++) {
                                pagingHtml += page == pageIndex ? `<span class=""pagnum curr"">${pageIndex}</span>` : `<a class=""pagnum"" href=""?page=${pageIndex}&limit=${limit}"">${pageIndex}</a>`;
                            }
                        }
                        pagingHtml += page == totalPaging ? `<span class=""pagnum curr"">▼</span>` : `<a class=""pagnum"" href=""?page=${page - 1}&limit=${limit}"">▼</a>`;
                    }

                



                    document.querySelector('.paging').inne");
                WriteLiteral("rHTML = pagingHtml;\r\n                }\r\n                else {\r\n                    console.log(response.data.message);\r\n                }\r\n            });\r\n        </script>\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
