using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseApi.Models
{
    public class Models
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int? makeId { get; set; }

        [ForeignKey("makeId")]
        public virtual Makes Makes { get; set; }

        public int modelId { get; set; }

    }
}
