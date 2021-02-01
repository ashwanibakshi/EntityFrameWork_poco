using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
   public class repository
    {
        public object getGridData()
        {
            using (empDBContext emp = new empDBContext())
            {
                return (from employee in emp.employees
                        join department in emp.departments
                        on employee.Department.Id equals department.Id
                        select new { firstname = employee.FirstName, lastname = employee.LastName, name = department.Name }).ToList();
           }
        }
    }
}
