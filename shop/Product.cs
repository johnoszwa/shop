using System;

class Product
{
    public string Name { get; private set; }
    public double Price { get; private set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
        
    }
    public void Display()
    {
        Console.WriteLine($"Product: {Name}");
        Console.WriteLine($"Price: {Price}");
    }
}
