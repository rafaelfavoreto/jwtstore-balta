using JwtStore.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JwtStore API",
        Version = "v1"
    });

    options.CustomSchemaIds(type => type.FullName);// Usar quando der erro de duplicaidade de nomes de modais 
});

builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();

builder.AddAccountContext();

builder.AddMediator();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "JwtStore API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
    
app.MapAccountEndpoints();
app.MapControllers();

app.Run();
