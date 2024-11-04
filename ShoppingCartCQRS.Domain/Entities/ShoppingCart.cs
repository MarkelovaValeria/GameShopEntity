using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShoppingCart
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    public double? TotalPrice { get; set; } 

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    public ShoppingCart() { }

    
    public void UpdateTotalPrice()
    {
        TotalPrice = Items.Sum(item => item.Price);
    }

}
