using System.Web.Optimization;

namespace Coursework.Web
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/libs/angularjs/angular.js"));

      bundles.Add(new ScriptBundle("~/bundles/problems").Include("~/Scripts/app/pages/problems/problems.module.js", "~/Scripts/app/pages/problems/problems.controller.js"));

      bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/css/custom/common.css", "~/Content/css/custom/user.css", "~/Content/css/custom/menu.css", "~/Content/css/custom/flexslider.css", "~/Content/css/lib/bootstrap.min.css"));

      bundles.Add(new ScriptBundle("~/bundles/flexslider").Include("~/Scripts/libs/flexslider/jquery.flexslider.js")); 

      BundleTable.EnableOptimizations = false;
    }
  }
}