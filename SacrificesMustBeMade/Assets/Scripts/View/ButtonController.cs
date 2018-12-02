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
    public bool isReset;
    public TextMeshPro testTMP;

    bool TESTMODE = true;

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    void DoResetAction()
    {
        Debug.LogError("Reset action to be implemented");
    }

    void DoGameAction(GameEventActionType gameEventActionType)
    {
        switch (gameEventActionType)
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
    }

    void ButtonAction()
    {
        if (isReset)
        {
            DoResetAction();
        }
        else
        {
            DoGameAction(gameEventActionType);

            if (TESTMODE)
            {
                Debug.LogError("TESTMODE -> TEST ACTION FIRING FROM THE BUTTON CONTROLLER!");
                string res = "" + gameEventActionType + " has been induced";

                PlotTextDisplay.setText(res);
                testTMP.text = res;

                BarsManager.UpdateDisplayedValueStatic(BarsManager.ResourceType.CULTIST, Random.Range(0, 11)); //0..10
                BarsManager.UpdateDisplayedValueStatic(BarsManager.ResourceType.WEALTH, Random.Range(0, 11)); // 0..10
                BarsManager.UpdateDisplayedValueStatic(BarsManager.ResourceType.ZEAL, Random.Range(0, 11));
                BarsManager.UpdateDisplayedValueStatic(BarsManager.ResourceType.NOTORITY, Random.Range(0, 11));

            }
        }


    }
    private void OnMouseUp()
    {

            StartCoroutine(DelayedActions());
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator DelayedActions()
    {
        yield return new WaitForSeconds(0.2f);

        if (!isReset)
        {
            PentagramPresentionController.doRotate();
        }
        ButtonAction();
    }
}
