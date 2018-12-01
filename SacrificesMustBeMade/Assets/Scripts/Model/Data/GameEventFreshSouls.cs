using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventFreshSouls
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Fresh Souls",
            Predicate = gs => gs.Res.Cultists <= 30,
            Priority = 5,
            Retention = 3,
            Description = "We desperately need more recruits. Should we trick somebody to join us using persuasion, kidnap and force them to work, or should we wait for some better moment to start recruitment?" +
            "Awaiting orders.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "After we gained their trust, they are more willing to cooperate. Even if the work is something different what they expected.",
                    Effect = gs => {
                        gs.Res.Cultists += 20;
                        gs.Res.Wealth -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Kidnapped people aren't willing to serve. They managed to escaped and also fred some less zealous followers. The police was informed about the kidnaps.",
                    Effect = gs => {
                        gs.Res.Cultists -= 10;
                        gs.Res.Zeal += 10;
                        gs.Res.Notority += 40;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Mortals are very anxious these days. They seek enlightenment on their own, I'm not required to take any actions to increase my following",
                    Effect = gs => {
                        gs.Res.Cultists += 10;
                        return gs;
                    }
                }
            }
        };

    }

}
