using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventAction
    {

        public GameEventActionType Type;

        public string Description;

        public System.Func<GameState, GameState> Effect = gs => gs;

        public void Verify(Verification verification)
        {
            verification.Verify(Description, d => d != null, "Description == null");
            verification.Verify(Description, d => d.Length == 0, "Description is empty");
            verification.Verify(Effect, e => e != null, "Effect == null");
        }

    }

}