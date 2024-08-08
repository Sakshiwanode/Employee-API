using System.ComponentModel.DataAnnotations;

namespace Employee_API.Models
{
   
        public class Employee
        {
            [Key]
            public int EmpId { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string MobileNumber { get; set; }
            public string AlternateNumber { get; set; }
            public string CurrentAddress { get; set; }
            public string PermanentAddress { get; set; }
            public string Nationality { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string Pincode  { get; set; }
            public string CompanyName { get; set; }
            public DateTime JoiningDate { get; set; }
            public decimal CurrentCTC { get; set; }
            public string EmploymentType { get; set; }
            public string DocumentType { get; set; }
            public string DocumentNumber { get; set; }
        }
    }


