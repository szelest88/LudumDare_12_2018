using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventRitualTheory
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Ritual theory",

            Predicate = gs => gs.Res.Wealth >= 30 && gs.Res.Zeal <= 100,
            Priority = 5,
            MinTurn = 1,
            Retention = 5,
            Description = "Our followers seem to be strong in faith, but weak in practice. Perhaps, it would be good idea to use some of our resources to perform... test rituals?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "Thanks to our ritual performing practices, the cult seems more devoted.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Zeal += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "I'm sure, we'll find another way to increase our devotion.",
                    Effect = gs => {
                        return gs;
                    }
                }

            }
        };

    }

}

