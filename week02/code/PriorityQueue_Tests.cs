using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with priorities: A(1), B(3), C(1). Dequeue three times.
    // Expected Result: B, A, C (highest priority removed first; ties follow FIFO)
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // highest priority
        Assert.AreEqual("A", priorityQueue.Dequeue()); // A and C tied; A was enqueued first
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue should throw; also verify FIFO among equal priorities
    // Expected Result: InvalidOperationException when empty; when priorities tie, earlier enqueued removed first
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        // Empty queue should throw
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException for empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }

        // Verify FIFO among equal priorities
        priorityQueue.Enqueue("X", 2);
        priorityQueue.Enqueue("Y", 5);
        priorityQueue.Enqueue("Z", 5);

        Assert.AreEqual("Y", priorityQueue.Dequeue()); // Y and Z have highest priority; Y was enqueued first
        Assert.AreEqual("Z", priorityQueue.Dequeue());
        Assert.AreEqual("X", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}