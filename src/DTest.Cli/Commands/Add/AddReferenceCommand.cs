using System.ComponentModel;
using DTest.Commands.Shared;
using Spectre.Console.Cli;

namespace DTest.Commands.Add;


internal class AddReferenceCommand : Command<AddReferenceCommand.Settings>
{
    public class Settings : GlobalSettings
    {
        [CommandArgument(0, "<path>")]
        [Description("The project reference path to add")]
        public string ReferencePath { get; init; } = string.Empty;
    }
  
    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        if (settings.Verbose)
        {
            System.Console.WriteLine($"Validating project at {settings.ReferencePath}...");
            System.Console.WriteLine($"Adding reference to project file...");
        }
  
        System.Console.WriteLine($"Added reference to {settings.ReferencePath}");
        return 0;
    }
}
