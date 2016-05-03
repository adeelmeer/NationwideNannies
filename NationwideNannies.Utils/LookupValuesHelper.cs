using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NationwideNannies.Utils
{
    public static class LookupValuesHelper
    {
        public static SelectList GetEmploymentType()
        {
            List<string> types = new List<string>() { "Full-time", "Part-time" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetNannyType()
        {
            List<string> types = new List<string>() { "Live in", "Live out" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetYesNo()
        {
            List<string> types = new List<string>() { "Yes", "No" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetChildAgeGroup()
        {
            List<string> types = new List<string>() { "Newborn", "Toddler", "Pre-Schooler", "School-Aged", "Multiple Ages"};
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetTimeForCall()
        {
            List<string> types = new List<string>() { "Morning", "Afternoon", "Evening", "After Hours" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetJobRadius()
        {
            List<string> types = new List<string>() { "5", "10", "15", "20" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }
    }
}
