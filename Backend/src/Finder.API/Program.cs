using Finder.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configure(builder.Configuration);

var app = builder.Build();

await app.ConfigureAsync();

await app.RunAsync();