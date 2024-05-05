using Task3.Core;

string path;
if (args.Length == 0)
{
    path = GetFilePathAndCheckAvailability();
}
else
{
    path = args[0];
}
MaxSumOfElements maxsumClass = new(path);
if (maxsumClass.IsMaxSumFound())
{
    Console.WriteLine("String with maximal sum of elements is " + (maxsumClass.GetNumberMaxSumLine()));
}
else
{
    Console.WriteLine("There is no maximal sum of elements"); 
}
int[] wrongLines = maxsumClass.GetNumbersWrongFormatLines();
Console.Write("String with wrong elements: " + string.Join(", ", wrongLines));

static string GetFilePathAndCheckAvailability()
{
    string filePath;
    while (true)
    {
        Console.WriteLine("Please enter path to file (enter ..\\..\\..\\..\\test.txt for example)");
        filePath = Console.ReadLine();
        FileInfo fileInfo = new(filePath);
        if (fileInfo.Exists)
        {
            return filePath;
        }
        else
        {
            Console.WriteLine("File not found\n");
        }
    }
}