using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// The Text that displays the currently visited Shelf ID.
    /// </summary>
    public Text shelfIDText;
    /// <summary>
    /// The instructional key GameObject for turning carts into Shipping.
    /// </summary>
    public GameObject shippingTurnInKey;

    /// <summary>
    /// The Text Component that holds the Completed Cart value.
    /// </summary>
    [Header("Picker Stats Variables")]
    public Text completedCartText;
    /// <summary>
    /// The Text Component that holds the Time Spent on Pick value.
    /// </summary>
    public Text pickTimerText;
    /// <summary>
    /// The Text Component that holds the time it took to make the previous pick.
    /// </summary>
    public Text previousPickTimeText;

    /// <summary>
    /// A list of the subshelf key graphics in the Interface.
    /// </summary>
    [Header("Subshelf Key Variables")]
    public List<GameObject> subshelfKeys = new List<GameObject>();
    /// <summary>
    /// A list of the Texts next to the Subshelf Keys.
    /// </summary>
    public List<Text> subshelfKeyTexts = new List<Text>();
    
    [Header("Current Item Display Variables")]
    /// <summary>
    /// The Text Component that holds the Order Picker's Current Item's name.
    /// </summary>
    public Text currentItemName;
    /// <summary>
    /// The Text Component that holds the Order Picker's Current Item's location.
    /// </summary>
    public Text currentItemLocation;
    /// <summary>
    /// The Image Component that holds the Order Picker's Current Item's sprite.
    /// </summary>
    public Image currentItemSprite;
    /// <summary>
    /// The graphics that represents the order picker making an invalid pick.
    /// </summary>
    public GameObject invalidPickGraphic;
    /// <summary>
    /// The icon that represents Shipping.
    /// </summary>
    public Sprite shippingIcon;
    /// <summary>
    /// A list of Sprites for Order Items to use.
    /// </summary>
    public List<Sprite> itemSpriteSymbols = new List<Sprite>();
    
    [Header("Orders Values Display Variables")]
    /// <summary>
    /// The text component that displays the Open Orders Value for the player.
    /// </summary>
    public Text openOrdersValue;
    /// <summary>
    /// The text component that displays the Picked Orders Value for the player.
    /// </summary>
    public Text pickedOrdersValue;

    /// <summary>
    /// An Order Item that actually repesents a direction towards Shipping.
    /// </summary>
    public OrderItem ShippingItem { get { return new OrderItem(
        "Go to Shipping",
        "Shipping Area",
        shippingIcon,
        Color.yellow); } }
    #endregion

    private void Start()
    {
        shelfIDText.text = string.Empty;
        previousPickTimeText.text = 0.ToString("F2");
    }

    /// <summary>
    /// Displays the currently visited Shelf ID.
    /// </summary>
    /// <param name="shelfID">
    /// The shelf ID.
    /// </param>
    public void DisplayShelfID(string shelfID)
    {
        shelfIDText.text = shelfID;
    }

    /// <summary>
    /// Displays the amount of Subshelf keys given.
    /// </summary>
    /// <param name="subshelves">
    /// The subshelves belonging to the shelf.
    /// </param>
    public void DisplaySubshelfKeys(List<Subshelf> subshelves)
    {
        HideSubshelfKeys();

        if (subshelves.Count > subshelfKeys.Count || subshelves.Count < 1)
        {
            Debug.LogError("Insufficent amount was given to DisplaySubshelfKeys.", gameObject);
            Debug.Log($"Subshelf Key List Count: {subshelfKeys.Count}");
            Debug.Log($"Amount of Subshelves: {subshelves.Count}");
            return;
        }

        for (int i = 0; i < subshelves.Count; i++)
        {
            subshelfKeys[i].SetActive(true);
            subshelfKeyTexts[i].text = $"{subshelves[i].shelfItem.ItemName} (Amt: {subshelves[i].currentItemCount})";
        }
    }

    /// <summary>
    /// Displays the current item the Order Picker has to pick.
    /// </summary>
    /// <param name="item">
    /// The item that needs to be picked.
    /// </param>
    public void DisplayCurrentItemToPick(OrderItem item)
    {
        currentItemName.text = item.ItemName;
        currentItemLocation.text = item.ParentSubshelfID;
        currentItemSprite.sprite = item.ItemSymbolSprite;
        currentItemSprite.color = item.ItemSymbolColor;
    }

    /// <summary>
    /// Updates the Orders Values UI.
    /// </summary>
    /// <param name="ordersCount"></param>
    /// <param name="cartAmount"></param>
    public void UpdateOrdersValues(int ordersCount, int cartAmount)
    {
        openOrdersValue.text = (ordersCount + 1).ToString();
        pickedOrdersValue.text = ((cartAmount - ordersCount) - 1).ToString();
    }

    /// <summary>
    /// Updates the Completed Cart Text with a new value.
    /// </summary>
    /// <param name="newCount">
    /// The new value for the text.
    /// </param>
    public void UpdateCompletedCartCount(int newCount)
    {
        completedCartText.text = newCount.ToString();
    }

    /// <summary>
    /// Updates the timer text to the given value.
    /// </summary>
    /// <param name="newTime">
    /// The time to be displayed.
    /// </param>
    public void UpdateTimerText(string newTime)
    {
        pickTimerText.text = newTime;
    }

    /// <summary>
    /// Toggles the Invalid Pick Graphic.
    /// </summary>
    /// <param name="status">
    /// The new status of the graphic.
    /// </param>
    public void ToggleInvalidPickGraphic(bool status)
    {
        invalidPickGraphic.SetActive(status);
    }

    /// <summary>
    /// Hides the subshelf keys.
    /// </summary>
    public void HideSubshelfKeys()
    {
        foreach (GameObject key in subshelfKeys)
        {
            key.SetActive(false);
        }
    }

    /// <summary>
    /// Gets a random Sprite Symbol for an Order Item.
    /// </summary>
    /// <returns></returns>
    public Sprite GetRandomItemSpriteSybol()
    {
        Sprite output;

        output = itemSpriteSymbols[Random.Range(0, itemSpriteSymbols.Count)];

        return output;
    }
}