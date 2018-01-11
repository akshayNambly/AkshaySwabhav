using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer { Location = "Mumbai", ID = 001, FirstName = "Akshay", LastName = "Nambly", MoneySpent = 150000 ,YearAttended = 2015 ,YearsAttended = new int[] { 2015,2017,2014} };
            Customer c2 = new Customer { Location = "Mumbai", ID = 002, FirstName = "Ryan", LastName = "Dias", MoneySpent = 20000, YearAttended = 2014, YearsAttended = new int[] { 2015, 2017, 2014 ,2016,2010 } };
            Customer c3 = new Customer { Location = "Dubai", ID = 003, FirstName = "Austin", LastName = "Dzouza", MoneySpent = 10000, YearAttended = 2015, YearsAttended = new int[] { 2015, 2017, 2013 } };
            Customer c4 = new Customer { Location = "Delhi", ID = 004, FirstName = "Keith", LastName = "Dias", MoneySpent = 2220000, YearAttended = 2017, YearsAttended = new int[] { 2010, 2017,2011,2014 } };
            IEnumerable<Customer> customer = new List<Customer> { c1, c2, c3, c4 };
            IEnumerable<Exhibition> exhibitions = new List<Exhibition> {  new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2010 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Delhi","Kolkata" } },
            new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2011 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Kolkata" } },new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2012 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Delhi","Kolkata" } },
            new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2013 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Delhi","Kolkata" } },new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2014 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Delhi","Kolkata" } },
            new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2015 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Kolkata" } },new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2016 ,Location= new string[] {"Bhubhaneshwar","Ranchi","Delhi","Kolkata" } },
            new Exhibition { ExhibitionName="IIMTF", ExhibitionYears = 2017 ,Location= new string[] {"Ranchi","Delhi","Kolkata" }}};
            //Case1(args);
            //Case3(args);
            Case6(customer,exhibitions);
        }

        private static void Case1(string[] args)
        {
            IEnumerator enumerator = args.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        private static void Case2(string[] args)
        {
            //IEnumerator enumerator = args.GetEnumerator();
            foreach(string c in args)
            {
                Console.WriteLine(c);
            }
        }
        private static void Case3(string[] args)
        {
            IEnumerable<string> companies = args;
            IEnumerable<string> companiesOrdered= companies.Where((c) => c.StartsWith("s") && c.Length>8)
                                                           .OrderBy(c => c)
                                                           ;
            foreach(string c in companiesOrdered)
            {
                Console.WriteLine(c);
            }
                
        }
        private static void Case4(IEnumerable<Customer> cust)
        {
            IEnumerable<Customer> customer1 = cust.OrderByDescending((c) => c.MoneySpent);
            foreach(Customer c in customer1)
            {
                Console.WriteLine(c.FirstName + " " + c.LastName + " : " + c.MoneySpent);
            }
            IEnumerable<Customer> customer2 = cust.OrderByDescending((c) => c.MoneySpent)
                                                  .Take(3);
            Console.WriteLine("\n Second Query");
            foreach (Customer c in customer2)
            {
                Console.WriteLine(c.FirstName + " " + c.LastName + " : " + c.MoneySpent);
            }
            IEnumerable<Customer> customer3 = cust.OrderBy(c => c.FirstName)
                                                  .ThenBy(c => c.LastName);
            Console.WriteLine("\n Third Query");
            foreach (Customer c in customer3)
            {
                Console.WriteLine(c.FirstName + " " + c.LastName + " : " + c.MoneySpent);
            }
            var customer4 = cust.Select ((c) => new { F=c.FirstName,L=c.LastName });
            Console.WriteLine("\n Fourth Query \n"+customer4.Count());
            foreach(var c in customer4)
            {
                Console.WriteLine(c.F + " " + c.L);
            }
            var customer5 = cust.GroupBy((c) => c.Location).Select((c) => c);
            Console.WriteLine("\n Fifth Query \n");
            foreach (var c in customer5)
            {
                var temp = c.Where((x) => x.Location == "Mumbai");
                foreach (var customer in temp)
                {
                    Console.WriteLine(customer.FirstName+" "+customer.LastName);
                }
            }

        }
        private static void Case5(IEnumerable<Customer> cust, IEnumerable<Exhibition> exhib,int year)
        {
            var customerDataByYears = cust.GroupBy(c => c.YearAttended).Select(c => c);
            foreach(var t in customerDataByYears)
            {
                var temp = t.Where(x => x.YearAttended == year);
                var yearData = temp.Join(exhib,
                                c => c.YearAttended,
                                e => e.ExhibitionYears,
                                (c, e) => new { Name = c.FirstName + " " + c.LastName, Money = c.MoneySpent, Year = c.YearAttended });
                foreach (var c in yearData)
                {
                    Console.WriteLine("{0}:{1} - {2}", c.Year, c.Name, c.Money);
                }
            }
            /*var yearData = cust.Join(exhib,
                                c => c.YearAttended,
                                e => e.ExhibitionYears,
                                (c, e) => new { Name = c.FirstName + " " + c.LastName, Money = c.MoneySpent ,Year=c.YearAttended});*/
            
        }
        private static void Case6(IEnumerable<Customer> cust, IEnumerable<Exhibition> exhib)
        {
            /*foreach(var v in exhib)
            {
                var temp = cust.Select(x => x).Where(x => x.YearsAttended.Contains(v.ExhibitionYears));
                Console.WriteLine(v.ExhibitionYears);
                foreach (var t in temp)
                {
                    Console.WriteLine(t.FirstName);
                }
            }
            var customersByYears = cust.SelectMany(x => x.YearsAttended).Join(exhib,
                                            customer => customer,
                                            e => e.ExhibitionYears,
                                            (customer, e) => new { Year = e.ExhibitionYears });
            foreach(var t in customersByYears)
            {
                Console.WriteLine(t.Year);
            }*/
            //var group = cust.GroupBy(x => x.YearsAttended).Select(x => x);
            var customrersByYears = from exhibition in exhib
                                    join customer in cust on exhibition.ExhibitionYears equals customer.

            foreach(var r in customrersByYears)
            {
                Console.WriteLine(r.ExhibitionName + " " + r.Name + " " + r.Year);
            }
        }
    }
}
