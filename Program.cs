// See https://aka.ms/new-console-template for more information
string playerName;
Random random = new Random();
int attempts = 0;
int hightScore = 0;


StartGame();

void StartGame()
{
   Console.WriteLine("Guess the number!");
   Console.WriteLine("What is your name?");
   playerName = Console.ReadLine();

   int guessNumber = random.Next(1,10);

   WantToPlay(guessNumber);
}

void WantToPlay(int guessNumber, bool playAgain = false)
{
    if(!playAgain)
    {
        Console.WriteLine($"Hi {playerName} are you ready? (Enter Yes/No)");
    }else
    {
         Console.WriteLine("Are you ready? (Enter Yes/No)");
    }
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
            WantToPlay(guessNumber);
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

        if(int.Parse(playerNumber) == guessNumber){
            PlayAgain();
        }
        else if(int.Parse(playerNumber) < guessNumber)
        {
            Console.WriteLine("The number is higher");
            attempts++;
            Play(guessNumber);
        }
        else
        {
            Console.WriteLine("The number is lower");
            attempts++;
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

void PlayAgain()
{
    Console.WriteLine("You Won!!");
    attempts++;
    if(hightScore == 0 || attempts < hightScore)
    {
        hightScore = attempts;
    }

    Console.WriteLine($"Attempts: {attempts} Score: {hightScore}");
    attempts = 0;

    int guessNumber = random.Next(1,10);
    Console.WriteLine("Would you like to play again?");
    WantToPlay(guessNumber,true);
}