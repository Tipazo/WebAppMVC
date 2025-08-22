using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebAppMvcDemo.Models;

namespace WebAppMvcDemo.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _client;

        public EmployeeService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("API_EMPLOYEE"))
            };
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<EmployeeNode>> GetEmpleadosAsync()
        {
            var response = await _client.GetAsync($"api/Employee");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponseEmployeeNode>(json);
                return result?.Data ?? new List<EmployeeNode>();
            }
            return new List<EmployeeNode>();
        }

        public async Task<Employee?> GetEmpleadoByIdAsync(int employeeId)
        {
            var response = await _client.GetAsync($"api/Employee/{employeeId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponseEmployee>(json);

                return result?.Data ?? new Employee();
            }

            return new Employee();
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            var formData = new Dictionary<string, string>
            {
                { "EmployeeId", employee.EmployeeId.ToString()},
                { "Position", employee.Position },
                { "FullName", employee.FullName },
                { "ManagerId", employee.ManagerId?.ToString() ?? "" },
                { "IsEnabled", employee.IsEnabled ? "true" : "false" }
            };

            var content = new FormUrlEncodedContent(formData);

            var response = await _client.PutAsync("api/Employee", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponseEmployee>(json);
                return result?.Data;
            }

            return null;
        }

        public async Task<Employee?> CreateEmployeeAsync(Employee employee)
        {
            var formData = new Dictionary<string, string>
            {
                { "Position", employee.Position },
                { "FullName", employee.FullName },
                { "ManagerId", employee.ManagerId?.ToString() ?? "" },
                { "IsEnabled", employee.IsEnabled ? "true" : "false" }
            };

            var content = new FormUrlEncodedContent(formData);

            var response = await _client.PostAsync("api/Employee", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponseEmployee>(json);
                return result?.Data;
            }

            return null;
        }

    }
}
