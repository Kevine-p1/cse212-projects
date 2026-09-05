public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new double array with the size given by 'length'.
        // 2. Loop through every index in the array starting at index 0.
        // 3. Calculate each multiple by multiplying 'number' by the position
        //    of the multiple. Since array indexes start at 0, use index + 1.
        // 4. Store each calculated multiple in the corresponding array index.
        // 5. After all positions have been filled, return the completed array.

        double[] multiples = new double[length];

        for (int index = 0; index < length; index++)
        {
            multiples[index] = number * (index + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Find the index where the last 'amount' items begin by subtracting
        //    'amount' from the number of items in the list.
        // 2. Copy the last 'amount' items into a temporary list using GetRange.
        // 3. Remove those items from their original positions using RemoveRange.
        // 4. Insert the saved items at index 0 using InsertRange.
        // 5. The original list is now rotated to the right by the requested amount.

        int startIndex = data.Count - amount;

        List<int> itemsToMove = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, itemsToMove);
    }
}