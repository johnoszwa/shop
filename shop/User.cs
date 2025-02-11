using System;

class User
{
    public string Username { get; private set; }
    private ShopCart Cart;

    public ShopCart GetCart()
    {
        return Cart;
    }
    public User(string username)
    {
        Username = username;
        Cart = new ShopCart();
    }
    public void Display()
    {
        Console.WriteLine($"User: {Username}");
        Cart.ViewItems();
    }
}
