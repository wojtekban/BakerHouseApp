namespace BakerHouseApp.Services;

public class EventHandlerService : IEventHandlerService
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<CustBread> _custBreadRepository;
    public EventHandlerService(IRepository<Bread> breadRepository, IRepository<CustBread> custBreadRepository)
    {
        _breadRepository = breadRepository;
        _custBreadRepository = custBreadRepository;
    }

    public void SubscribeToEvents()
    {
        _breadRepository.ItemAdded += BreadRepositoryOnItemAdded;
        _breadRepository.ItemRemoved += BreadRepositoryOnItemRemoved;
        _custBreadRepository.ItemAdded += CustBreadRepositoryOnItemAdded;
        _custBreadRepository.ItemRemoved += CustBreadRepositoryOnItemRemoved;
    }

    private void BreadRepositoryOnItemAdded(object? sender, Bread e)
    {
        AddAuditInfo(e, "BREAD ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Bread\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void BreadRepositoryOnItemRemoved(object? sender, Bread e)
    {
        AddAuditInfo(e, "BREAD REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Bread\n{e}\nremoved successfully.\n");
        Console.ResetColor();
    }

    private void CustBreadRepositoryOnItemAdded(object? sender, CustBread e)
    {
        AddAuditInfo(e, "CUST BREAD ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Cust Bread\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void CustBreadRepositoryOnItemRemoved(object? sender, CustBread e)
    {
        AddAuditInfo(e, "CUST BREAD REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Cust Bread\n{e}\nremoved successfully.\n");
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
