using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{

    [System.Serializable]
    public class Game
    {
        public System.Random Random = new System.Random();
        public GameEvent[] GameEvents = GameDataDB.GameEvents;
        public GameState GameState = new GameState();

        public bool Verbose;

        public void NextEvent()
        {
            GameState = GameLogic.NextEvent(GameEvents, GameState, Random, Verbose);
        }

        public void PerformAction(GameEventActionType actionType)
        {
            GameState = GameLogic.PerformAction(GameState, actionType, Verbose);
        }

        public bool IsFinished()
        {
            return GameLogic.IsFinished(GameState);
        }

        public GameResult GetResult()
        {
            return GameLogic.GetResult(GameState);
        }

        public void Validate()
        {
            var verifier = new Verifier();
            verifier.Verify(GameEvents, "Game event from game event db is not valid.");
            
            if (verifier.Errors.Count != 0) {
                Debug.LogErrorFormat(
                    "Game event db validation failed. Errors: \n{0}",
                    string.Join("\n", verifier.Errors.ToArray())
                );
            }
        }

    }

}
