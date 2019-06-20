using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Helpers
{
    public interface IDataTableAjaxModel
    {
        int draw { get; set; }
        int start { get; set; }
        int length { get; set; }
        List<Column> columns { get; set; }
        Search search { get; set; }
        List<Order> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}
