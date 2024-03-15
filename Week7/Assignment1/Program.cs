// See https://aka.ms/new-console-template for more information

var input = new [] { 6, 1, 4, 5, 2, 8 };
var output = ThresholdSum(input, 4);  // 6 + 5 + 8

 int ThresholdSum( int[] inputArray, int threshold)
 { int sum = 0; 
    for (var i = 0; i < inputArray.Length; i++)
    {
        if (inputArray[i] > threshold)
        {
            sum += inputArray[i];
        }
    }

    return sum; 
 }

Console.WriteLine(output); // 19