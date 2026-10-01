using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Lehi",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "Andrea Ramos",
            address1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(
            new Product("Notebook", "P001", 5.99, 2)
        );

        order1.AddProduct(
            new Product("Pen Set", "P002", 3.50, 3)
        );

        order1.AddProduct(
            new Product("Backpack", "P003", 24.99, 1)
        );


        Address address2 = new Address(
            "45 Reforma Avenue",
            "Mexico City",
            "CDMX",
            "Mexico"
        );

        Customer customer2 = new Customer(
            "Carlos Lopez",
            address2
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(
            new Product("Headphones", "P004", 29.99, 1)
        );

        order2.AddProduct(
            new Product("Mouse", "P005", 18.50, 2)
        );


        Console.WriteLine("ORDER 1");
        Console.WriteLine();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine(
            $"Total Cost: ${order1.CalculateTotalCost():0.00}"
        );

        Console.WriteLine();
        Console.WriteLine("----------------------------");
        Console.WriteLine();


        Console.WriteLine("ORDER 2");
        Console.WriteLine();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine(
            $"Total Cost: ${order2.CalculateTotalCost():0.00}"
        );
    }
}