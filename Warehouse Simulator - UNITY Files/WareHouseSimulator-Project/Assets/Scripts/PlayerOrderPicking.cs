using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrderPicking : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The items the player has picked on their cart.
    /// </summary>
    public List<OrderItem> pickedItems = new List<OrderItem>();

    /// <summary>
    /// The current shelf the player is visiting.
    /// </summary>
    public Shelf CurrentShelf { get; set; } = null;
    #endregion

    void Update()
    {
        if (CurrentShelf != null)
        {
            CheckForPick();
        }
    }
    
    /// <summary>
    /// Checks for if the player makes a pick for an item.
    /// </summary>
    private void CheckForPick()
    {
        if (Input.anyKeyDown)
        {
            //The number the player pressed if they do press a number.
            int number;
            //Try and parse the input the player made at this frame.
            bool isANumber = int.TryParse(Input.inputString, out number);

            //If what was inputted was a number, and is was one of the following: 0123456789
            if (isANumber && number >= 0 && number < 10)
            {
                //Try and Pick an item on the shelf.
                OrderItem pickedItem = CurrentShelf.PickItem(number);

                if (pickedItem != null)
                {
                    pickedItems.Add(pickedItem);
                }
            }
        }
    }
}