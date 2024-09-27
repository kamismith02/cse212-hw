public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the multiples.
        // The size of the array will be 'length'.
        double[] multiples = new double[length];

        // Step 2: Use a for loop to calculate each multiple.
        // We'll loop 'length' times, starting from 1 up to 'length'.
        for (int i = 1; i <= length; i++)
        {
            // Step 3: Calculate the multiple and store it in the array.
            // multiples[i-1] will hold the value of number * i.
            multiples[i - 1] = number * i;
        }

        // Step 4: Return the array with all the multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Handle the case where the list is empty or the amount is zero.
        if (data == null || data.Count == 0 || amount == 0) return;

        // Step 2: Calculate the actual number of positions to rotate (in case amount > data.Count).
        // Use modulo to ensure the amount is within the list size.
        int n = data.Count;
        amount = amount % n;

        // Step 3: Split the list into two parts.
        // Part 1: The last 'amount' elements (which will move to the front).
        List<int> part1 = data.GetRange(n - amount, amount);

        // Part 2: The first 'n - amount' elements (which will move to the back).
        List<int> part2 = data.GetRange(0, n - amount);

        // Step 4: Clear the original list and reinsert the elements in the rotated order.
        data.Clear();
        data.AddRange(part1);  // Add the rotated part to the front.
        data.AddRange(part2);  // Add the remaining part to the back.
    }
}
