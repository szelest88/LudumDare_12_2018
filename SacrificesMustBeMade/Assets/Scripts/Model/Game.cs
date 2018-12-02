using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{

    public class Game
    {
        public System.Random Random = new System.Random();
        public GameEvent[] GameEvents = GameDataDB.GameEvents;
        public GameState GameState = new GameState();

        public void Start() {
            GameState.CurrentEvent = GameLogic.NextEvent(GameEvents, GameState, Random, false);
        }

        public void PerformAction(GameEventActionType action) {

        }

        public void NextEvent() {

        }

        public bool IsFinished() {
            return false;
        }

        public void Validate()
        {

        }

    }

}
