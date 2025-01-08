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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //STEPS
        //1. Input: A double (starting number) and an int (number of multiples) E.G (7, 5).
        //2. Create an array of size length to store the multiples.
        //3. Use a for loop that runs length times.
        //4. For each iteration:
            //4.1 Compute the multiple by multiplying the starting number by the current iteration index (starting from 1).
            //4.2 Store the result in the array at the corresponding index.
        //5. Then return the filled array

        double[] multiples = new double[length]; // Step 1: Initialize the array to store the multiples

        for (int i = 0; i < length; i++) // Step 2: Populate the array with multiples of the number
        {   
            multiples[i] = number * (i + 1); // Compute the multiple and store it in the array
        }
       
        return multiples;  // Step 3: Return the array of multiples
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //STEP BY STEP OF THE CODE
        // 1. Handle edge cases (empty list, single element, or where amount = 0).
        // 2. Calculate the effective rotation amount using modulo operator to handle cases where amount > list size.
        // 3. Split the list into two parts:
        //    - The last 'amount' elements.
        //    - The remaining elements.
        // 4. Rearrange the list:
        //    - Move the last 'amount' elements to the front.
        //    - Append the remaining elements.
        // 5. Now modify the existing list by clearing it and adding the reordered elements.
        //Simple...

        
        if (data == null || data.Count <= 1 || amount == 0) return;  // Step 1: Handle edge cases

        // Step 2: Calculate the effective rotation amount
        int count = data.Count;
        amount = amount % count; // Handles cases where amount > count

        // Step 3: Lets Split the list into two parts
        var rotatedPart = data.GetRange(count - amount, amount); // Last 'amount' elements
        var remainingPart = data.GetRange(0, count - amount);    // Remaining elements

        // Step 4: Modify the original list
        data.Clear();
        data.AddRange(rotatedPart);    // Add the rotated part
        data.AddRange(remainingPart);  // Add the remaining part
    }
}
