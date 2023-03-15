using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApp
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               // Home style
               bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                         "~/Content/style.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/sbadmin/min/css").Include(
                    "~/Content/css/sb-admin-2.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/site/css").Include(
                    "~/Content/Site.css", new CssRewriteUrlTransform()));
               // Animate.css
               bundles.Add(new StyleBundle("~/bundles/f-f-f/css").Include(
                    "~/Content/vendor/fontawesome-free/css/all.min.css", new CssRewriteUrlTransform()));

               // Pe-icon-7-stroke
               bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css").Include(
                         "~/Content/pe-icons/pe-icon-7-stroke.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css/helper").Include(
                        "~/Content/pe-icons/helper.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css/style").Include(
                        "~/Content/stroke-icons/style.css", new CssRewriteUrlTransform()));

               // Bootstrap style
               bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                         "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

               // Font Awesome icons style
               bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                         "~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));
               //Toaster
               bundles.Add(new StyleBundle("~/bundles/toaster/css").Include(
                         "~/Vendors/toastr/toastr.min.css", new CssRewriteUrlTransform()));
               //DataTables
               bundles.Add(new StyleBundle("~/bundles/datatables/css").Include(
                   "~/Vendors/datatables/datatables.min.css", new CssRewriteUrlTransform()));

               // Bootstrap
               bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                         "~/Scripts/bootstrap.min.js"));

               // jQuery
               bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                         "~/Scripts/jquery-3.3.1.min.js"));

               // Unobtrusive           
               bundles.Add(new ScriptBundle("~/bundles/unobtrusive/js").Include(
                         "~/Scripts/jquery.unobtrusive-ajax.min.js"));

               // Pace
               bundles.Add(new ScriptBundle("~/bundles/pace/js").Include(
                         "~/Scripts/pace.min.js"));

               // Luna
               bundles.Add(new ScriptBundle("~/bundles/luna/js").Include(
                         "~/Scripts/luna.js"));

               // jQuery Validation
               bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                         "~/Scripts/jquery.validate.min.js"));

               //Toaster
               bundles.Add(new ScriptBundle("~/bundles/toaster/js").Include(
                        "~/Vendors/toastr/toastr.min.js"));

               //DataTables
               bundles.Add(new ScriptBundle("~/bundles/datatables/js").Include(
                   "~/Vendors/datatables/datatables.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/jquery/bootstrap/javascript/js").Include(
                    "~/Content/vendor/jquery/jquery.min.js", "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js", "~/Content/vendor/jquery-easing/jquery.easing.min.js", "~/Content/js/sb-admin-2.min.js", "~/Content/vendor/chart.js/Chart.min.js", "~/Content/js/demo/chart-area-demo.js", "~/Content/js/demo/chart-pie-demo.js"));
          }
     }
}