using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NationwideNannies.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string IsMenuSelected(this HtmlHelper html, string menuUrl)
        {
            string cssClass = string.Empty;

            string currentUrl = System.Web.HttpContext.Current.Request.RawUrl;
            if (currentUrl.Equals(menuUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                cssClass = "active";
            }

            return cssClass;
        }
    }
}