using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration);
});


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowPolicyAll", b => b.AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader());
})
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowPolicyAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
