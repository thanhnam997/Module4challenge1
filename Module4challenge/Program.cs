using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        PlaySecretNumberGame();
    }

    static void PlaySecretNumberGame()
    {
        // Setting the console output encoding to support UTF8
        Console.OutputEncoding = Encoding.UTF8;

        const int MAX_NUMBER = 10; // Maximum number range
        const int MIN_NUMBER = 1;  // Minimum number range
        int score = 0; // Variable to store the number of attempts

        // Generating a random secret number between MIN_NUMBER and MAX_NUMBER
        var rand = new Random();
        int secretNumber = rand.Next(MIN_NUMBER, MAX_NUMBER + 1);

        // Asking the user for their guess
        Console.WriteLine("Guess the secret number ({0}-{1}):", MIN_NUMBER, MAX_NUMBER);

        while (true)
        {
            int yourNumber = Convert.ToInt32(Console.ReadLine());
            score++;

            if (yourNumber == secretNumber)
            {
                Console.WriteLine("Congratulations! You've guessed the secret number!");
                break;
            }
            else if (yourNumber > secretNumber)
            {
                Console.WriteLine("Your number is greater than the secret number. Try again!");
            }
            else
            {
                Console.WriteLine("Your number is less than the secret number. Try again!");
            }

            // Providing hints to the user
            GiveHints(secretNumber);
            Console.WriteLine("Guess again:");
        }

        // Displaying the final score
        Console.WriteLine($"You guessed the number in {score} attempts!");
    }

    // Method to provide hints to the user
    static void GiveHints(int number)
    {
        // Hint: Divisible by 5
        if (number % 5 == 0)
        {
            Console.WriteLine("Hint: The number is divisible by 5.");
        }

        // Hint: Digit in the tens place
        int tensDigit = (number / 10) % 10;
        if (tensDigit == 7)
        {
            Console.WriteLine("Hint: The digit in the tens place is 7.");
        }

        // Hint: Perfect square
        if (IsPerfectSquare(number))
        {
            Console.WriteLine("Hint: The number is a perfect square.");
        }
    }

    // Method to check if a number is a perfect square
    static bool IsPerfectSquare(int number)
    {
        int sqrt = (int)Math.Sqrt(number);
        return sqrt * sqrt == number;
    }
}
