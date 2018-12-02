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
            MinTurn = 1,
            Retention = 10,
            Description = "My Lord, worshipers seem not to care about the cult as they used to. Shall we unleash your anger upon them, so they know once and for all whom they serve?" +
            "Or maybe they just lack pleasures of the mind and the body. We could always blackmail them, we are going to report them to the police or harm their families.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Disciplinary ritual sacrifices of some people renewed their faith.",
                    Effect = gs => {
                        gs.Res.Zeal += 40;
                        gs.Res.Cultists -= 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "We used some money to provide the followers with better goods. Turns out, distracting them even more didn't help with their faith. Quite the opposite: they started spreading the news, how 'cool' our cult is. At least, this has led some new worshipers to our doors.",
                    Effect = gs => {
                        gs.Res.Zeal -= 10;
                        gs.Res.Cultists += 10;
                        gs.Res.Wealth -= 20;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "We had to report some of cultists to police. With others, a simple blackmail was enough. Still, their faith is now stronger.",
                    Effect = gs => {
                        gs.Res.Zeal += 20;
                        gs.Res.Cultists -= 5;
                        gs.Res.Notority += 10;
                        return gs;
                    }
                }
            }
        };

    }

}
