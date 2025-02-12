using System.Diagnostics;
using Ngg.Hint;

namespace Ngg;

public static class Game
{
    private static int _chances { get; set; }
    private static int _target { get; set; }
    private static bool _restart { get; set; } = true;
    
    private static readonly Stopwatch _stopwatch = new();
    private static readonly HintStrategyFactory _hintStrategyFactory = new();

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

    private static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!" +
                          "\nI'm thinking of a number between 1 and 100.");
    }

    private static void DifficultySelection()
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

    private static void Gameplay()
    {
        _stopwatch.Start();
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
                _stopwatch.Stop();
                Console.WriteLine($"Congratulations! You guessed the correct number in {tries} attempts in {_stopwatch.Elapsed.Seconds} seconds.");
                return;
            }

            Console.WriteLine(input > _target
                ? $"Incorrect! The number is less than {input}."
                : $"Incorrect! The number is greater than {input}.");

            tries++;
            
            Hint(tries, _target, _chances.ToEnum<Difficulty>());
        }
        
        Console.WriteLine($"You lose! The target number was {_target}.");
        _stopwatch.Reset();
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

    private static void Hint(int tries, int target, Difficulty difficulty)
    {
        if (difficulty == Difficulty.Hard)
        {
            return;
        }

        var hintSettings = new Dictionary<Difficulty, Dictionary<int, HintType>>()
        {
            {
                Difficulty.Easy, new Dictionary<int, HintType>()
                {
                    { 3, HintType.Broad },
                    { 6, HintType.Specific },
                    { 9, HintType.VerySpecific }
                }
            },
            {
                Difficulty.Medium, new Dictionary<int, HintType>()
                {
                    { 3, HintType.Broad },
                    { 6, HintType.Specific }
                }
            }
        };

        if (hintSettings.TryGetValue(difficulty, out var triesToHint)
            && triesToHint.TryGetValue(tries, out var hintType))
        {
            _hintStrategyFactory
                .CreateHintStrategy(hintType)
                .Hint(target);
        }
    }
}