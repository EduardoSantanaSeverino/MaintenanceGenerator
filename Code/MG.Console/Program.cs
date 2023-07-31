// See https://aka.ms/new-console-template for more information

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
        services.AddSingleton<IItemToReplace, ItemToReplace>();
    })
    .Build();


var crudGenerator = host.Services.GetService<ICrudGenerator>(); 
var generateControls = host.Services.GetService<IGenerateControls>();
var frm = new FrmMainApp(crudGenerator, generateControls);
var inputs = new List<IControl>();
inputs.Add(new Control("XXXEntityLowerSingularXXX", "place"));
inputs.Add(new Control("XXXSpecificTypeXXX", "int"));
frm.SetInputsFromParameters(inputs);
var presentation = new Presentation();
presentation.AddInputsToTable(frm.FlowInput);
presentation.AddOutputsToTable(frm.FlowOutput);
presentation.RenderTables();
// Console.ReadKey();
// await host.RunAsync();
// Console.WriteLine("Hello, World!");