using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    class Customer
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MoneySpent { get; set; }
        public int YearAttended { get; set; }
        public int[] YearsAttended { get; set; }
    }
}
