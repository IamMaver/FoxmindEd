using System;
using System.Text;


public class Anagram
{
    public string ReverseWord(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return string.Empty;
        }

        char[] chars = word.ToCharArray();
        char temp;
        int j = word.Length - 1;

        for (int i = 0; i < chars.Length && i < j; i++)
        {
            if (!char.IsLetter(word[i]))
            {
                continue;
            }

            if (char.IsLetter(word[i]))
            {
                temp = chars[i];
                for (; j > i; j--)
                {
                    if (char.IsLetter(word[j]))
                    {
                        chars[i] = chars[j];
                        chars[j] = temp;
                        j--;
                        break;
                    }
                }
            }
        }

        return string.Concat(chars);
    }

    public string Reverse(string origText)
    {
        if (string.IsNullOrEmpty(origText))
        {
            return string.Empty;
        }

        var words = origText.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = ReverseWord(words[i]);
        }

        return string.Join(" ", words);
    }

    public string Reverse2nd(string origText)
    {
        StringBuilder result = new StringBuilder();
        int i = 0;
        while (i < origText.Length)
        {
            if (char.IsLetter(origText[i]))
            {
                int j = i;
                while (j < origText.Length && char.IsLetter(origText[j]))
                {
                    j++;
                }
                string word = origText.Substring(i, j - i);
                result.Append(ReverseWord(word));
                i = j;
            }
            else
            {
                result.Append(origText[i]);
                i++;
            }
        }

        return result.ToString();
    }
}
