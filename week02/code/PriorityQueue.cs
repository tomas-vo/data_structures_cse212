public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        // DEFECT FIX: Correctly verifies if the queue is empty and throws the precise exception message.
        if (_queue.Count == 0) 
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        
        // DEFECT FIX: Changed condition to 'index < _queue.Count' so the loop evaluates the last item in the list.
        for (int index = 1; index < _queue.Count; index++)
        {
            // DEFECT FIX: Changed '>=' to '>' to maintain FIFO behavior. 
            // If two items have the same highest priority, the first one encountered stays selected.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Get the value of the highest priority item
        var value = _queue[highPriorityIndex].Value;
        
        // DEFECT FIX: Actually remove the item from the underlying list using RemoveAt
        _queue.RemoveAt(highPriorityIndex);
        
        // Return the extracted value
        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}