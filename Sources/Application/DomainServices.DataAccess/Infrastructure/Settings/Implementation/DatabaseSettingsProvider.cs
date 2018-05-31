using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;

namespace Mmu.Kms.DomainServices.DataAccess.Infrastructure.Settings.Implementation
{
    public class DatabaseSettingsProvider : IDatabaseSettingsProvider
    {
        public DatabaseSettings ProvideDatabaseSettings() => new DatabaseSettings
        {
            CollectionName = "mmu-col",
            DatabaseName = "mmu-db",
            Host = "drmuellersdb.documents.azure.com",
            Password = "73LMdjYOqc3XGipXWSepgApEIk94yspVHT6SdWi9fTCgsZx2SoXpeEasXl1pepXptbuoNwVCgtmbP91juOdrYA==",
            Port = 10255,
            UserName = "drmuellersdb",
            UseSsl = true
        };
    }
}