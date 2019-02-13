using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Workshop2019.EmployeeApi
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Employees _employees = new Employees();

        [HttpGet]
        public GetEmployeesResponse Get()
        {
            var employees = _employees
                .AllEmployees
                .Select(employee => new GetEmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    Surname = employee.Surname
                })
                .ToArray();

            return new GetEmployeesResponse
            {
                Employees = employees
            };
        }

        public class GetEmployeesResponse
        {
            public GetEmployeeDto[] Employees { get; set; }
        }

        public class GetEmployeeDto
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
        }

        [HttpGet]
        [Route("{employeeId:int}/work-log")]
        public GetEmployeeWorkLogResponse GetEmployeeWorkLog(int employeeId, [FromQuery(Name = "from")] string dateFromString, [FromQuery(Name = "to")] string dateToString)
        {
            var dateFrom = ParseDate(dateFromString);
            var dateTo = ParseDate(dateToString);

            var workLogItems = _employees
                .GetById(employeeId)
                .GetWorkItems(dateFrom, dateTo)
                .Select(workLogItem => new EmployeeWorkLogItemDto
                {
                    Date = FormatDate(workLogItem.Date),
                    WorkedHours = workLogItem.WorkedHours
                })
                .ToArray();

            return new GetEmployeeWorkLogResponse
            {
                WorkLogItems = workLogItems
            };
        }

        private static DateTime ParseDate(string dateFromString)
        {
            return DateTime.ParseExact(dateFromString, DateFormat, CultureInfo.InvariantCulture);
        }

        private static string FormatDate(DateTime date)
        {
            return date.ToString(DateFormat, CultureInfo.InvariantCulture);
        }

        private static readonly string DateFormat = "yyyy-MM-dd";

        public class GetEmployeeWorkLogResponse
        {
            public EmployeeWorkLogItemDto[] WorkLogItems { get; set; }
        }

        public class EmployeeWorkLogItemDto
        {
            public string Date { get; set; }
            public decimal WorkedHours { get; set; }
        }
    }
}
