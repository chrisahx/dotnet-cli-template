using DTest.Commands.Add;
using DTest.Commands.List;
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
    }
}
