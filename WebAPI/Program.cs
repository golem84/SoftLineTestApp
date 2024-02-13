using ClassLib.EFContext;
using Microsoft.EntityFrameworkCore;

string fname = Path.Combine(@"D:\MyGitProjects\SoftLineTestApp\", "TestAppDB.db");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqLiteDB>(opt =>
opt.UseSqlite("Data source="+fname));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
