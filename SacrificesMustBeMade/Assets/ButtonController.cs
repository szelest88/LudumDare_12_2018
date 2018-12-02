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

    bool TESTMODE = true;
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnMouseUp()
    {
        switch(gameEventActionType)
        {
            case GameEventActionType.Apathy:
                Debug.LogError("Apathy action to be implemented");
                break;
            case GameEventActionType.Conflict:
                Debug.LogError("Conflict action to be implemented");
                break;
            case GameEventActionType.Diplomacy:
                Debug.LogError("Diplomacy action to be implemented");
                break;
            case GameEventActionType.Enthusiasm:
                Debug.LogError("Enthusiasm action to be implemented");
                break;
            case GameEventActionType.Ruse:
                Debug.LogError("Ruse action to be implemented");
                break;


        }


        GetComponent<SpriteRenderer>().color = Color.white;

        if (TESTMODE)
        {
            Debug.LogError("TESTMODE -> TEST ACTION FIRING FROM THE BUTTON CONTROLLER!");
            string res = "" + gameEventActionType + " has been induced";

            barsManager.setSomeTestValues();

            testTMP.text = res;
        }


        PentagramPresentionController.doRotate();

    }
}
