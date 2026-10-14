using System.ComponentModel;
using Spectre.Console.Cli;

namespace DTest.Commands.Shared;


internal class GlobalSettings : CommandSettings
{
    [CommandOption("-v|--verbose")]
    [Description("Enable verbose output")]
    [DefaultValue(false)]
    public bool Verbose { get; init; }
}
