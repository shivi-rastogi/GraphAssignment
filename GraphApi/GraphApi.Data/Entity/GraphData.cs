using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GraphApi.Data.Entity
{
    public class GraphData
    {
        [Key]
        [Column(Order = 1)]
        public String SessionID { get; set; }
        [Key]
        [Column(Order = 2)]
        [RegularExpression("^[a-zA-Z0-9]*$",ErrorMessage ="Name can be alphanumeric only.")]
        public string Name { get; set; }
        public string Color { get; set; }
        public int height { get; set; }
    }
}