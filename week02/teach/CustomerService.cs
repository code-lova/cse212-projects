/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Scenario: Add customers to the queue until it is full.
        // Expected Customers should be added successfully until _queue.Count == _maxSize.
        // Attempting to add beyond _maxSize should display: "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 1");
        var cs3 = new CustomerService(2);
        cs3.AddNewCustomer(); // Expected: Add first customer.
        cs3.AddNewCustomer(); // Expected: Add second customer.
        cs3.AddNewCustomer(); // Expected: Maximum Number of Customers in Queue.
        Console.WriteLine(cs3.ToString());
        Console.WriteLine("=================");


        // Defect(s) Found: AddNewCustomer: The condition is incorrect: if (_queue.Count > _maxSize).
        // Solution: Change to if (_queue.Count >= _maxSize)

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Serve customers from the queue.
        // Expected Result: The next customer should be removed and displayed.
        // If the queue is empty, display an error message: "No customers to serve."
        Console.WriteLine("Test 2");
        cs3.ServeCustomer(); // Expected: Serve first customer.
        cs3.ServeCustomer(); // Expected: Serve second customer.
        cs3.ServeCustomer(); // Expected: No customers to serve.
        Console.WriteLine(cs3.ToString());
        Console.WriteLine("=================");

        // Defect(s) Found: We try to remove customer fist before showing var customer = _queue[0];
        // Solution : Print customer first then remove them

        // Defect(s) Found: in ServeCustomer function 
        // Issue: The method does not handle empty queues properly.
        // Fix: Include an empty check

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        //Test 3
        //Scenario: Create a CustomerService object with valid and invalid sizes.
        // Expected: For size 5: _maxSize should be 5. For size 0 or negative: _maxSize should default to 10.

        // Test 3: Valid Queue Initialization
        Console.WriteLine("Test 3");
        var cs1 = new CustomerService(5);
        Console.WriteLine(cs1.ToString()); // Expected: size=0 max_size=5

        var cs2 = new CustomerService(0);
        Console.WriteLine(cs2.ToString()); // Expected: size=0 max_size=10
        Console.WriteLine("=================");


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers to serve.");
            return;
        }
        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}