using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventSlackingFollowers
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Slacking followers",
            Predicate = gs => gs.Res.Cultists >= 70 && gs.Res.Zeal <= 50,
            Priority = 5,
            MinTurn = 1,
            Retention = 5,
            Description = "There so many of us, that some of our worshipers aren't eager to work. They just do it partly, execute task incompletely or claim that" +
            "they have lost the passion. What should we do about them?",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "I didn't know that the most lazy ones are most sutiable for offerings.",
                    Effect = gs => {
                        gs.Res.Cultists -= 30;
                        gs.Res.Wealth += 10;
                        gs.Res.Zeal += 40;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "The book about leadership and motivation that we've ordered from some coaching site, doesn't seem to be of big use. That's just money" +
                    "that went down the drain.",
                    Effect = gs => {
                        gs.Res.Cultists -= 10;
                        gs.Res.Wealth -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Ignoring this matter went better than expected. Some of them that couldn't sleep at night felt guilty, and took extra hours" +
                    " to help the cult.",
                    Effect = gs => {
                        gs.Res.Zeal += 10;
                        gs.Res.Wealth += 20;
                        return gs;
                    }
                }
            }
        };

    }

}
