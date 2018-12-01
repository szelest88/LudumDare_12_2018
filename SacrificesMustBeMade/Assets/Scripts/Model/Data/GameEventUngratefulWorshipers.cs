using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventUngratefulWorshipers
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Ungrateful Worshipers",
            Predicate = gs => gs.Res.Zeal <= 30,
            Priority = 8,
            Retention = 10,
            Description = "My Lord, worshipers seem not to care about the cult as they used to. Shall we unleash your anger upon them, so they know once and for all whom they serve?" +
            "Or maybe they just lack pleasures of the mind and the body. We could always blackmail them, we are going to report them to the police or harm their families.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "I'm the anger. I'm the vengance. Everyone will obey me, or they die!",
                    Effect = gs => {
                        gs.Res.Zeal += 30;
                        gs.Cultists -= 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthiusiasm,
                    Description = "Distracting them even more won't help. More fresh worshipers are willing to join my following, but what's the use of them anyway?",
                    Effect = gs => {
                        gs.Res.Zeal -= 10;
                        gs.Cultists += 10;
                        gs.Wealth -= 30;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "Suddenly, those weak mortal souls are more willing to cooperate, when they know what is the jeopardy of ingoring me.",
                    Effect = gs => {
                        gs.Res.Zeal += 20;
                        gs.Cultists -= 20;
                        gs.Res.Wealth += 10;
                        return gs;
                    }
                }
            }
        };

    }

}
