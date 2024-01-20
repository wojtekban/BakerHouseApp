﻿using BakerHouseApp.Entities;
using System.Runtime.InteropServices;

namespace BakerHouseApp.Repositores
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item)   
        {
            item.Id = _items.Count == 0 ? 1 : _items.Max(item => item.Id) + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                // Console.WriteLine(item);
            }
        }
    }
}
