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
        "street lights",
        "spice bottle",
        "watch",
        "empty tin can",
        "sidewalk",
        "toy car",
        "bottle of paint",
        "comb",
        "box of chocolates",
        "toy soldier",
        "video games",
        "egg timer",
        "miniature portrait",
        "pair of scissors",
        "pocketwatch",
        "camera",
        "spool of ribbon",
        "shirt button",
        "bookmark",
        "bow tie",
        "towel",
        "notebook",
        "chair",
        "bottle of pills",
        "mop",
        "spring",
        "clock",
        "cucumber",
        "desk",
        "bottle of glue",
        "lamp shade",
        "light bulb",
        "bag",
        "washcloth",
        "eraser",
        "soccer ball",
        "pants",
        "rock",
        "trash bag",
        "pail",
        "wishbone",
        "tissue box",
        "rat",
        "orange",
        "multitool",
        "hair brush",
        "photo album",
        "vase",
        "postage stamp",
        "grid paper"
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