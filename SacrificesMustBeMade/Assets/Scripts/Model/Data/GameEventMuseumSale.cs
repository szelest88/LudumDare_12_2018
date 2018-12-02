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
            Predicate = gs => gs.Res.Wealth >= 120 && gs.Res.Cultists >= 40 && gs.Res.Relic == false,
            Priority = 8,
            MinTurn = 6,
            Retention = 5,
            Description = "A museum nearby has recently received new exhibits. I went there personally, and saw, one of them is an ancient sacrifical dagger. Also, it comes out, the museum has financial troubles, and will be organising a sale. Many items, including the dagger, will be there. I think, sending some men to steal it at night would be a good idea. Or, we can just wait and send someone to buy the artifact, but the price will not be low.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "We equipped and sent most suitable people to break into museum. They managed to grab the dagger, but when leaving, they set off an alarm. Guards and police were not happy about this. Many were slain, but few have returned with the relic.",
                    Effect = gs => {
                        gs.Res.Cultists -= 20;
                        gs.Res.Wealth -= 40;
                        gs.Res.Notority += 50;
                        gs.Res.Relic = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Sometimes even a cult does things by the book. We bought the relic on the auction. Many people also wanted the dagger, and our actions did not go unnoticed.",
                    Effect = gs => {
                        gs.Res.Wealth -= 100;
                        gs.Res.Notority += 20;
                        gs.Res.Relic = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Later, we heard, some rich snob has bought the dagger, and hung it over his chimney. Such a waste.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
