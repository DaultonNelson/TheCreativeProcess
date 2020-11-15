using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOrderPicking : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The Order Cart Prefab to spawn after the player has turned in their cart.
    /// </summary>
    public GameObject orderCartPrefab;
    /// <summary>
    /// The place to attach new order carts.
    /// </summary>
    public Transform cartAttachment;
    /// <summary>
    /// The items the player has picked on their cart.
    /// </summary>
    public List<OrderItem> pickedItems = new List<OrderItem>();
    /// <summary>
    /// Fires off an event once this Order Picker has completed their pick list.
    /// </summary>
    public UnityEvent OnCompletePickList;

    /// <summary>
    /// The current shelf the player is visiting.
    /// </summary>
    public Shelf CurrentShelf { get; set; } = null;
    /// <summary>
    /// The cart this order picker currently has.
    /// </summary>
    public OrderCart currentCart { get; set; } = null;

    /// <summary>
    /// The pick list the player has.
    /// </summary>
    private Queue<OrderItem> pickList = new Queue<OrderItem>();
    /// <summary>
    /// The current Order Item this Order Picker must pick;
    /// </summary>
    private OrderItem currentItemToPick;
    /// <summary>
    /// The User Interface in the scene.
    /// </summary>
    private UserInterface ui;
    /// <summary>
    /// The Labor Logging logic in the scene.
    /// </summary>
    private LaborLogging labor;
    #endregion

    private void Start()
    {
        ui = FindObjectOfType<UserInterface>();
        labor = FindObjectOfType<LaborLogging>();

        AcquireNewOrderCart();
    }

    /// <summary>
    /// Acquire's a new Order Cart for the player.
    /// </summary>
    public void AcquireNewOrderCart()
    {
        GameObject newCartObject = Instantiate(orderCartPrefab, cartAttachment.position, Quaternion.identity);
        newCartObject.transform.parent = cartAttachment;
        newCartObject.transform.localEulerAngles = Vector3.zero;
        currentCart = newCartObject.GetComponent<OrderCart>();

        currentCart.cartOrders = currentCart.PopulateCartOrders();

        for (int i = 0; i < currentCart.cartOrders.Count; i++)
        {
            pickList.Enqueue(currentCart.cartOrders[i]);
        }

        QueueNextOrderItem();
    }

    /// <summary>
    /// Queues up the next Order.
    /// </summary>
    private void QueueNextOrderItem()
    {
        if (pickList.Count > 0)
        {
            OrderItem orderToPick = pickList.Dequeue();

            currentItemToPick = orderToPick;
            ui.DisplayCurrentItemToPick(orderToPick);
            ui.UpdateOrdersValues(pickList.Count, currentCart.amountOfItemsOnCart);
        }
        else
        {
            currentCart.Filled = true;

            ui.UpdateOrdersValues(-1, currentCart.amountOfItemsOnCart);

            if (OnCompletePickList != null)
            {
                OnCompletePickList.Invoke(); 
            }

            SendToShipping();
        }
    }

    /// <summary>
    /// Sends the Order Picker to Shipping.
    /// </summary>
    private void SendToShipping()
    {
        currentItemToPick = null;
        pickList.Clear();

        ui.DisplayCurrentItemToPick(ui.ShippingItem);

        //Debug.Log("Go to Shipping");
    }

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
                OrderItem pickedItem = CurrentShelf.PickItem(number, currentItemToPick);

                if (pickedItem != null)
                {
                    ui.ToggleInvalidPickGraphic(false);
                    labor.LogTimer();
                    pickedItems.Add(pickedItem);
                    QueueNextOrderItem();
                }
            }
        }
    }
}