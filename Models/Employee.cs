using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCRUD.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Column("Name")]
        public string EmployeeName { get; set; }

        public DateTime JoiningDate { get; set; }

        public string Designation { get; set; }

        [Column("Address")]
        public string CurrentAddress { get; set; }

       

        public decimal Salary { get; set; }

      
    }
}
