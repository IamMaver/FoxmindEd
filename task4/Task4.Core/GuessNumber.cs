using Task4.Core;
namespace Task4.Core
{
    public enum Answers { Less, More, Equal }

    public class GuessNumber
    {
        private readonly GuessNumberSetts _gns;
        private readonly Random _rnd = new();
        private int _number;

        public int Number { get { return _number; } } // it is for unit tests

        public GuessNumber(GuessNumberSetts gns)
        {
            _gns = gns;
            _number = _rnd.Next(_gns.MinValue, _gns.MaxValue + 1);
        }

        public void GameGuessNumber()
        {
            bool want2play, foundN;
            int inputNumber;
            do
            {
                Console.WriteLine("Game \"Guess Number\"\nI guessed a number greater than {0} less than {1}. Guess the number.", _gns.MinValue, _gns.MaxValue);
                do
                {
                    foundN = false;
                    do
                    {
                        Console.WriteLine("Please input your number");
                    } while (!Int32.TryParse(Console.ReadLine(), out inputNumber));
                    switch (this.CheckNumber(inputNumber))
                    {
                        case Answers.Less:
                            Console.WriteLine("My number is bigger.Try again.");
                            break;
                        case Answers.More:
                            Console.WriteLine("My number is smaller. Try again.");
                            break;
                        case Answers.Equal:
                            Console.WriteLine("You are amazing! You guessed my number!");
                            foundN = true;
                            break;
                    }
                } while (!foundN);
                Console.WriteLine("Do you want to play again? Press 'y' for 'yes' or any other key to exit");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    want2play = true;
                    _number = _rnd.Next(_gns.MinValue, _gns.MaxValue + 1);
                }
                else
                {
                    want2play = false;
                }
            } while (want2play);
        }

        public Answers CheckNumber(int n)
        {
            if (n < _number)
            {
                return Answers.Less;
            }
            if (n > _number)
            {
                return Answers.More;
            }
            return Answers.Equal;
        }
    }
}