public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(
        int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();

        InsertMiddle(
            sortedNumbers,
            0,
            sortedNumbers.Length - 1,
            bst
        );

        return bst;
    }

    /// <summary>
    /// Insert the middle value, then recursively insert
    /// the middle of the left and right portions.
    /// </summary>
    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        // Problem 5

        // Base case:
        // there are no values left in this section.
        if (first > last)
            return;

        // Find the middle index.
        int middle = (first + last) / 2;

        // Insert the middle value first.
        bst.Insert(sortedNumbers[middle]);

        // Recursively handle the left half.
        InsertMiddle(
            sortedNumbers,
            first,
            middle - 1,
            bst
        );

        // Recursively handle the right half.
        InsertMiddle(
            sortedNumbers,
            middle + 1,
            last,
            bst
        );
    }
}