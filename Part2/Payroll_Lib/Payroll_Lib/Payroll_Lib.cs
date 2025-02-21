using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Payroll_Lib
{
    public class Payroll_Lib
    {
        public struct Employee
        {
            public string FirstName;
            public string Surname;
            public int Children;
            public string Department;
            public string Position;
            public int WorkExperience;
            public int Income;
            public double Bonus;

            // Constructor
            public Employee(string FirstName, string Surname, int Children, string Department, string Position, int WorkExperience, int Income, double Bonus)
            {
                // Exceptions για τις τιμές 3 πεδίων(σύμφωνα με την εκφώνηση)

                //string Department (Τμήμα εταιρίας – τιμές: Δημοσίων Έργων – Τραπεζικών Έργων – Δικτύων)
                string[] validDepartments = { "Δημοσίων Έργων", "Τραπεζικών Έργων", "Δικτύων" };
                // Αν προσπαθήσουμε να βάλουμε στο πεδίο Department κάποια τιμή εκτός των παραπάνω, τότε έχουμε ArgumentException.
                // Την ίδια λογική ακολουθούμε και για το Position.
                if (!Array.Exists(validDepartments, dep => dep == Department))
                    throw new ArgumentException("Exception!Invalid Department.Επιτρεπτές τιμές:Δημοσίων Έργων, Τραπεζικών Έργων, Δικτύων", nameof(Department));

                //string Position (θέση εργασίας εργαζομένου: Junior Developer – Mid-level Developer – Senior Developer – IT Manager)
                string[] validPositions = { "Junior Developer", "Mid-level Developer", "Senior Developer", "IT Manager" };
                if (!Array.Exists(validPositions, pos => pos == Position))
                    throw new ArgumentException("Exception!Invalid Position.Επιτρεπτές τιμές:Junior Developer, Mid-level Developer, Senior Developer, IT Manager", nameof(Position));

                //int WorkExperience (έτη προϋπηρεσίας – τιμές: από 0 έως 38)
                // Αν προσπαθήσουμε να βάλουμε στο πεδίο workExperience κάποια τιμή εκτός των παρακάτω, τότε έχουμε ArgumentOutOfRangeException.
                if (WorkExperience < 0 || WorkExperience > 38)
                    throw new ArgumentOutOfRangeException(nameof(WorkExperience), "Exception!Invalid WorkExperience.Επιτρεπτές τιμές:0-38");

                this.FirstName = FirstName;
                this.Surname = Surname;
                this.Children = Children;
                this.Department = Department;
                this.Position = Position;
                this.WorkExperience = WorkExperience;
                this.Income = Income;
                this.Bonus = Bonus;
            }
        }

        // Μέθοδοι και συναρτήσεις για τη διαχείριση των εργαζόμενων
        public static bool CheckPhone(string Phone, ref string PhoneCountry)
        {
            PhoneCountry = string.Empty; 
            string validPhone = @"^(00|\+)(30|357|39|44)[0-9]+$";
            if (!Regex.IsMatch(Phone, validPhone)) // έλεγχος
            {
                return false;
            }

            // Εύρεση χώρας προέλευσης
            if (Phone.StartsWith("00") || Phone.StartsWith("+"))
            {
                if (Phone.StartsWith("0030") || Phone.StartsWith("+30"))
                    if (Phone.Length == 13 || Phone.Length == 14)
                        PhoneCountry = "Greece";
                    else
                        return false;
                if (Phone.StartsWith("00357") || Phone.StartsWith("+357"))
                    if (Phone.Length == 12 || Phone.Length == 13)
                        PhoneCountry = "Cyprus";
                    else
                        return false;
                if (Phone.StartsWith("0039") || Phone.StartsWith("+39"))
                    if (Phone.Length == 12 || Phone.Length == 13 || Phone.Length == 14) 
                        PhoneCountry = "Italy";
                    else
                        return false;
                if (Phone.StartsWith("0044") || Phone.StartsWith("+44"))
                    if (Phone.Length == 13 || Phone.Length == 14 || Phone.Length == 15)
                        PhoneCountry = "UK";
                    else
                        return false;
                
            }

            return true; // Επιστρέφει true αν υπάρχει αναγνωρισμένη χώρα
        }

        public static bool CheckIBAN(string IBAN, ref string IBANCountry)
        {
            if (string.IsNullOrWhiteSpace(IBAN) || IBAN.Length < 22) // έλεγχος(IBAN length in the UK:22 chars)
            {
                IBANCountry = string.Empty; // Άκυρο IBAN
                return false;
            }

            // Ανάγνωση του πρώτου μέρους του IBAN(κωδικός χώρας)
            string countryCode = IBAN.Substring(0, 2).ToUpper();

            // Έλεγχος χώρας(με βάση το πρώτο μέρος του IBAN)
            switch (countryCode)
            {
                case "GR":
                    IBANCountry = "Ελλάδα";
                    break;
                case "CY":
                    IBANCountry = "Κύπρος";
                    break;
                case "IT":
                    IBANCountry = "Ιταλία";
                    break;
                case "GB":
                    IBANCountry = "Αγγλία";
                    break;
                default:
                    IBANCountry = string.Empty;
                    return false; // Μη αποδεκτή χώρα(Άκυρο IBAN)
            }

            // Έλεγχος IBAN (Modulo 97 Validation με βάση τους 2 συνδέσμους της εκφώνησης)
            // Βήματα:
            // 1. Μετακινούμε τους τέσσερις πρώτους χαρακτήρες στο τέλος του αριθμού
            // 2. Μετατρέπουμε τα γράμματα σε αριθμούς σύμφωνα με τον δοσμένο πίνακα
            // 3. Διαιρούμε τον αριθμό με 97
            // 4. Εάν το υπόλοιπο της διαίρεσης είναι 1, ο ΙΒΑΝ είναι σωστός. Διαφορετικά, είναι λάθος. 
            string shuffle = IBAN.Substring(4) + countryCode + IBAN.Substring(2, 2);
            string num = string.Empty;

            foreach (char c in shuffle)
            {
                if (char.IsLetter(c))
                    num += (c - 'A' + 10).ToString();
                else
                    num += c;
            }

            // Επαλήθευση 
            if (BigInteger.ModPow(BigInteger.Parse(num), 1, 97) != 1)
            {
                IBANCountry = string.Empty;
                return false; // Άκυρο IBAN
            }

            return true; // Έγκυρο IBAN(πέρασε με επιτυχία όλους τους ελέγχους)
        }


        public static bool CheckZipCode(int ZipCode)
        {
            bool found = false;
            // Μετατροπή του ZipCode σε string για να γίνει εύκολος ο παρακάτω έλεγχος σχετικά με το μήκος των χαρακτήρων
            string zip = ZipCode.ToString();

            // Έλεγχος μήκους χαρακτήρων για τους Ιταλικούς ΤΚ
            if (zip.Length != 5)
                return false;



            // Επιτρεπτά Zip Codes με βάση τον κατάλογο της εκφώνησης
            List<(int, int)> zipRanges = new List<(int, int)>
    {
        (118, 199), (30100, 30124), (20100, 20199), (37100, 37139),
        (10100, 10159), (35100, 35143), (40100, 40141), (56121, 56128),
        (80100, 80147)
    };

        
            HashSet<int> validZipCodes = new HashSet<int>
    {
        37011, 37016, 37018, 37019, 38066, 38068, 38100, 39100, 39012,
        39017, 39019, 39011, 39031, 39042, 39046, 39047, 39048, 39052,
        39057, 45011, 5100, 6100, 7100, 7026, 9100, 12100, 13900,
        14100, 15100, 11100, 16100, 17100, 19100, 20025, 20900, 22060,
        24100, 25010, 25015, 25087, 25100, 46100, 31100, 32043, 32100,
        36100, 33100, 47921, 47838, 47841, 50100, 53100, 55100, 61100,
        61011, 70100, 90100, 98039, 98055, 98100
    };

            

            if (validZipCodes.Contains(ZipCode))
                found = true;
            else
            {
                foreach (var (start, end) in zipRanges)
                {
                    if (ZipCode >= start && ZipCode <= end)
                        found = true;
                }
            }
            

            return found; // Ο ΤΚ δεν είναι έγκυρος
        }


        public static void CalculateSalary(Employee EmplX, ref double AnnualGrossSalary, ref double NetAnnualIncome, ref double NetMonthIncome, ref double Tax, ref double Insurance)
        {
            // Με βάση το Παράρτημα:
            // Επιλογή Βασικού Μισθού ανά Θέσης Εργασίας 
            double baseSalary;
            double maxSalary;

            // Η μέθοδος δέχεται ως παραμέτρους τα στοιχεία ενός υπαλλήλου
            // Στο συγκεκριμένο σημείο χρησιμοποιούμε το πεδίο Position του υπαλλήλου
            switch (EmplX.Position)
            {
                case "Junior Developer":
                    baseSalary = 1000;
                    maxSalary = 1400;
                    break;
                case "Mid-level Developer":
                    baseSalary = 1500;
                    maxSalary = 2000;
                    break;
                case "Senior Developer":
                    baseSalary = 2000;
                    maxSalary = 2800;
                    break;
                case "IT Manager":
                    baseSalary = 3500;
                    maxSalary = 5000;
                    break;
                default:
                    throw new ArgumentException("Invalid Position", nameof(EmplX.Position));
            }

            if (EmplX.WorkExperience<0)
                throw new ArgumentOutOfRangeException(nameof(EmplX.WorkExperience), "Number of years cannot be negative.");
          
            // 3% για κάθε χρόνο προϋπηρεσίας, χωρίς να υπερβαίνει το ανώτερο όριο της κάθε θέσης εργασίας 
            baseSalary += Math.Round(baseSalary * 0.03 * Math.Min(EmplX.WorkExperience, 38));
            baseSalary = Math.Min(baseSalary, maxSalary);

            // 1) Μικτές ετήσιες αποδοχές
            AnnualGrossSalary = baseSalary * 14;

            // Χρήση του συνδέσμου https://aftertax.gr/el/explain#1 για τον Υπολογισμό της Μισθοδοσίας
            // 2) Ασφαλιστικές εισφορές
            double monthlyInsurance = Math.Round(baseSalary * 0.1337); // οι ασφαλιστικές εισφορές αντιστοιχούν σε 13.37% του μικτού μισθού
            Insurance = monthlyInsurance * 14; 

            // Υπολογισμός Ετήσιου Φορολογητέου Εισοδήματος
            // Για έναν μικτό μηνιαίο μισθό €1000, επί 14 μήνες τον χρόνο, μετά τις ασφαλιστικές εισφορές το ετήσιο φορολογητέο εισόδημα ανέρχεται σε €12124
            double annualTaxableIncome = AnnualGrossSalary - Insurance;

            // Χρήση του συνδέσμου https://aftertax.gr/el/explain#1 για τους παρακάτω υπολογισμούς
            double tax = 0;
            if (annualTaxableIncome > 40000)
                tax += Math.Round((annualTaxableIncome - 40000) * 0.44);
            if (annualTaxableIncome > 30000)
                tax += Math.Round((Math.Min(annualTaxableIncome, 40000) - 30000) * 0.36);
            if (annualTaxableIncome > 20000)
                tax += Math.Round((Math.Min(annualTaxableIncome, 30000) - 20000) * 0.28);
            if (annualTaxableIncome > 10000)
                tax += Math.Round((Math.Min(annualTaxableIncome, 20000) - 10000) * 0.22);
            if (annualTaxableIncome > 0)
                tax += Math.Round(Math.Min(annualTaxableIncome, 10000) * 0.09);

            // Εφαρμογή έκπτωσης φόρου βάσει παιδιών
            // Η μέθοδος δέχεται ως παραμέτρους τα στοιχεία ενός υπαλλήλου
            // Στο συγκεκριμένο σημείο χρησιμοποιούμε το πεδίο Children του υπαλλήλου
            if (EmplX.Children < 0)
                throw new ArgumentOutOfRangeException(nameof(EmplX.Children), "Number of children cannot be negative.");
            

            double taxReduction = EmplX.Children switch
            {
                0 => 777,
                1 => 810,
                2 => 900,
                3 => 1120,
                _ => 1340
            };

            Tax = Math.Max(0, tax - taxReduction);

            // 4) Καθαρές ετήσιες αποδοχές
            NetAnnualIncome = annualTaxableIncome - Tax;

            // 5) Καθαρές μηνιαίες αποδοχές
            NetMonthIncome = Math.Round(NetAnnualIncome / 14);
        }


        public static int NumofEmployees(Employee[] Empls, string Position)
        {
            int count = 0;

            foreach (Employee emp in Empls)
            {
                if (emp.Position == Position) // Στο συγκεκριμένο σημείο χρησιμοποιούμε το πεδίο Position του υπαλλήλου
                {
                    count++;
                }
            }

            // Η συνάρτηση αυτή επιστρέφει το πλήθος των υπαλλήλων μιας συγκεκριμένης θέσης εργασίας.
            return count;
        }

        public static bool GetBonus(ref Employee[] Empls, string Department, double IncomeGoal, double Bonus)
        {
            double depIncome = 0;

            // Υπολογισμός στόχου εσόδων:συνολικά έσοδα από κάθε υπάλληλο του Τμήματος
            // Χρήση λίστας υπαλλήλων
            List<Employee> depEmployees = new List<Employee>();
            foreach (Employee employee in Empls)
            {
                if (employee.Department == Department) // Στο συγκεκριμένο σημείο χρησιμοποιούμε το πεδίο Department του υπαλλήλου
                {
                    depEmployees.Add(employee); // προσθήκη στη λίστα των υπαλλήλων
                    depIncome += employee.Income; // Στο συγκεκριμένο σημείο χρησιμοποιούμε το πεδίο Income του υπαλλήλου
                }
            }

            // Ελέγχουμε αν το τμήμα έπιασε τον στόχο εσόδων
            if (depIncome > IncomeGoal)
            {
                // Η συνάρτηση αυτή επιστρέφει αν οι υπάλληλοι ενός Τμήματος δικαιούνται μπόνους επίδοσης και υπολογίζει το ποσό του καθενός.
                foreach (Employee employee in depEmployees)
                {
                    // Το μπόνους κάθε υπαλλήλου υπολογίζεται ως εξής:υπολογίζεται το ποσοστό που έχει συμβάλει ο υπάλληλος στα συνολικά έσοδα του 
                    // Τμήματος και παίρνει αυτό το ποσοστό του μπόνους του Τμήματος
                    double empRateOfContribution = employee.Income / depIncome;
                    empRateOfContribution = Math.Round(empRateOfContribution, 2);
                    for (int i = 0; i < Empls.Length; i++)
                    {
                        // Στο συγκεκριμένο σημείο χρησιμοποιούμε τα πεδία FirstName,Surname του υπαλλήλου
                        if (Empls[i].FirstName == employee.FirstName && Empls[i].Surname == employee.Surname)
                        {
                            // Πολλαπλασιάζουμε το ποσοστό που έχει συμβάλει ο υπάλληλος με το Bonus του τμήματος
                            Empls[i].Bonus = empRateOfContribution * Bonus; // Στο συγκεκριμένο σημείο υπολογίζουμε το πεδίο Bonus του υπαλλήλου
                            break;
                        }
                    }
                }

                return true; // το Τμήμα έπιασε τον στόχο του
            }

            return false; // το Τμήμα δεν έπιασε τον στόχο του
        }

    }
}