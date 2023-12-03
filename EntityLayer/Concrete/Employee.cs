using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {
        //Employee içindeki alanlarımızın tanımı
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeGender { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
    }
}
