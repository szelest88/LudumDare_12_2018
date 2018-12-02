using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventWorkHarder
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Work Harder",
            Predicate = gs => gs.Res.Cultists >= 40,
            Priority = 5,
            MinTurn = 1,
            Retention = 5,
            Description = "I noticed, many of our followers have some free time. A time, they could be spending to increase our wealth. I could... rearrange their schedules. Perhaps even add some overtime?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "More work hours means more money. Good.",
                    Effect = gs => {
                        gs.Res.Wealth += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "A few extra overtime hours won't hurt them... much. Anyway, the extra income is well worth it. Over time, the people start complaining, so I reduce their work hours to a reasonable amount.",
                    Effect = gs => {
                        gs.Res.Wealth += 30;
                        gs.Res.Zeal -= 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "There are only a few ways, cultists can spend free time here. And most of them revolve around worshipping you.",
                    Effect = gs => {
                        gs.Res.Zeal += 20;
                        return gs;
                    }
                }
            }
        };

    }

}
