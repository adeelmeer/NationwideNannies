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
        public static SelectList GetEmploymentType(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "Full-time", "Part-time" };
            if (addEmpty)
            {
                types.Insert(0, string.Empty);
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetHearAboutUsOptions()
        {
            List<string> types = new List<string>() { "Marketing email", "Word of mouth", "Social media", "Web Search" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetMaritalStatus()
        {
            List<string> types = new List<string>() { "Single", "Married", "Separated", "Widowed", "Divorced", "Co-Habitating" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetJobDurationType()
        {
            List<string> types = new List<string>() {"Any","Temporary (under 12 weeks)", "Long-term (over 12 weeks)" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetNannyType(bool addEmpty=false)
        {
            List<string> types = new List<string>() { "Live in", "Live out" };
            if (addEmpty)
            {
                types.Insert(0, string.Empty);
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetPreferenceTypes(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "Not necessary", "Essential", "Preferred" };
            if (addEmpty)
            {
                types.Insert(0, string.Empty);
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetYesNo(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "No" , "Yes"};
            if (addEmpty)
            {
                types.Insert(0, string.Empty);
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetTypeOfChildCare(bool addEmpty= false)
        {
            List<string> types = new List<string>() { "Nanny", "Mother’s help", "Nanny housekeeper", "Maternity/Night nurse", "Afterschool help", "Shared nanny", "Babysitter", "Other" };
            if (addEmpty)
            {
                types.Insert(0, string.Empty);
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList PreferedPosition(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "Nanny", "Maternity/Night nurse", "Babysitter" };
            if (addEmpty)
            {
                types.Insert(0, "");
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetSchoolType()
        {
            List<string> types = new List<string>() { "Nursery", "Playgroup", "School", "Other" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetLanguageSkill(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "Basic", "Intermediate", "Fluent" };
            if (addEmpty)
            {
                types.Insert(0, "");
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetChildAgeGroup(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "Newborn", "Toddler", "Pre-Schooler", "School-Aged", "Multiple Ages"};
            if (addEmpty)
            {
                types.Insert(0, string.Empty);
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetLiveInNannyFacilities()
        {
            List<string> types = new List<string>() { "Separate bedroom", "Bath room", "TV in room", "Separate accommodation" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetTimeForCall()
        {
            List<string> types = new List<string>() { "Morning", "Afternoon", "Evening", "Anytime" };
            SelectList selectList = new SelectList(types);
            return selectList;
        }

        public static SelectList GetJobRadius(bool addEmpty = false)
        {
            List<string> types = new List<string>() { "5", "10", "15", "20" };
            if (addEmpty)
            {
                types.Insert(0, "0");
            }
            SelectList selectList = new SelectList(types);
            return selectList;
        }
    }
}
