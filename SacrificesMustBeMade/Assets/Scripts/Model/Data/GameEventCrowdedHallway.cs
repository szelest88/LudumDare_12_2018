using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventCrowdedHallway
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Crowded Hallway",
            Predicate = gs => gs.Res.Cultists > 60,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "New worshipers are constantly swarming our domain. It seems we can't contain them all. Should we execute the weakest so only the strongest are left?" +
            "We could move some of the servants to some other temporary location while we enlarge our domain. Or do nothing, they should be grateful for what we offer them.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "The weakest were slain, our following shrinked, but the will of the strongest seems to be stronger than ever.",
                    Effect = gs => {
                        gs.Res.Cultists -= 30;
                        gs.Res.Zeal += 40;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "It was more costly, than we originally expected. Also, wandering groups of people grow suspicion in the hearts of citizens. But now we have more worshipers than we could ever imagine.",
                    Effect = gs => {
                        gs.Res.Cultists += 30;
                        gs.Res.Wealth -= 30;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We underestimated the problem. Some cultists fled with goods as they could no longer bear the conditions. That influenced worshipers' morale adversely.",
                    Effect = gs => {
                        gs.Res.Cultists -= 20;
                        gs.Res.Wealth -= 20;
                        gs.Res.Zeal -= 20;
                        return gs;
                    }
                }
            }
        };

    }

}
