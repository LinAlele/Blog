using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AleBlog.API.Model.Dto.Response
{
    public class PageResponse<T>
    {
        public int Total { get; set; }

        private List<T> _data;
        public List<T> Data { get { return _data ?? new List<T>(); } set { _data = value; } }
    }
}
