using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Subshelf
{
    /// <summary>
    /// The item that populates this subshelf.
    /// </summary>
    public OrderItem subshelfItem { get; set; }
    /// <summary>
    /// The amount of items currently on this shelf.
    /// </summary>
    public int currentItemCount { get; set; }

    public OrderItem TakeFromSubshelf()
    {
        OrderItem output = null;

        if (currentItemCount <= 0)
        {
            Debug.LogError("This Subshelf has no items in it.");
            return output;
        }

        output = subshelfItem;
        currentItemCount--;
        //Debug.Log($"There are {currentItemCount} {shelfItem.ItemName}'s left on this shelf.");

        return output;
    }
}