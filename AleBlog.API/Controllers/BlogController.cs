/**
 * author:linjiajia
 * 20200405
 * 【笔记】
 *  ResponseCache 
 *      CacheProfileName: Default允许缓存 Never不允许缓存
 *      VaryByQueryKeys这类特性是为了不同参数对应不同的返回结果，并将这些结果存放在客户端
 *      doc:https://docs.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-3.1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AleBlog.API.BaseStuct;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AleBlog.API.Model.Entity.Blog;
using AleBlog.API.Model.Dto.Blog;
using AleBlog.API.Model.Dto.Response;
using System.Globalization;

namespace AleBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "test1")]
    public partial class BlogController : ControllerBase
    {

        private readonly AleBlogDbContext _context;

        public BlogController(AleBlogDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 返回博客文
        /// </summary>
        /// <param name="page_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("page")]
        [ResponseCache(CacheProfileName = "Default", VaryByQueryKeys = new string[] { "page_id" })]
        public async Task<Responce<PageDto>> GetPageAsync(int page_id)
        {
       

            var page = await _context.Page.FirstOrDefaultAsync(f=>f.Page_Id==page_id);
            
            return new Responce<PageDto>() {  Result=new PageDto {  page_content=page.page_content} };
        }

        /// <summary>
        /// 返回测试数据
        /// </summary>
        /// <param name="pl"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("page/queryPage")]
        [ResponseCache(CacheProfileName = "Default", VaryByQueryKeys = new string[] { "page", "limit" })]
        public async Task<PageResponse<QueryPageTitlle>> QueryPageTitleAsync([FromQuery]PageLimit pl)
        {
            if (pl.Page == 0 || pl.Limit == 0){
                pl.Page = 1; pl.Limit = 10;
            }

            var pages = await _context.Page.ToListAsync();
            var count = pages.Count();

            var result = pages.OrderByDescending(o => o.Page_Id)
                .Skip((pl.Page - 1) * pl.Limit)
                .Take(pl.Limit)
                .Select(s => new PageTitleDto{
                    Page_Id =s.Page_Id,
                    Page_Title = s.page_title,
                    Create_Dt= GetDateTime(s.Create_Dt).ToString("MMMM dd, yyyy HH:mm:ss", new CultureInfo("en-us")),
                    Year = GetDateTime(s.Create_Dt).ToString("yyyy")
                })
                .GroupBy(g=>g.Year)
                .Select(s=>new QueryPageTitlle{
                     Year=s.Key,
                      PageTitleDtos=s.ToList()
                }).ToList();
            return new PageResponse<QueryPageTitlle>() { Total=count,Data=result};
        }

        /// <summary>
        /// 时间戳Timestamp转换成日期  
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        private DateTime GetDateTime(int timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = ((long)timeStamp * 10000000);
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);
            return targetDt;
        } 
    }
}
