using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string? userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public DateTime createdAt { get; set; }
        public bool? status { get; set; }

        [ForeignKey("PersonID")]
        public int personID { get; set; }
        public Person person{ get; set; }
    }
}
