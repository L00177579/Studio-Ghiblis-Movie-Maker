using Microsoft.Extensions.Configuration;
using StudioGhibliMovieMaker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<StudioGhibliMovieMakerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudioGhibliMovieMakerContext") ?? throw new InvalidOperationException("Connection string 'StudioGhibliMovieMakerContext' not found.")));

builder.Services.AddMvc();
builder.Services.Add(new ServiceDescriptor(typeof(StudentRecordsContext), new StudentRecordsContext(builder.Configuration.GetConnectionString("MariaDbConnectionString"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
