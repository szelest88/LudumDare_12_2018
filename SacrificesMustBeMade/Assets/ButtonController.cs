using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public bool isActive;

    public GameEventActionType gameEventActionType;

    void OnMouseDown()
    {
        Debug.LogError("" + gameEventActionType);
        // load a new scene
    }
}
