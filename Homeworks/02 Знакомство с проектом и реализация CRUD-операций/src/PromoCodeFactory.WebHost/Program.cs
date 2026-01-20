using PromoCodeFactory.WebHost;
using PromoCodeFactory.DataAccess;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDataAccess();

builder.Services.AddControllers();
builder.Services.AddOpenApi(builder.Environment);

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();