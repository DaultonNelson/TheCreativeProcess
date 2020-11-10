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
    #endregion

    private void Start()
    {
        shelfIDText.text = string.Empty;
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
}