using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutiveDocumentation.Models
{
    public class AktHiddenWork
    {
        public string ID { get; set; }
        public string DayStart { get; set; }
        public string DayEnd { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string WorkType { get; set; }
        public string ProjectFounder { get; set; }
        public string Certificate { get; set; }
        public string TechRelevant { get; set; }
        public string NextWork { get; set; }
        public string DocRelevant { get; set; }

        public override string ToString()
        {
            return ID + WorkType;
        }

    }
}
