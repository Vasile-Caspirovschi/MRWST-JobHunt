using DbUp;
using JobHunt.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace JobHunt.Infrastructure.DbUp;

internal class DatabaseUpgrader(IConfiguration _configuration) : IDatabaseUpgrader
{
    public void PerformUpgrade()
    {
        try
        {
            string connectionString = _configuration.GetConnectionString("SqlServerConnection")
                ?? throw new InvalidOperationException("DefaultConnection connection string is not configured.");

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgradeEngine = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssemblies([typeof(DatabaseUpgrader).Assembly])
                .LogToConsole()
                .Build();
            //Console.WriteLine("Checking if the database needs to be upgraded...");
            //if (!upgradeEngine.IsUpgradeRequired())
            //{
            //    Console.WriteLine("No changes found, upgrade not needed.");
            //    return;
            //}

            var upgradeResult = upgradeEngine.PerformUpgrade();
            if (upgradeResult.Successful)
            {
                Console.WriteLine("Database upgrade successful.");
                return;
            }
            else
            {
                Console.WriteLine("Database upgrade failed.\n" + upgradeResult.Error.Message);
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong during the database upgrade.\n" + ex.Message);
        }
    }
}
