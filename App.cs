namespace BakerHouseApp;

public class App : IApp
{

        private readonly IDataGeneration _dataGeneration;
        private readonly IUserCommunication _userCommunication;
        private readonly IEventHandlerService _eventHandlerService;
        private readonly BakerHouseAppDbContext _bakerHauseAppDbContext;

        public App(IDataGeneration dataGeneration, IUserCommunication userCommunication, IEventHandlerService eventHandlerService, BakerHouseAppDbContext bakerHauseAppDbContext)
        {
            _dataGeneration = dataGeneration;
            _userCommunication = userCommunication;
            _eventHandlerService = eventHandlerService;
            _bakerHauseAppDbContext = bakerHauseAppDbContext;
            _bakerHauseAppDbContext.Database.EnsureCreated();

    }
        public void Run()
        {
            _eventHandlerService.SubscribeToEvents();
            _dataGeneration.ViewDataSourceInfo();
            _dataGeneration.AddBread();
            _dataGeneration.AddCustomer();
            _userCommunication.UserChoice();
    }
}


