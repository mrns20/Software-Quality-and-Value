using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Payroll_Lib.Payroll_Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Payroll_Lib_Tests
{
    [TestClass]
    public class UTCheckPhone
    {
        [TestMethod]
        public void TestCheckPhone()
        {

            string phoneCountry = string.Empty;

            object[,] testCases =
{
    { "00306970542505", true, "Greece" },
    { "+306970542505", true, "Greece" },
    { "0035722667820", true, "Cyprus" },
    { "+35722667820", true, "Cyprus" },
    { "00390612345678", true, "Italy" },
    { "+390612345678", true, "Italy" },
    { "+39335123456", true, "Italy" },
    { "0039335123456", true, "Italy" },
    { "+447911123456", true, "UK" },
    { "00447911123456", true, "UK" },
    { "006712775091392", false, string.Empty },
    { "+6712775091392", false, string.Empty },
    { "+30698845671604", false, string.Empty },
    { "0030698845671604", false, string.Empty },
    { "003069884567", false, string.Empty },
    { "+3069884567", false, string.Empty },
    { "0044791356", false, string.Empty },
    { "+447900567123501", false, string.Empty },
    { "@392719517309", false, string.Empty },
    { "#358915205543", false, string.Empty },
    {"", false, string.Empty },

};

            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    string phone = (string)testCases[i, 0];
                    bool expectedResult = (bool)testCases[i, 1];
                    string expectedCountry = (string)testCases[i, 2];


                    bool result = CheckPhone(phone, ref phoneCountry);
                    Assert.AreEqual(expectedResult, result);


                    Assert.AreEqual(expectedCountry, phoneCountry);
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