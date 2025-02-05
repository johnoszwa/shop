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
            Dictionary<string, ShopCart> users = new Dictionary<string, ShopCart>();
            List<string> menuOptions = new List<string>
            {
                "1. View Item(s)",
                "2. Add Item(s)",
                "3. Remove Item(s)",
                "4. Item Count",
                "5. Switch User",
                "6. Go Back/Exit",

            };
            bool running = true;
            string currentUser = null;

            while (running)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Enter a Username:");
                    currentUser=Console.ReadLine();

                    if (!users.ContainsKey(currentUser))
                    {
                        users[currentUser] = new ShopCart();
                        Console.WriteLine($"New user '{currentUser}' created");
                    }
                    else 
                    {
                        Console.WriteLine($"Welcome back {currentUser}");
                    }
                }
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
                        users[currentUser].ViewItems();
                        break;
                    case "2":
                        Console.Write("Enter item to add: ");
                        var addItem = Console.ReadLine();
                        users[currentUser].AddItem(addItem);
                        break;
                    case "3":
                        Console.Write("Enter item to remove: ");
                        var removeItem = Console.ReadLine();
                        users[currentUser].RemoveItem(removeItem);
                        break;
                    case "4":
                        Console.WriteLine($"Total items in cart: {users[currentUser].ItemCount()}");
                        break;
                    case "5":
                        currentUser = null; 
                        Console.WriteLine("Switching user...");
                        break;
                    case "6":
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
        Console.WriteLine();

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
