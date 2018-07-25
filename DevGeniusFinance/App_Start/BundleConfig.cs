
using System.Web.Optimization;

namespace DevGeniusFinance.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            StyleBundle estilosDefault = new StyleBundle("~/bundles/estilos-default");

            estilosDefault.Include("~/Content/bootstrap/bootstrap.css");
            estilosDefault.Include("~/Content/_layout/main.css");

            bundles.Add(estilosDefault);

        }
    }
}