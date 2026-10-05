using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public abstract class Employee : ISalaryCalculable, IProjectable
    {
        private string position;
        public string Position
        {
            get { return position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Посада не може бути порожньою.");
                position = value;
            }
        }
        public int Experience { get; set; }
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public Employee(string position, int experience, double hourlyRate)
        {
            Position = position;
            Experience = experience;
            HourlyRate = hourlyRate;
        }
        public abstract double CalculateMonthlySalary(int hoursWorked);
        public abstract List<string> GetProjects();
    }
}
