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

        public static SelectList GetMaritalStatus()
        {
            List<string> types = new List<string>() { "Single", "Married", "Separated" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetJobDurationType()
        {
            List<string> types = new List<string>() {"Any","Temporary (under 12 weeks)", "Long-term (over 12 weeks)" };
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

        public static SelectList PreferedPosition()
        {
            List<string> types = new List<string>() { "nanny", "maternity/night nurse", "babysitter " };
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
            List<string> types = new List<string>() { "Morning", "Afternoon", "Evening", "Anytime" };
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
