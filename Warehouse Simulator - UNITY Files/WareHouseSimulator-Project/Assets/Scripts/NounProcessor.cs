using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class NounProcessor
{
    #region Variables
    public static List<string> NounNames = new List<string>()
    {
        "Street Light",
        "Spice bottle",
        "Watch",
        "Empty Tin Can",
        "Sidewalk",
        "Toy car",
        "Bottle of paint",
        "Comb",
        "Box of chocolates",
        "Toy Soldier",
        "Video Game",
        "Egg Timer",
        "Miniature Portrait",
        "Pair of Scissors",
        "Pocketwatch",
        "Camera",
        "Spool of Ribbon",
        "Shirt Button",
        "Bookmark",
        "Bow Tie",
        "Towel",
        "Notebook",
        "Chair",
        "Bottle of Pills",
        "Mop",
        "Spring",
        "Clock",
        "Cucumber",
        "Desk",
        "Bottle of Glue",
        "Lamp Shade",
        "Light Bulb",
        "Bag",
        "Washcloth",
        "Eraser",
        "Soccer Ball",
        "Pants",
        "Rock",
        "Trash Bag",
        "Pail",
        "Wishbone",
        "Tissue Box",
        "Rat",
        "Orange",
        "Multitool",
        "Hair Brush",
        "Photo Album",
        "Vase",
        "Postage Stamp",
        "Grid Paper"
    };
    #endregion

    /// <summary>
    /// Gets a random Noun.
    /// </summary>
    /// <returns>
    /// A random Noun.
    /// </returns>
    public static string GetRandomNoun()
    {
        string output = string.Empty;

        output = NounNames[(int)Random.Range(0, NounNames.Count)];

        return output;
    }
}