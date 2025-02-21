using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Payroll_Lib.Payroll_Lib;

namespace Payroll_Lib_Tests
{
    [TestClass]
    public class UTCalculateSalary
    {
        [TestMethod]
        public void TestCalculateSalaryExpectedGrossSalary()
        {
            var testCases = new[]
            {
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 0, Children = 0 },
                    ExpectedGrossSalary = 14000.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 4, Children = 1 },
                    ExpectedGrossSalary = 15680.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 15, Children = 2 },
                    ExpectedGrossSalary = 28000.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 9, Children = 3 },
                    ExpectedGrossSalary = 26670.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Senior Developer", WorkExperience = 13, Children = 4 },
                    ExpectedGrossSalary = 38920.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 21, Children = 0 },
                    ExpectedGrossSalary = 70000.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 14, Children = 2 },
                    ExpectedGrossSalary = 69580.0,
                    
                }/*,
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 2, Children = -1 },
                    ExpectedGrossSalary = 0.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = -1, Children = 0 },
                    ExpectedGrossSalary = 0.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Reception", WorkExperience = 5, Children = 0 },
                    ExpectedGrossSalary = 0.0,
                    
                }*/
            };

            bool failed = false;

            foreach (var testCase in testCases)
            {

                try
                {
                    double annualGrossSalary = 0;
                    double netAnnualIncome = 0;
                    double netMonthIncome = 0;
                    double tax = 0;
                    double insurance = 0;



                    CalculateSalary(testCase.Employee, ref annualGrossSalary, ref netAnnualIncome, ref netMonthIncome, ref tax, ref insurance);


                    Assert.AreEqual(testCase.ExpectedGrossSalary, annualGrossSalary);
                   
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed test case for Employee on Annual Gross Salary: {testCase.Employee.Position}, {testCase.Employee.WorkExperience}, {testCase.Employee.Children}. Reason: {e.Message}.");
                    
                }

            }
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestCalculateSalaryNetAnnualIncome()
        {
            var testCases = new[]
           {
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 0, Children = 0 },
                    ExpectedNetAnnualIncome = 11534.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 4, Children = 1 },
                    ExpectedNetAnnualIncome = 12702.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 15, Children = 2 },
                    ExpectedNetAnnualIncome = 20869.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 9, Children = 3 },
                    ExpectedNetAnnualIncome = 20252.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Senior Developer", WorkExperience = 13, Children = 4 },
                    ExpectedNetAnnualIncome = 27816.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 21, Children = 0 },
                    ExpectedNetAnnualIncome = 42832.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 14, Children = 2 },
                    ExpectedNetAnnualIncome = 42759.0,
                    
                }/*,
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 2, Children = -1 },
                  
                    ExpectedNetAnnualIncome = 0.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = -1, Children = 0 },
                    ExpectedNetAnnualIncome = 0.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Reception", WorkExperience = 5, Children = 0 },
                    ExpectedNetAnnualIncome = 0.0,
                    
                }*/
            };

            bool failed = false;

            foreach (var testCase in testCases)
            {

                try
                {
                    double annualGrossSalary = 0;
                    double netAnnualIncome = 0;
                    double netMonthIncome = 0;
                    double tax = 0;
                    double insurance = 0;



                    CalculateSalary(testCase.Employee, ref annualGrossSalary, ref netAnnualIncome, ref netMonthIncome, ref tax, ref insurance);


                     Assert.AreEqual(testCase.ExpectedNetAnnualIncome, netAnnualIncome);
                    
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed test case for Employee on Net Annual Income: {testCase.Employee.Position}, {testCase.Employee.WorkExperience}, {testCase.Employee.Children}. Reason: {e.Message}.");

                }

            }
            if (failed) Assert.Fail();
        }
        [TestMethod]
        public void TestCalculateSalaryInsurance()
        {
            var testCases = new[]
           {
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 0, Children = 0 },
              
                    ExpectedInsurance = 1876.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 4, Children = 1 },
                    
                    ExpectedInsurance = 2100.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 15, Children = 2 },
                   
                    ExpectedInsurance = 3738.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 9, Children = 3 },
                  
                    ExpectedInsurance = 3570.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Senior Developer", WorkExperience = 13, Children = 4 },
                    
                    ExpectedInsurance = 5208.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 21, Children = 0 },
                  
                    ExpectedInsurance = 9366.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 14, Children = 2 },
                   
                    ExpectedInsurance = 9296.0,
                    
                }/*,
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 2, Children = -1 },
                  
                    ExpectedInsurance = 0.0,
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = -1, Children = 0 },
                   
                    ExpectedInsurance = 0.0,
                },
                new
                {
                    Employee = new Employee { Position = "Reception", WorkExperience = 5, Children = 0 },
                   
                    ExpectedInsurance = 0.0,
                }*/
            };


                bool failed = false;

            foreach (var testCase in testCases)
            {

                try
                {
                    double annualGrossSalary = 0;
                    double netAnnualIncome = 0;
                    double netMonthIncome = 0;
                    double tax = 0;
                    double insurance = 0;



                    CalculateSalary(testCase.Employee, ref annualGrossSalary, ref netAnnualIncome, ref netMonthIncome, ref tax, ref insurance);


                    
                     Assert.AreEqual(testCase.ExpectedInsurance, insurance);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed test case for Employee on Insurance: {testCase.Employee.Position}, {testCase.Employee.WorkExperience}, {testCase.Employee.Children}. Reason: {e.Message}.");

                }

            }
            if (failed) Assert.Fail();
        }
        [TestMethod]
        public void TestCalculateSalaryNetMonthlyIncome()
        {
            var testCases = new[]
           {
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 0, Children = 0 },
                   
                    ExpectedNetMonthlyIncome = 824.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 4, Children = 1 },
                    
                    ExpectedNetMonthlyIncome = 907.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 15, Children = 2 },
                    
                    ExpectedNetMonthlyIncome = 1491.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 9, Children = 3 },
                    ExpectedNetMonthlyIncome = 1447.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Senior Developer", WorkExperience = 13, Children = 4 },
                    ExpectedNetMonthlyIncome = 1987.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 21, Children = 0 },
                    ExpectedNetMonthlyIncome = 3059.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 14, Children = 2 },
                    ExpectedNetMonthlyIncome = 3054.0,
                    
                }/*,
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 2, Children = -1 },
                   
                    ExpectedNetMonthlyIncome = 0.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = -1, Children = 0 },
                    ExpectedNetMonthlyIncome = 0.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Reception", WorkExperience = 5, Children = 0 },
                    ExpectedNetMonthlyIncome = 0.0,
                    
                }*/
            };

            bool failed = false;

            foreach (var testCase in testCases)
            {

                try
                {
                    double annualGrossSalary = 0;
                    double netAnnualIncome = 0;
                    double netMonthIncome = 0;
                    double tax = 0;
                    double insurance = 0;



                    CalculateSalary(testCase.Employee, ref annualGrossSalary, ref netAnnualIncome, ref netMonthIncome, ref tax, ref insurance);



                    Assert.AreEqual(testCase.ExpectedNetMonthlyIncome, netMonthIncome);
                }

                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed test case for Employee on Net Monthly Income: {testCase.Employee.Position}, {testCase.Employee.WorkExperience}, {testCase.Employee.Children}. Reason: {e.Message}.");

                }

            }
            if (failed) Assert.Fail();

        }
        [TestMethod]
        public void TestCalculateSalaryTax()
        {
            var testCases = new[]
           {
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 0, Children = 0 },
                    ExpectedTax = 590.0,
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 4, Children = 1 },
                    
                    ExpectedTax = 878.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 15, Children = 2 },
                    
                    ExpectedTax = 3393.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Mid-level Developer", WorkExperience = 9, Children = 3 },
                    
                    ExpectedTax = 2848.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Senior Developer", WorkExperience = 13, Children = 4 },
                    
                    ExpectedTax = 5896.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 21, Children = 0 },
                   
                    ExpectedTax = 17802.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "IT Manager", WorkExperience = 14, Children = 2 },
                    
                    ExpectedTax = 17525.0,
                   
                }/*,
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = 2, Children = -1 },
                    
                    ExpectedTax = 0.0,
                    
                },
                new
                {
                    Employee = new Employee { Position = "Junior Developer", WorkExperience = -1, Children = 0 },
                    ExpectedTax = 0.0,
                   
                },
                new
                {
                    Employee = new Employee { Position = "Reception", WorkExperience = 5, Children = 0 },
                   
                    ExpectedTax = 0.0,
                   
                }*/
            };



            bool failed = false;

            foreach (var testCase in testCases)
            {

                try
                {
                    double annualGrossSalary = 0;
                    double netAnnualIncome = 0;
                    double netMonthIncome = 0;
                    double tax = 0;
                    double insurance = 0;



                    CalculateSalary(testCase.Employee, ref annualGrossSalary, ref netAnnualIncome, ref netMonthIncome, ref tax, ref insurance);


                    
                    Assert.AreEqual(testCase.ExpectedTax, tax);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed test case for Employee on Tax: {testCase.Employee.Position}, {testCase.Employee.WorkExperience}, {testCase.Employee.Children}. Reason: {e.Message}.");

                }

            }
            if (failed) Assert.Fail();

        }
    }
}
