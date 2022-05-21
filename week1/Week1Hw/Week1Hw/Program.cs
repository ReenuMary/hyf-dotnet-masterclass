// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



string input = "world";
string reversed = ReverseString(input); //TODO: Implement ReverseString
Console.WriteLine($"Reversed input value: {reversed}");


input = "Intellectualization";
int vowelCount = GetVowelCount(input); //TODO: Implement GetVowelCount
Console.WriteLine($"Number of vowels: {vowelCount}");

int[] arr = new[] { 271, -3, 1, 14, -100, 13, 2, 1, -8, -59, -1852, 41, 5 };
int[] result = GetResult(arr); //TODO: Implement GetResult


Console.WriteLine($"Sum of negative numbers: {result[0]}. Multiplication of positive numbers: {result[1]}");


int n = 4;
int nthNumber = Fibonacci(n); //TODO: Implement Fibonacci
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181
if (nthNumber < 0)
{
    Console.WriteLine("Value of n should be greater than 0");

}
else
{
    Console.WriteLine($"{n}th fibonacci number is {nthNumber}");

}


int[] arrayToSplit = new[] { 1, 2, 5, 7, 2, 3, 5, 7 };

if (arrayToSplit.Length % 2 != 0)
{
    Console.WriteLine("Array length is not an even number");
}
else
{
    int[,] splitArray = Split(arrayToSplit);
    int[] sumOfSplitArrays = AddArray(splitArray);
    WriteResult(sumOfSplitArrays);
}

int[,] Split(int[] arrayToSplit)
{

    int[,] splitArray = new int[2, arrayToSplit.Length / 2];
    for (int i = 0; i < arrayToSplit.Length / 2; i++)
    {
        splitArray[0, i] = arrayToSplit[i];
    }
    int x = 0;
    for (int i = arrayToSplit.Length / 2; i < arrayToSplit.Length; i++)
    {
        splitArray[1, x] = arrayToSplit[i];
        ++x;
    }

    return splitArray;

}

void WriteResult(int[] sumOfSplitArrays)
{
    for (int i = 0; i < sumOfSplitArrays.Length; i++)
    {
        Console.WriteLine($"{sumOfSplitArrays[i]}");
    }
}

int[] AddArray(int[,] splitArray)
{
    int[] sumOfSplitArrays = new int[splitArray.Length / 2];

    for (int i = 0; i < splitArray.Length / 2; i++)
    {
        sumOfSplitArrays[i] = splitArray[0, i] + splitArray[1, i];
    }
    return sumOfSplitArrays;
}


//nth Fibonacci number

int Fibonacci(int n)
{
    if (n <= 0)
        return -1;
    else if (n == 1)
        return 0;
    else
    {
        int[] fibonacci = new int[n];
        fibonacci[0] = 0;
        fibonacci[1] = 1;

        int i = 2;
        while (i < n)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            ++i;
        }

        return fibonacci[n - 1];
    }
}


int[] GetResult(int[] arr)
{
    int[] result = { 0, 1 };

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < 0)
        {
            result[0] += arr[i];
        }
        else
        {
            result[1] *= arr[i];
        }
    }
    return result;
}

int GetVowelCount(string input)
{
    input = input.ToLower();
    string vowels = "aeiou";
    int count = 0;
    foreach (char c in input)
    {
        if (vowels.Contains(c))
        {
            ++count;
        }
    }
    return count;
}


static string ReverseString(string input)
{
    char[] inputArray = input.ToCharArray();
    Array.Reverse(inputArray);

    //string.Join("",inputArray)
    //new string(inputArray)

    return string.Concat(inputArray);
}



