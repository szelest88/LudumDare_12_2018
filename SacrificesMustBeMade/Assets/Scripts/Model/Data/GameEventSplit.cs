using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventSplit
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Split",

            Predicate = gs => gs.Res.Cultists >= 180,
            Priority = 10,
            MinTurn = 1,
            Retention = 2,
            Description = "Ranks of our cult have grown so much, some have started worshipping other gods. Attempts to persuade them otherwise have proven inefficient. I'm considering kicking the heretics out of our cult. Or, we could go more extreme and kill them.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Some cultists, faced with choice, have left. But the bigger part is still with us.",
                    Effect = gs => {
                        gs.Res.Cultists -= 80;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "It never ceases to suprise me, how efficient mass murder is at solving various problems. Too bad, the heretics started retaliating, and we had a small internal war. The upside is, the ones, who survived, are very faithful to our cause.",
                    Effect = gs => {
                        gs.Res.Cultists -= 100;
                        gs.Res.Zeal += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We allowed the matter to solve itself over time. Eventually, many cultists left on their own to form a new cult. They took some of our resources with them.",
                    Effect = gs => {
                        gs.Res.Cultists -= 60;
                        gs.Res.Wealth -= 40;
                        return gs;
                    }
                }

            }
        };

    }

}
