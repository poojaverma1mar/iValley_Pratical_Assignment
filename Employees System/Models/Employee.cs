using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employees_System.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }  
        public string City { get; set; }       
        public string Zip { get; set; }  
        public DateTime CreatedDate { get; set; }
    }
}