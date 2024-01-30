namespace BakerHouseApp.Services;

public class EventHandlerService : IEventHandlerService
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<Customer> _customerRepository;
    public EventHandlerService(IRepository<Bread> breadRepository, IRepository<Customer> customerRepository)
    {
        _breadRepository = breadRepository;
        _customerRepository = customerRepository;
    }

    public void SubscribeToEvents()
    {
        _breadRepository.ItemAdded += BreadRepositoryOnItemAdded;
        _breadRepository.ItemRemoved += BreadRepositoryOnItemRemoved;
        _customerRepository.ItemAdded += CustomerRepositoryOnItemAdded;
        _customerRepository.ItemRemoved += CustomerRepositoryOnItemRemoved;
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

    private void CustomerRepositoryOnItemAdded(object? sender, Customer e)
    {
        AddAuditInfo(e, "CUSTOMER ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Cust Bread\n{e}\nadded successfully.\n");
        Console.ResetColor();
    }

    private void CustomerRepositoryOnItemRemoved(object? sender, Customer e)
    {
        AddAuditInfo(e, "CUSTOMER REMOVED");
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
