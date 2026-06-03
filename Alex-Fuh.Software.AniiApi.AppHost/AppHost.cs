var builder = DistributedApplication.CreateBuilder(args);

var api = builder
    .AddProject<Projects.Alex_Fuh_Software_AniiApi>("api");

// var frontend = builder
//     .AddProject<Projects.Alex_Fuh_Software_AniiApi_FrontEnd>("frontend")
//     .WithReference(api)
//     .WaitFor(api)
//     .WithExternalHttpEndpoints();

builder.Build().Run();