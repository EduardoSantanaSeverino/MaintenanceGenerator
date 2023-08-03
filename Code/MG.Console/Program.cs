using System.ComponentModel;
using MG.Application.Forms;
using MG.Application.Generic;
using MG.Application.SocialUplift;
using MG.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

var app = new CommandApp<CrudGeneratorCommand>();
return app.Run(args);

internal sealed class CrudGeneratorCommand : Command<CrudGeneratorCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Entity name for which to generate the template, Example: place.")]
        [CommandOption("-e|--entity")]
        public string? EntityName { get; set; }
        
        [Description("Project Directory for which to generate the template, Example: /Users/eduardosantana/source/Restore/SocialLiftApp/GitRepo/Code/WebApp/SocialUplift.")]
        [CommandOption("-d|--projectDirectory")]
        public string? ProjectDirectory { get; set; }
        
        [CommandOption("-s|--save")]
        public bool IsSaved { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IClassInfoData, ClassInfoData>();  
                services.AddSingleton<IConfiguration, Configuration>();  
                services.AddSingleton<ICrudGenerator, CrudGenerator>();  
                services.AddSingleton<IGenerateControls, GenerateControls>();  
                services.AddSingleton<IItemFileToGenerate, ItemFileToGenerate>();
            })
            .Build();

        // TODO: Remove code when pushing to container.
        settings.EntityName = "place";
        settings.ProjectDirectory =
            "/Users/eduardosantana/source/Restore/SocialLiftApp/GitRepo/Code/WebApp/SocialUplift";
        
        var configuration = host.Services.GetService<IConfiguration>();
        configuration.AddConfig(new ItemConfig("XXXEntityLowerSingularXXX", settings.EntityName));
        configuration.AddConfig(new ItemConfig("ProjectDirectory", settings.ProjectDirectory));
        configuration.LateLoadingDefaultConfigs();

        var crudGenerator = host.Services.GetService<ICrudGenerator>(); 
        var generateControls = host.Services.GetService<IGenerateControls>();
        var frm = new FrmMainApp(crudGenerator, generateControls);
        var presentation = new Presentation();
        presentation.AddInputsToTable(frm.FlowInput);
        presentation.AddOutputsToTable(frm.FlowOutput);
        presentation.RenderTables();

        if (settings.IsSaved)
        {
            // Save generated files code goes in here...
        }
        
        return 0;
    }
}
