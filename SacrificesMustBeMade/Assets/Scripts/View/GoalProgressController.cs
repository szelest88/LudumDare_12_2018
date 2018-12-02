using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalProgressController : MonoBehaviour {

    public SpriteRenderer dagger;
    public SpriteRenderer altar;
    public SpriteRenderer virgin;

    public void OnGameEventAction(Model.Game game)
    {
        dagger.color = game.GameState.Res.Relic ? Color.white : Color.black;
        altar.color = game.GameState.Res.Altair ? Color.white : Color.black;
        virgin.color = game.GameState.Res.Virgin ? Color.white : Color.black;
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
