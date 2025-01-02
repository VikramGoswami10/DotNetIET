using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34EntityFramework.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column("EId",TypeName="int")]
        public int Id { get; set; }

        [Column("EName",TypeName ="varchar(50)")]
        public string EName { get; set; }

        [Column("EAddress",TypeName ="varchar(50)")]
        public string Address { get; set; }
    }
}
