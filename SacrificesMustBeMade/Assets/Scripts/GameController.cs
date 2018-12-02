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
        RestartGame,
    }

    public static GameController Instance = null;

    public GameObject EventReceiver;

    public StateType State = StateType.Intro;

    public bool EventReceived = false;
    public EventType EventObject;
    public GameEventActionType EventParamAction;

    public bool Debug = false;

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
        EventReceived = false;
    }

    void Start()
    {
        StartCoroutine(MainLoop());
    }

    void Update()
    {
        if (Game != null)
        {
            Game.Verbose = Debug;
        }
    }

    IEnumerator MainLoop()
    {
        while (true)
        {
            EventReceiver.BroadcastMessage("OnIntro");

            {
                yield return new WaitUntil(() => EventReceived);
                var eventObject = HandleEvent(e => e == EventType.GameStart || e == EventType.RestartGame);
                if (eventObject == EventType.RestartGame) goto restart;
            }

            Game = new Game();
            Game.Verbose = Debug;
            Game.Validate();

            while (!Game.IsFinished())
            {
                Game.NextEvent();
                EventReceiver.BroadcastMessage("OnGameEvent", Game);

                {
                    yield return new WaitUntil(() => EventReceived);
                    var eventObject = HandleEvent(e => e == EventType.PerformAction || e == EventType.RestartGame);
                    if (eventObject == EventType.RestartGame) goto restart;
                }

                Game.PerformAction(EventParamAction);
                EventReceiver.BroadcastMessage("OnGameEventAction", Game);

                {
                    yield return new WaitUntil(() => EventReceived);
                    var eventObject = HandleEvent(e => e == EventType.FinishAction || e == EventType.RestartGame);
                    if (eventObject == EventType.RestartGame) goto restart;
                }
            }

            EventReceiver.BroadcastMessage("OnGameFinish", Game);
            {
                yield return new WaitUntil(() => EventReceived);
                HandleEvent(e => e == EventType.RestartGame);
            }

        restart:
            Game = null;
        }
    }

    public void GameStart()
    {
        ReceiveEvent(EventType.GameStart);
    }

    public void PerformAction(GameEventActionType action)
    {
        ReceiveEvent(EventType.PerformAction);
        EventParamAction = action;
    }

    public void FinishAction()
    {
        ReceiveEvent(EventType.FinishAction);
    }

    public void RestartGame()
    {
        ReceiveEvent(EventType.RestartGame);
    }

    private void ReceiveEvent(EventType eventObject)
    {
        EventReceived = true;
        EventObject = eventObject;
    }

    private EventType HandleEvent(System.Predicate<EventType> predicate)
    {
        EventReceived = false;
        if (predicate(EventObject) == false)
        {
            throw new System.Exception(
                string.Format("Failed to receive event. state: {0} event: {1}", State, EventObject)
            );
        }
        return EventObject;
    }
}
