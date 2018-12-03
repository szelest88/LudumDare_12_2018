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

            Predicate = gs => gs.Res.Virgin == false && gs.Res.Cultists >= 70 && gs.Res.Wealth >= 80 && gs.Res.Zeal >= 70,
            Priority = 8,
            MinTurn = 8,
            Retention = 10,
            Description = "We found out, a wealthy man will be driving through the city, with his family. Including his daughter, who's a virgin. We've learned their place of rest, well guarded manor at the edge of town. It's known that virgins father is willing to arrange marriage with respectable noble to enlarge his fortune. Girl herself is naive and believes in true love at first sight, willing to risk scandal to just be swayed away by lover.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "The fight was long and fierce. The cult suffered severe casualties, but it was worth it: We got the virgin! The cult members rejoice!",
                    Effect = gs => {
                        gs.Res.Cultists -= 60;
                        gs.Res.Wealth -= 40;
                        gs.Res.Zeal += 10;
                        gs.Res.Virgin = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "As you commanded, I ordered the cultists to refrain from action. There will be other occasions. Still, the long wait tires them.",
                    Effect = gs => {
                        gs.Res.Zeal -= 5;
                        return gs;
                    }
                },

                new GameEventAction
                {
                    Type = GameEventActionType.Diplomacy,
                    Description = "We've managed to get one cultist invited to dinner at which our brother convinced wealthy man to promise her hand to him in marriage. Mournful girl taken away from her fathers protection. Glad father speaking words of praise for young gentleman whom bestowed affection on his only child. Both unaware of her place in our greater plan.",
                    Effect = gs => {
                        gs.Res.Wealth -= 70;
                        gs.Res.Notority -= 20;
                        gs.Res.Virgin = true;
                        return gs;
                    }
                },

                new GameEventAction
                {
                    Type = GameEventActionType.Ruse,
                    Description = "Seduced by stranger. His tales of far away lands. His words of otherworldly wisdom. More than enough to sway daughter away from overprotective father. She shall witness firsthand what gifts and forbidden knowledge can compliance to the dark one bring. Enraged parent has put bounty on head of mysterious lover.",
                    Effect = gs => {
                        gs.Res.Zeal += 20;
                        gs.Res.Notority += 70;
                        gs.Res.Virgin = true;
                        return gs;
                    }
                }
            }
        };

    }

}
