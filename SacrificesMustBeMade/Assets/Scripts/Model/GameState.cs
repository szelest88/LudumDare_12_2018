using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class GameState
    {
        // Turn number
        // Turn counting starts from 1.
        public uint Turn = 1;
        public GameResources Res = new GameResources();
        public GameEvent CurrentEvent;
        public GameEventAction CurrentEventAction;

        public Dictionary<GameEvent, uint> GameEventLastTurn = new Dictionary<GameEvent, uint>();

        public void Validate() {
            Res.Validate();
        }
    }
}
