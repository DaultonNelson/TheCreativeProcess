using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OrderItem : IComparable<OrderItem>
{
    #region Variables
    /// <summary>
    /// The name of this Order Item.
    /// </summary>
    public string ItemName;
    /// <summary>
    /// The Sprite Symbol that represent this Order Item.
    /// </summary>
    public Sprite ItemSymbolSprite { get; set; }
    /// <summary>
    /// The color of the Order Item symbol.
    /// </summary>
    public Color ItemSymbolColor { get; set; } = Color.white;
    /// <summary>
    /// The ID of the Shelf this Order Item belongs to.
    /// </summary>
    public string ParentShelfID;
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
        ItemName = _name;
        ParentShelfID = _parent;
    }

    // > 0 - Current instance is greater than object being compared with.
    // < 0 - Current instance is less than object being compared with.
    // == 0 - Current instance is equal to object being compared with.
    public int CompareTo(OrderItem otherItem)
    {
        int output = 0;

        output = ParentShelfID.CompareTo(otherItem.ParentShelfID);

        return output;
    }
}