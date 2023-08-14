using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    internal class AktHiddenWork
    {
        int ID { get; set; }
        int DayStart { get; set; }
        int DayEnd { get; set; }
        string Month { get; set; }
        string Year { get; set; }
        string WorkType { get; set; }
        string ProjectFounder { get; set; }
        string Certificate { get; set; }
        string TechRelevant { get; set; }
        string NextWork { get; set; }
        string DocRelevant { get; set; }    

    }
}
