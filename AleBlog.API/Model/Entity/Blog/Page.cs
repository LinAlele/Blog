using System;
using System.ComponentModel.DataAnnotations;

namespace AleBlog.API.Model.Entity.Blog
{
    public class Page
    {
        /// <summary>
        /// 文章自增ID
        /// </summary>
        [Key]
        public int Page_Id { get; set; }

        /// <summary>
        /// 用户uid
        /// </summary>
        public int user_uid { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 项目节点组id
        /// </summary>
        public int item_id { get; set; }

        /// <summary>
        /// 项目 组子节点 id
        /// </summary>
        public int cat_id { get; set; }

        /// <summary>
        ///  标题
        /// </summary>
        public string page_title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string page_content { get; set; }

        /// <summary>
        /// 若超99个字符 markdown 不做渲染
        /// </summary>
        public int s_number { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public int Create_Dt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public int page_comments { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public int is_del { get; set; }

    }
}
