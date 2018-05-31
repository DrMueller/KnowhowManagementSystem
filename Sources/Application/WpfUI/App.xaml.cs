using System.Windows;
using Mmu.Mlh.WpfExtensions.Areas.Initialization;

namespace Mmu.Kms.WpfUI
{
    public partial class App
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var thisAssembly = typeof(App).Assembly;
            var appIcon = WpfUI.Properties.Resources.M;

            var appConfig = ApplicationConfiguration.CreateFromIcon("Know-how Management System", appIcon);

            var tra = new Mmu.Kms.DomainServices.DataAccess.Areas.Dtos.ShadowFileDto();

            await BootstrapService.StartUpAsync(thisAssembly, appConfig);
        }
    }
}