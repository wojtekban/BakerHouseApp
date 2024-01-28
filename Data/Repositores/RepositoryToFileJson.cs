using System.Text.Json;

namespace BakerHouseApp.Data.Repositores;

internal class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
{

    private readonly List<T> _items = new();
    private int lastUsedId = 1;
    private readonly string path = $"{typeof(T).Name}_save.json";
    
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    //private readonly List<T> _items2 = new();
    //protected static readonly string fileName = "WheadBreadFileWrite";
    //protected static readonly string fileName2 = "RyeBreadFileWrite";
    //protected static readonly string uRLFile = $@"C:\Users\Wojtek\source\repos\wojtekban\BakerHouseApp\DataBase\{fileName}.json";
    //protected static readonly string uRLFile2 = $@"C:\Users\Wojtek\source\repos\wojtekban\BakerHouseApp\DataBase\{fileName2}.json";

    //public delegate void ItemAdded(object item);



    //private readonly ItemAdded _itemAddedCallback;

    //private readonly Action<T> itemAddedCallback;
    //private readonly Action<T> itemRemovedCallback;

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }

    public void Add(T item)
    {
        if (_items.Count == 0)
        {
            item.Id = lastUsedId;
            lastUsedId++;
        }
        else if (_items.Count > 0)
        {
            lastUsedId = _items[_items.Count - 1].Id;
            item.Id = ++lastUsedId;
        }

        _items.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public T? GetById(int id)
    {
        var itemById = _items.SingleOrDefault(item => item.Id == id);
        if (itemById == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Object {typeof(T).Name} with id {id} not found.");
            Console.ResetColor();
        }
        return itemById;
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        File.Delete(path);
        var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
        File.WriteAllText(path, objectsSerialized);
    }
    public IEnumerable<T> Read()
    {
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
            if (deserializedObjects != null)
            {
                foreach (var item in deserializedObjects)
                {
                    _items.Add(item);
                }
            }
        }
        return _items;
    }

    public int GetListCount()
    {
        return _items.Count;
    }

}
//    public void Add(T itemToSave)
//    {
//        itemToSave.Id = _items.Count + 1;
//        _items.Add(itemToSave);
//    }
//    public void Save()
//    {
//        throw new NotImplementedException();
//    }
//    public void AddInt(string value)
//    {
//        if (int.TryParse(value, out int number))
//        {
//            Console.WriteLine("The conversion success.");
//        }
//        else
//        {
//            Console.WriteLine("The conversion wasn't successful.");
//        }
//    }

//    public T? GetById(int id)
//    {
//        if (id > 0)
//        {
//            return _items.Find(item => item.Id == id);
//        }
//        else
//        {
//            throw new IndexOutOfRangeException();
//        }
//    }

//    public void Remove(T item)
//    {
//        if (item != null)
//        {
//            _items.Remove(item);
//        }
//        else
//        {
//            throw new InvalidOperationException("The product doesn't exist");
//        }
//    }

//    public void SaveWheatBread()
//    {
//        var json = JsonSerializer.Serialize(_items);
//        File.WriteAllText(uRLFile, json);
//        Console.WriteLine("Conversion to file JSON successful.");
//    }
//    public void SaveRyeBread()
//    {
//        var json = JsonSerializer.Serialize(_items);
//        File.WriteAllText(uRLFile2, json);
//        Console.WriteLine("Conversion to file JSON successful.");
//    }
//    //public IEnumerable<T> GetAll()
//    //{
//    //    var readfile = File.ReadAllText(uRLFile);
//    //    var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);

//    //    if (json != null)
//    //    {
//    //        return json.ToList();
//    //    }
//    //    else
//    //    {
//    //        throw new Exception("File is empty");
//    //    }
//    //}
//    public IEnumerable<T> GetAllRyeBread()
//    {
//        var readfile = File.ReadAllText(uRLFile2);
//        var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
//        if (json != null)
//        {
//            return json.ToList();
//        }
//        else
//        {
//            throw new Exception("File is empty");
//        }
//    }
//    public void WriteAllConsoleFromFileWheatBread(RepositoryToFileJson<WheatBread> repository1)
//    {
//        var items = repository1.GetAll();
//        foreach (var item in items)
//        {
//            Console.WriteLine(item);
//        }
//    }
//    public void WriteAllConsoleFromFileRyeBread(RepositoryToFileJson<RyeBread> repository2)
//    {
//        var items = repository2.GetAllRyeBread();
//        foreach (var item in items)
//        {
//            Console.WriteLine(item);
//        }
//    }

//}

