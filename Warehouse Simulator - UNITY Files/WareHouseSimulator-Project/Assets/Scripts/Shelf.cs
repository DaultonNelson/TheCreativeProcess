using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The code for this type of Shelf.
    /// </summary>
    public string areaCode;
    /// <summary>
    /// The letter representing what lane this Shelf is in.
    /// </summary>
    public string laneLetter;
    /// <summary>
    /// The number Shelf this is relative to the lane it's in.
    /// </summary>
    public int shelfNumber;
    /// <summary>
    /// The amount of subshelves this Shelf has.
    /// </summary>
    public int subshelfAmount;

    /// <summary>
    /// The identification string of this shelf.
    /// </summary>
    public string ShelfID { get { return $"{areaCode.ToUpper()}:{laneLetter.ToUpper()}{shelfNumber}"; } }
    /// <summary>
    /// Return true if the order picker is at this Shelf, or false if not.
    /// </summary>
    public bool PickerAtShelf { get; set; }

    /// <summary>
    /// The User Interface in the scene.
    /// </summary>
    private UserInterface ui;
    #endregion

    private void Start()
    {
        name = $"{name.Substring(0, 11)}_{ShelfID}";

        ui = FindObjectOfType<UserInterface>();
    }

    /// <summary>
    /// Picks an item from the given subshelf.
    /// </summary>
    /// <param name="subshelfIndex">
    /// The index of the subshelf to take from.
    /// </param>
    public void PickItem(int subshelfIndex)
    {
        if (subshelfIndex > subshelfAmount || subshelfAmount < 1)
        {
            Debug.Log("Invalid value given to PickItem.", gameObject);
            return;
        }

        Debug.Log($"An Item is being picked by the player at {ShelfID} - Subshelf: {subshelfIndex}", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.DisplayShelfID(ShelfID);
            ui.DisplaySubshelfKeys(subshelfAmount);

            PickerAtShelf = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.DisplayShelfID(string.Empty);
            ui.HideSubshelfKeys();

            PickerAtShelf = false;
        }
    }
}