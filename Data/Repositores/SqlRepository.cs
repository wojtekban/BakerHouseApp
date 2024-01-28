using BakerHouseApp.Data.Entities;

namespace BakerHouseApp.Data.Repositores;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;


    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public SqlRepository(DbContext dbcontext)
    {
        _dbContext = dbcontext;
        _dbSet = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext?.SaveChanges();
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }

    public int GetListCount()
    {
        return Read().ToList().Count;
    }

}