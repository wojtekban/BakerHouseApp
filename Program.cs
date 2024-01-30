using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<IBreadProvider, BreadProvider>();
services.AddSingleton<IQueryInfoProvider, QueryInfoProvider>();
services.AddSingleton<IRepository<Bread>, ListRepository<Bread>>();                // ListRepository
services.AddSingleton<IRepository<CustBread>, ListRepository<CustBread>>();        // ListRepository
services.AddSingleton<IDataGenerator, DataGeneratorListRepository>();              // ListRepository


var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>()!;
app.Run();

