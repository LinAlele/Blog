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

namespace AleBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "test1")]
    public partial class TestController : ControllerBase
    {

        private readonly AleBlogDbContext _context;

        public TestController(AleBlogDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 返回测试数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("test")]
        [ResponseCache(CacheProfileName = "Default", VaryByQueryKeys = new string[] { "str" })]
        public async Task<string> GetTest(string str)
        {
            var page = await _context.Page.FirstOrDefaultAsync();
            return page.page_content;
        }
    }
}
