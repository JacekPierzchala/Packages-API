using Microsoft.EntityFrameworkCore;
using Zadanie2.Application;
using Zadanie2.Application.Mapper;
using Zadanie2.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("ApplicationDbContext"));
//builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddTransient<IRecipientRepository, RecipientRepository>();
builder.Services.AddTransient<IPackageRepository, PackageRepository>();


builder.Services.AddTransient<IRecipientCommands, RecipientCommands>();
builder.Services.AddTransient<IRecipientQueries, RecipientQueries>();
builder.Services.AddTransient<IPackageQueries, PackageQueries>();
builder.Services.AddTransient<IPackageCommands, PackageCommands>();
builder.Services.AddTransient<IBarCodeService, BarCodeService>();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    serviceScope.ServiceProvider.GetService<ApplicationDbContext>().SeedData();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
