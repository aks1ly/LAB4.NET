using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Programmer : Employee, IBonusCalculable
    {
        private string level;
        private List<string> projects = new List<string>();
        public string Level
        {
            get { return level; }
            set
            {
                if (value != "Junior" && value != "Senior")
                    throw new ArgumentException("Рівень повинен бути Junior або Senior.");
                level = value;
            }
        }
        public Programmer(string position, int experience, double hourlyRate, string level)
            : base(position, experience, hourlyRate)
        {
            Level = level;
        }
        public double CalculateBonus()
        {
            if (Level == "Senior")
                return HourlyRate * 20;
            else
                return HourlyRate * 10;
        }
        public override double CalculateMonthlySalary(int hoursWorked)
        {
            return HourlyRate * hoursWorked + CalculateBonus();
        }
        public override List<string> GetProjects()
        {
            return projects;
        }
    }
}