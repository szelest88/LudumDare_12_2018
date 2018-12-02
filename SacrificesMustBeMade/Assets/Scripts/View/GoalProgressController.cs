using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalProgressController : MonoBehaviour {

    public SpriteRenderer dagger;
    public SpriteRenderer altar;
    public SpriteRenderer virgin;

    public void onGameTurnStart(bool[] state)
    {
        dagger.color = state[0] ? Color.white : Color.black;
        altar.color = state[1] ? Color.white : Color.black;
        virgin.color = state[2] ? Color.white : Color.black;
    }

    void Start ()
    {
        dagger.color = Color.black;
        altar.color = Color.black;
        virgin.color = Color.black;
    }

    void Reset()
    {
        dagger.color = Color.black;
        altar.color = Color.black;
        virgin.color = Color.black;
    }

}
