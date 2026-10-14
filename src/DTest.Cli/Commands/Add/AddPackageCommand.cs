using System.ComponentModel;
using DTest.Commands.Shared;
using DTest.Services;
using Spectre.Console.Cli;

namespace DTest.Commands.Add;

internal class AddPackageCommand(IPackageService packageService) : Command<AddPackageCommand.Settings>
{
    public class Settings : GlobalSettings
    {
        [CommandArgument(0, "<name>")]
        [Description("The package name to add")]
        public string PackageName { get; init; } = string.Empty;

        [CommandOption("--version")]
        [Description("The packasge version (defaults: latest)")]
        public string? Version { get; init; }

    }
  
    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        var version = settings.Version ?? "latest";
  
        if (settings.Verbose)
        {
            System.Console.WriteLine($"Searching for package {settings.PackageName}...");
            System.Console.WriteLine($"Resolving version {version}...");
            System.Console.WriteLine($"Installing to ./packages...");
        }
  
        System.Console.WriteLine($"Added package {settings.PackageName} v{version}");
        System.Console.WriteLine(packageService.CheckPackage(settings.PackageName, version));
        return 0;
    }
}
