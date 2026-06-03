using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 University Ave", "Provo", "Utah", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LTP100", 750.00m, 1));
        order1.AddProduct(new Product("Mouse", "MSE200", 25.00m, 2));
        order1.AddProduct(new Product("Keyboard", "KBD300", 45.00m, 1));

        Address address2 = new Address("45 Eduardo Mondlane Ave", "Beira", "Beira", "Mozambique");
        Customer customer2 = new Customer("Osvaldo João", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "BAG400", 60.00m, 1));
        order2.AddProduct(new Product("Notebook", "NTB500", 5.00m, 4));
        order2.AddProduct(new Product("Water Bottle", "WTB600", 15.00m, 2));

        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"Order {orderNumber}");
        Console.WriteLine("-------------------------");

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
        Console.WriteLine("=========================");
        Console.WriteLine();
    }
}