using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFinder
{
    public class Utilities
    {
        public static void Main()
        {
            DateTime date1 = new DateTime(2009, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2009, 8, 1, 12, 0, 0);
            int result = DateTime.Compare(date1, date2);
            string relationship;

            if (result < 0)
                relationship = "is earlier than";
            else if (result == 0)
                relationship = "is the same time as";
            else
                relationship = "is later than";

            Console.WriteLine("{0} {1} {2}", date1, relationship, date2);
        }

    }
}
