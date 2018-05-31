using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using StructureMap;

namespace Mmu.Kms.WpfUI.Infrastructure.DependencyInjection
{
    public class WpfUiRegistry : Registry
    {
        public WpfUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(WpfUiRegistry));
                    scanner.AddAllTypesOf<IViewModel>();
                    scanner.AddAllTypesOf(typeof(IViewModelCommandContainer<>));
                    scanner.WithDefaultConventions();
                });

            For<IViewModel>().Transient();
        }
    }
}
