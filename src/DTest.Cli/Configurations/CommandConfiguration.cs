using DTest.Commands.Add;
using DTest.Commands.List;
using Spectre.Console;
using Spectre.Console.Cli;

namespace DTest.Cli.Configuration;


internal static class CustomCommandConfiguration
{
    public static void Configure(IConfigurator config)
    {
        config.AddBranch("add", add =>
        {
            add.AddCommand<AddPackageCommand>("package")
              .WithAlias("pkg");

            add.AddCommand<AddReferenceCommand>("reference")
              .WithAlias("ref")
              .WithDescription("Display the references for this package");
        });

        config.AddCommand<ListCommand>("list");


        config.SetExceptionHandler((ex, resolver) =>
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.NoStackTrace);
      
            return ex switch
            {
                InvalidOperationException => 2,
                FileNotFoundException => 3,
                _ => 1
            };
        });
    }
}
