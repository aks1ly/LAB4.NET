using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Manager : Employee, IBonusCalculable
    {
        public int TeamSize { get; set; }
        private List<string> projects = new List<string>();
        public Manager(string position, int experience, double hourlyRate, int teamSize)
            : base(position, experience, hourlyRate)
        {
            TeamSize = teamSize;
        }
        public double CalculateBonus()
        {
            return TeamSize * 100;
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

