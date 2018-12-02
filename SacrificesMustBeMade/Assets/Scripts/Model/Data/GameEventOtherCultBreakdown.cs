using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventOtherCultBreakdown
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Other Cult Breakdown",

            Predicate = gs => gs.Res.Notority >= 60,
            Priority = 5,
            MinTurn = 5,
            Retention = 10,
            Description = "A messenger from a different cult has arrived, informing us, their cult is breaking down. The Inquisition is on their tails, and it is only a matter of time, before their base gets burnt to the ground. He asks, if some of them could join us. I worry, that they would bring some inquisitors with them. Metaphorically.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "Large number of new cultists joined our ranks. And there are no inquisitors in sight. Yet.",
                    Effect = gs => {
                        gs.Res.Cultists += 40;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "We order them not to draw any attention. Later, a small number of cultists join our cause. They promise, they have not been followed.",
                    Effect = gs => {
                        gs.Res.Cultists += 20;
                        return gs;
                    }
                },

                new GameEventAction
                {
                    Type = GameEventActionType.Apathy,
                    Description = "We agree to accept this one man. The rest has to worry for themselves",
                    Effect = gs => {
                        gs.Res.Cultists += 1;
                        return gs;
                    }
                }
            }
        };

    }

}
