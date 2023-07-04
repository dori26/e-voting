using HyperledgerFabricApi.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var  corsOriginName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsOriginName,
        builder =>
        {
            builder.WithOrigins("*");
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoDbContext, MongoDbDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsOriginName);
app.UseAuthorization();

app.MapControllers();

app.Run();