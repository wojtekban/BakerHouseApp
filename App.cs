namespace BakerHouseApp;

public class App : IApp // main app
{

        private readonly IDataGenerator _dataGenerator;
        private readonly IUserCommunication _userCommunication;
        private readonly IEventHandlerService _eventHandlerService;

        public App(IDataGenerator dataGenerator, IUserCommunication userCommunication, IEventHandlerService eventHandlerService)
        {
            _dataGenerator = dataGenerator;
            _userCommunication = userCommunication;
            _eventHandlerService = eventHandlerService;
        }
        public void Run()
        {
            _dataGenerator.ViewDataSourceInfo();
            _dataGenerator.AddWheatBread();
            _dataGenerator.AddRyeBread();
        }
}


