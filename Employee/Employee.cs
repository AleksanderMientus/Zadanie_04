using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Employee
    {
        private string nazwisko;
        private string imie;
        private double stawkaGodzinowa;
        private double pensja;
        private Dictionary<string, double> czasPracy = new Dictionary<string, double>(2);

        /// <summary>
        /// Definicja pracownika
        /// </summary>
        /// <param name="imie">string imię pracownika</param>
        /// <param name="nazwisko">string nazwisko pracownika</param>
        /// <param name="stawkaGodzinowa">stawka za godzinę pracy pracownika</param>
        public Employee(string imie, string nazwisko, double stawkaGodzinowa)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.stawkaGodzinowa = stawkaGodzinowa;
            pensja = 0.00;
            czasPracy.Add("Normalne", 0.00);
            czasPracy.Add("Nadgodziny", 0.00);
            EmployeeInfo();
        }

        /// <summary>
        /// Rejestruje czas pracy pracownika i zlicza jego pensję.
        /// </summary>
        /// <param name="przepracowaneGodziny">double przepracowane godziny w danym dniu</param>
        public void RegisterTime(double przepracowaneGodziny)
        {
            if (przepracowaneGodziny <= 8) 
            {
                pensja += stawkaGodzinowa * przepracowaneGodziny;
                czasPracy["Normalne"] += przepracowaneGodziny;
            }
            else
            {
                pensja += (stawkaGodzinowa * 8) + (stawkaGodzinowa * 2 * (przepracowaneGodziny - 8));
                czasPracy["Normalne"] += 8;
                czasPracy["Nadgodziny"] += przepracowaneGodziny - 8;
            }
        }

        public void EmployeeInfo()
        {
            Console.WriteLine("Pracownik:");
            Console.WriteLine("{0,-20}{1,7:0.00}", "Nazwisko i imię: ", nazwisko + " " + imie);
            Console.WriteLine("{0,-20}{1,7:0.00}", "Stawka godzinowa: ", stawkaGodzinowa);
        }
        /// <summary>
        /// Wypłata pensji.
        /// </summary>
        public void PaySalary()
        {
            Console.WriteLine("\n------------------");
            Console.WriteLine("  WYPŁATA PENSJI");
            Console.WriteLine("------------------");
            EmployeeInfo();
            Console.WriteLine("{0,-20}{1,7:0.00}", "Do wypłaty: ", pensja);
            Console.WriteLine("Czas pracy:");
            Console.WriteLine("{0,-20}{1,7:0.00}", "Normalne godziny: ", czasPracy["Normalne"]);
            Console.WriteLine("{0,-20}{1,7:0.00}", "Nadgodziny: ", czasPracy["Nadgodziny"]);
            // zerowanie pensji po wypłacie
            pensja = 0;
            czasPracy["Normalne"] = 0;
            czasPracy["Nadgodziny"] = 0;
        }
    }
}
