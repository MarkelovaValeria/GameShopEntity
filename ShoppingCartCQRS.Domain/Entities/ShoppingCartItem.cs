using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ShoppingCartItem
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public string GameTitle { get; set; } = default!;
    public double Price { get; set; } = default!;

    public int ShoppingCartId { get; set; } 
    public ShoppingCart ShoppingCart { get; set; }

}
