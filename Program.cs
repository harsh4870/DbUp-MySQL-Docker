using System;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.MySql;
using DbUp.Engine.Output;
using MySql.Data.MySqlClient;

namespace dbupmysql.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var environmentVariableConnectionString = Environment.GetEnvironmentVariable("DbUpConnectionString");
            var connectionString = environmentVariableConnectionString == null ? args.FirstOrDefault() ?? "server=127.0.0.1;port=3306;database=test;user=root;password=passwordsecret;" : environmentVariableConnectionString;
            Console.WriteLine(connectionString);
            EnsureDatabase.For.MySqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .MySqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

#if DEBUG
            Console.ReadLine();
#endif

            return 0;
        }
    }
}
