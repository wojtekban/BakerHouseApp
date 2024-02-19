namespace BakerHouseApp.ApplicationServices.Services;

public abstract class UserCommunicationBase
{
    protected void WritelineColor(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = default)
    {
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    protected string GetInputFromUser(string comment)
    {
        WritelineColor(comment, ConsoleColor.DarkYellow);
        string userInput = Console.ReadLine();
        return userInput;
    }

    protected void EmptyInputWarning(ref string? input, string inputName)
    {
        while (string.IsNullOrEmpty(input))
        {
            WritelineColor($"This input can not be empty.", ConsoleColor.Red);
            input = GetInputFromUser($"{inputName}:");
        }
    }

    protected T GetValueFromUser<T>(string comment) where T : struct
    {
        while (true)
        {
            var input = GetInputFromUser(comment);
            try
            {
                if (typeof(T) == typeof(int))
                {
                    return (T)(object)int.Parse(input);
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.Parse(input);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    return (T)(object)decimal.Parse(input);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Inavlid value, please try again.");
            }
        }
    }

    protected DateTime GetDateFromUser()
    {
        DateTime Date = default;
        bool canParse = false;
        while (!canParse)
        {
            Console.WriteLine("Input  date");

            int year = intParser("Input year (must be number)");
            int month = intParser("Input month (must be number)");
            int day = intParser("Input day (must be number)");

            try
            {
                Date = new DateTime(year, month, day);
                canParse = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("This date is not valid. Please try again.");
            }
        }
        return Date;
    }

    public int intParser(string message)
    {
        int i = 0;
        bool canParse = false;
        while (!canParse)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            canParse = int.TryParse(input, out i);
        }
        return i;
    }

}
