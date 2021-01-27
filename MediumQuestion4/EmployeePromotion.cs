using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumQuestion4
{
    class EmployeePromotion
    {
        public void EmployeeDetails()
        {
            int input = 1;
            var employees = new Dictionary<int, Employee>();
            List<Employee> employeeList = new List<Employee>();
            try
            {
                while (input == 1)
                {
                    Employee employeeClassObject = new Employee();
                    employeeClassObject.TakeEmployeeDetailsFromUser();
                    employees.Add(employeeClassObject.Id, employeeClassObject);
                    Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                    input = Convert.ToInt32(Console.ReadLine());
                }
                foreach (var employeeDictObject in employees)
                {
                    employeeList.Add(employeeDictObject.Value);
                }

                if (input == 0)
                {
                    SortAndPrintEmployees(employeeList);
                    
                    FilterEmployeesOlderThanTheSelectedEmployee(employeeList);
                }
                else
                {
                    Console.WriteLine("Please Enter 1 or 0 only !! Thank You");
                    EmployeeDetails();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry !! An error has occured !! Please Try Again !!");
                Console.WriteLine(e);
                EmployeeDetails();
            }
        }
        public void SortAndPrintEmployees(List<Employee> employeeListToSort)
        {
            try
            {
                employeeListToSort.Sort();
                Console.WriteLine("The sorted employee list ");
                foreach (var employeeListObjectToSort in employeeListToSort)
                {
                    Console.WriteLine(employeeListObjectToSort);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Sorry !! Something went wrong !! Please Try again !!");
                Console.WriteLine(e);
            }
        }
        
        public void FilterEmployeesOlderThanTheSelectedEmployee(List<Employee> employeeListToFilter)
        {
            int employeeIdToFilterElderEmployees;
            try
            {
                Console.WriteLine("Please enter the employee ID");
                employeeIdToFilterElderEmployees = Convert.ToInt32(Console.ReadLine());
                int ageToFilter = 0;
                foreach (var employeeListObject in employeeListToFilter)
                {
                    if (employeeListObject.Id == employeeIdToFilterElderEmployees)
                    {
                        ageToFilter = employeeListObject.Age;
                    }
                }
                //Console.WriteLine(ageToFilter);
                var filteredResult = from empListToFilter2 in employeeListToFilter where empListToFilter2.Age > ageToFilter select empListToFilter2;
                foreach (var filteredEmployeeListObject in filteredResult)
                {
                    Console.WriteLine(filteredEmployeeListObject);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Sorry !! Something went wrong !! Please Try again !!");
                Console.WriteLine(e);

            }
        }
    }
}
