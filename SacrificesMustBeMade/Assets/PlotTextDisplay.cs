using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlotTextDisplay : MonoBehaviour {

    static TextMeshPro plotTMP;
	
    // Use this for initialization
	void Start () {
        plotTMP = GetComponent<TextMeshPro>();	
	}
	
    /// <summary>
    /// sets the text on the game plot display
    /// </summary>
    /// <param name="text"></param>
    public static void setText(string text)
    {
        plotTMP.SetText(text);
    }

}
