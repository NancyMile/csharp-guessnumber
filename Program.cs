
using System;
// See https://aka.ms/new-console-template for more information

StartGame();

void StartGame()
{
   Console.WriteLine("Guess the number!");
   Console.WriteLine("What is your name?");
   var playerName = Console.ReadLine();
   WantToPlay(playerName);
}

void WantToPlay(string? playerName)
{
     Console.WriteLine($"Hi {playerName} are you ready? (Enter Yes/No)");
    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower().Trim())
    {
        case "yes":
            Play();
            break;
        case "no":
            DontPlay();
            break;
        default:
            Console.WriteLine("Not a valid option, Please enter yes or not");
            WantToPlay(playerName);
            break;
    }
}

void Play()
{
    Random random = new Random();
    int guessNumber = random.Next(1,10);

    try
    {
        Console.WriteLine("Please enter a number between 1 and 10");
        var playerNumber = Console.ReadLine();

        if(playerNumber is null)
            throw new Exception("Please enter a number");
        if(int.Parse(playerNumber) < 1 || int.Parse(playerNumber) > 10)
            throw new Exception("Enter a number between 1 and 10");
    }
    catch (Exception e)
    {
         Console.WriteLine($"Error: {e.Message}");
         Play();
    }
}

void DontPlay()
{
    Console.WriteLine("Stop Playing ..");
}

void GuessNumber(int guessNumber)
{
    Console.WriteLine("Please enter a number between 1 and 10");
    var playerNumber = int.Parse(Console.ReadLine());

    if(playerNumber == guessNumber)
        Console.WriteLine($"You Won the number is {guessNumber}");
    else if(playerNumber < guessNumber)
        Console.WriteLine("The number is higher");
    else
        Console.WriteLine("The number is lower");
}