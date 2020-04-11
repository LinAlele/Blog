using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AleBlog.API.Model.Dto.Blog
{
    public class pageTitleDto
    {
        public int Page_Id { get; set; }
        /// <summary>
        ///  标题
        /// </summary>
        public string Page_Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Create_Dt { get; set; }

        /// <summary>
        /// 创建年份
        /// </summary>
        public string Year { get; set; }
    }

    public class QueryPageTitlle
    {
        public string Year { get; set; }
        public IList<pageTitleDto> PageTitleDtos { get; set; }
    }
}
