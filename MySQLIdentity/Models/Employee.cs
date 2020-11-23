using System;
using System.Collections.Generic;

namespace MySQLIdentity.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string JobTitle { get; set; }
        public decimal? Salary { get; set; }
    }
}
