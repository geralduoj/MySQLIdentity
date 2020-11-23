using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLIdentity.Models
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        workforceContext context;
        public EFEmployeeRepository(workforceContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Employee> Employees => context.Employee;
    }
}
