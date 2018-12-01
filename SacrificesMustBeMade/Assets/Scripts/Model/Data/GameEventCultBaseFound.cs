using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventCultBaseFound
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Cult base found",

            Predicate = gs => gs.Res.Cultists >= 50 && gs.Res.Wealth >= 50 && gs.Res.Notority >= 150,
            Priority = 5,
            MinTurn = 1,
            Retention = 5,
            Description = "Your presence is ever more prominent in this world. Our ranks are constantly increasing. Unfortunately, the Inquisition has also heard of your cult. We suspect, they are doing their best to find our base. Should we move to a different location? Or maybe we should send some of our followers to set up a fake base?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "We sent some cultists with part of our items, so they could get set up in a cellar far away from our location. After that, we never heard from them again. We assume, they did their job, because the pressure of the Inquisitors has vanished.",
                    Effect = gs => {
                        gs.Res.Cultists -= 30;
                        gs.Res.Wealth -= 20;
                        gs.Res.Notority -= 50;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "We found a different place suitable for our new base. It's not as spacious as the previous one, but it will do. Sadly, we lost part of our wealth during the move.",
                    Effect = gs => {
                        gs.Res.Wealth -= 20;
                        gs.Res.Zeal -= 5;
                        gs.Res.Notority -= 30;
                        gs.Res.Altair = false;
                        return gs;
                    }
                }

            }
        };

    }

}
