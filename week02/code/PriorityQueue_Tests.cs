using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and verify they are removed in the correct priority order.
    // Expected Result: The item with the highest priority is removed first.
    // Test Result: Passed. The item with the highest priority was removed correctly.
    // Defect(s) Found: None.
    public void TestPriorityQueue_DequeueHighPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 5);
        priorityQueue.Enqueue("MediumPriority", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriority", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority and verify the first inserted is dequeued first (FIFO).
    // Expected Result: The first item with the highest priority is removed.
    // Test Result: Passed. The item with the highest priority was removed correctly.
    // Defect(s) Found: None.
    public void TestPriorityQueue_DequeueSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Test Result: Passed. An error was thrown for the empty queue.
    // Defect(s) Found: None.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_DequeueFromEmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}