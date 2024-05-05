using System.Text.Json;
using Task4.Core;

GuessNumberSetts? gns;
if (File.Exists("guessn.json"))
{
    using (FileStream fs = new FileStream("guessn.json", FileMode.OpenOrCreate))
    {
        gns = JsonSerializer.Deserialize<GuessNumberSetts>(fs);
    }
}
else
{
    gns = new GuessNumberSetts(0, 100);
}
GuessNumber guessNumber = new GuessNumber(gns);
guessNumber.GameGuessNumber();