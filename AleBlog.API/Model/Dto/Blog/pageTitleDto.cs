using System.Collections.Generic;

namespace AleBlog.API.Model.Dto.Blog
{
    public class PageTitleDto
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
        public IList<PageTitleDto> PageTitleDtos { get; set; }
    }
}
