using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation
{
    internal class DateThisProject
    {
        public static string getNameOfMonth(DateTime date)
        {
            String monthString = "";
            switch (date.Month)
            {
                case 1: monthString = "января"; break;
                case 2: monthString = "февраля"; break;

            }
            return monthString;
        }
    }
}
