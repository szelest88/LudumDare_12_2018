using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventCultistsInterrogated
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Cultists Interrogated",
            Predicate = gs => gs.Res.Notority >= 100,
            Priority = 5,
            Retention = 10,
            Description = "A few of our cultists, when performing their duties outside, got captured by Inquisitors. I fear, their will won't hold against the tortures, and they will spill our secrets. They are held in a moderately protected building, three streets from our base. We must attack and free them! Um, I mean, only if you support this idea. If you don't, then we can bribe the guards, sneak there and free them in a less violent way.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Yes! A frontal assault! Many inquisitors were taken by suprise. Many fought back. Many of our followers fell that day in your name. And we revealed our presence. But we got our captured brothers back. But, if we did nothing, they would learn even more about our cult.",
                    Effect = gs => {
                        gs.Res.Cultists -= 30;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "Even among inquisitors, many are willing to cooperate when introduced to money. Still, we had to assasinate those less potent to bribery. But, we have our kidnapped cultists back.",
                    Effect = gs => {
                        gs.Res.Wealth -= 30;
                        gs.Res.Notority += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "As you command, we don't waste our resources on few followers, who have trouble watching their own back. Still, even, if they did not know all our secrets, the Inquisition will surely learn a lot about us.",
                    Effect = gs => {
                        gs.Res.Notority += 40;
                        return gs;
                    }
                }
            }
        };

    }

}
