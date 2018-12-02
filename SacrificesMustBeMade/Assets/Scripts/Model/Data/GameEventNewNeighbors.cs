using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventNewNeighbors
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "New Neighbors",
            Predicate = gs => gs.Res.Wealth <= 60,
            Priority = 5,
            MinTurn = 1,
            Retention = 8,
            Description = "The increasing number of homeless people, who walk around and sleep nearby our base, makes it hard to ignore them any longer. Eventually, they might figure out the nature of our activities here. I'd really like to scare them off. But, if you deem them worthy, we could invite them inside as new cult members. But, their health state would force us to invest some money into them.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "I ordered our cultists to scare them off. The homeless did not want to leave so easily, so we had to kill a few. This increased suspicions around us, but the problem has been solved.",
                    Effect = gs => {
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "We gave the homeless a place, they can call home. The stench from them was hard to stand, but after taking a shower and getting a set of new clothes, they became proper, faithful followers.",
                    Effect = gs => {
                        gs.Res.Cultists += 20;
                        gs.Res.Wealth -= 20;
                        gs.Res.Zeal += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We ignored the issue. Over the next days, it was hard for us to attend our tasks, when our every move was closely observed by countless eyes. Luckily, weeks later, the homeless were so numerous, the police have chased them away. This has increased the city's attention on our base even more.",
                    Effect = gs => {
                        gs.Res.Notority += 30;
                        return gs;
                    }
                }
            }
        };

    }

}
