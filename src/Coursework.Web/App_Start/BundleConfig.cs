using System.Web.Optimization;

namespace Coursework.Web
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
        "~/Scripts/libs/jquery/jquery-{version}.js",
        "~/Scripts/libs/jquery-ui/jquery-ui.min.js",
        "~/Scripts/libs/jquery-ui/jquery.nicescroll.min.js",

        // datatables
        "~/Scripts/libs/datatables/jquery.dataTables.min.js",
        "~/Scripts/libs/datatables/buttons.html5.min.js",
        "~/Scripts/libs/datatables/buttons.print.min.js",
        "~/Scripts/libs/datatables/dataTables.buttons.min.js",
        "~/Scripts/libs/datatables/dataTables.responsive.min.js",
        "~/Scripts/libs/datatables/dataTables.select.min.js",        
        "~/Scripts/libs/datatables/row().show().js",
        "~/Scripts/libs/datatables/absolute.js",
        "~/Scripts/libs/datatables/pdfmake.min.js",
        "~/Scripts/libs/datatables/vfs_fonts.js",
        "~/Scripts/libs/datatables/jszip.min.js",

        // datatime formatter
        "~/Scripts/libs/moment/moment.min.js",

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
        "~/Scripts/app/shared/nicescroll.module.js",
        "~/Scripts/app/shared/datatables.module.js",
        "~/Scripts/app/shared/moment.module.js",
        "~/Scripts/app/shared/plotly.module.js",
        "~/Scripts/app/shared/app.module.js",
        "~/Scripts/app/shared/app.constants.js",
        "~/Scripts/app/shared/top-bar.directive.js",
        "~/Scripts/app/shared/root.controller.js",
        "~/Scripts/app/shared/notification.service.js",
        "~/Scripts/app/shared/api.service.js",
        "~/Scripts/app/home/index.controller.js",
        "~/Scripts/app/account/account.service.js",
        "~/Scripts/app/account/account.controller.js",
        "~/Scripts/app/antennas-radiation-pattern-problem/antennas-radiation-pattern-problem.controller.js",
        "~/Scripts/app/antennas-radiation-pattern-problem/antennas-radiation-pattern-problem.service.js",
        "~/Scripts/app/branching-points-problem/branching-points-problem.controller.js",

        // praph
        "~/Scripts/libs/plotly/plotly-latest.min.js"));

      bundles.Add(new StyleBundle("~/bundles/css").Include(
        "~/Content/css/lib/bootstrap.min.css",
        "~/Content/css/lib/toastr.css",

        "~/Content/css/lib/datatables/buttons.dataTables.min.css",
        "~/Content/css/lib/datatables/editor.dataTables.min.css",
        "~/Content/css/lib/datatables/jquery.dataTables.min.css",
        "~/Content/css/lib/datatables/responsive.dataTables.min.css",
        "~/Content/css/lib/datatables/select.dataTables.min.css",

        "~/Content/css/lib/jquery-ui/jquery-ui.min.css",

        "~/Content/css/custom/common.css", 
        "~/Content/css/custom/user.css", 
        "~/Content/css/custom/menu.css", 
        "~/Content/css/custom/flexslider.css",
        "~/Content/css/custom/top-bar.css",
        "~/Content/css/custom/account.css",
        "~/Content/css/custom/problem.css",
        "~/Content/css/custom/datatables.css"
        ));

      BundleTable.EnableOptimizations = false;
    }
  }
}