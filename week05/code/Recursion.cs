using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of
    /// 1^2 + 2^2 + 3^2 + ... + n^2.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
        {
            return 0;
        }

        // Recursive case
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Create permutations of the requested size.
    /// </summary>
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        // Base case:
        // We have built a permutation of the desired size.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each remaining letter.
        for (int i = 0; i < letters.Length; i++)
        {
            // Remove the letter that we are about to use.
            string lettersLeft = letters.Remove(i, 1);

            // Add the selected letter to the current word.
            PermutationsChoose(
                results,
                lettersLeft,
                size,
                word + letters[i]
            );
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the ways to climb stairs taking
    /// 1, 2, or 3 stairs at a time.
    /// </summary>
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        // Base cases
        if (s == 0)
            return 0;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        // Create the memoization dictionary on the first call.
        remember ??= new Dictionary<int, decimal>();

        // If we already solved this value, reuse the result.
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve the smaller problems recursively.
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Remember the answer for later recursive calls.
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Replace every wildcard with all possible
    /// combinations of 0 and 1.
    /// </summary>
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        // Find the first wildcard.
        int wildcardIndex = pattern.IndexOf('*');

        // Base case:
        // No wildcard remains, so this is a complete result.
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        string before = pattern[..wildcardIndex];
        string after = pattern[(wildcardIndex + 1)..];

        // Replace the wildcard with 0.
        WildcardBinary(
            before + "0" + after,
            results
        );

        // Replace the wildcard with 1.
        WildcardBinary(
            before + "1" + after,
            results
        );
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to find all paths from (0,0)
    /// to the end of the maze.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the path on the first call.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add the current position to our path.
        currPath.Add((x, y));

        // Base case:
        // We reached the end of the maze.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Backtrack before returning.
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Move left.
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(
                results,
                maze,
                x - 1,
                y,
                currPath
            );
        }

        // Move right.
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(
                results,
                maze,
                x + 1,
                y,
                currPath
            );
        }

        // Move up.
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(
                results,
                maze,
                x,
                y - 1,
                currPath
            );
        }

        // Move down.
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(
                results,
                maze,
                x,
                y + 1,
                currPath
            );
        }

        // Backtracking:
        // Remove this position so another recursive branch
        // can explore a different path.
        currPath.RemoveAt(currPath.Count - 1);
    }
}