var names = new []
{
    "Egon Spengler",
    "Peter Venkman",
    "Ray Stantz",
    "Winston Zeddemore",
};

var output = GetLongestString(names);

string GetLongestString(string[] nameArray)
{
    int wordLenght = 0;
    string longestName = "";
    for (var i = 0; i < nameArray.Length; i++)
    {
        int letterLength = 0;
        char[] letters = nameArray[i].ToCharArray();
        for (var a = 0; a < letters.Length; a++)
        { 
            letterLength += letters[a];
        }
        if (letterLength > wordLenght)
        {
            longestName = nameArray[i];

        }
    }

    return longestName;
}

Console.WriteLine(output);  // Winston Zeddemore