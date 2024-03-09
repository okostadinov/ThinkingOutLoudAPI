using Microsoft.EntityFrameworkCore;
using ThinkingOutLoud.Data;
using ThinkingOutLoud.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<TagService>();

builder.Services.AddDbContext<ThinkingOutLoudContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddScoped<DbInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();
