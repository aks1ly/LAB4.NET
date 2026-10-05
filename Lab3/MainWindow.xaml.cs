using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private List<Employee> employees = new List<Employee>();
        private List<string> projects = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void EmployeeTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AdditionalFieldLabel == null)
                return;
            if (EmployeeTypeComboBox.SelectedIndex == 0)
            {
                AdditionalFieldLabel.Text = "Рівень";
                LevelComboBox.Visibility = Visibility.Visible;
                SpecializationComboBox.Visibility = Visibility.Collapsed;
                TeamSizeTextBox.Visibility = Visibility.Collapsed;
            }
            else if (EmployeeTypeComboBox.SelectedIndex == 1)
            {
                AdditionalFieldLabel.Text = "Спеціалізація";
                LevelComboBox.Visibility = Visibility.Collapsed;
                SpecializationComboBox.Visibility = Visibility.Visible;
                TeamSizeTextBox.Visibility = Visibility.Collapsed;
            }
            else if (EmployeeTypeComboBox.SelectedIndex == 2)
            {
                AdditionalFieldLabel.Text = "Кількість працівників";
                LevelComboBox.Visibility = Visibility.Collapsed;
                SpecializationComboBox.Visibility = Visibility.Collapsed;
                TeamSizeTextBox.Visibility = Visibility.Visible;
            }
        }
        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProjectTextBox.Text))
            {
                MessageBox.Show("Введіть назву проєкту.");
                return;
            }
            projects.Add(ProjectTextBox.Text);
            ProjectsListBox.Items.Add(ProjectTextBox.Text);
            ProjectTextBox.Clear();
        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmployeeTypeComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Оберіть тип співробітника.");
                    return;
                }
                string position = PositionTextBox.Text;
                int experience = int.Parse(ExperienceTextBox.Text);
                double hourlyRate = double.Parse(HourlyRateTextBox.Text);
                int hoursWorked = int.Parse(HoursTextBox.Text);
                Employee employee;
                string employeeInfo;
                if (EmployeeTypeComboBox.SelectedIndex == 0)
                {
                    if (LevelComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Оберіть рівень програміста.");
                        return;
                    }
                    string level = ((ComboBoxItem)LevelComboBox.SelectedItem).Content.ToString()!;
                    Programmer programmer = new Programmer(position, experience, hourlyRate, level);
                    employee = programmer;
                    double salary = programmer.CalculateMonthlySalary(hoursWorked);
                    employeeInfo = $"Програміст | {programmer.Position} | стаж: {programmer.Experience} р. | {programmer.Level} | зарплата: {salary:F2} грн";
                }
                else if (EmployeeTypeComboBox.SelectedIndex == 1)
                {
                    if (SpecializationComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Оберіть спеціалізацію дизайнера.");
                        return;
                    }
                    string specialization = ((ComboBoxItem)SpecializationComboBox.SelectedItem).Content.ToString()!;
                    Designer designer = new Designer(position, experience, hourlyRate, specialization);
                    employee = designer;
                    double projectCost = designer.CalculateProjectCost(hoursWorked);
                    double salary = designer.CalculateMonthlySalary(hoursWorked);
                    employeeInfo = $"Дизайнер | {designer.Position} | стаж: {designer.Experience} р. | {designer.Specialization} | вартість проєкту: {projectCost:F2} грн | зарплата: {salary:F2} грн";
                }
                else
                {
                    int teamSize = int.Parse(TeamSizeTextBox.Text);
                    Manager manager = new Manager(position, experience, hourlyRate, teamSize);
                    employee = manager;
                    double salary = manager.CalculateMonthlySalary(hoursWorked);
                    employeeInfo = $"Менеджер | {manager.Position} | стаж: {manager.Experience} р. | команда: {manager.TeamSize} | зарплата: {salary:F2} грн";
                }
                employee.HoursWorked = hoursWorked;
                foreach (string project in projects)
                {
                    employee.GetProjects().Add(project);
                }
                employeeInfo += $" | проєкти: {string.Join(", ", employee.GetProjects())}";
                employees.Add(employee);
                EmployeesListBox.Items.Add(employeeInfo);
                double total = EmployeeAnalysis.CalculateTotalSalaryFund(employees);
                TotalSalaryTextBlock.Text = $"{total:F2} грн";
                PositionTextBox.Clear();
                ExperienceTextBox.Clear();
                HourlyRateTextBox.Clear();
                HoursTextBox.Clear();
                LevelComboBox.SelectedIndex = -1;
                SpecializationComboBox.SelectedIndex = -1;
                TeamSizeTextBox.Clear();
                projects.Clear();
                ProjectsListBox.Items.Clear();
                ProjectTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}