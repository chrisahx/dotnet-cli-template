using System.ComponentModel;
using DTest.Cli.Configuration;
using DTest.Infrastructure.DependencyInjection;
using DTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var services = new ServiceCollection();
services.AddServices();
var registrar = new TypeRegistrar(services);

var app = new CommandApp(registrar);
app.Configure(CustomCommandConfiguration.Configure);

return app.Run(args);
