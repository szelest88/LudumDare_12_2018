using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventCanvasser
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Canvasser",
            Predicate = gs => gs.Res.Notority >= 50,
            Priority = 5,
            MinTurn = 1,
            Retention = 6,
            Description = "A canvasser has knocked on our door. He seems completely oblivious of our activities here. He offers a variety of books for a reasonable price. I checked though them, and there are a few, that could help our cause. Would you like us to buy them?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "The books are now laying safely on our shelves. Their content brings enlightenment to our followers.",
                    Effect = gs => {
                        gs.Res.Wealth -= 20;
                        gs.Res.Zeal += 40;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "I started bargaining with the canvasser. It became apparent, he knows his job well. I quickly bought a few books, before he could raise the price even higher.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Zeal += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We sent the man away.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
