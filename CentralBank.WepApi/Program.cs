using CentralBank.Business.Abstracts;
using CentralBank.Business.Concretes;
using CentralBank.DataAccess.Abstracts;
using CentralBank.DataAccess.Concretes;
using CentralBank.Entities.Data;
using CentralBank.WepApi.Formatters;
using CentralBank.WepApi.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddHttpClient<CurrencyService>();
builder.Services.AddHostedService<FetchCurrencyService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});



builder.Services.AddScoped<IValuteDal, ValuteDal>();
builder.Services.AddScoped<IValuteService, ValuteService>();

builder.Services.AddScoped<IValCursDal, ValCursDal>();
builder.Services.AddScoped<IValCursService, ValCursService>();

builder.Services.AddScoped<IValTypeDal, ValTypeDal>();
builder.Services.AddScoped<IValTypeService, ValTypeService>();  

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<CentralBankDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

//builder.Services.AddControllers(opt =>
//{
//    opt.OutputFormatters.Insert(0, new VCardOutputFormatter());
//});


//builder.Services.AddHttpClient<IhttpCL>
var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlingMiddleWare>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
