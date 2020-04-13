using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AleBlog.API.Model.Dto.Response
{
    public class Responce<T>
    {
        public T Result { get; set; }
    }
}
