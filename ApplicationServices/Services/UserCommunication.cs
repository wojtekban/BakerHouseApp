namespace BakerHouseApp.ApplicationServices.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IQueryInfoProvider _queryInfoProvider;

    public UserCommunication(IRepository<Bread> breadRepository, IRepository<Customer> customerRepository, IQueryInfoProvider queryInfoProvider)
    {
        _breadRepository = breadRepository;
        _customerRepository = customerRepository;
        _queryInfoProvider = queryInfoProvider;
    }

    public void UserChoice()
    {
        bool CloseApp = false;

        while (!CloseApp)
        {
            Console.WriteLine();
            WritelineColor("--- MAIN MENU ---\n" +
                "1 - View all Bread or Customer\n" +
                "2 - Add new Bread or Customer\n" +
                "3 - Find Bread or Customer by id\n" +
                "4 - Remove Bread or Customer from File\n" +
                "5 - Get query information...\n" +
                "X - Close the app and save changes\n", ConsoleColor.Cyan);

            var userInput = GetInputFromUser("What you want to do? \nPress key 1, 2, 3, 4, 5 or X: ").ToUpper();

            switch (userInput)
            {
                case "1": // View all
                    var userChoiceToShowAll = GetInputFromUser("B - View all BREAD\nC - View all CUSTOMER\nAny Other key - leave and go to MENU").ToUpper();
                    if (userChoiceToShowAll == "B")
                    {
                        WriteAllToConsole(_breadRepository);
                        break;
                    }
                    if (userChoiceToShowAll == "C")
                    {
                        WriteAllToConsole(_customerRepository);
                        break;
                    }
                    break;

                case "2": // Add new
                    var userChoiceToAdd = GetInputFromUser("B - Add new BREAD\nC - Add new CUSTOMER\nQ - leave and go to MENU").ToUpper();
                    if (userChoiceToAdd == "B")
                    {
                        AddNewBread();
                        break;
                    }
                    if (userChoiceToAdd == "C")
                    {
                        AddNewCustomer();
                        break;
                    }
                    break;

                case "3": // Find by id
                    var userChoiceToFind = GetInputFromUser("B - Find BREAD by id\nC - Find CUSTOMER by id\nQ - leave and go to MENU").ToUpper();
                    if (userChoiceToFind == "B")
                    {
                        FindEntityById(_breadRepository);
                        break;
                    }
                    if (userChoiceToFind == "C")
                    {
                        FindEntityById(_customerRepository);
                        break;
                    }
                    break;

                case "4": // Remove by id
                    var userChoiceToRemove = GetInputFromUser("B - Remove BREAD by id\nC - Remove CUSTOMER by id\nQ - leave and go to MENU").ToUpper();
                    if (userChoiceToRemove == "B")
                    {
                        RemoveBreadCustomer(_breadRepository);
                        break;
                    }
                    if (userChoiceToRemove == "C")
                    {
                        RemoveBreadCustomer(_customerRepository);
                        break;
                    }
                    break;

                case "5": // Get specific info...

                    _queryInfoProvider.GetQueryInfo();

                    break;

                case "X": // Close app and Save changes
                    CloseApp = CloseAppSaveChanges();
                    break;

                default:
                    WritelineColor("Invalid operation.\n", ConsoleColor.Red);
                    continue;
            }
        }

        WritelineColor("\n\nBye Bye! Press any key to leave.", ConsoleColor.DarkCyan);
    }

    private void WriteAllToConsole<T>(IRepository<T> repository) where T : class, IEntity
    {
        WritelineColor("\n\n----- View all -----", ConsoleColor.Cyan);
        var items = repository.GetAll();
        if (items.ToList().Count == 0)
        {
            WritelineColor($"No objects found.", ConsoleColor.Red);
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private void AddNewBread()
    {
        var Name = GetInputFromUser("Name:");
        EmptyInputWarning(ref Name, "Name:");
        var Quantity = GetValueFromUser<int>("Quantity:");
        var Weight = GetValueFromUser<double>("Weight:");

        DateTime Date = GetDateFromUser();
        DateTime ExpirationDate = GetDateFromUser();
        DateTime DateOfProduction = GetDateFromUser();
        var Calories = GetValueFromUser<double>("Calories:");
        var StandardCost = GetValueFromUser<decimal>("Standard Cost:");
        var Price = GetValueFromUser<decimal>("Price:");
        var Type = GetInputFromUser("Type: Wheat or Rye");
        EmptyInputWarning(ref Type, "Type: Wheat or Rye");

        while (true)
        {
            var choice = GetInputFromUser("Is this Bread?\nPress Y if YES\t\tPress N if NO").ToUpper();
            if (choice == "Y")
            {
                var newBread = new Bread { Name = Name, Quantity = Quantity, Weight = Weight, Date = Date, ExpirationDate = ExpirationDate, DateOfProduction = DateOfProduction, Calories = Calories, StandardCost = StandardCost, Price = Price, Type = Type };
                _breadRepository.Add(newBread);
                break;
            }
            if (choice == "N")
            {
                var newBread = new Bread { Name = Name, Quantity = Quantity, Weight = Weight, Date = Date, ExpirationDate = ExpirationDate, DateOfProduction = DateOfProduction, Calories = Calories, StandardCost = StandardCost, Price = Price, Type = Type };
                _breadRepository.Add(newBread);
                break;
            }
            else
            {
                WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
            }
        }

    }

    private void AddNewCustomer()
    {
        var CustName = GetInputFromUser("Customer Name:");
        EmptyInputWarning(ref CustName, "Customer Name:");
        var AddressStreet = GetInputFromUser("Address Street:");
        EmptyInputWarning(ref AddressStreet, "Address Street:");
        var AddressCityName = GetInputFromUser("Address City Name:");
        EmptyInputWarning(ref AddressCityName, "Address City Name:");
        var AddressZipCode = GetValueFromUser<decimal>("Address Zip Code:");
        var NipNum = GetValueFromUser<decimal>("Nip Num:");
        while (true)
        {
            {
                var choice = GetInputFromUser("Is this Customer?\nPress Y if YES\t\tPress N if NO").ToUpper();
                if (choice == "Y")
                {
                    var newCustomer = new Customer { CustName = CustName, AddressStreet = AddressStreet, AddressCityName = AddressCityName, AddressZipCode = AddressZipCode, NipNum = NipNum };
                    _customerRepository.Add(newCustomer);
                    break;
                }
                if (choice == "N")
                {
                    var newCustomer = new Customer { CustName = CustName, AddressStreet = AddressStreet, AddressCityName = AddressCityName, AddressZipCode = AddressZipCode, NipNum = NipNum };
                    _customerRepository.Add(newCustomer);
                    break;
                }
                else
                {
                    WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
                }
            }
        }
    }

    private T? FindEntityById<T>(IRepository<T> entityRepository) where T : class, IEntity
    {
        while (true)
        {
            var choiceID = GetInputFromUser($"Enter the ID of the {typeof(T).Name} you want to find:");
            int choiceIDValue;
            var isParsed = int.TryParse(choiceID, out choiceIDValue);
            if (!isParsed)
            {
                WritelineColor("Please enter the integer number for ID.", ConsoleColor.Red);
            }
            else
            {
                var entity = entityRepository.GetById(choiceIDValue);
                if (entity != null)
                {
                    WritelineColor(entity.ToString()!, ConsoleColor.Green);
                }
                return entity;
            }
        }
    }

    private void RemoveBreadCustomer<T>(IRepository<T> breadCustRepository) where T : class, IEntity
    {
        var breadCustFound = FindEntityById(breadCustRepository);
        if (breadCustFound != null)
        {
            while (true)
            {
                WritelineColor($"Do you really want to remove this {typeof(T).Name}?", ConsoleColor.Red);
                var choice = GetInputFromUser("Press Y if YES\t\tPress N if NO").ToUpper();
                if (choice == "Y")
                {
                    breadCustRepository.Remove(breadCustFound);
                    break;
                }
                else if (choice == "N")
                {
                    break;
                }
                else
                {
                    WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
                }
            }
        }
    }

    private bool CloseAppSaveChanges()
    {
        while (true)
        {
            var choice = GetInputFromUser("Do you want to save changes?\nPress Y if YES\t\tPress N if NO").ToUpper();
            if (choice == "Y")
            {
                _breadRepository.Save();
                _customerRepository.Save();
                WritelineColor("Changes successfully saved.", ConsoleColor.Green);
                return true;
            }
            else if (choice == "N")
            {
                return true;
            }
            else
            {
                WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
            }
        }
    }
}
