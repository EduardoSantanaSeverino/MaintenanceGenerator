﻿using System.ComponentModel;
using MG.Application.Forms;
using MG.Application.Generic;
using MG.Application.AspnetBoilerPlate._8._1._0;
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

        [Description("Project Name for which to generate the template, Example: SocialUplift.")]
        [CommandOption("-n|--projectName")]
        public string? ProjectName { get; set; }

        [CommandOption("-s|--save")]
        public bool IsSaved { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IConfiguration, Configuration>();
                services.AddSingleton<ICrudGenerator, CrudGenerator>();
                services.AddSingleton<IGenerateControls, GenerateControls>();
                services.AddSingleton<IItemFileToGenerate, ItemFileToGenerate>();
            })
            .Build();

        // TODO: Remove code when pushing to container.
        // settings.EntityName = "place";
        // settings.ProjectDirectory =
        //     "/Users/eduardosantana/source/Restore/SocialLiftApp/GitRepo/Code/WebApp/SocialUplift";

        // settings.EntityName = "place";
        // settings.ProjectName = "AspnetBoilerPlate";

        var configuration = host.Services.GetService<IConfiguration>();
        if (!string.IsNullOrWhiteSpace(settings.EntityName))
        {
            configuration.AddConfig(new ItemConfig("XXXEntityLowerSingularXXX", settings.EntityName));
        }

        if (!string.IsNullOrWhiteSpace(settings.ProjectDirectory))
        {
            configuration.AddConfig(new ItemConfig("XXXProjectDirectoryXXX", settings.ProjectDirectory));
        }

        if (!string.IsNullOrWhiteSpace(settings.ProjectName))
        {
            configuration.AddConfig(new ItemConfig("XXXProjectNameXXX", settings.ProjectName));
        }

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
            crudGenerator.SaveOnToDisk();
            Console.WriteLine("Template Saved!");
        }

        return 0;
    }
}
