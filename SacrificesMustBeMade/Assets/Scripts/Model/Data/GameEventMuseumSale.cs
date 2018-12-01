using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventMuseumSale
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Museum Sale",
            Predicate = gs => gs.Res.Wealth > 100,
            Priority = 8,
            MinTurn = 6,
            Retention = 5,
            Description = "It seems, our cult is doing well, when it comes to wealth. We could use it to build an altar in our base. We could ",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "We warmy welcome our new cult members.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Cultists += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "We offer them a place in our family, but refuse to waste expenses on them, until they prove their worth to you. Half of them agree to our terms.",
                    Effect = gs => {
                        gs.Res.Cultists += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We send them back to wherever they came from.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
