using System;
using System.Linq;

namespace Workshop2019.EmployeeApi
{
    public class Employees
    {
        public readonly Employee[] AllEmployees = new[]
        {
            new Employee
            {
                Id = 1,
                FirstName = "John",
                Surname = "Doe",
                StandingOutWorkItems = new[]
                {
                    new WorkLogItem { Date = new DateTime(2019, 2, 4), WorkedHours = 10 }, // monday
                    new WorkLogItem { Date = new DateTime(2019, 2, 5), WorkedHours = 9 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 6), WorkedHours = 9 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 7), WorkedHours = 10 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 8), WorkedHours = 12 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 9), WorkedHours = 8 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 10), WorkedHours = 8 }
                }
            },
            new Employee
            {
                Id = 2,
                FirstName = "Maria",
                Surname = "Gracia",
                StandingOutWorkItems = new[]
                {
                    new WorkLogItem { Date = new DateTime(2019, 2, 4), WorkedHours = 9 }, // monday
                    new WorkLogItem { Date = new DateTime(2019, 2, 5), WorkedHours = 9 }
                }
            },
            new Employee
            {
                Id = 3,
                FirstName = "James",
                Surname = "Johnson",
                StandingOutWorkItems = new WorkLogItem[]
                {
                }
            },
            new Employee
            {
                Id = 4,
                FirstName = "Emily",
                Surname = "Rodriguez",
                StandingOutWorkItems = new[]
                {
                    new WorkLogItem { Date = new DateTime(2019, 2, 4), WorkedHours = 8 }, // monday
                    new WorkLogItem { Date = new DateTime(2019, 2, 5), WorkedHours = 8 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 6), WorkedHours = 8 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 7), WorkedHours = 16 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 8), WorkedHours = 16 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 9), WorkedHours = 0 },
                    new WorkLogItem { Date = new DateTime(2019, 2, 9), WorkedHours = 4 }
                }
            }
        };

        public Employee GetById(int employeeId)
        {
            return AllEmployees.Single(employee => employee.Id == employeeId);
        }
    }
}