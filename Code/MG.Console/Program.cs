
using MG.Application.Forms;
using MG.Application.Generic;
using MG.Application.SocialUplift;
using MG.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IClassInfoData, ClassInfoData>();  
        services.AddSingleton<IConfiguration, Configuration>();  
        services.AddSingleton<ICrudGenerator, CrudGenerator>();  
        services.AddSingleton<IGenerateControls, GenerateControls>();  
        services.AddSingleton<IItemFileToGenerate, ItemFileToGenerate>();
    })
    .Build();

var configuration = host.Services.GetService<IConfiguration>(); 
configuration.AddConfig(new ItemConfig("XXXEntityLowerSingularXXX", "place"));
configuration.AddConfig(new ItemConfig("ProjectDirectory", "/Users/eduardosantana/source/Restore/SocialLiftApp/GitRepo/Code/WebApp/SocialUplift"));
configuration.LateLoadingDefaultConfigs();

var crudGenerator = host.Services.GetService<ICrudGenerator>(); 
var generateControls = host.Services.GetService<IGenerateControls>();
var frm = new FrmMainApp(crudGenerator, generateControls);
var presentation = new Presentation();
presentation.AddInputsToTable(frm.FlowInput);
presentation.AddOutputsToTable(frm.FlowOutput);
presentation.RenderTables();
