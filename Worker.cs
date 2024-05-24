namespace gm_idag_ivar;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private int _taskCounter;
    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _taskCounter = 0;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await GoAndFetchSomethingFromSomewhere(stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task GoAndFetchSomethingFromSomewhere(CancellationToken cancellationToken)
    {
        _taskCounter++;
        Console.WriteLine($"Attempting to get something from somewhere using task {_taskCounter}");
        await Task.Delay(2500,cancellationToken); //Time consuming operation here
        Console.WriteLine($"Finished attempting to get something from somewhere using task {_taskCounter}");
    }
}
