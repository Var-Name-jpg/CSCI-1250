using System;

class Program {
    static void Main() {
        // Array of integers (data type 1: int)
        int[] numbers = { 10, 20, 30, 40, 50 };
	Console.WriteLine($"Here is the list of numbers: {string.Join(',', numbers)}");
        
        // Calculate sum using double for precision (data type 2: double)
        double total = CalculateSum(numbers);
        
        // Format as string (data type 3: string)
        string message = FormatResult(total);
        Console.WriteLine(message);
    }
    
    // Method 1: Sums array using foreach loop
    static double CalculateSum(int[] arr) {
        double sum = 0.0;
        foreach (int num in arr) {
            sum += num;
        }
        return sum;
    }
    
    // Method 2: Formats the result
    static string FormatResult(double value) {
        return $"The total sum is: {value}";
    }
}
