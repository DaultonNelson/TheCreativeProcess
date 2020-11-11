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
    /// <param name="amountOfKeys">
    /// The amount of keys to be displayed.
    /// </param>
    public void DisplaySubshelfKeys(int amountOfKeys)
    {
        HideSubshelfKeys();

        if (amountOfKeys > subshelfKeys.Count || amountOfKeys < 1)
        {
            Debug.LogError("Insufficent amount was given to DisplaySubshelfKeys.", gameObject);
            Debug.Log($"List Count: {subshelfKeys.Count}");
            Debug.Log($"Amount of Keys Given: {amountOfKeys}");
            return;
        }

        for (int i = 0; i < amountOfKeys; i++)
        {
            subshelfKeys[i].SetActive(true);
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