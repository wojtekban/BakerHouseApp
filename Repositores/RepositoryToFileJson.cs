using System.Text.Json;
using BakerHouseApp.Entities;

namespace BakerHouseApp.Repositores
{
    internal class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly List<T> _items = new();
        private readonly List<T> _items2 = new();
        protected static readonly string fileName = "WheadBreadFileWrite";
        protected static readonly string fileName2 = "RyeBreadFileWrite";
        protected static readonly string uRLFile = $@"C:\Users\Wojtek\source\repos\wojtekban\BakerHouseApp\DataBase\{fileName}.json";
        protected static readonly string uRLFile2 = $@"C:\Users\Wojtek\source\repos\wojtekban\BakerHouseApp\DataBase\{fileName2}.json";


        public delegate void ItemAdded(object item);

        private readonly ItemAdded _itemAddedCallback;

        private readonly Action<T> itemAddedCallback;
        private readonly Action<T> itemRemovedCallback;

        public void Add(T itemToSave)
        {
            itemToSave.Id = _items.Count + 1;
            _items.Add(itemToSave);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
        public void AddInt(string value)
        {
            if (int.TryParse(value, out int number))
            {
                Console.WriteLine("The conversion success.");
            }
            else
            {
                Console.WriteLine("The conversion wasn't successful.");
            }
        }

        public T? GetById(int id)
        {
            if (id > 0)
            {
                return _items.Find(item => item.Id == id);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(T item)
        {
            if (item != null)
            {
                _items.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("The product doesn't exist");
            }
        }

        public void SaveWheatBread()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(uRLFile, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        public void SaveRyeBread()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(uRLFile2, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        public IEnumerable<T> GetAll()
        {
            var readfile = File.ReadAllText(uRLFile);
            var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);

            if (json != null)
            {
                return json.ToList();
            }
            else
            {
                throw new Exception("File is empty");
            }
        }
        public IEnumerable<T> GetAllRyeBread()
        {
            var readfile = File.ReadAllText(uRLFile2);
            var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (json != null)
            {
                return json.ToList();
            }
            else
            {
                throw new Exception("File is empty");
            }
        }
        public void WriteAllConsoleFromFileWheatBread(RepositoryToFileJson<WheatBread> repository1)
        {
            var items = repository1.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public void WriteAllConsoleFromFileRyeBread(RepositoryToFileJson<RyeBread> repository2)
        {
            var items = repository2.GetAllRyeBread();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

    }

}

