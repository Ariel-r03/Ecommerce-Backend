using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Characteristic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int characteristicID { get;set; }
        public string? detail { get; set; }

        public bool? status { get; set; }

    }
}
