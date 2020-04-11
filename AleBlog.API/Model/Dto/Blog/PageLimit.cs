using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AleBlog.API.Model.Dto.Blog
{
    public class PageLimit
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 限制条数
        /// </summary>
        public int Limit { get; set; }
    }
}
