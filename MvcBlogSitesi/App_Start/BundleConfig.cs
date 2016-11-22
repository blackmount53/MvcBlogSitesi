using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcBlogSitesi.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin/layout").Include(
               "~/Scripts/jquery-2.2.3.min.js",
               "~/Scripts/bootstrap.min.js",
               "~/Scripts/jquery.slimscroll.min.js",
               "~/Scripts/fastclick.js",
               "~/Scripts/app.min.js",
               "~/Scripts/demo.js"
            ));
        }

    }
}