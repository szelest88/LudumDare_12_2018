using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventTemplate
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "<<This is a place for your event name>>",
            Predicate = gs => gs.Res.Altair == true,
            Priority = 8,
            MinTurn = 1,
            Retention = 10,
            Description = "<<This is a place for your event description>>",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "<<This is a place for your event action>>",
                    Effect = gs => {
                        gs.Res.Altair = false;
                        return gs;
                    }
                }
            }
        };

    }

}
