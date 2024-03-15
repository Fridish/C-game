var number = FindDuplicateNumber(new[] { 2, 14, 95, 8, 20, 14, 7, 3 });

int FindDuplicateNumber(int[] numberArray)
{
    int duplicate = 0; 

    int[] input = numberArray; 
    for (var i = 0; i < numberArray.Length; i++)
    {
        int count = 0;
        for (var a = 0; a < input.Length; a++)
        {
            if (numberArray[i] == input[a])
            {
                count++;

            }
            if (count == 2)
            {
                duplicate = numberArray[i];
                return duplicate;
            }
        }
    }

    return duplicate; 
}
Console.WriteLine(number);  // 14