using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseApi.Models
{
    public class Makes
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<Models> Models { get; set; }

    }
}
