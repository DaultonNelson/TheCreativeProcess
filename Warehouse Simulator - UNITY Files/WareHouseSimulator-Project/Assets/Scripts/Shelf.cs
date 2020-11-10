using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The code for this type of pallet.
    /// </summary>
    public string areaCode;
    /// <summary>
    /// The letter representing what lane this shelf is in.
    /// </summary>
    public string laneLetter;
    /// <summary>
    /// The number shelf this is relative to the lane it's in.
    /// </summary>
    public int shelfNumber;

    /// <summary>
    /// The identification string of this shelf.
    /// </summary>
    public string ShelfID { get { return $"{areaCode.ToUpper()}:{laneLetter.ToUpper()}{shelfNumber}"; } }

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

    //TODO: Don't want this as Stay, but collider is so big, it exit's while in the middle of another shelf
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.DisplayShelfID(ShelfID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.DisplayShelfID(string.Empty);
        }
    }
}