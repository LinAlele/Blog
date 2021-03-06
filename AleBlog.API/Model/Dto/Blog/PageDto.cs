﻿using AleBlog.API.Model.Entity.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AleBlog.API.Model.Dto.Blog
{
    public class PageDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容 markdown 
        /// </summary>
        public string Page_Content { get; set; }
        /// <summary>
        /// markdown 转 html
        /// </summary>
        public string page_html { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Create_Dt_Str { get; set; }

        public PageToPageDto Previous{ get; set; }

        public PageToPageDto Next { get; set; }
    }
}
