using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopCart cart = new ShopCart();
            List<string> menuOptions = new List<string>
            {
                "1. View Item(s)",
                "2. Add Item(s)",
                "3. Remove Item(s)",
                "4. Item Count",
                "5. Go Back/Exit",
            };
            bool running = true;


            while (running)
            {
                Console.WriteLine("Shopping Cart Menu:");
                foreach (var choice in menuOptions)
                {
                    Console.WriteLine(choice);
                }

                Console.Write("Pick an Option: ");


                string option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        cart.ViewItems();
                        break;
                    case "2":
                        Console.Write("Enter item to add: ");
                        var addItem = Console.ReadLine();
                        cart.AddItem(addItem);
                        break;
                    case "3":
                        Console.Write("Enter item to remove: ");
                        var removeItem = Console.ReadLine();
                        cart.RemoveItem(removeItem);
                        break;
                    case "4":
                        Console.WriteLine($"Total items in cart: {cart.ItemCount()}");
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Option Invalid. Try again.");
                        break;
                }
                Console.WriteLine();
            }



        }
    }
}

class ShopCart
{
    private List<string> items;

    public ShopCart()
    {
        items = new List<string>();
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"{item} was added to cart.");
    }

    public void RemoveItem(string item)
    {
        bool found = false;
        foreach (string cartItem in items)
        {
            if (cartItem == item)
            {
                found = true;
                break;
            }

        }

        if (found)
        {
            items.Remove(item);
            Console.WriteLine($"{item} was removed from cart.");

        }
        else
        {
            Console.WriteLine($"{item} was not found.");
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
            foreach (string item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    public int ItemCount()
    {
        return items.Count;
    }


}