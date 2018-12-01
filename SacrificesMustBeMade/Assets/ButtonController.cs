using Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public BarsManager barsManager;
    public bool isActive;

    public GameEventActionType gameEventActionType;
    public TextMeshPro testTMP;

    void OnMouseDown()
    {
        string res = "" + gameEventActionType + " has been induced";

        Debug.LogError("REMOVE THIS MOTHERFUCKER!");
        testTMP.text = res;

        barsManager.setSomeTestValues();
    }
}
