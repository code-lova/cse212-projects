using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single object and then Dequeue it.
    // Expected Result: The same object is dequeued.
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Object1", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Object1", result);
        //Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple object with different priorities and Dequeue one by one.
    // Expected Result: objects are dequeued in priority order.
    // Defect(s) Found: incorrectly prioritizes items during dequeue, 
    // so it fails to identify and remove the item with the highest priority.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Object1", 1);
        priorityQueue.Enqueue("Object2", 3);
        priorityQueue.Enqueue("Object3", 2);

        Assert.AreEqual("Object2", priorityQueue.Dequeue());
        Assert.AreEqual("Object3", priorityQueue.Dequeue());
        Assert.AreEqual("Object1", priorityQueue.Dequeue());
        //Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Enqueue an object with the same priority and Dequeue one by one.
    // Expected Result: Objects with the same priority are dequeued in FIFO order.
    // Defect(s) Found: incorrectly prioritizes items during dequeue, 
    // so it fails to identify and remove the item with the highest priority.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Object1", 2);
        priorityQueue.Enqueue("Object2", 2);
        priorityQueue.Enqueue("Object3", 2);

        Assert.AreEqual("Object1", priorityQueue.Dequeue());
        Assert.AreEqual("Object2", priorityQueue.Dequeue());
        Assert.AreEqual("Object3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown.
    // Defect(s) Found: No defects found
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

}