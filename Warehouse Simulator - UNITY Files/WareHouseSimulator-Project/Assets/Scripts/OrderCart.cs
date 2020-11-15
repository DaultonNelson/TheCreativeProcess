using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class OrderCart : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The amount of Order Items on this Order Cart.
    /// </summary>
    //We need an amount of items to put on our cart
    public int amountOfItemsOnCart;
    /// <summary>
    /// The orders associated with this Order Cart.
    /// </summary>
    public List<OrderItem> cartOrders = new List<OrderItem>();

    /// <summary>
    /// Return true if Order Cart has been filled with Cart Orders, or false if not.
    /// </summary>
    public bool Filled { get; set; } = false;
    #endregion

    //private void Start()
    //{
    //    cartOrders = PopulateCartOrders();
    //}
    
    /// <summary>
    /// Populates a List of Order Items for the Order Picker to pick.
    /// </summary>
    public List<OrderItem> PopulateCartOrders()
    {
        List<OrderItem> output = new List<OrderItem>();

        cartOrders.Clear();

        //Get the Order Items in the warehouse
        List<Shelf> shelves = FindObjectsOfType<Shelf>().ToList();
        
        //We need a random assortment of items from the warehouse.
        for (int i = 0; i < amountOfItemsOnCart; i++)
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