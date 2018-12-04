using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventSellOurStuff
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Sell Our Stuff",
            Predicate = gs => gs.Res.Wealth <= 50 && gs.Res.Zeal >= 50,
            Priority = 5,
            MinTurn = 1,
            Retention = 5,
            Description = "Our cult could use more money. I could call some of my contacts to sell some decorations in our base. There's not much practical use out of them anyway. They just look nice. Well, I guess, without them, the cult's prestige could suffer, but I expect to get a good deal for esoteric ornaments.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "My associate turned the decorations into money for us. Unfortunately, those with lesser will find it harder to respect you now.",
                    Effect = gs => {
                        gs.Res.Wealth += 40;
                        gs.Res.Zeal -= 30;
                        gs.Res.Notority -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Of course. I'll remember, faith of our followers is of utmost importance.",
                    Effect = gs => {
                        gs.Res.Zeal += 5;
                        return gs;
                    }
                }
            }
        };

    }

}
