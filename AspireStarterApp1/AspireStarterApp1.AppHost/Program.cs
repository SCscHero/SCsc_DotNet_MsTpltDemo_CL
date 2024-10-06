var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireStarterApp1_ApiService>("apiservice");

builder.AddProject<Projects.AspireStarterApp1_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
