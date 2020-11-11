using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfPicking : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The Shelf attached to the same object as this.
    /// </summary>
    private Shelf shelf;
    #endregion

    void Start()
    {
        shelf = GetComponent<Shelf>();
    }

    void Update()
    {
        if (shelf.PickerAtShelf)
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
            int number;
            //Try and parse the input I just made at this frame.
            bool isANumber = int.TryParse(Input.inputString, out number);

            if (isANumber && number >= 0 && number < 10)
            {
                shelf.PickItem(number);
            } 
        }
    }
}