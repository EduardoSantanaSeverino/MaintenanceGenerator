// See https://aka.ms/new-console-template for more information

using MG.Application.Forms;
using MG.Application.Generic;
using MG.Application.SocialUplift;
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

// await host.RunAsync();
// Console.WriteLine("Hello, World!");