using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Payroll_Lib.Payroll_Lib;

namespace Payroll_Lib_Tests
{
    [TestClass]
    public class UTCheckZipCode
    {
        [TestMethod]
        public void TestCheckZipCode()
        {
            object[,] testCases =
{
    { 05100, true },
    { 00119, true },
    { 10100, true },
    { 111, false },
    { 98100, true },
    { 1111, false },
    { 99999, false }
};

            bool failed = false;
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    int zipCode = (int)testCases[i, 0];
                    bool expectedResult = (bool)testCases[i, 1];
                    bool result = CheckZipCode(zipCode);
                    Assert.AreEqual(expectedResult, result);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {i + 1}. Reason: {e.Message}");
                    
                }
            }
            if (failed) Assert.Fail();
        }
    }
}

