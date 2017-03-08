using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice2
{
    public delegate bool IsRechargableDelegate(Employee emp);
    public class Program
    {

        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { EMPId = 101, Name = "John", Experience = 6, Salary = 10000, Balance = 10 });
            empList.Add(new Employee() { EMPId = 102, Name = "Johnny", Experience = 4, Salary = 40000, Balance = 0 });
            empList.Add(new Employee() { EMPId = 103, Name = "Jaanu", Experience = 5, Salary = 30000, Balance = 110 });
            empList.Add(new Employee() { EMPId = 104, Name = "Jenny", Experience = 7, Salary = 60000, Balance = 4 });
            empList.Add(new Employee() { EMPId = 105, Name = "Jeni", Experience = 3, Salary = 50000, Balance = 3 });
            IsRechargableDelegate isRechargable = new IsRechargableDelegate(Vodafone.RechargeForVodafone);
            IsRechargableDelegate isRechargable1 = new IsRechargableDelegate(Airtel.RechargeForAirtel);
            Telecom.RechargeBonus(empList, isRechargable);
            Console.WriteLine("--------------------------");
            Telecom.RechargeBonus(empList, isRechargable1);
            Console.ReadLine();
        }

    }
    public class Vodafone {
        public static bool RechargeForVodafone(Employee emp)
        {
            if (emp.Balance == 0)
            {
                emp.Balance += 10;
                return true;
            }
            else
                return false;
        }
    }
    public class Airtel {
        public static bool RechargeForAirtel(Employee emp)
        {
            if (emp.Balance <= 5)
            {
                emp.Balance += 10;
                return true;
            }
            else
                return false;
        }
    }
    public class Employee
    {
        public int EMPId { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }
        public int Balance { get; set; }
    }

    public class Telecom
    {
        public int EMPId { get; set; }
       
        public static void RechargeBonus(List<Employee> employees, IsRechargableDelegate isEligibleToRechargeBonus)
        {
            foreach (Employee emp in employees)
            {
                if (isEligibleToRechargeBonus(emp))
                    Console.WriteLine("Congratualations {0}!! You have been recharged!!", emp.Name);
            }
        }
    }
}
