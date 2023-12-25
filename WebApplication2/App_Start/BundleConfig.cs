using System.Web;
using System.Web.Optimization;

namespace WebApplication2
{
    // BundleConfig类用于配置捆绑（Bundling）的设置
    public class BundleConfig
    {
        // RegisterBundles方法用于注册捆绑
        // 参数BundleCollection bundles包含了所有捆绑的集合
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 添加名为“~/bundles/jquery”的脚本捆绑，包括jQuery库的指定版本
            // 不要动现有的方法！！！
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-{version}.js"
                        ));

            // 添加名为“~/bundles/lib”的脚本捆绑
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                            "~/Scripts/bootbox.all.min.js",
                            "~/Scripts/dataTables/jquery.dataTables.min.js",
                            "~/Scripts/dataTables/dataTables.bootstrap5.min.js",
                            "~/Scripts/typeahead.bundle.js"
                        ));

            // 添加名为“~/bundles/jqueryval”的脚本捆绑，包括jQuery验证脚本
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                            "~/Scripts/jquery.validate*"
                        ));

            // 添加名为“~/bundles/modernizr”的脚本捆绑，包括Modernizr库的开发版本
            // 在生产环境中，可以通过 https://modernizr.com 上的生成工具选择所需的测试
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"
                        ));

            // 添加名为“~/bundles/bootstrap”的捆绑，包括Bootstrap库的脚本
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"
                      ));

            // 添加名为“~/Content/css”的样式捆绑，包括Bootstrap和自定义样式表
            bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/bootstrap-morph.css",
                          "~/Content/dataTables/dataTables.bootstrap5.min.css",
                          "~/Content/typeahead.css",
                          "~/Content/Site.css"
                      ));
        }
    }
}

