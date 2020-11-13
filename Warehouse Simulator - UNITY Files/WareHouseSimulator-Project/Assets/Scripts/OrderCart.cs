using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class OrderCart : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The amount of Order Items that will be put on a cart.
    /// </summary>
    //We need an amount of items to put on our cart
    public int amountOfItemsPerCart;
    /// <summary>
    /// The orders associated with the cart the player has.
    /// </summary>
    public List<OrderItem> cartOrders = new List<OrderItem>();
    #endregion
    
    private void Start()
    {
        cartOrders = PopulateCartOrders();
    }
    
    /// <summary>
    /// Populates a List of Order Items for the Order Picker to pick.
    /// </summary>
    private List<OrderItem> PopulateCartOrders()
    {
        List<OrderItem> output = new List<OrderItem>();
        
        //Get the Order Items in the warehouse
        List<Shelf> shelves = FindObjectsOfType<Shelf>().ToList();
        
        //We need a random assortment of items from the warehouse.
        for (int i = 0; i < amountOfItemsPerCart; i++)
        {
            Shelf randomShelf = shelves[Random.Range(0, shelves.Count)];
            Subshelf randomSubshelf = randomShelf.subshelves[Random.Range(0, randomShelf.subshelfAmount)];

            output.Add(randomSubshelf.shelfItem);
        }

        //We need to sort the list based on warehouse layout
        output.Sort();

        //Finally, we return the list.
        return output;
    }
}