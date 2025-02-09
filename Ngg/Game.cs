using Microsoft.VisualBasic;

namespace Ngg;

public static class Game
{
    private static int _chances { get; set; }
    private static int _target { get; set; }
    private static bool _restart { get; set; } = true;

    public static void Start()
    {
        WelcomeMessage();

        while (_restart)
        {
            DifficultySelection();
            Gameplay();
            Replay();
        }
    }
    
    public static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!" +
                          "\nI'm thinking of a number between 1 and 100.");
    }

    public static void DifficultySelection()
    {
        Console.WriteLine($"Please select the difficulty level:" +
                          $"\n1. {Difficulty.Easy.ToString()} ({Difficulty.Easy} chances)" +
                          $"\n2. {Difficulty.Medium.ToString()} ({Difficulty.Medium} chances)" +
                          $"\n3. {Difficulty.Hard.ToString()} ({Difficulty.Hard} chances)" +
                          $"\n");
        
        var input = ReadInput(
            message: "Enter you choice: ",
            min: NumericConstant.One,
            max: NumericConstant.Three);

        _chances = MenuParser(input);
        Console.WriteLine($"Great! You have selected the {_chances.ToEnum<Difficulty>().ToString()} difficulty level.");
    }

    public static void Gameplay()
    {
        Console.WriteLine("Let's start the game!" +
                          "\n");

        _target = GenerateNumber();
        var tries = NumericConstant.One;
        
        while (tries <= _chances)
        {
            var input = ReadInput(
                message: "Enter your guess: ",
                min: NumericConstant.One,
                max: NumericConstant.Hundred);

            if (input == _target)
            {
                Console.WriteLine($"Congratulations! You guessed the correct number in {tries} attempts.");
                return;
            }

            Console.WriteLine(input > _target
                ? $"Incorrect! The number is less than {input}."
                : $"Incorrect! The number is greater than {input}.");

            tries++;
        }
        
        Console.WriteLine($"You lose! The target number was {_target}.");
        _chances = 0;
        _target = 0;
    }

    private static int MenuParser(int input)
    {
        return input switch
        {
            1 => Difficulty.Easy.ToInt32(),
            2 => Difficulty.Medium.ToInt32(),
            3 => Difficulty.Hard.ToInt32(),
            _ => throw new ArgumentOutOfRangeException(input.ToString())
        };
    }
    
    private static int ReadInput(string message, int min, int max)
    {
        while (true)
        {
            Console.Write(message);
            var input = Console.ReadLine();

            if (int.TryParse(input, out var value)
                && (value >= min && value <= max))
            {
                return value;
            }

            Console.WriteLine($"Invalid input. Try again! " +
                              $"\nChoose a number between {min} and {max}.");
        }
    }

    private static int GenerateNumber()
    {
        var generator = new Random();
        return generator.Next(1, 100);
    }

    private static void Replay()
    {
        Console.WriteLine("Do you want to play again? Y/N\n");

        var key = Console.ReadKey();
        if (key.Key != ConsoleKey.Y)
        {
            _restart = false;
        }
    }
}