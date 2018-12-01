using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventGetVirgin
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Get Virgin",

            Predicate = gs => gs.Res.Virgin == false && gs.Res.Cultists >= 50 && gs.Res.Wealth >= 30 && gs.Res.Zeal >= 20,
            Priority = 8,
            MinTurn = 8,
            Retention = 10,
            Description = "We found out, a wealthy man will be driving through the city, with his family. Including his daughter, who's a virgin. And also surrounded by his guards. Still, maybe it would be beneficial to attack their convoy to get the virgin? We expect to lose resources and many men during the fight.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "The fight was long and fierce. The cult suffered severe casualties, but it was worth it: We got the virgin! The cult members rejoice!",
                    Effect = gs => {
                        gs.Res.Cultists -= 40;
                        gs.Res.Wealth -= 20;
                        gs.Res.Zeal += 10;
                        gs.Res.Virgin = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "As you commanded, I ordered the cultists to refrain from action. There will be other occations. Still, the long wait tires them.",
                    Effect = gs => {
                        gs.Res.Zeal -= 5;
                        return gs;
                    }
                }

            }
        };

    }

}
