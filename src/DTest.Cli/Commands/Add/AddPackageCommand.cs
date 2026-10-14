using System.ComponentModel;
using DTest.Commands.Shared;
using DTest.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace DTest.Commands.Add;

internal class AddPackageCommand(IAnsiConsole console, IPackageService packageService) : Command<AddPackageCommand.Settings>
{
    public class Settings : GlobalSettings
    {
        [CommandArgument(0, "[name]")]
        [Description("The package name to add")]
        public string? PackageName { get; init; }

        [CommandOption("--version")]
        [Description("The packasge version (defaults: latest)")]
        public string? Version { get; init; }

    }
  
    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        var packageName = Console.IsInputRedirected
            ? Console.In.ReadToEnd().Trim()
            : settings.PackageName;

        if (string.IsNullOrWhiteSpace(packageName))
        {
            throw new NullReferenceException("Provide a package name as an argument or through stdin.");
        }

        var version = settings.Version ?? "latest";

        if (settings.Verbose)
        {
            console.MarkupLine( $"Searching for package [yellow]{Markup.Escape(packageName)}[/]...");
         }

        console.MarkupLine(
            $"[green]Added[/] package {Markup.Escape(packageName)} v{Markup.Escape(version)}");

        console.MarkupLine(
            $"[green] {packageService.CheckPackage(packageName, version)} [/]");

        return 0;
    }
}
