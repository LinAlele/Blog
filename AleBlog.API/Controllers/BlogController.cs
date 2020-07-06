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
using Swashbuckle.AspNetCore.Filters.Extensions;

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
        /// 返回路径
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("dir")]
        [ResponseCache(CacheProfileName = "Default")]
        public async Task<string> GetDir(int page_id)
        {
            string result = $"AppDomain.CurrentDomain.BaseDirectory={AppDomain.CurrentDomain.BaseDirectory};Environment.CurrentDirectory={Environment.CurrentDirectory};";

            return result;
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
            var response = new Responce<PageDto>();

            var page = await _context.Page.FirstOrDefaultAsync(f=>f.Page_Id==page_id);

            if (page.Equals(null))
            {
                response.Message = $"page_id:{page_id}不存在";
                return response;
            }
            
            var previous = await _context.Page
                .Where(w => w.Create_Dt > page.Create_Dt)
                 .OrderBy(o => o.Create_Dt)
                .Take(1)
                .FirstOrDefaultAsync();

            var next = await _context.Page
                .Where(w => w.Create_Dt < page.Create_Dt)
                .OrderByDescending(o => o.Create_Dt)
                .Take(1)
                .FirstOrDefaultAsync();

           var result = new PageDto
            {
                Author = page.user_name,
                Title = page.page_title,
                Page_Content = page.page_content,
                Create_Dt_Str = GetDateTime(page.Create_Dt).ToString("yyyy-MM-dd HH:mm:ss"),
                Previous = previous ==null?null: new PageToPageDto()
                {
                     Page_Id=previous.Page_Id,
                      Title = previous.page_title
                } ,  
                Next = next == null?null: new PageToPageDto()
                {
                     Page_Id= next.Page_Id,
                      Title = next.page_title
                }

            };

            response.Result = result;

            return response;
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
            if (pl.Page == 0){
                pl.Page = 1;
            }
            if (pl.Limit == 0)
            {
               pl.Limit = 10;
            }

            var pages = await _context.Page.ToListAsync();
            var count = pages.Count();

            var result = pages.OrderByDescending(o => o.Create_Dt)
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

        public async Task<Responce<object>> PutPageQuery()
        {
            var response = new Responce<object>();

            Model.Entity.Blog.Page page = new Model.Entity.Blog.Page();
            
            //something data
            response.Result =await _context.Page.AddAsync(page);

            return response;
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
