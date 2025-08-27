using AZ_AI_CustomVision_MultiLabelImageClassification.Interfaces;
using AZ_AI_CustomVision_MultiLabelImageClassification.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IClassificationService, ClassificationService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AzureVision:Endpoint"]);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
