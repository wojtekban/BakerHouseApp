using BakerHouseApp.Entities;

namespace BakerHouseApp.Repositores
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {
    }
}
