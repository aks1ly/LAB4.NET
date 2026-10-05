using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class EmployeeAnalysis
    {
        public static double CalculateTotalSalaryFund(IEnumerable<ISalaryCalculable> employees) 
            //перебираємо об'єкти не як Programmer, Designer чи Manager, а об'єкти з інтерфейсом ISalaryCalculable
        {
            double total = 0;
            foreach (ISalaryCalculable employee in employees)
            {
                total += employee.CalculateMonthlySalary(employee.HoursWorked);
            }
            return total;
        }

    }
}