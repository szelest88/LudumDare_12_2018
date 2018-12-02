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
    public bool isGoOn;
    public TextMeshPro testTMP;

    bool TESTMODE = false;

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
        GameController.Instance.PerformAction(gameEventActionType);
    }

    public void OnGameEventAction(Model.Game game) // disactivating/activating
    {
        // deaktywować guzik
        GetComponent<SpriteRenderer>().color = Color.grey;
        foreach(GameEventAction ac in game.GameState.CurrentEvent.Actions)
            if (ac.Type == gameEventActionType)
            {
                // guzik aktywny
                GetComponent<SpriteRenderer>().color = Color.white;
                GameController.Instance.FinishAction();
            }

    }

    void GoOn()
    {
        GameController.Instance.FinishAction();
    }

    void ButtonAction()
    {
        if (isReset)
        {
            DoResetAction();
        }
        else if (isGoOn)
        {
            GoOn();
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
