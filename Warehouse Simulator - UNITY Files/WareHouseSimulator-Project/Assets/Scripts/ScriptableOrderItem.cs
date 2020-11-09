using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewOrderItem", menuName = "Custom Scriptables/Order Item")]
public class ScriptableOrderItem : ScriptableObject
{
    #region Variables
    /// <summary>
    /// The Sprite Symbol that represent this OrderItem.
    /// </summary>
    public Sprite itemSymbolSprite;
    /// <summary>
    /// The color of the OrderItem symbol.
    /// </summary>
    public Color itemSymbolColor = Color.white;
    /// <summary>
    /// The unique ID of this OrderItem.
    /// </summary>
    public string itemID = Guid.NewGuid().ToString();
    /// <summary>
    /// The Shelf this OrderItem belongs to.
    /// </summary>
    public string parentShelf;
    #endregion
}