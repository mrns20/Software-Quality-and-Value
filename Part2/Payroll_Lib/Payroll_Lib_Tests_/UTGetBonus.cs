using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static Payroll_Lib.Payroll_Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Payroll_Lib_Tests
{
    [TestClass]
    public class UTGetBonus
    {
        [TestMethod]

        public void TestGetBonusD1()
        {


            bool failed = false;
            Employee[] emp = new Employee[]
            {
               new Employee { FirstName = "Δημήτριος", Surname = "Στεφάνου", Income = 710, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Δημήτριος", Surname = "Γουρδομιχάλης", Income = 1027, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Μαρίνο", Surname = "Τσελάνι", Income = 890, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Παναγιώτα", Surname = "Δόση", Income = 298, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Ανδρέας", Surname = "Αλεξανδράτος", Income = 614, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Αθανάσιος", Surname = "Μαυρίκης", Income = 918, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Γεώργιος", Surname = "Αποστολάκης", Income = 770, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Μαρία", Surname = "Ανδριώτη", Income = 1125, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Σοφία", Surname = "Ανδριώτη", Income = 864, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Αλεξάνδρα", Surname = "Πουλημένου", Income = 1457, Department = "Δικτύων", Bonus = 0.0 }



            };
            double depBonus = 2000;
            double incomeGoal = 2100;
            string dep = "Δημόσιων Έργων";


            try
            {
                bool success = GetBonus(ref emp, dep, incomeGoal, depBonus);

                Assert.AreEqual(true, success);
                Assert.AreEqual(540.0, emp[0].Bonus);
                Assert.AreEqual(780.0, emp[1].Bonus);
                Assert.AreEqual(680.0, emp[2].Bonus);

            }
            catch (Exception e)
            {
                failed = true;
                Console.WriteLine($"Failed test case for Department \'Δημόσιων Έργων\'. Reason: {e.Message}.");

            }

            if (failed) Assert.Fail();

        }
        [TestMethod]

        public void TestGetBonusD2()
        {
            bool failed = false;
            Employee[] emp = new Employee[]
            {
               new Employee { FirstName = "Δημήτριος", Surname = "Στεφάνου", Income = 710, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Δημήτριος", Surname = "Γουρδομιχάλης", Income = 1027, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Μαρίνο", Surname = "Τσελάνι", Income = 890, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Παναγιώτα", Surname = "Δόση", Income = 298, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Ανδρέας", Surname = "Αλεξανδράτος", Income = 614, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Αθανάσιος", Surname = "Μαυρίκης", Income = 918, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Γεώργιος", Surname = "Αποστολάκης", Income = 770, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Μαρία", Surname = "Ανδριώτη", Income = 1125, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Σοφία", Surname = "Ανδριώτη", Income = 864, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Αλεξάνδρα", Surname = "Πουλημένου", Income = 1457, Department = "Δικτύων", Bonus = 0.0 }



            };
            double depBonus = 1800;
            double incomeGoal = 2500;
            string dep = "Τραπεζικών Έργων";


            try
            {
                bool success = GetBonus(ref emp, dep, incomeGoal, depBonus);

                Assert.AreEqual(false, success);
                Assert.AreEqual(0.0, emp[3].Bonus);
                Assert.AreEqual(0.0, emp[4].Bonus);
                Assert.AreEqual(0.0, emp[5].Bonus);

            }
            catch (Exception e)
            {
                failed = true;
                Console.WriteLine($"Failed test case for Department \'Τραπεζικών Έργων\'. Reason: {e.Message}.");

            }

            if (failed) Assert.Fail();
        }
        [TestMethod]

        public void TestGetBonusD3()
        {
            bool failed = false;
            Employee[] emp = new Employee[]
            {
               new Employee { FirstName = "Δημήτριος", Surname = "Στεφάνου", Income = 710, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Δημήτριος", Surname = "Γουρδομιχάλης", Income = 1027, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Μαρίνο", Surname = "Τσελάνι", Income = 890, Department = "Δημόσιων Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Παναγιώτα", Surname = "Δόση", Income = 298, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Ανδρέας", Surname = "Αλεξανδράτος", Income = 614, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Αθανάσιος", Surname = "Μαυρίκης", Income = 918, Department = "Τραπεζικών Έργων", Bonus = 0.0 },
               new Employee { FirstName = "Γεώργιος", Surname = "Αποστολάκης", Income = 770, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Μαρία", Surname = "Ανδριώτη", Income = 1125, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Σοφία", Surname = "Ανδριώτη", Income = 864, Department = "Δικτύων", Bonus = 0.0 },
               new Employee { FirstName = "Αλεξάνδρα", Surname = "Πουλημένου", Income = 1457, Department = "Δικτύων", Bonus = 0.0 }



            };
            double depBonus = 2500;
            double incomeGoal = 4000;
            string dep = "Δικτύων";


            try
            {
                bool success = GetBonus(ref emp, dep, incomeGoal, depBonus);

                Assert.AreEqual(true, success);
                Assert.AreEqual(450.0, emp[6].Bonus);
                Assert.AreEqual(675.0, emp[7].Bonus);
                Assert.AreEqual(500.0, emp[8].Bonus);
                Assert.AreEqual(875.0, emp[9].Bonus);


            }
            catch (Exception e)
            {
                failed = true;
                Console.WriteLine($"Failed test case for Department \'Δικτύων\'. Reason: {e.Message}.");

            }

            if (failed) Assert.Fail();
        }

    }

}
