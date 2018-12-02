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

    public enum ButtonType { ACTION, RESET, GO_ON};
    public ButtonType buttonType;

    void DoResetAction()
    {
        Debug.LogError("Reset action to be implemented");
    }

    void DoGameAction(GameEventActionType gameEventActionType)
    {
        if(isActive)
        GameController.Instance.PerformAction(gameEventActionType);
    }

    public void OnGameEventAction(Model.Game game)
    {
        switch (buttonType)
        {
            case ButtonType.GO_ON:

                isActive = true;
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case ButtonType.ACTION:

                isActive = false;
                GetComponent<SpriteRenderer>().color = Color.grey;
                break;
        } 
    }
    public void OnGameEvent(Model.Game game) 
    {
        if(isGoOn)
        {

            isActive = false;
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if(!isGoOn)
        {
            isActive = false;
            GetComponent<SpriteRenderer>().color = Color.grey;
            foreach (GameEventAction ac in game.GameState.CurrentEvent.Actions)
            {

                if (ac.Type == gameEventActionType)
                {
                    isActive = true;
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
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
        if (isActive)
        {
            StartCoroutine(DelayedActions());
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnMouseDown()
    {
        if (isActive)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            GameObject.Find("Audio").GetComponent<MusicController>().ButtonClick();
        }
            
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
