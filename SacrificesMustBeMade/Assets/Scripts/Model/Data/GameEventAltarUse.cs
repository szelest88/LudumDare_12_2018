using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventAltarUse
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Altar Use",
            Predicate = gs => gs.Res.Altair == true,
            Priority = 5,
            Retention = 6,
            Description = "A rare setup of stars is going to happen soon. We could use our altar to perform a ritual for you. According to the sacred texts, it will bring us deeper understanding of the Dark Arts. All I need, is a word of your acceptance. Oh, and there is a more extreme version of this ritual, that could bestow us with mystic powers. But that requires some human sacrifices and costly ingredients.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "The ritual lasted an entire night. Many of us experienced various visions. Some could view events, that are going to happen in the future. Some even peeked into Your domain. And some could not comprehend this, and died, or have gone insane.",
                    Effect = gs => {
                        gs.Res.Zeal += 40;
                        gs.Res.Cultists -= 5;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "The preparations lasted a few days, but eventually, it was worth it. During the ritual, many cultists have gained ability to cause miracles. Others have grown tentacles.",
                    Effect = gs => {
                        gs.Res.Wealth -= 30;
                        gs.Res.Cultists -= 20;
                        gs.Res.Zeal += 80;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Even without the ritual, some cultists experienced strange visions during that special night.",
                    Effect = gs => {
                        gs.Res.Zeal += 10;
                        return gs;
                    }
                }
            }
        };

    }

}
