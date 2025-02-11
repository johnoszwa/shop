using System;
using System.Collections.Generic;
using System.Linq;

class ShopCart
{
    private List<Product> items;

    public ShopCart()
    {
        items = new List<Product>();
    }

    public void AddItem(Product product)
    {
        items.Add(product);
        Console.WriteLine($"{product.Name} was added to cart.");
        Console.WriteLine();

    }

    public void RemoveItem(string productName)
    {
        Product product = items.FirstOrDefault(p => p.Name.Equals(productName,StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            items.Remove(product);
            Console.WriteLine($"{product.Name} was removed from cart.");
        }
        else
        {
            Console.WriteLine("Item not found in cart.");
        }
    }

    public void ViewItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Cart empty");
        }
        else
        {
            Console.WriteLine("Here are the items in your cart: ");
            foreach (Product product in items)
            {
                Console.WriteLine($"- {product.Name} - ${product.Price:F2}");
            }
        }
    }

    public int ItemCount()
    {
        return items.Count;
    }


}