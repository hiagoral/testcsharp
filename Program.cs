namespace TestesTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] dailyRevenues = { 1200.5, 1500.0, 0, 2000.8, 800.0, 0, 1800.2, 2500.0, 0, 1900.0, 2200.0, 0, 1600.5, 1700.0 };
            var revenue = new Revenue(dailyRevenues);
            var fibonacciChecker = new SequenceValidator(0, 1);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("2. Check Sum Result");
                Console.WriteLine("2. Check Fibonacci Sequence");
                Console.WriteLine("3. Revenue Statistics (Hardcoded Data)");
                Console.WriteLine("4. Process Revenue Data from File");
                Console.WriteLine("5. Reverse the sentence ");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                            var sum = new SumCalculator(13);
                        Console.WriteLine($"The sum result is: {sum.Sum()}");
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("\nEnter a number to check if it is in the Fibonacci sequence: ");
                        if (int.TryParse(Console.ReadLine(), out int number))
                        {
                            bool isInFibonacci = fibonacciChecker.InSequence(number);
                            Console.WriteLine(isInFibonacci
                                ? $"{number} is in the Fibonacci sequence."
                                : $"{number} is NOT in the Fibonacci sequence.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine($"\nLowest revenue: {revenue.CalculateLowestRevenue():C}");
                        Console.WriteLine($"Highest revenue: {revenue.CalculateHighestRevenue():C}");
                        Console.WriteLine($"Monthly average: {revenue.CalculateMonthlyAverage():C}");
                        Console.WriteLine($"Days with revenue above average: {revenue.DaysAboveAverage()}");
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Choose file format:");
                        Console.WriteLine("1. JSON");
                        Console.WriteLine("2. XML");
                        Console.Write("Enter your choice: ");
                        string formatChoice = Console.ReadLine()!;

                        string format = formatChoice == "1" ? "json" : formatChoice == "2" ? "xml" : string.Empty;

                        if (string.IsNullOrEmpty(format))
                        {
                            Console.WriteLine("Invalid choice. Returning to menu...");
                            break;
                        }

                        string projectRootPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
                        string filePath = Path.Combine(projectRootPath, "data", "dados." + format);

                        Console.WriteLine($"File path: {filePath}");

                        try
                        {
                            var fileProcessor = new RevenueProcessor(format, filePath);

                            Console.WriteLine("\nProcessed Revenue Data:");
                            Console.WriteLine($"Lowest revenue: {fileProcessor.CalculateLowestRevenue():C}");
                            Console.WriteLine($"Highest revenue: {fileProcessor.CalculateHighestRevenue():C}");
                            Console.WriteLine($"Monthly average: {fileProcessor.CalculateMonthlyAverage():C}");
                            Console.WriteLine($"Days with revenue above average: {fileProcessor.DaysAboveAverage()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Enter a sentence to reverse: ");
                        string inputSentence = Console.ReadLine()!;
                        string reversedSentence = ReverseString.Reverse(inputSentence);
                        Console.WriteLine($"Reversed sentence: {reversedSentence}");
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
