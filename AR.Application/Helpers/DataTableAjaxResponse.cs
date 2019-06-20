using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Helpers
{
    public class DataTableAjaxResponse<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public T data { get; set; }
    }
}
