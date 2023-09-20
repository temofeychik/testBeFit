
Console.WriteLine("Enter the numbers array separated by comma");
string? inputNumbers = Console.ReadLine();
Console.WriteLine(SumRowNumbers(inputNumbers));
Console.WriteLine("Enter the numbers array separated by comma");
inputNumbers = Console.ReadLine();
Console.WriteLine("Enter the number");
string? checkNumber = Console.ReadLine();
Console.WriteLine(CheckSum(inputNumbers, checkNumber));

//2
string SumRowNumbers(string? input)
{
    try
    {
        if (input == null)
            return "Please enter the numbers";
        string[] arrayOfStrings = input.Split(new char[] { ',' });
        IEnumerable<double> arrayOfDoubles = arrayOfStrings.Select(s => double.Parse(s));
        IEnumerable<double> arrayOfSums = arrayOfDoubles.Aggregate((IEnumerable<double>)new List<double>(),
                       (a, i) => a.Concat(new[] { a.LastOrDefault() + i }));
        return $"Sum of row numbers: {string.Join(",", arrayOfSums)}";
    }
    catch(Exception ex) {
        return $"Parsing error: {ex.Message}";
    }
}

//4
string CheckSum(string? stringNumbers, string? stringNumber)
{
    try
    {
        if (stringNumbers == null || stringNumber == null)
            return "Please enter the numbers";
        string[] arrayOfStrings = stringNumbers.Split(new char[] { ',' });
        List<int> intNumbers = arrayOfStrings.Select(s => int.Parse(s)).ToList();

        int n = int.Parse(stringNumber);

        List<int> sumsOfFirstPartNumbers = new List<int>();
        List<int> sumsOfSecondPartNumbers = new List<int>();
        List<int> firstPartNumbers = intNumbers.GetRange(0, intNumbers.Count / 2);
        List<int> secondPartNumbers = intNumbers.GetRange(intNumbers.Count / 2, intNumbers.Count - intNumbers.Count / 2);

        foreach (var sumsNumbersPair in new List<SumClass> { new SumClass { FirstList = sumsOfFirstPartNumbers, SecondList = firstPartNumbers }, new SumClass { FirstList = sumsOfSecondPartNumbers, SecondList = secondPartNumbers } })
        {
            var sums = sumsNumbersPair.FirstList;
            var numbers = sumsNumbersPair.SecondList;

            foreach (var number in numbers)
            {
                foreach (var sum_ in new List<int>(sums))
                {
                    sums.Add(sum_ + number);
                }

                sums.Add(number);
            }
        }

        foreach (var sum_ in sumsOfFirstPartNumbers)
        {
            if (sumsOfSecondPartNumbers.Contains(n - sum_))
            {
                return $"Number - {stringNumber} can be the sum of numbers: {stringNumbers}";
            }
        }

        return $"Number - {stringNumber} can not be the sum of numbers: {stringNumbers}";
    }
    catch (Exception ex)
    {
        return $"Parse exception: {ex.Message}";
    }
}

public class SumClass
{
    public List<int> FirstList { get; set; } = new ();
    public List<int> SecondList { get; set; } = new ();
}