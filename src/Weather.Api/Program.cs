using Weather.Api.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IdGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    var idGenerator = context.RequestServices.GetRequiredService<IdGenerator>();
    logger.LogInformation("Id: {id}", idGenerator.Id);
    await next();
});

app.MapGet("/lifetime", (IdGenerator idGenerator) =>
{
    return idGenerator.Id;
});

app.Run();