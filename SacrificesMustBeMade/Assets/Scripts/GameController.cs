using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class GameController : MonoBehaviour
{
    public enum StateType
    {
        Intro,
        GameEvent,
        GameAction,
        Finish,

    }

    public enum EventType
    {
        GameStart,
        PerformAction,
        FinishAction,
    }

    public static GameController Instance = null;

    public GameObject EventReceiver;

    public StateType State = StateType.Intro;

    public bool EventReceived;
    public EventType EventObject;
    public GameEventActionType EventParamAction;

    public Game Game;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(MainLoop());
    }

    IEnumerator MainLoop()
    {
        EventReceiver.BroadcastMessage("OnIntro");

        yield return new WaitUntil(() => EventReceived);
        HandleEvent(e => e == EventType.GameStart);

        Game = new Game();

        while (!Game.IsFinished())
        {
            Game.NextEvent();

            EventReceiver.BroadcastMessage("OnGameEvent", Game);

            yield return new WaitUntil(() => EventReceived);
            HandleEvent(e => e == EventType.PerformAction);

            Game.PerformAction(EventParamAction);

            yield return new WaitUntil(() => EventReceived);
            HandleEvent(e => e == EventType.FinishAction);
        }

        EventReceiver.BroadcastMessage("OnGameFinish", Game);
    }

    public void GameStart() {
        ReceiveEvent(EventType.GameStart);
    }

    public void PerformAction(GameEventActionType action) {
        ReceiveEvent(EventType.PerformAction);
        EventParamAction = action;
    }

    public void FinishAction() {
        ReceiveEvent(EventType.FinishAction);
    }

    private void ReceiveEvent(EventType eventObject) {
        EventReceived = true;
        EventObject = eventObject;
    }

    private EventType HandleEvent(System.Predicate<EventType> predicate)
    {
        EventReceived = false;
        if (predicate(EventObject) == false)
        {
            throw new System.Exception(
                string.Format("Failed to receive event. state: {0} event: {1}", State, EventObject);
            );
        }
        return EventObject;
    }
}
