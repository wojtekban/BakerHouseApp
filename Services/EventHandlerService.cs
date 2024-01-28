namespace BakerHouseApp.Services;

public class EventHandlerService : IEventHandlerService
{
    private readonly IRepository<WheatBread> _wheatBreadRepository;
    private readonly IRepository<RyeBread> _ryeBreadRepository;
    public EventHandlerService(IRepository<WheatBread> wheatBreadRepository, IRepository<RyeBread> ryeBreadRepository)
    {
        _wheatBreadRepository = wheatBreadRepository;
        _ryeBreadRepository = ryeBreadRepository;
    }

    public void SubscribeToEvents()
    {
        _wheatBreadRepository.ItemAdded += WheatBreadRepositoryOnItemAdded;
        _wheatBreadRepository.ItemRemoved += WheatBreadRepositoryOnItemRemoved;
        _ryeBreadRepository.ItemAdded += RyeBreadRepositoryOnItemAdded;
        _ryeBreadRepository.ItemRemoved += RyeBreadRepositoryOnItemRemoved;
    }

    private void WheatBreadRepositoryOnItemAdded(object? sender, WheatBread e)
    {
        AddAuditInfo(e, "WHEAT BREAD ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Bread\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void WheatBreadRepositoryOnItemRemoved(object? sender, WheatBread e)
    {
        AddAuditInfo(e, "WHEAT BREAD REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Bread\n{e}\nremoved successfully.\n");
        Console.ResetColor();
    }

    private void RyeBreadRepositoryOnItemAdded(object? sender, RyeBread e)
    {
        AddAuditInfo(e, "RYE BREAD ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Rye Bread\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void RyeBreadRepositoryOnItemRemoved(object? sender, RyeBread e)
    {
        AddAuditInfo(e, "RYE BREAD REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Rye Bread\n{e}\nremoved successfully.\n");
        Console.ResetColor();
    }
    private void AddAuditInfo<T>(T e, string info) where T : class, IEntity
    {
        using (var writer = File.AppendText((IRepository<IEntity>.auditFileName)))
        {
            writer.WriteLine($"[{DateTime.UtcNow}]\t{info} :\n    [{e}]");
        }
    }
}
