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
    /// A list of the subshelf key graphics in the Interface.
    /// </summary>
    public List<GameObject> subshelfKeys = new List<GameObject>();
    /// <summary>
    /// A list of the Texts next to the Subshelf Keys.
    /// </summary>
    public List<Text> subshelfKeyTexts = new List<Text>();
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
    /// Hides the subshelf keys.
    /// </summary>
    public void HideSubshelfKeys()
    {
        foreach (GameObject key in subshelfKeys)
        {
            key.SetActive(false);
        }
    }
}