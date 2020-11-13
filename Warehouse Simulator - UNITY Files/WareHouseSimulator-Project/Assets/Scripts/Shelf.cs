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
    /// A list of this Shelf's subshelfs.
    /// </summary>
    public List<Subshelf> subshelves { get; set; } = new List<Subshelf>();

    /// <summary>
    /// The User Interface in the scene.
    /// </summary>
    private UserInterface ui;
    #endregion

    private void Awake()
    {
        name = $"{name.Substring(0, 11)}_{ShelfID}";

        ui = FindObjectOfType<UserInterface>();

        PopulateSubshelves();
    }

    /// <summary>
    /// Populates the subshelves of this Shelf with random values.
    /// </summary>
    private void PopulateSubshelves()
    {
        for (int i = 0; i < subshelfAmount; i++)
        {
            Subshelf subshelf = new Subshelf()
            {
                shelfItem = new OrderItem(
                    OrderItemProcessor.GetRandomNoun(),
                    $"{ShelfID}.{i + 1}",
                    ui.GetRandomItemSpriteSybol(),
                    Random.ColorHSV()),

                currentItemCount = Random.Range(1, 31)
            };

            subshelves.Add(subshelf);
        }
    }

    /// <summary>
    /// Picks an item from the given subshelf.
    /// </summary>
    /// <param name="subshelfIndex">
    /// The index of the subshelf to take from.
    /// </param>
    public OrderItem PickItem(int subshelfIndex, OrderItem expectedOrder)
    {
        OrderItem output = null;

        if (subshelfIndex > subshelfAmount || subshelfAmount < 1)
        {
            Debug.LogError($"Invalid value given to PickItem at {ShelfID}.", gameObject);
            return output;
        }
        
        if (expectedOrder != subshelves[subshelfIndex - 1].shelfItem)
        {
            Debug.LogError("Invalid Order Item pick was attempted.", gameObject);
            return output;
        }

        //Debug.Log($"An Item is being picked by the player at {ShelfID} - Subshelf: {subshelfIndex}", gameObject);
        output = subshelves[subshelfIndex - 1].TakeFromSubshelf();
        ui.DisplaySubshelfKeys(subshelves);

        return output;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerOrderPicking orderPicking = other.transform.root.GetComponent<PlayerOrderPicking>();
            if (orderPicking != null)
            {
                orderPicking.CurrentShelf = this;
            }

            ui.DisplayShelfID(ShelfID);
            ui.DisplaySubshelfKeys(subshelves);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerOrderPicking orderPicking = other.transform.root.GetComponent<PlayerOrderPicking>();
            if (orderPicking != null)
            {
                orderPicking.CurrentShelf = null;
            }

            ui.DisplayShelfID(string.Empty);
            ui.HideSubshelfKeys();
        }
    }
}