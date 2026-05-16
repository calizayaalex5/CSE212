using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 item to the queue with different priorities and then dequeue all items.
    // Expected Result: Dequeie return "high"
    // Defect(s) Found: The loop used Count-1, omitting the last element in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low",    1);
        priorityQueue.Enqueue("medium", 2);
        priorityQueue.Enqueue("high",   3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Add 2 items, Run dequeue 2 times
    // Expected Result: First dequeur return high", second return "medium"
    // Defect(s) Found: The item was not removed from the queue after the Dequeue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low",  1);
        priorityQueue.Enqueue("high", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("low",  priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add 3 items and the first two have the same priority.
    // Expected Result: The one that was added first is returned first (FIFO).
    // Defect(s) Found: The >= operator instead of > caused the return of
    //                  the last item with the highest priority instead of the first.

    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first",  3);
        priorityQueue.Enqueue("second", 3);
        priorityQueue.Enqueue("low",    1);

        Assert.AreEqual("first",  priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Run Dequeue on an empty queue
    // Expected Result: Display appropriate error message and do not crash.
    // Defect(s) Found: None - this functionality worked correctly from the start.

    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}