using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventHornOfPlenty
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "The Horn of Plenty",
            Predicate = gs => gs.Res.Wealth > 50,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "We managed to gather a considerable amount of goods. How shall we spend our new income? Should we distribute it evenly between our needs? We could invest the goods we gained to plot" +
            "some evil intrigue on the city's authorities. We could also wait it out, and save for tougher times.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Resonable managment of wealth is essential.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Notority -= 10;
                        gs.Res.Zeal += 10;
                        gs.Res.Cultists += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "As expected, our plot succeeded. Local authorities feel so threatened that they pay us bribes to keep their life safe.",
                    Effect = gs => {
                        gs.Res.Wealth += 60;
                        gs.Res.Notority += 40;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Sometimes, lack of action is the best thing.",
                    Effect = gs => {
                        gs.Res.Notority -= 10;
                        return gs;
                    }
                }
            }
        };

    }

}
