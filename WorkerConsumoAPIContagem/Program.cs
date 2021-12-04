using WorkerConsumoAPIContagem;
using WorkerConsumoAPIContagem.Resilience;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton(
            FallbackContagem.CreateFallbackPolicy().WrapAsync(
                MonkeyPolicyContagem.CreateMonkeyPolicy()));
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();