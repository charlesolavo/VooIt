using VooIt.Api.Filters;
using VooIT.Common.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIoC();

builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(GlobalExceptionFilter));
    config.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition =
           System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
