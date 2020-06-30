using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceLayer
{
    public class EmployeeController
    {
        public int EmployeeAfterFiveYears(EmployeeViewModel employee)
        {
            return employee.Age + 5;
        }
    }
}
