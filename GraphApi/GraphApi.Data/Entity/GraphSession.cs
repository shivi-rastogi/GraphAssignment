using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphApi.Data.Entity
{
    public class GraphSession
    {
        [Key]
        public int Id { get; set; }
        public string SessionId { get; set; }
        public List<GraphData> DataList { get; set; }
    }
}