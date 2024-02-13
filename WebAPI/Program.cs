using System.IO;
using ClassLib.EFContext;
using ClassLib.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using static System.Console;

/*
void ConfigureServices(IServiceCollection services)
{
    string fname = Path.Combine(@"D:\MyGitProjects\SoftLineTestApp\", "TestAppDB.db");
    services.AddDbContext<SqLiteDB>(options => options.UseSqlite("Filename=" + fname));
    services.AddControllers(options =>
    {
        WriteLine("Default output formatters:");
        foreach (IOutputFormatter formatter in options.OutputFormatters)
        {
            var mediaformatter = formatter as OutputFormatter;
            if (mediaformatter == null)
            {
                WriteLine($"{formatter.GetType().Name}");
            }
            else
            {
                WriteLine("{0}, Media types: {1}",
                arg0: mediaformatter.GetType().Name,
                arg1: string.Join(", ", mediaformatter.SupportedMediaTypes));
            }
        }
    }).AddXmlDataContractSerializerFormatters()
    .AddXmlSerializerFormatters();
}
*/
string fname = Path.Combine(@"D:\MyGitProjects\SoftLineTestApp\", "TestAppDB.db");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<SqLiteDB>(opt =>
opt.UseSqlite("Data source="+fname));
/*
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
*/


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
