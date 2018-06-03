using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;

namespace Mmu.Kms.WpfUI.Areas.FileTagManagement.Services
{
    public interface IFileTagNavigationService
    {
        Task NavigateToFileTagEditAsync(Maybe<string> id);
    }
}