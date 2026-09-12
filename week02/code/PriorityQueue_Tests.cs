using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Add three items with different priorities. Put the highest-priority
    // item at the back to verify the entire queue is searched.
    //
    // Expected Result:
    // Items should be dequeued in this order: High, Medium, Low.
    //
    // Defect(s) Found:
    // The original loop did not examine the last item in the queue.
    // The original Dequeue method also returned an item without removing it.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Add two items with the same highest priority followed by a lower-priority item.
    //
    // Expected Result:
    // The first high-priority item should be removed before the second one,
    // following FIFO order: First, Second, Low.
    //
    // Defect(s) Found:
    // The original code used >= when comparing priorities. This allowed a later
    // item with equal priority to replace the earlier item as the selected item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Add three items and verify that Enqueue places each new item at the back.
    //
    // Expected Result:
    // [A (Pri:1), B (Pri:2), C (Pri:3)]
    //
    // Defect(s) Found:
    // No defect found. Enqueue correctly adds new items to the back.
    public void TestPriorityQueue_Enqueue()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual(
            "[A (Pri:1), B (Pri:2), C (Pri:3)]",
            priorityQueue.ToString()
        );
    }

    [TestMethod]
    // Scenario:
    // Attempt to dequeue from an empty priority queue.
    //
    // Expected Result:
    // InvalidOperationException with the exact message "The queue is empty."
    //
    // Defect(s) Found:
    // No defect found. The original empty-queue exception behavior was correct.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}