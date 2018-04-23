using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace DXCallbackPanel.Models {
    public static class NorthwindDataProvider {
        static NorthwindDataContext db;

        public static NorthwindDataContext DB {
            get {
                if(db == null)
                    db = new NorthwindDataContext();
                return db;
            }
        }
        public static IEnumerable GetEmployeesList() {
            return from employee in DB.Employees
                   select new {
                       ID = employee.EmployeeID,
                       Name = employee.LastName + " " + employee.FirstName
                   };
        }
        public static int GetFirstEmployeeID() {
            return (from employee in DB.Employees
                    select employee.EmployeeID).First<int>();
        }
        public static IEnumerable GetEmployees() {
            return from employee in DB.Employees select employee;
        }
        public static Employee GetEmployee(int employeeId) {
            return (from employee in DB.Employees
                    where employeeId == employee.EmployeeID
                    select employee).Single<Employee>();
        }
    }
}