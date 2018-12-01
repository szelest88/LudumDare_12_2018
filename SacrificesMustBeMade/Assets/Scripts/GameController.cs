using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class GameController : MonoBehaviour
{
    public enum EventType
    {
        GAME_START_REQUEST,
        GAME_ACTION_REQUEST,
        GAME_ACTION_FINISHED,
    }

    public static GameController instance = null;

    public bool eventReceived;
    public EventType eventObject;
    public GameEventAction action;

    public Game game;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
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
        BroadcastMessage("OnIntro");

        yield return new WaitUntil(() => eventReceived);
        if (eventObject != EventType.GAME_START_REQUEST)
        {
            throw new System.Exception("Invalid event: " + eventObject);
        }

        game = new Game();

        while (!game.IsFinished())
        {
            game.NextEvent();

            BroadcastMessage("OnGameEvent", game);

            yield return new WaitUntil(() => eventReceived);
            if (eventObject != EventType.GAME_ACTION_REQUEST)
            {
                throw new System.Exception("Invalid event: " + eventObject);
            }

            game.PerformAction(action);

            yield return new WaitUntil(() => eventReceived);
            if (eventObject != EventType.GAME_ACTION_FINISHED)
            {
                throw new System.Exception("Invalid event: " + eventObject);
            }
        }

        BroadcastMessage("OnGameFinish", game);
    }
}
