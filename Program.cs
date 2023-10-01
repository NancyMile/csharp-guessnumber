
using System;
// See https://aka.ms/new-console-template for more information

StartGame();

void StartGame()
{
   Console.WriteLine("Guess the number!");
   Console.WriteLine("What is your name?");
   var playerName = Console.ReadLine();

   Random random = new Random();
   int guessNumber = random.Next(1,10);

   WantToPlay(playerName, guessNumber);
}

void WantToPlay(string? playerName, int guessNumber)
{
     Console.WriteLine($"Hi {playerName} are you ready? (Enter Yes/No)");
    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower().Trim())
    {
        case "yes":
            Play(guessNumber);
            break;
        case "no":
            DontPlay();
            break;
        default:
            Console.WriteLine("Not a valid option, Please enter yes or not");
            WantToPlay(playerName,guessNumber);
            break;
    }
}

void Play(int guessNumber)
{
    try
    {
        Console.WriteLine("Please enter a number between 1 and 10");
        var playerNumber = Console.ReadLine();

        if(playerNumber is null)
            throw new Exception("Please enter a number");
        if(int.Parse(playerNumber) < 1 || int.Parse(playerNumber) > 10)
            throw new Exception("Enter a number between 1 and 10");

        if(int.Parse(playerNumber) == guessNumber)
            Console.WriteLine($"You Won the number is {guessNumber}");
        else if(int.Parse(playerNumber) < guessNumber)
        {
            Console.WriteLine("The number is higher");
            Play(guessNumber);
        }
        else
        {
            Console.WriteLine("The number is lower");
            Play(guessNumber);
        }
    }
    catch (Exception e)
    {
         Console.WriteLine($"Error: {e.Message}");
         Play(guessNumber);
    }
}

void DontPlay()
{
    Console.WriteLine("Stop Playing ..");
}