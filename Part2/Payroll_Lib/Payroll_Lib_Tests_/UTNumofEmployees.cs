using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Payroll_Lib.Payroll_Lib;

namespace Payroll_Lib_Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void TestNumofEmployees1()
        {
            Employee[] employees = new Employee[]
            {
                new Employee("John", "Doe", 2, "Δημοσίων Έργων", "Senior Developer", 5, 0, 0),
                new Employee("Jane", "Smith", 1, "Δημοσίων Έργων", "Mid-level Developer", 3, 0, 0),
                new Employee("Alex", "Johnson", 0, "Τραπεζικών Έργων", "Junior Developer", 1, 0, 0),
                new Employee("Maria", "Brown", 2, "Δημοσίων Έργων", "Senior Developer", 7, 0, 0),
                new Employee("James", "Davis", 3, "Δικτύων", "IT Manager", 10, 0, 0)
            };

            int count = NumofEmployees(employees, "Senior Developer");

            try
            {
                Assert.AreEqual(2, count);
            }
            catch(Exception e) 
            {
                    Console.WriteLine($"Test case failed. {e.Message}");
            }
        }

        [TestMethod]
        public void TestNumofEmployees2()
        {
            Employee[] employees = new Employee[]
             {
                new Employee("John", "Doe", 2, "Δημοσίων Έργων", "Senior Developer", 5, 0, 0),
                new Employee("Jane", "Smith", 1, "Δημοσίων Έργων", "Mid-level Developer", 3, 0, 0),
                new Employee("Alex", "Johnson", 0, "Τραπεζικών Έργων", "Junior Developer", 1, 0, 0),
                new Employee("Maria", "Brown", 2, "Δημοσίων Έργων", "Senior Developer", 7, 0, 0),
                new Employee("James", "Davis", 3, "Δικτύων", "IT Manager", 10, 0, 0)
             };

            int count = NumofEmployees(employees, "Mid-level Developer");

            try
            {
                Assert.AreEqual(1, count);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test case failed. {e.Message}");
            }
        }

        [TestMethod]
        public void TestNumofEmployees3()
        {
            Employee[] employees = new Employee[]
             {
                new Employee("John", "Doe", 2, "Δημοσίων Έργων", "Senior Developer", 5, 0, 0),
                new Employee("Jane", "Smith", 1, "Δημοσίων Έργων", "Mid-level Developer", 3, 0, 0),
                new Employee("Alex", "Johnson", 0, "Τραπεζικών Έργων", "Junior Developer", 1, 0, 0),
                new Employee("Maria", "Brown", 2, "Δημοσίων Έργων", "Junior Developer", 7, 0, 0),
                new Employee("James", "Davis", 3, "Δικτύων", "Junior Developer", 10, 0, 0)
             };

            int count = NumofEmployees(employees, "Junior Developer");

            try
            {
                Assert.AreEqual(3, count);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test case failed. {e.Message}");
            }
        }
        [TestMethod]
        public void TestNumofEmployees4()
        {
            Employee[] employees = new Employee[]
             {
                new Employee("John", "Doe", 2, "Δημοσίων Έργων", "IT Manager", 5, 0, 0),
                new Employee("Jane", "Smith", 1, "Δημοσίων Έργων", "IT Manager", 3, 0, 0),
                new Employee("Alex", "Johnson", 0, "Τραπεζικών Έργων", "IT Manager", 1, 0, 0),
                new Employee("Maria", "Brown", 2, "Δημοσίων Έργων", "IT Manager", 7, 0, 0),
                new Employee("James", "Davis", 3, "Δικτύων", "IT Manager", 10, 0, 0)
             };

            int count = NumofEmployees(employees, "IT Manager");

            try
            {
                Assert.AreEqual(4, count);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test case failed. {e.Message}");
            }
        }

            
    }
}
