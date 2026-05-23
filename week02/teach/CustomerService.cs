/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(-3);
        Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: add a customer to the queue and then serve that customer
        // Expected Result: the queue should be empty after serving the customer
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        cs.ServeCustomer();
        Console.WriteLine(cs);
        Console.WriteLine("Test 1");

        // Defect(s) Found: The code crashed because we tried to display a customer that we already removed from the queue.  I need to get the customer information before removing it from the queue.


        Console.WriteLine("=================");

        // Test 2
        // Scenario: Try to remove a customer from an empty queue
        // Expected Result: A message indicating no customers in the queue should be displayed
        Console.WriteLine("Test 2");

        // Defect(s) Found: The code didn't handle the case where the queue is empty when trying to serve a customer

        cs.ServeCustomer();
        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
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

        // Defect 1 - should use >= instead of >
         if (_queue.Count >= _maxSize) {
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
        // Defect 2 - Need to check queue length before trying to serve a customer
       if (_queue.Count <= 0) 
        {
            Console.WriteLine("No Customers in the queue");
        }
        else {

            // Defect 3 - Need to check queue length before trying to serve a customer
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
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