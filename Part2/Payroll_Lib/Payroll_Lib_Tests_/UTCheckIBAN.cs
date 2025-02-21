using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Payroll_Lib.Payroll_Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Payroll_Lib_Tests
{
    [TestClass]
    public class UTCheckIBAN
    {
        [TestMethod]
        public void TestCheckIBAN()
        {

            string IBANCountry = string.Empty;


            object[,] testCases =
{
    { "GR1601101250000000012300695", true, "Ελλάδα" },
    { "CY17002001280000001200527600", true, "Κύπρος" },
    { "IT60X0542811101000000123456", true, "Ιταλία" },
    { "GB29NWBK60161331926819", true, "Αγγλία" },
    { "GR160110125000000001230", false, string.Empty },
    { "CY170020012800000012", false, string.Empty },
    { "IT6010542811101", false, string.Empty },
    { "GB2999996016133", false, string.Empty },
    { "", false, string.Empty } // no IBAN
};

            bool failed = false;
            
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    string IBAN = (string)testCases[i, 0];
                    bool expectedResult = (bool)testCases[i, 1];
                    string expectedCountry = (string)testCases[i, 2];


                    bool result = CheckIBAN(IBAN, ref IBANCountry);
                    Assert.AreEqual(expectedResult, result);


                    Assert.AreEqual(expectedCountry, IBANCountry);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {i + 1}. Reason: {e.Message}");
                    
                }

            }
            if ( failed ) Assert.Fail();
        }
    }
}
