namespace WebAppMvcDemo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; } = 0;
        public string Position { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public bool IsEnabled { get; set; } = true;

    }
}
