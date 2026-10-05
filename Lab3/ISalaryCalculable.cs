using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public interface ISalaryCalculable
    {
        int HoursWorked { get; set; }
        double CalculateMonthlySalary(int hoursWorked);
    }
}