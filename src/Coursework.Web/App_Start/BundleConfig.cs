using System.Web.Optimization;

namespace Coursework.Web
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/custom/common.css"));

      BundleTable.EnableOptimizations = false;
    }
  }
}