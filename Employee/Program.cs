using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        /// <summary>
        /// Zaimplementuj klasę `Employee` umożliwiającą rejestrowanie czasu pracy oraz
        /// wypłacanie pensji na podstawie zadanej stawki godzinowej. Jeżeli pracownik
        /// będzie pracował więcej niż 8 godzin (podczas pojedynczej rejestracji czasu) to
        /// kolejne godziny policz jako nadgodziny (z podwójną stawką godzinową).
        /// 
        /// Konstruktor klasy niech przyjmuje imię, nazwisko i stawkę godzinową.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Jan", "Nowak", 100.0);
            emp1.RegisterTime(5);   //za to naliczy mu się 5*100
            emp1.RegisterTime(10);  //za to naliczy mu się 8*100 + 2*200
            emp1.RegisterTime(7.5); //za to naliczy mu się 7.5*100
            emp1.PaySalary(); //wyplacanie = stan należności po stronie pracodawcy = 0
            emp1.RegisterTime(11);  //za to naliczy mu się 8*100 + 3*200
            emp1.PaySalary();

            Console.ReadKey();
        }
    }
}
