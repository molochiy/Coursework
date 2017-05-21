using System.Web.Optimization;

namespace Coursework.Web
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
        "~/Scripts/libs/jquery/jquery-{version}.js",
        
        //"~/Scripts/libs/flexslider/jquery.flexslider.js",

        // notifications
        "~/Scripts/libs/toastr/toastr.js",

        // angular libs
        "~/Scripts/libs/angularjs/angular.js",
        "~/Scripts/libs/angularjs/angular-base64.js",
        "~/Scripts/libs/angularjs/angular-cookies.js",
        "~/Scripts/libs/angularjs/angular-route.js",
        "~/Scripts/libs/angularjs/angular-validator.js",
        
        // angular apps
        "~/Scripts/app/shared/app.module.js",
        "~/Scripts/app/shared/top-bar.directive.js",
        "~/Scripts/app/shared/root.controller.js",
        "~/Scripts/app/shared/notification.service.js",
        "~/Scripts/app/shared/api.service.js",
        "~/Scripts/app/home/index.controller.js",
        "~/Scripts/app/account/account.service.js",
        "~/Scripts/app/account/account.controller.js",
        "~/Scripts/app/problem1/problem1.controller.js",
        "~/Scripts/app/problem2/problem2.controller.js",

        // praph
        "~/Scripts/libs/plotly/plotly-latest.min.js"));

      bundles.Add(new StyleBundle("~/bundles/css").Include(
        "~/Content/css/lib/bootstrap.min.css",
        "~/Content/css/lib/toastr.css",

        "~/Content/css/custom/common.css", 
        "~/Content/css/custom/user.css", 
        "~/Content/css/custom/menu.css", 
        "~/Content/css/custom/flexslider.css",
        "~/Content/css/custom/top-bar.css",
        "~/Content/css/custom/account.css",
        "~/Content/css/custom/problem.css"
        ));

      BundleTable.EnableOptimizations = false;
    }
  }
}