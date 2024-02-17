using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
//services.AddSingleton<IApp, AppCsv>();
//services.AddSingleton<IApp, AppXml>();
services.AddSingleton<IXmlCreator, XmlCreator>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<IBreadProvider, BreadProvider>();
services.AddSingleton<IQueryInfoProvider, QueryInfoProvider>();
services.AddSingleton<IRepository<Bread>, ListRepository<Bread>>();                // ListRepository
services.AddSingleton<IRepository<Customer>, ListRepository<Customer>>();        // ListRepository
services.AddSingleton<IDataGeneration, DataGeneratorListRepository>();              // ListRepository
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<ICsvProvider, CsvProvider>();
services.AddSingleton<IRepository<Bread>, SqlRepository<Bread>>();
services.AddSingleton<IRepository<Customer>, SqlRepository<Customer>>();
services.AddSingleton<IDataGeneration, DataGenerationSql>();
services.AddDbContext<BakerHouseAppDbContext>(options => options
    .UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = BakerHouseAppStorage; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate=True; Application Intent = ReadWrite; Multi Subnet Failover=False;"));


var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>()!;
app.Run();

