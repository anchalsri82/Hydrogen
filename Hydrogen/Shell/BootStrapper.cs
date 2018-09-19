using Prism.Autofac;
using Prism.Modularity;
using System.Windows;

namespace Hydrogen.Shell
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new Views.Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        //https://stackoverflow.com/questions/1152282/looking-for-prism-example-of-modules-loading-themselves-into-a-menu
        //http://dynamicreconfiguration.blogspot.com/2010/12/creating-dynamic-menus-in-wpf-and-prism.html
        //https://blogs.msdn.microsoft.com/dphill/2011/01/23/closable-tabbed-views-in-prism/
        //https://app.pluralsight.com/player?course=prism-mastering-tabcontrol&author=brian-lagunas&name=prism-mastering-tabcontrol-m2&clip=6&mode=live

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
