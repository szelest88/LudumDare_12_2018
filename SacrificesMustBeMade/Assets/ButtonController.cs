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

        testTMP.text = res;

        barsManager.setSomeTestValues();
        // load a new scene
    }
}
