using System.Web;
using System.Web.Optimization;

namespace WebPage
{
     public class BundleConfig
     {
          // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
          public static void RegisterBundles(BundleCollection bundles)
          {
               bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                           "~/Scripts/jquery-{version}.js"));
               
               bundles.Add(new ScriptBundle("~/bundles/popper/js").Include(
                                "~/Scripts/popper.js"));

               bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                           "~/Scripts/jquery.validate*"));

               bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                         "~/Content/font-awesome.min.css"));

               bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                         "~/Content/animate.min.css"));

               bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                           "~/Scripts/modernizr-*"));

               bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                         "~/Scripts/bootstrap.js"));

               bundles.Add(new StyleBundle("~/Content/css").Include(
                         "~/Content/bootstrap.css",
                         "~/Content/styles/SSite.css"));
          }
     }
}
