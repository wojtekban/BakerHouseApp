﻿namespace BakerHouseApp.Data.Repositores;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    public IEnumerable<T> Read();
    public int GetListCount();
}
