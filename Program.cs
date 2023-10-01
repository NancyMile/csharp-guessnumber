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
    Console.WriteLine("Play");
}

void DontPlay()
{
    Console.WriteLine("Stop Playing ..");
}