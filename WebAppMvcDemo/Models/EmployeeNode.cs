namespace WebAppMvcDemo.Models
{
    public class EmployeeNode
    {
        public int? EmployeeId { get; set; }
        public string Position { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public int? Level { get; set; }
        public bool IsEnabled { get; set; } = true;

        public List<EmployeeNode> Children { get; set; } = new List<EmployeeNode>();
    }
}
