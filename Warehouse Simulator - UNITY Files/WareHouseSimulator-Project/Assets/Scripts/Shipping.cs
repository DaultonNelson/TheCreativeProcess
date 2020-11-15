using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shipping : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The event that fires off whenever the Order Picker turns in their cart.
    /// </summary>
    public UnityEvent OnOrderCartTurnIn;

    /// <summary>
    /// The User Interface in the scene.
    /// </summary>
    private UserInterface ui;
    /// <summary>
    /// The Labor Logger in the scene.
    /// </summary>
    private LaborLogging labor;
    /// <summary>
    /// A player order picker.
    /// </summary>
    private PlayerOrderPicking orderPicker = null;

    /// <summary>
    /// The amount of carts turned in by the Order Picker.
    /// </summary>
    private int completedCarts = 0;
    #endregion

    private void Start()
    {
        ui = FindObjectOfType<UserInterface>();
        labor = FindObjectOfType<LaborLogging>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && orderPicker != null)
        {
            AttemptCartTurnIn();
        }
    }

    /// <summary>
    /// Attempts to have the order picker turn in their cart.
    /// </summary>
    public void AttemptCartTurnIn()
    {
        OrderCart cart = orderPicker.currentCart;

        if (orderPicker.currentCart.Filled)
        {
            completedCarts++;

            orderPicker.currentCart = null;
            
            ui.shippingTurnInKey.SetActive(false);
            ui.UpdateCompletedCartCount(completedCarts);
            labor.LogTimer();

            Destroy(cart.gameObject);

            orderPicker.AcquireNewOrderCart();

            OnOrderCartTurnIn.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            orderPicker = other.transform.root.GetComponent<PlayerOrderPicking>();
            if (orderPicker.currentCart != null && orderPicker.currentCart.Filled)
            {
                ui.shippingTurnInKey.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            orderPicker = null;
            ui.shippingTurnInKey.SetActive(false);
        }
    }
}