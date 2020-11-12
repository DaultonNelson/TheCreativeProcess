using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Can't have an individual instance of a parent shelf reference for scriptable objects because that would change the base file.
[Serializable]
public class OrderItem
{
    #region Variables
    /// <summary>
    /// The name of this Order Item.
    /// </summary>
    public string itemName;
    /// <summary>
    /// The Sprite Symbol that represent this Order Item.
    /// </summary>
    public Sprite itemSymbolSprite { get; set; }
    /// <summary>
    /// The color of the Order Item symbol.
    /// </summary>
    public Color itemSymbolColor { get; set; } = Color.white;
    /// <summary>
    /// The ID of the Shelf this Order Item belongs to.
    /// </summary>
    public string parentShelfID { get; set; }
    #endregion

    /// <summary>
    /// Creates a new instance of Order Item.
    /// </summary>
    /// <param name="_name">
    /// The name of the Order Item.
    /// </param>
    /// <param name="_parent">
    /// The parent ID of this Order Item.
    /// </param>
    public OrderItem(string _name, string _parent)
    {
        itemName = _name;
        parentShelfID = _parent;
    }
}