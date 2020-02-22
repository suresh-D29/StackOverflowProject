using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace StackOverflowProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/jquery-3.3.1.js", "~/Scripts/umd/popper.js","~/Scripts/bootstarp.js").IncludeDirectory("~/Scripts/umd", "*.js"));
            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include("~/Content/bootstrap.cs").IncludeDirectory("~/Content","*.css"));
            bundles.Add(new StyleBundle("~/Styles/site").Include("~/Content/Styles.cs").IncludeDirectory("~/Content","*.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}