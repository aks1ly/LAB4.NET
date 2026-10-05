using Lab3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3Tests
{
    [TestClass] //перевіряємо бонус менеджера, його зарплату, проєкти і найголовніше — поліморфну колекцію List<ISalaryCalculable>
    public class InterfaceTests
    {
        [TestMethod]
        public void ManagerCalculateBonus_ReturnsCorrectBonus()
        {
            Manager manager = new Manager("Менеджер", 5, 100, 4);
            double result = manager.CalculateBonus();
            Assert.AreEqual(400, result);
        }
        [TestMethod]
        public void ManagerCalculateMonthlySalary_ReturnsCorrectSalary()
        {
            Manager manager = new Manager("Менеджер", 5, 100, 4);
            double result = manager.CalculateMonthlySalary(160);
            Assert.AreEqual(16400, result);
        }
        [TestMethod]
        public void ManagerGetProjects_ReturnsProjects()
        {
            Manager manager = new Manager("Менеджер", 5, 100, 4);
            manager.GetProjects().Add("Evently");
            Assert.HasCount(1, manager.GetProjects());
        }
        [TestMethod]
        public void CalculateTotalSalaryFund_WorksWithInterface()
        {
            List<ISalaryCalculable> employees = new List<ISalaryCalculable>
            {
                new Programmer("Програміст", 2, 20, "Junior") { HoursWorked = 160 },
                new Designer("Дизайнер", 3, 25, "UI/UX") { HoursWorked = 100 },
                new Manager("Менеджер", 5, 30, 4) { HoursWorked = 160 }
            };
            double result = EmployeeAnalysis.CalculateTotalSalaryFund(employees);
            Assert.AreEqual(11100, result);
        }
    }
}